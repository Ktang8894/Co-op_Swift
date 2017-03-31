using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Co_Op_Swift
{
  public partial class sprintPlan : Form
  {
    public sprintPlan(String username, String projectName)
    {
      InitializeComponent();

      projectNameToolStripMenuItem.Text = projectName;
      memberNameToolStripMenuItem.Text = username;
      sprintPlanToolStripMenuItem.Font = new Font(sprintPlanToolStripMenuItem.Font, FontStyle.Bold);

      /***************************** this is for select a project drop down menu **********************************/

      //get all project ids associated with the user ids
      DataTable proj_ids = SQL.getUserProjectIDs(SQL.getOwnerUserID(memberNameToolStripMenuItem.Text));

      string proj_name;

      // get all project names associated with the project ids
      foreach (DataRow row in proj_ids.Rows)
      {
        //put project names in select project drop down menu
        proj_name = SQL.getProjectName(int.Parse(row["Proj_ID"].ToString()));
        selectProjectToolStripMenuItem.DropDownItems.Add(proj_name);
      }
      /*************************************************************************************************************/
    
    }

    static void ExecuteActionQuery(SqlConnection db, string sql)
    {
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      cmd.ExecuteNonQuery();
    }
    private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void ideaBoxToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ideaBox frm = new ideaBox(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void taskTreeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      taskTree frm = new taskTree(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void releasePlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      releasePlan frm = new releasePlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Login frm2 = new Login();
      frm2.Show();
      this.Close();
    }

    private void teamToolStripMenuItem_Click(object sender, EventArgs e)
    {
      addMembers frm = new addMembers(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
    }

    public int getPID()
    {
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";
      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      string sql;

      db = new SqlConnection(connectionInfo);
      sql = string.Format(@"
Select Proj_ID
FROM Projects
WHERE Title = '{0}';
", projectNameToolStripMenuItem.Text);
      db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();

      db.Close();

      return id;
    }



    private void textBox1_TextChanged(object sender, EventArgs e)
    {
     
    }

    private void sprintPlan_Load(object sender, EventArgs e)
    {
      /**** DB INFO ****/
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";
      int pidTemp = getPID();
      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      string sql;

      db = new SqlConnection(connectionInfo);
      db.Open();
      /**** DB INFO END ****/

      int PID = getPID();

      //Load Sprints
      sql = string.Format(@"
SELECT *
FROM Sprints
INNER JOIN ProjectSprints
ON Sprints.SprintID = ProjectSprints.SprintID
WHERE ProjectSprints.Proj_ID = {0};
", PID);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      cmd.CommandText = sql;
      adapter.Fill(ds);
      ds.Tables[0].TableName = "Sprints";

      foreach (DataRow row in ds.Tables["Sprints"].Rows)
      {
        DateTime start = DateTime.Parse(Convert.ToString(row["StartDate"]));
        DateTime end = DateTime.Parse(Convert.ToString(row["EndDate"]));
        string startDate = start.ToShortDateString();
        string endDate = end.ToShortDateString();
        string msg = Convert.ToString(row["SprintID"] + ": " + startDate + " - " + endDate);
        sprintBox.Items.Add(msg);
      }

//      //Load Tasks
//      sql = string.Format(@"
//SELECT TaskName
//FROM TaskTable;
//");

//      DataSet ds2 = new DataSet();
//      cmd.CommandText = sql;
//      adapter.Fill(ds2);
//      ds2.Tables[0].TableName = "TaskTable";

//      foreach (DataRow row in ds2.Tables["TaskTable"].Rows)
//      {
//        //string msg = Convert.ToString(row["IdeaName"]);
//        taskBox.Items.Add(row["TaskName"]);
//      }

      db.Close();

    }

    //Reload text box
    private void refreshTaskBox(int SID)
    {
      /**** DB INFO ****/
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";
      int pidTemp = getPID();
      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      SqlCommand cmd = new SqlCommand();
      DataSet ds2 = new DataSet();
      string sql;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();
        /**** DB INFO END ****/

        taskBox.Items.Clear();
        //Load Tasks
        sql = string.Format(@"
SELECT TaskTable.TaskName
FROM TaskTable
INNER JOIN SprintTasks
ON TaskTable.Task_ID = SprintTasks.Task_ID
WHERE SprintTasks.SprintID = {0};
", SID);

        cmd.Connection = db;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);


        cmd.CommandText = sql;
        adapter.Fill(ds2);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        if (db != null && db.State == ConnectionState.Open)
          db.Close();
      }

      if (ds2 != null)
      {
        ds2.Tables[0].TableName = "TaskTable";
        Boolean isFound = false;

        foreach (DataRow row in ds2.Tables["TaskTable"].Rows)
        {
          isFound = false;
          foreach (string s in taskBox.Items)
          {
            if (s.Equals(row["TaskName"].ToString()))
            {
              isFound = true;
              break;
            }
          }

          if (!isFound)
            taskBox.Items.Add(row["TaskName"]);

        }
      }

    }

    private void createTask_Click(object sender, EventArgs e)
    {
      /**** DB INFO ****/
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";
      int pidTemp = getPID();
      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      string sql;

      db = new SqlConnection(connectionInfo);
      /**** DB INFO END ****/

      string taskName = taskNameBox.Text;
      string description = descriptionBox.Text;
      string sprint = Convert.ToString(sprintBox.SelectedItem);
      int stop = sprint.IndexOf(':');
      int SID = Convert.ToInt32(sprint.Substring(0, stop));

      db.Open(); // open connection to database
      //Insert TaskTable
      sql = string.Format(@"
INSERT INTO TaskTable(UID, PID, TaskName, TaskDetail, Completed)
VALUES ({3}, {2}, '{0}', '{1}', 0);
", taskName, description, 1, SQL.getOwnerUserID(memberNameToolStripMenuItem.Text));
      ExecuteActionQuery(db, sql);
      //taskBox.Items.Add(taskName);

      //Get Task ID
      sql = string.Format(@"
SELECT Task_ID
FROM TaskTable
WHERE TaskName = '{0}'
AND TaskDetail = '{1}';
", taskName, description);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;
      int TID = (int)cmd.ExecuteScalar();

      //Add to linking table (SprintTasks)
      sql = string.Format(@"
INSERT INTO SprintTasks(SprintID, Task_ID)
VALUES ({0}, {1});
", SID, TID);

      ExecuteActionQuery(db, sql);

      db.Close();
      refreshTaskBox(SID);
    }

    private void taskBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (taskBox.SelectedItem == null)
      {
        return;
      }

      infoBox.Items.Clear();
      /**** DB INFO ****/
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";
      int pidTemp = getPID();
      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      string sql;

      db = new SqlConnection(connectionInfo);
      db.Open();
      /**** DB INFO END ****/
      sql = string.Format(@"
SELECT TaskDetail
FROM TaskTable
WHERE TaskName = '{0}';
", taskBox.GetItemText(taskBox.SelectedItem));

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      string info = (string)cmd.ExecuteScalar();
      infoBox.Items.Add(info);
            
      db.Close();
      infoBox.Refresh();
    }

    private void sprintBox_SelectedIndexChanged(object sender, EventArgs e)
    {
      string sprint = Convert.ToString(sprintBox.SelectedItem);
      int stop = sprint.IndexOf(':');
      int SID = Convert.ToInt32(sprint.Substring(0, stop));

      refreshTaskBox(SID);
    }

    private void label5_Click(object sender, EventArgs e)
    {

    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }

    private void selectProjectToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      //get the name of the drop down item that was clicked
      string proj_name = e.ClickedItem.ToString();

      FormCollection fc = Application.OpenForms;
      bool isFound = false;
      foreach (Form frm in fc)
      {
        if (frm.Name == "Main")
        {
          frm.Focus();
          isFound = true;
          this.Hide();
        }
      }

      if (isFound == false)
      {
        Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, proj_name);
        frm.Show();
        this.Hide();
      }

    }

        private void assignRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SQL.isOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
            {

                MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
            else
            {
                assignRole frm = new assignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
                frm.Show();
            }
        }

        private void assignTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assignTask frm = new assignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
            frm.Show();
        }
    }
}
