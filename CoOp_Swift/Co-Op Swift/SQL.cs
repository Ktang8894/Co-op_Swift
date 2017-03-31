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
  public class SQL
  {
    //credentials and info to connect to Azure database
    static string netID = "ddoyle4";
    static string dbName = "Co-Op Swift";
    static string password = "cAtsaref0n";

    static public string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);



    //ExecuteActionQuery
    static public void ExecuteActionQuery(SqlConnection db, string sql)
    {
      SqlCommand cmd = null;

      try
      {
        cmd = new SqlCommand(sql, db);
        cmd.ExecuteNonQuery();
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        if (cmd == null)
          MessageBox.Show("ExecuteActionQuery failed to execute query");
      }
    }


    //method that executes a login query
    static public Boolean ExecuteLogin(String username, string user_pass)
    {
      SqlConnection db = null;
      SqlCommand    cmd = null;
      DataSet       ds = null;
      Boolean       pass = false;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        string sql = string.Format("select * FROM UserAccounts where UserName = '{0}' ", username);

        cmd = new SqlCommand(sql, db);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        ds = new DataSet();

        adapter.Fill(ds);
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


      if (ds != null)
      {
        DataTable dt = ds.Tables["Table"];

        if (dt.Rows.Count == 0) {
          MessageBox.Show("User doesn't exist.", "User Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
          return pass;
        }
        else {
          DataRow row = dt.Rows[0];
          String password = string.Format("{0}", row["Password"].ToString());

          if (password.Equals(user_pass))
            pass = true;
        }
      }
      return pass;
    }// end of ExecuteLogin



    //method that executes a registration query
    static public void ExecuteRegistration(String username, String password, String LastName, String FirstName, String answer)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int QID = 1; //Temp
      int PID = 1; //Temp

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        // CHECK IF USERNAME IS ALREADY BEING USED
        string sql = string.Format(@" SELECT COUNT(*) FROM UserAccounts WHERE UserName = '{0}';", username);

        cmd = new SqlCommand(sql, db);
        int count = (int)cmd.ExecuteScalar();


        // If Username Exists
        if (count != 0)
          MessageBox.Show("Email / Username already exists.");
        else
        {
          //ADD USER INFO
          sql = string.Format(@"
                          INSERT INTO
                          UserAccounts(UserName, Password, LastName, FirstName, QID, Answer, PID)
                          Values('{0}', '{1}', '{2}', '{3}', {4}, '{5}', {6});
                          ", username, password, LastName, FirstName, QID, answer, PID);

          ExecuteActionQuery(db, sql);
        }
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

    }// end ExecuteRegistration



    //method that executes the resetting of a users password
    static public void ExecutePasswordReset(String username, String password)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        string sql = string.Format(@"Update UserAccounts Set Password = '{0}' where Username = '{1}' ",
        password, username);

        ExecuteActionQuery(db, sql);
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
    }// end ExecutePasswordReset



    // method to check if user exists in database
    static public int CheckUserExsistence(String username)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int count = 0;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                                  SELECT COUNT(*) 
                                  FROM UserAccounts
                                  WHERE UserName = '{0}';
                                  ",
                                    username);

        cmd = new SqlCommand(sql, db);

        count = (int)cmd.ExecuteScalar();
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

      return count;
    }// end CheckUserExisistence


    //method to get the ID of the owner(creator) of the project
    static public int getOwnerUserID(String username)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int id = 0;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                                  SELECT UID 
                                  FROM UserAccounts
                                  WHERE UserName = '{0}';
                                  ",
                                    username);

        cmd = new SqlCommand(sql, db);

        id = (int)cmd.ExecuteScalar();
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

      return id;
    }// end getOwnerID



    //method to get the ID of the owner(creator) of the project
    static public int getProjectID(int ownerID)
    {
      SqlConnection db = null;
      int id = 0;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                                    SELECT Proj_ID
                                    FROM Projects
                                    WHERE OwnerID = {0};
                                    ",
                                    ownerID);

        SqlCommand cmd = new SqlCommand(sql, db);

        id = (int)cmd.ExecuteScalar();
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

      return id;
    }// end getOwnerID


    // method to create project in database
    static public void ExecuteProjectCreation(int ownerID, string title, string releaseEndDate, int timezoneID,
      string projectStartDate, string description, int isPrivate)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        //ADD PROJECT INFO
        string sql = string.Format(@"
                          INSERT INTO
                          Projects(OwnerID, Title, Description, Private, TID)
                          Values({0}, '{1}', '{2}', {3}, {4});
                          ", ownerID, title, description, isPrivate, timezoneID);

        ExecuteActionQuery(db, sql);
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.Message);
      }
      finally
      {
        if (db != null && db.State == ConnectionState.Open)
          db.Close(); // close database connection
      }

     // insertSprintInfo(sprintStartDate);
      int projID = getProjectID(ownerID);
      addUserToProject(ownerID,projID,1);

    }// end ExecuteProjectCreation\


    //static public void insertSprintInfo(string startDate)
    //{
    //  SqlConnection db = null;
    //  string sprintEndDate = DateTime.Now.AddDays(21).ToShortDateString();

    //  try
    //  {
    //    db = new SqlConnection(connectionInfo);
    //    db.Open(); // open connection to database

    //    //ADD PROJECT INFO
    //    string sql = string.Format(@"
    //                      INSERT INTO
    //                      Sprints(StartDate, EndDate)
    //                      Values('{0}', '{1}');
    //                      ", startDate, sprintEndDate);

    //    ExecuteActionQuery(db, sql);
    //  }
    //  catch (Exception ex)
    //  {
    //    MessageBox.Show(ex.Message);
    //  }
    //  finally
    //  {
    //    if (db != null && db.State == ConnectionState.Open)
    //      db.Close(); // close database connection
    //  }
    //}// end insertSprintInfo


    //method loads the user's securty question into onto 'ResetForm1'
    static public void loadUserSecurityQuestion(String username, TextBox textBox)
    {
      SqlConnection db = null;
      SqlCommand    cmd = null;
      DataSet       ds = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        string sql = string.Format("select QID FROM UserAccounts where UserName = '{0}' ", username);

        cmd = new SqlCommand(sql, db);
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        adapter.Fill(ds);
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


      if (ds != null)
      {
        DataTable dt = ds.Tables["Table"];

        if (dt.Rows.Count == 0)
        {
          MessageBox.Show("User Not Found. Please Register or choose different username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
          return;
        }
        else
        {
          DataRow row = dt.Rows[0];
          String pass = string.Format("{0}", row["QID"].ToString());

          if (pass.Equals("1"))
            pass = "In what city or town does your nearest sibling live?";
          else if (pass.Equals("2"))
            pass = "What time of day were you born?";
          else if (pass.Equals("3"))
            pass = "What is the name of the first person you kissed??";
          else if (pass.Equals("4"))
            pass = "What is the name of your elementary/primary school?";

          textBox.Text = pass;
        }
      }
      else {
        MessageBox.Show("Query didn't return any results");
      }

    }//end loadUserSecurityQuestion

    

    // method that checks if the user's answer to security question matches the one on file
    static public Boolean checkAnswerWithDatabase(String username, String answer)
    {
      Boolean         isCorrect = false;
      SqlConnection   db = null;
      SqlCommand      cmd = null;
      DataSet         ds = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                                    SELECT *
                                    FROM UserAccounts
                                    WHERE UserName = '{0}';
                                    ",
                                    username);

        cmd = new SqlCommand(sql, db);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        ds = new DataSet();

        adapter.Fill(ds);
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


      DataTable dt = ds.Tables["Table"];
      DataRow row = dt.Rows[0];
      String pass = string.Format("{0}", row["Answer"].ToString());

      if (pass.Equals(answer))
        isCorrect = true;

      return isCorrect;

    }//end checkAnswerWithDatabase


    //method that fills the listboxes in the 'addMembers' form
    static public DataTable getProjectMembersForAddMembers(int projID)
    {
      SqlConnection db = null;
      SqlCommand    cmd = null;
      DataSet       ds = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to data

        string sql = string.Format("select * FROM ProjectMembers WHERE Proj_ID = {0}", projID);

        cmd = new SqlCommand(sql, db);

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adapter.Fill(ds);
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


      if (ds != null)
        return ds.Tables["Table"];
      else {
        MessageBox.Show("Dataset returned empty");
        return null;
      }

    }//end getProjectMembers



    /********************************************************************************************************************************/
    /*                                                                                                                              */
    /*                                                 FUNCTIONS ABOVE ARE FIXED                                                    */
    /*                                            ------------------------------------                                              */
    /*                                              FUNCTIONS BELOW NEED TO BE FIXED                                                */
    /*                                                                                                                              */
    /********************************************************************************************************************************/



    //method that fills the listboxes in the 'addMembers' form
    static public void getMembers(ListBox currentUsers, ListBox teamMembers, String username, Boolean isCreating, int projID)
    {
      SqlConnection db = null;
      DataTable t ;
      string curr_name, prev_name = "" ;
     
      //get project members
      if (!isCreating)
      {
        t = getProjectMembersForAddMembers(projID);

        foreach (DataRow s in t.Rows)
        {
          curr_name = SQL.getFullName(int.Parse(s["UID"].ToString()));

          if (!curr_name.Equals(prev_name))
          {
            teamMembers.Items.Add(curr_name);
            prev_name = curr_name;
          }

        }
      }

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM UserAccounts");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      String fullname, firstName, lastName;

      foreach (DataRow row in dt.Rows)
      {
        firstName = row["FirstName"].ToString();
        lastName = row["LastName"].ToString();
        fullname = String.Format(firstName + " " + lastName);

        if (!fullname.Equals(" "))
        {
          string userFullname = SQL.getFullName(SQL.getOwnerUserID(username));
          if (fullname.Equals(userFullname))
            teamMembers.Items.Add(fullname);

          currentUsers.Items.Add(fullname);
          //teamMembers.Items.Add(row["UID"].ToString());
        }
      }

      db.Close(); // close database connection


    }//end of getMembers


    //method to get the username of a user
    static public string getUsername(string fullname)
    {
      String[] names = fullname.Split(' ');
      String firstName = names[0];
      String lastName = names[1];
      SqlConnection db = null;


      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM UserAccounts where FirstName = '{0}' and LastName = '{1}'",
                                                                                   firstName, lastName);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      DataRow row = dt.Rows[0];
      String name = string.Format("{0}", row["UserName"].ToString());
      db.Close();

      return name;

    }//end getUsername


    //method to add user to project
    static public void addUserToProject(int userID, int projID, int position)
    {

      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //ADD PROJECT INFO
      string sql = string.Format(@"
                        INSERT INTO
                        ProjectMembers(Proj_ID, UID,PID)
                        Values({0}, {1}, {2});
                        ", projID, userID,position);

      ExecuteActionQuery(db, sql);

      db.Close(); // close database connection

    }// end addUserToProject


    //method to get the ID of a project
    static public int getProjectID(string projName)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT Proj_ID
                                  FROM Projects
                                  WHERE Title = '{0}';
                                  ", projName);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();

      return id;

    }//end getProjectID


    //method to add user to project
    static public void removeUserFromProject(int userID, int projID)
    {

      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //ADD PROJECT INFO
      string sql = string.Format(@"
                        DELETE FROM
                        ProjectMembers
                        WHERE Proj_ID = {0} AND UID = {1};
                        ", projID, userID);

      ExecuteActionQuery(db, sql);

      db.Close(); // close database connection

    }// end removeUserFromProject


    //metod to get the ID of a timezone
    static public int getTimeZoneID(string timezone)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT TID
                                  FROM TimeZones
                                  WHERE TimeZone = '{0}';
                                  ", timezone);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();

      return id;

    }//end getTimeZoneID


    //method to add timezones to listbox in 'create project' form
    static public void addTimeZonesToForm(ListBox cp)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM TimeZones");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      String timezone;

      foreach (DataRow row in dt.Rows)
      {
        timezone = row["Timezone"].ToString();
        cp.Items.Add(timezone);
      }

      db.Close(); // close database connection

    }//end addTimeZonesToForm


    static public void getDevelopers(ListBox currentUsers, ListBox teamMembers, String username)
    {
      String usersFullName;
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM UserAccounts as u join Positions as p on u.PID = p.PID where Position = 'Developer' ");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      String fullname, firstName, lastName;

      foreach (DataRow row in dt.Rows)
      {
        firstName = row["FirstName"].ToString();
        lastName = row["LastName"].ToString();
        fullname = String.Format(firstName + " " + lastName);

        if (!fullname.Equals(" "))
        {
          if (username.Equals(row["UserName"].ToString()))
          {
            usersFullName = fullname; // for remove members button
            teamMembers.Items.Add(fullname);
          }
          else
            currentUsers.Items.Add(fullname);
        }
      }

      db.Close(); // close database connection


    }//end of getDevelopers


        static public bool isManager(string username, string projName)
        {
            //check if they are a manager
            SqlConnection db = null;
            SqlCommand cmd;
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database
            //SqlCommand cmd;
            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"
                                  SELECT Position 
                                  FROM UserAccounts 
                                    INNER JOIN ProjectMembers on ProjectMembers.UID = UserAccounts.UID
                                    INNER JOIN Positions on Positions.PID = ProjectMembers.PID
                                  WHERE UserAccounts.UserName = '{0}'
                                  
                                  
                                  ", username, SQL.getProjectID(projName));
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            string id = (string)cmd.ExecuteScalar();

            db.Close();
            return id.Equals("Manager");

        }


        static public bool isOwner(string username, string proj)
        {
            SqlConnection db = null;
            SqlCommand cmd;
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database
            //SqlCommand cmd;
            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"
                                  SELECT Position 
                                  FROM UserAccounts 
                                    INNER JOIN ProjectMembers on ProjectMembers.UID = UserAccounts.UID
                                    INNER JOIN Positions on Positions.PID = ProjectMembers.PID
                                  WHERE UserAccounts.UserName = '{0}'
                                  
                                  
                                  ", username, SQL.getProjectID(proj));
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            string id = (string)cmd.ExecuteScalar();
            db.Close();
            return id.Equals("Project Owner");
        }
        static public void getProjectMembers(ListBox teamMembers, String username, string proj)
    {
            //String usersFullName;
            SqlConnection db = null;

            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            String sql;
            SqlCommand cmd;

            sql = string.Format(@"select * FROM UserAccounts 
inner join ProjectMembers  on UserAccounts.UID = ProjectMembers.UID 
where ProjectMembers.Proj_ID ='{0}'", SQL.getProjectID(proj));

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            String fullname, firstName, lastName;

            foreach (DataRow row in dt.Rows)
            {
                firstName = row["FirstName"].ToString();
                lastName = row["LastName"].ToString();
                fullname = String.Format(firstName + " " + lastName);

                if (!fullname.Equals(" "))
                {
                    Console.Write(fullname);
                    teamMembers.Items.Add(fullname);
                }
            }

            db.Close(); // close database connection


        }//end of getProjectMembers


    static public void ExecuteChangePosition(int userid, String role,String proj)
    {
            SqlConnection db = null;

            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            String sql;

            sql = string.Format(@"Update Positions  
Set Position = '{0}'
FROM Positions
INNER JOIN ProjectMembers on ProjectMembers.PID = Positions.PID
INNER JOIN UserAccounts on UserAccounts.UID = ProjectMembers.UID
where UserAccounts.UID = '{1}' and ProjectMembers.Proj_ID = {2}

",
              role, userid, SQL.getProjectID(proj) //and ProjectMembers.Proj_ID ='{2}'
                                                     //username,
              );

            ExecuteActionQuery(db, sql);
            Console.Write("woke");
            db.Close(); // close database connection
        } //end of change role button


        static public void getTasks(ComboBox tasks, string proj_id)
        {
            //String usersFullName;
            SqlConnection db = null;

            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            String sql;
            SqlCommand cmd;

            sql = string.Format(@"Select * from TaskTable
INNER JOIN SprintTasks on TaskTable.Task_ID = SprintTasks.Task_ID
INNER JOIN Projects on Projects.TID = SprintTasks.Task_ID
INNER JOIN ProjectSprints on ProjectSprints.SprintID = SprintTasks.SprintID
where ProjectSprints.Proj_ID = {0}
            ", SQL.getProjectID(proj_id));

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            String fulldetail, name, detail;

            foreach (DataRow row in dt.Rows)
            {
                name = row["TaskName"].ToString();
                detail = row["TaskDetail"].ToString();
                //maybe get completeness here?
                fulldetail = String.Format(name + " " + detail);

                if (!fulldetail.Equals(" "))
                {
                    tasks.Items.Add(fulldetail);
                }
            }

            db.Close(); // close database connection


        }//end of getTasks


        static public string getPosition(int username, string projID)
        {
            SqlConnection db = null;

            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database
            SqlCommand cmd;
            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"
                                  SELECT Position 
                                  FROM UserAccounts 
                                    INNER JOIN ProjectMembers on ProjectMembers.UID = UserAccounts.UID
                                    INNER JOIN Positions on Positions.PID = ProjectMembers.PID
                                  WHERE UserAccounts.UID = '{0}'
                                  AND ProjectMembers.Proj_ID = {1}
                                  ",
                                        username, SQL.getProjectID(projID));
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables["Table"];
            String firstName = "";

            foreach (DataRow row in dt.Rows)
            {
                firstName = row["Position"].ToString();

            }
            db.Close();
            return firstName;
        }


    //method to get the fullname of a user
    static public string getFullName(int userID)
    {
      //String usersFullName;
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("Select * from userAccounts WHERE UID = {0}",userID);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      string fullname = " ";
      DataRow row = dt.Rows[0];

      fullname = String.Format(row["FirstName"].ToString() + " " + row["LastName"].ToString());
      db.Close();

      return fullname;
    }

    static public void getProjectNames(ListBox box)
    { 
      SqlConnection db = null;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM Projects");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      

      foreach (DataRow row in dt.Rows)
      {
        box.Items.Add(row["Title"].ToString());
      }
      db.Close();
    }


    static public string getProjectName(int project_id)
    {
      SqlConnection db = null;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select Title FROM Projects WHERE Proj_ID = {0}", project_id);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      DataRow row = dt.Rows[0];
      string name = row["Title"].ToString();

      db.Close();
      return name;
    }


    static public void getProjUsers(ListBox box)
    { 
      SqlConnection db = null;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM ProjectMembers");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      

      foreach (DataRow row in dt.Rows)
      {
        box.Items.Add(SQL.getFullName(int.Parse(row["UID"].ToString())) + "----->" + row["Proj_ID"].ToString());
      }
      db.Close();
    }
  
    static public void ExecuteStory(String username,String name, string desc)
    {
        SqlConnection db = null;
        //SqlTransaction tx = null;


        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database
   

        string sql = string.Format(@"
                      INSERT INTO
                      Ideas(UID, IdeaName, IdeaDetail)
                      Values('{0}', '{1}', '{2}');
                      ", SQL.getOwnerUserID(username), name, desc);

        ExecuteActionQuery(db, sql);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;
            

        db.Close(); // close database connection

    }// end ExecuteRegistration

    static public void getStories(ListBox currentUsers,  String username, int projID)
    {
        SqlConnection db = null;
            

        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        String sql;
        SqlCommand cmd;

       // sql = string.Format(@"select * FROM Ideas where UID = '{0}'",SQL.getOwnerUserID(username));
        
        sql = string.Format(@"select * FROM Ideas
                              INNER JOIN ProjectIdeas on ProjectIdeas.IdeaID = Ideas.IdeaID
                              where ProjectIdeas.Proj_ID = '{0}'", projID);
                              
        cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;

        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adapter.Fill(ds);

        DataTable dt = ds.Tables["Table"];
        String name;

        foreach (DataRow row in dt.Rows)
        {
            name = row["IdeaName"].ToString();
                
            Console.Write("It made it" + name);

            if (!name.Equals(" "))
            {
                    currentUsers.Items.Add(name);
            }
        }
        Console.Write("It not made it" );
        db.Close(); // close database connection


    }//end of getMembers

    static public string getStoryDesc(string name,string proj)
    {

        SqlConnection db = null;

        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                              SELECT IdeaDetail
                              FROM Ideas join ProjectIdeas on ProjectIdeas.IdeaID = Ideas.IdeaID
                              WHERE IdeaName = '{0}' and ProjectIdeas.Proj_ID = {1};
                              ",
                                    name,SQL.getProjectID(proj));

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;

        var id = (string)cmd.ExecuteScalar();

        return id;

    }// end getOwnerID


    static public int getIdeasID(string name)
    {

        SqlConnection db = null;

        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                              SELECT IdeaID
                              FROM Ideas
                              WHERE IdeaName = '{0}';
                              ",
                                    name);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;

        var id = (int)cmd.ExecuteScalar();

        return id;

    }// end getOwnerID


    static public void acceptStory(string projName,string ideaname)
    {
        SqlConnection db = null;
        //SqlTransaction tx = null;


        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database


        string sql = string.Format(@"
                      INSERT INTO
                      ProjectIdeas(Proj_ID, IdeaID)
                      Values('{0}', '{1}');
                      ", SQL.getProjectID(projName),SQL.getIdeasID(ideaname));

        ExecuteActionQuery(db, sql);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;


        db.Close(); // close database connection
    }

    static public void getIdeasFromProject(string name,int proj,ListBox items)
    {

        SqlConnection db = null;

        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                              SELECT *
                              FROM Ideas join ProjectIdeas on Ideas.IdeaID = ProjectIdeas.IdeaID
                              WHERE Proj_ID = '{0}';
                              ",
                                    proj);

           

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        cmd.CommandText = sql;

        adapter.Fill(ds);

        ds.Tables[0].TableName = "Ideas";

        foreach (DataRow row in ds.Tables["Ideas"].Rows)
        {
            //string msg = Convert.ToString(row["IdeaName"]);
            items.Items.Add(row["IdeaName"]);
        }

        db.Close();
    }// end getIdeasFromProject
     

    //method to check if a user is in a project
    static public int isInProject(int uid)
    {
      SqlConnection db = null;
      SqlCommand cmd;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database
      //SqlCommand cmd;
          
      string sql = string.Format(@"
                              SELECT Proj_ID 
                              FROM ProjectMembers 
                              WHERE UID = {0} ", uid);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      string tmp = Convert.ToString(cmd.ExecuteScalar());
      int id = 0;

      if (string.IsNullOrEmpty(tmp))
        return id;
      else
        id = int.Parse(tmp);

      db.Close();

      return id;
    }// end isInProject


    //method to get the position of a user
    static public string getUserPosition(int pid)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("Select * from Positions WHERE PID = {0}", pid);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      DataRow row = dt.Rows[0];

      string position = row["Position"].ToString();
      
      db.Close();

      return position;
    }


        //assign task to ppl
        static public void ExecuteAssignTask(int userid, String task, int sprint)
        {
            SqlConnection db = null;

            try
            {
              db = new SqlConnection(connectionInfo);
              db.Open(); // open connection to database

              String sql = string.Format(@"Update TaskTable  
                                  Set UID = '{0}'
                                  FROM TaskTable 
                                  where TaskTable.Task_ID = '{1}'
                                  and
                                  TaskTable.TaskName = '{2}' ",
                userid, sprint, task //and ProjectMembers.Proj_ID ='{2}'
                //username,SQL.getProjectID(proj)
                                                             );

              ExecuteActionQuery(db, sql);
              //Console.Write("woke");
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

        } //end of change task button


        static public void getUndoneTask(ComboBox teamMembers, String username, string proj)
        {
            //String usersFullName;
            SqlConnection db = null;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();

            try
            {
              db = new SqlConnection(connectionInfo);
              db.Open(); // open connection to database

              String sql = string.Format(@"select * FROM TaskTable 
                                          
                                          where TaskTable.PID ='{0}'
                                          ", SQL.getProjectID(proj));

              cmd.Connection = db;
              cmd.CommandText = sql;

              SqlDataAdapter adapter = new SqlDataAdapter(cmd);

              adapter.Fill(ds);
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

            if (ds != null)
            {
              DataTable dt = ds.Tables["Table"];
              String firstName;

              foreach (DataRow row in dt.Rows)
              {
                firstName = row["TaskName"].ToString();
                //lastName = row["LastName"].ToString();
                // fullname = String.Format(firstName + " " + lastName);

                if (!firstName.Equals(" "))
                {
                  teamMembers.Items.Add(firstName);
                }
              }
            }
      
        }//end of getUndoneTask

        

        static public void getUserTask(ListBox teamMembers, int userid, string proj)
        {
            //String usersFullName;
            SqlConnection db = null;
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
              db = new SqlConnection(connectionInfo);
              db.Open(); // open connection to database

              String sql = string.Format(@"select * FROM TaskTable 
                                  join UserAccounts  on UserAccounts.UID = TaskTable.UID 
                                  TaskTable.UID = '{1}'
", SQL.getProjectID(proj),userid);

              cmd.Connection = db;
              cmd.CommandText = sql;

              SqlDataAdapter adapter = new SqlDataAdapter(cmd);
              adapter.Fill(ds);
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

            if (ds != null)
            {
              DataTable dt = ds.Tables["Table"];
              String firstName;

              foreach (DataRow row in dt.Rows)
              {
                firstName = row["TaskName"].ToString();
                //lastName = row["LastName"].ToString();
                // fullname = String.Format(firstName + " " + lastName);

                if (!firstName.Equals(" "))
                {
                  teamMembers.Items.Add(firstName);
                }
              }
            }

        }//end of getUserTasks


        //method to retrieve the timezones
        static public void getTimeZones(ComboBox timeBox)
        {
          SqlConnection db = null;
          DataSet ds = new DataSet();
          SqlCommand cmd = new SqlCommand();
          
          try
          {
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"SELECT * FROM TimeZones");

            
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }

          if(ds != null)
          {
            DataTable dt = ds.Tables["Table"];
            string timezone = "";

            foreach (DataRow row in dt.Rows)
            {
              timezone = row["Timezone"].ToString();
              timeBox.Items.Add(timezone);
            }
         }

        }//end getTimeZones
        

        //method to get the description of a project
        static public void getProjectDescription(string project_name, TextBox description_box)
        {

          SqlConnection db = null;
          SqlCommand cmd = new SqlCommand();
          DataSet ds = new DataSet();

          try
          {
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"SELECT * FROM Projects WHERE Title = '{0}' ", project_name);

            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }

          if (ds != null)
          {
            DataTable dt = ds.Tables["Table"];
            DataRow row = dt.Rows[0];

            description_box.Text = row["Description"].ToString();
          }

        }//end getProjectDescription



        //method to check if a project name is already taken
        static public Boolean isNameUnique(string name)
        {
          Boolean isTrue = false;
          SqlConnection db = null;
          SqlCommand cmd = new SqlCommand();
          DataSet ds = new DataSet();

          try
          {
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"SELECT * FROM Projects WHERE Title = '{0}' ", name);

            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }

          if (ds != null)
          {
            DataTable dt = ds.Tables["Table"];

            if (dt.Rows.Count == 1)
              isTrue = true;
            
          }

          return isTrue;
        }//end isNameUnique

        static public int getUserID(String firstname, String lastname)
        {
            SqlConnection db = null;
            int id = 0;

            try
            {
                db = new SqlConnection(connectionInfo);
                db.Open(); // open connection to database

                //CHECK IF USERNAME EXISTS
                String sql = string.Format(@"select UID FROM UserAccounts 
                                  
                                  where UserAccounts.FirstName ='{0}'
                                  and UserAccounts.LastName = '{1}'
", firstname, lastname);

                SqlCommand cmd = new SqlCommand(sql, db);

                id = (int)cmd.ExecuteScalar();
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

            return id;
        }// end getOwnerID


        //method to get the id of a comment
        static public DataTable getUserProjectIDs(int userID)
        {
          SqlConnection db = null;

          db = new SqlConnection(connectionInfo);
          db.Open(); // open connection to database

          //CHECK IF USERNAME EXISTS
          string sql = string.Format(@"
                                  SELECT Proj_ID
                                  FROM ProjectMembers
                                  WHERE UID = {0};
                                  ", userID);

          SqlCommand cmd = new SqlCommand();
          cmd.Connection = db;
          cmd.CommandText = sql;

          SqlDataAdapter adapter = new SqlDataAdapter(cmd);
          DataSet ds = new DataSet();
          adapter.Fill(ds);

          DataTable dt = ds.Tables["Table"];

          return dt;
        }// end getUserProjectIDs
    }

}














