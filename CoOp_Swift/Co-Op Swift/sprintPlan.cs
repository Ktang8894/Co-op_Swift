using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Co_Op_Swift.Properties;

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

      //get all project ids associated with the user ids
      var projIds = Sql.getUserProjectIDs(Sql.getOwnerUserID(memberNameToolStripMenuItem.Text));

      // get all project names associated with the project ids
      foreach (DataRow row in projIds.Rows)
      {
        //put project names in select project drop down menu
        var projName = Sql.getProjectName(int.Parse(row["Proj_ID"].ToString()));
        selectProjectToolStripMenuItem.DropDownItems.Add(projName);
      }
    }

    private static void ExecuteActionQuery(string sql)
    {
      var cmd = new SqlCommand
      {
        Connection = Sql.Db,
        CommandText = sql
      };

      cmd.ExecuteNonQuery();
    }

    private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm = new Dashboard(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      Close();
    }

    private void ideaBoxToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm = new IdeaBox(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      Close();
    }

    private void taskTreeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm = new TaskTree(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      Close();
    }

    private void releasePlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm = new ReleasePlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      Close();
    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm2 = new Login();
      frm2.Show();
      Close();
    }

    private void teamToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm = new AddMembers(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
    }

    public int GetPid()
    {
      var getPid = string.Format(SqlStrings.GetPid, projectNameToolStripMenuItem.Text);
      Sql.Db.Open();
      var cmd = new SqlCommand
      {
        Connection = Sql.Db,
        CommandText = getPid
      };
      var id = (int) cmd.ExecuteScalar();
      Sql.Db.Close();
      return id;
    }

    private void sprintPlan_Load(object sender, EventArgs e)
    {
      Sql.Db.Open();
      var pid = GetPid();
      var sql = string.Format(SqlStrings.GetSprintPlans, pid);
      var cmd = new SqlCommand
      {
        Connection = Sql.Db
      };
      var adapter = new SqlDataAdapter(cmd);
      var ds = new DataSet();
      cmd.CommandText = sql;
      adapter.Fill(ds);
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

      Sql.Db.Close();
    }

    //Reload text box
    private void RefreshTaskBox(int sid)
    {      
      var cmd = new SqlCommand();
      var ds2 = new DataSet();
      try
      {    
        Sql.Db.Open();
        taskBox.Items.Clear();
        //Load Tasks
        var sql = string.Format(SqlStrings.GetTasks, sid);
        cmd.Connection = Sql.Db;
        var adapter = new SqlDataAdapter(cmd);
        cmd.CommandText = sql;
        adapter.Fill(ds2);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        if (Sql.Db != null && Sql.Db.State == ConnectionState.Open)
          Sql.Db.Close();
      }

      ds2.Tables[0].TableName = "TaskTable";

      foreach (DataRow row in ds2.Tables["TaskTable"].Rows)
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

    private void createTask_Click(object sender, EventArgs e)
    {
      var taskName = taskNameBox.Text;
      var description = descriptionBox.Text;
      var sprint = Convert.ToString(sprintBox.SelectedItem);
      var stop = sprint.IndexOf(':');
      var sid = Convert.ToInt32(sprint.Substring(0, stop));

      Sql.Db.Open(); 
      //Insert TaskTable
      var insertTaskTable = string.Format(SqlStrings.InsertTaskTable, taskName, description, 1, Sql.getOwnerUserID(memberNameToolStripMenuItem.Text));
      ExecuteActionQuery(insertTaskTable);

      //Get Task ID
      var getTaskId = string.Format(SqlStrings.GetTaskId, taskName, description);

      var cmd = new SqlCommand();
      cmd.Connection = Sql.Db;
      cmd.CommandText = getTaskId;
      var tid = (int) cmd.ExecuteScalar();

      //Add to linking table (SprintTasks)
      var addToLinkingTable = string.Format(SqlStrings.AddToLinkingTable, sid, tid);
      ExecuteActionQuery(addToLinkingTable);
      Sql.Db.Close();
      RefreshTaskBox(sid);
    }

    private void taskBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (taskBox.SelectedItem == null) return;
      infoBox.Items.Clear();
      Sql.Db.Open();
      var sql = string.Format(SqlStrings.GetTaskDetail, taskBox.GetItemText(taskBox.SelectedItem));

      var cmd = new SqlCommand
      {
        Connection = Sql.Db,
        CommandText = sql
      };

      var info = (string) cmd.ExecuteScalar();
      infoBox.Items.Add(info);

      Sql.Db.Close();
      infoBox.Refresh();
    }

    private void sprintBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      var sprint = Convert.ToString(sprintBox.SelectedItem);
      var stop = sprint.IndexOf(':');
      var sid = Convert.ToInt32(sprint.Substring(0, stop));

      RefreshTaskBox(sid);
    }

    private void selectProjectToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      //get the name of the drop down item that was clicked
      var projName = e.ClickedItem.ToString();

      var fc = Application.OpenForms;
      var isFound = false;
      foreach (Form frm in fc)
        if (frm.Name == "Main")
        {
          frm.Focus();
          isFound = true;
          Hide();
        }

      if (isFound == false)
      {
        var frm = new Dashboard(memberNameToolStripMenuItem.Text, projName);
        frm.Show();
        Hide();
      }
    }

    private void assignRolesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (!Sql.isOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text)
      ) // THIS SQL NEEDS TO BE DONE
      {
        MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1);
      }
      else
      {
        var frm = new AssignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
        frm.Show();
      }
    }

    private void assignTasksToolStripMenuItem_Click(object sender, EventArgs e)
    {
      var frm = new AssignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
    }
  }
}