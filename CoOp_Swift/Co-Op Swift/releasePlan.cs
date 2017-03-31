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
  public partial class releasePlan : Form
  {
    static void ExecuteActionQuery(SqlConnection db, string sql)
    {
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      cmd.ExecuteNonQuery();
    }

    public releasePlan(String username, String projectName)
    {
      InitializeComponent();

      projectNameToolStripMenuItem.Text = projectName;
      memberNameToolStripMenuItem.Text = username;
      releasePlanToolStripMenuItem.Font = new Font(releasePlanToolStripMenuItem.Font, FontStyle.Bold);

      /****************** this is for select a project drop down menu ******************************/

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
      /********************************************************************************************/
   
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

    private void sprintPlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      sprintPlan frm = new sprintPlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
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

    int columnCounter = 0; //Global variable for latest sprint
    private void releasePlan_Load(object sender, EventArgs e)
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
      db.Open(); // open connection to database

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      SqlDataAdapter adapter = new SqlDataAdapter(cmd);

      int PID = getPID();
      //Load Sprints
      sql = string.Format(@"
SELECT Sprints.SprintID, StartDate, EndDate
FROM Sprints
INNER JOIN ProjectSprints
ON Sprints.SprintID = ProjectSprints.SprintID
WHERE ProjectSPrints.Proj_ID = {0};
", PID);

      DataSet ds2 = new DataSet();
      cmd.CommandText = sql;
      adapter.Fill(ds2);

      ds2.Tables[0].TableName = "Sprints";


      foreach (DataRow row in ds2.Tables["Sprints"].Rows)
      {
        //string msg = Convert.ToString(row["IdeaName"]);
        int SID = Convert.ToInt32(row["SprintID"]);
        DateTime start = DateTime.Parse(Convert.ToString(row["StartDate"]));
        DateTime end = DateTime.Parse(Convert.ToString(row["EndDate"]));
        string startDate = start.ToShortDateString();
        string endDate = end.ToShortDateString();
        dataGridView1.Columns.Add("Sprint" + SID, "Sprint ID: " + SID + "\n" + startDate + "\n" + "-\n" + endDate);

        //Add Tasks for each column 
        string sql2 = string.Format(@"
SELECT TaskTable.TaskName
FROM TaskTable
INNER JOIN SprintTasks
ON TaskTable.Task_ID = SprintTasks.Task_ID
WHERE SprintTasks.SprintID = {0};
", SID);

        SqlCommand cmd2 = new SqlCommand();
        cmd2.Connection = db;
        DataSet ds = new DataSet();
        cmd2.CommandText = sql2;
        SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
        adapter2.Fill(ds);
        ds.Tables[0].TableName = "TaskTable";
        int i = 0;
        foreach(DataRow row2 in ds.Tables["TaskTable"].Rows)
        {
          string destColumn = "Sprint" + SID;
          while (dataGridView1.Rows[i].Cells[destColumn].Value != null)
          {
            i++;
          }
          dataGridView1.Rows.Add();
          dataGridView1.Rows[i].Cells[destColumn].Value = Convert.ToString(row2["TaskName"]);
        }

      }

      //Get ID Number
      sql = string.Format(@"
SELECT MAX(SprintID)
FROM Sprints;
");
      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;
      int id = (int)cmd.ExecuteScalar();
      
      columnCounter = id;


      db.Close();
    }

    //Add Sprint Button
    private void addSprint_Click(object sender, EventArgs e)
    {
      /**** DB INFO ****/
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";

      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      string sql;

      db = new SqlConnection(connectionInfo);
      /**** DB INFO END ****/

      string sMonth = startMonth.Text;
      string sDay = startDay.Text;
      string sYear = startYear.Text;
      string eMonth = endMonth.Text;
      string eDay = endDay.Text;
      string eYear = endYear.Text;
      string startDate = sMonth + "/" + sDay + "/" + sYear;
      string endDate = eMonth + "/" + eDay + "/" + eYear;

      //Validate Date
      DateTime sDate;
      DateTime eDate;

      if (DateTime.TryParse(startDate, out sDate) && DateTime.TryParse(endDate, out eDate))
      {
        if (eDate.Date < sDate.Date)
        {
          MessageBox.Show("End Date cannot be before Start Date", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        else
        {
          db.Open(); // open connection to database

          //Insert Sprint
          sql = string.Format(@"
INSERT INTO Sprints(StartDate, EndDate)
VALUES ('{0}', '{1}')
", sDate, eDate);

          ExecuteActionQuery(db, sql);

          //Get ID Number
          sql = string.Format(@"
SELECT MAX(SprintID)
FROM Sprints;
");
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = db;
          cmd.CommandText = sql;
          int id = (int)cmd.ExecuteScalar();
          dataGridView1.Columns.Add("Sprint" + id, "Sprint ID: " + id + "\n" + startDate + "\n" + "-\n" + endDate);
          
          columnCounter = id;

          int PID = getPID();

          sql = string.Format(@"
INSERT INTO ProjectSprints(Proj_ID, SprintID)
VALUES ({0}, {1});
", PID, id);

          ExecuteActionQuery(db, sql);

          db.Close();
        }
      }

     else
      {
        MessageBox.Show("Not a valid start/end date", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
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

    }//End of addSprintClick

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