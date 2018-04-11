using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Co_Op_Swift.Resources;

namespace Co_Op_Swift
{
  public partial class ReleasePlan : Form
  {
    public ReleasePlan(string username, string projectName)
    {
      InitializeComponent();
      projectNameToolStripMenuItem.Text = projectName;
      memberNameToolStripMenuItem.Text = username;
      releasePlanToolStripMenuItem.Font = new Font(releasePlanToolStripMenuItem.Font, FontStyle.Bold);

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

    private void SprintPlanToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new SprintPlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
      Close();
    }

    private void LogoutToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new Login();
      form.Show();
      Close();
    }

    private void TeamToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new AddMembers(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
    }

    public int GetPid()
    {
      var sql = string.Format(SqlStrings.GetPid, projectNameToolStripMenuItem.Text);
      var id = Sql.GetSingleInt(sql);
      return id;
    }

    private int _columnCounter;
    private void ReleasePlanLoad(object sender, EventArgs e)
    {
      //Load Sprints
      var sql = string.Format(SqlStrings.LoadReleasePlan, GetPid());
      var releasePlanDataSet = Sql.GetDataSet(sql);
      releasePlanDataSet.Tables[0].TableName = "Sprints";

      foreach (DataRow row in releasePlanDataSet.Tables["Sprints"].Rows)
      {
        var sid = Convert.ToInt32(row["SprintID"]);
        var start = DateTime.Parse(Convert.ToString(row["StartDate"]));
        var end = DateTime.Parse(Convert.ToString(row["EndDate"]));
        var startDate = start.ToShortDateString();
        var endDate = end.ToShortDateString();
        dataGridView1.Columns.Add("Sprint" + sid, "Sprint ID: " + sid + "\n" + startDate + "\n" + "-\n" + endDate);

        //Add Tasks for each column 
        sql = string.Format(SqlStrings.GetTasks, sid);
        var ds = Sql.GetDataSet(sql);
        ds.Tables[0].TableName = "TaskTable";
        var i = 0;
        foreach (DataRow row2 in ds.Tables["TaskTable"].Rows)
        {
          var destColumn = "Sprint" + sid;
          while (dataGridView1.Rows[i].Cells[destColumn].Value != null) i++;
          dataGridView1.Rows.Add();
          dataGridView1.Rows[i].Cells[destColumn].Value = Convert.ToString(row2["TaskName"]);
        }
      }
      var id = Sql.GetSingleInt(SqlStrings.GetSprintId);
      _columnCounter = id;
    }

    //Add Sprint Button
    private void AddSprintClick(object sender, EventArgs e)
    {
      var sMonth = startMonth.Text;
      var sDay = startDay.Text;
      var sYear = startYear.Text;
      var eMonth = endMonth.Text;
      var eDay = endDay.Text;
      var eYear = endYear.Text;
      var startDate = sMonth + "/" + sDay + "/" + sYear;
      var endDate = eMonth + "/" + eDay + "/" + eYear;

      if (DateTime.TryParse(startDate, out var sDate) && DateTime.TryParse(endDate, out var eDate))
        if (eDate.Date < sDate.Date)
        {
          MessageBox.Show(MessageBoxStrings.EndDateBeforeStartDate, MessageBoxStrings.ERROR, MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        else
        {
          var sql = string.Format(SqlStrings.InsertSprintTable, sDate, eDate);
          Sql.ExecuteActionQuery(sql);

          var id = Sql.GetSingleInt(SqlStrings.GetSprintId);
          dataGridView1.Columns.Add("Sprint" + id, "Sprint ID: " + id + "\n" + startDate + "\n" + "-\n" + endDate);

          _columnCounter = id;
          var pid = GetPid();
          sql = string.Format(SqlStrings.InsertProjectSprintTable, pid, id);
          Sql.ExecuteActionQuery(sql);
        }

      else
      {
        MessageBox.Show(MessageBoxStrings.InvalidStartEndDate, MessageBoxStrings.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1);
      }
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
        MessageBox.Show(MessageBoxStrings.NotOwner, MessageBoxStrings.ERROR, MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
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

    private void TimeLineToolStripMenuItemClick(object sender, EventArgs e)
    {
      var form = new TaskTree(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      form.Show();
      Close();
    }
  }
}