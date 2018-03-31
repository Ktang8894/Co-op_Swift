using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;


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

      /****************** this is for select a project drop down menu ******************************/

      //get all project ids associated with the user ids
      DataTable proj_ids = Sql.getUserProjectIDs(Sql.getOwnerUserID(memberNameToolStripMenuItem.Text));

      string proj_name;

      // get all project names associated with the project ids
      foreach (DataRow row in proj_ids.Rows)
      {
        //put project names in select project drop down menu
        proj_name = Sql.getProjectName(int.Parse(row["Proj_ID"].ToString()));
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
      IdeaBox frm = new IdeaBox(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void sprintPlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SprintPlan frm = new SprintPlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
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
      AddMembers frm = new AddMembers(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
    }

    public int getPID()
    {

    
      string sql;

      
      sql = string.Format(@"
Select Proj_ID
FROM Projects
WHERE Title = '{0}';
", projectNameToolStripMenuItem.Text);
      Sql.Db.Open();
      SqlCommand cmd = new SqlCommand();
      cmd.Connection = Sql.Db;
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();

      Sql.Db.Close();

      return id;
    }

    int columnCounter = 0; //Global variable for latest sprint
    private void releasePlan_Load(object sender, EventArgs e)
    {
      
      string sql;


      Sql.Db.Open(); // open connection to database

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = Sql.Db;
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
        cmd2.Connection = Sql.Db;
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
      cmd.Connection = Sql.Db;
      cmd.CommandText = sql;
      int id = (int)cmd.ExecuteScalar();
      
      columnCounter = id;


      Sql.Db.Close();
    }

    //Add Sprint Button
    private void addSprint_Click(object sender, EventArgs e)
    {

      
      string sql;

      
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
          Sql.Db.Open(); // open connection to database

          //Insert Sprint
          sql = string.Format(@"
INSERT INTO Sprints(StartDate, EndDate)
VALUES ('{0}', '{1}')
", sDate, eDate);

          Sql.ExecuteActionQuery(sql);

          //Get ID Number
          sql = string.Format(@"
SELECT MAX(SprintID)
FROM Sprints;
");
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = Sql.Db;
          cmd.CommandText = sql;
          int id = (int)cmd.ExecuteScalar();
          dataGridView1.Columns.Add("Sprint" + id, "Sprint ID: " + id + "\n" + startDate + "\n" + "-\n" + endDate);
          
          columnCounter = id;

          int PID = getPID();

          sql = string.Format(@"
INSERT INTO ProjectSprints(Proj_ID, SprintID)
VALUES ({0}, {1});
", PID, id);

          Sql.ExecuteActionQuery(sql);

          Sql.Db.Close();
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
            if (!Sql.isOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
            {

                MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
            else
            {
                AssignRole frm = new AssignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
                frm.Show();
            }
           
        }

        private void assignTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignTask frm = new AssignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
            frm.Show();
        }

    private void timeLineToolStripMenuItem_Click(object sender, EventArgs e)
    {
      TaskTree frm = new TaskTree(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }
  }
}