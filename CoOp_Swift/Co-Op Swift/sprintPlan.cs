using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Co_Op_Swift.Resources;

namespace Co_Op_Swift
{
  public partial class SprintPlan : Form
  {
    public SprintPlan(string username, string projectName)
    {
      InitializeComponent();

      projectNameToolStripMenuItem.Text = projectName;
      memberNameToolStripMenuItem.Text = username;
      sprintPlanToolStripMenuItem.Font = new Font(sprintPlanToolStripMenuItem.Font, FontStyle.Bold);

      var projIds = Sql.GetUserProjectIDs(Sql.GetOwnerUserId(memberNameToolStripMenuItem.Text));

      foreach (DataRow row in projIds.Rows)
      {
        var projName = Sql.GetProjectName(int.Parse(row["Proj_ID"].ToString()));
        selectProjectToolStripMenuItem.DropDownItems.Add(projName);
      }
    }

    private void DashboardToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new Dashboard(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
      Close();
    }

    private void IdeaBoxToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new IdeaBox(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
      Close();
    }

    private void TaskTreeToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new TaskTree(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
      Close();
    }

    private void ReleasePlanToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new ReleasePlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
      Close();
    }

    private void LogoutToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form2 = new Login();
      form2.Show();
      Close();
    }

    private void TeamToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new AddMembers(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
    }

    public int GetPid()
    {
      var getPid = string.Format(SqlStrings.GetPid, projectNameToolStripMenuItem.Text);
      return Sql.GetSingleInt(getPid);
    }

    private void SprintPlanLoad(object sender, EventArgs e)
    {
      var sql = string.Format(SqlStrings.GetSprintPlans, GetPid());
      var ds = Sql.GetDataSet(sql);
      ds.Tables[0].TableName = "Sprints";

      foreach (DataRow row in ds.Tables["Sprints"].Rows)
      {
        var start = DateTime.Parse(Convert.ToString(row["StartDate"]));
        var end = DateTime.Parse(Convert.ToString(row["EndDate"]));
        var startDate = start.ToShortDateString();
        var endDate = end.ToShortDateString();
        var msg = Convert.ToString(row["SprintID"] + ": " + startDate + " - " + endDate);
        sprintBox.Items.Add(msg);
      }
    }

    private void RefreshTaskBox(int sid)
    {
      taskBox.Items.Clear();
      var sql = string.Format(SqlStrings.GetTasks, sid);
      var ds = Sql.GetDataSet(sql);
      ds.Tables[0].TableName = "TaskTable";

      foreach (DataRow row in ds.Tables["TaskTable"].Rows)
      {
        var isFound = false;
        foreach (string s in taskBox.Items)
          if (s.Equals(row["TaskName"].ToString()))
          {
            isFound = true;
            break;
          }

        if (!isFound)
          taskBox.Items.Add(row["TaskName"]);
      }
    }

    private void CreateTaskClick(object sender, EventArgs e)
    {
      var taskName = taskNameBox.Text;
      var description = descriptionBox.Text;
      var sprint = Convert.ToString(sprintBox.SelectedItem);
      var stop = sprint.IndexOf(':');
      var sid = Convert.ToInt32(sprint.Substring(0, stop));

      var insertTaskTable = string.Format(SqlStrings.InsertTaskTable, taskName, description, 1,
        Sql.GetOwnerUserId(memberNameToolStripMenuItem.Text));
      Sql.ExecuteActionQuery(insertTaskTable);

      var getTaskId = string.Format(SqlStrings.GetTaskId, taskName, description);

      var cmd = new SqlCommand
      {
        Connection = Sql.Db,
        CommandText = getTaskId
      };
      var tid = (int) cmd.ExecuteScalar();

      var addToLinkingTable = string.Format(SqlStrings.AddToLinkingTable, sid, tid);
      Sql.ExecuteActionQuery(addToLinkingTable);
      RefreshTaskBox(sid);
    }

    private void TaskBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      if (taskBox.SelectedItem == null) return;
      infoBox.Items.Clear();
      var sql = string.Format(SqlStrings.GetTaskDetail, taskBox.GetItemText(taskBox.SelectedItem));
      var info = Sql.GetSingleString(sql);
      infoBox.Items.Add(info);
      infoBox.Refresh();
    }

    private void SprintBoxSelectedIndexChanged(object sender, EventArgs e)
    {
      var sprint = Convert.ToString(sprintBox.SelectedItem);
      var stop = sprint.IndexOf(':');
      var sid = Convert.ToInt32(sprint.Substring(0, stop));
      RefreshTaskBox(sid);
    }

    private void SelectProjectToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      var projName = e.ClickedItem.ToString();
      var fc = Application.OpenForms;
      var isFound = false;
      foreach (Form form in fc)
        if (form.Name == "Main")
        {
          form.Focus();
          isFound = true;
          Hide();
        }

      if (isFound == false)
      {
        var form = new Dashboard(memberNameToolStripMenuItem.Text, projName);
        form.Show();
        Hide();
      }
    }

    private void AssignRolesToolStripMenuItemClick(object sender, EventArgs e)
    {
      if (!Sql.IsOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text)
      )
      {
        MessageBox.Show(MessageBoxStrings.NotOwner, MessageBoxStrings.ERROR, MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1);
      }
      else
      {
        var form = new AssignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
        form.Show();
      }
    }

    private void AssignTasksToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new AssignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
    }
  }
}