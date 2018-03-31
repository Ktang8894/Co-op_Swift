using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Co_Op_Swift
{
  public class Sql
  {
    //credentials and info to connect to Azure database
    public static string ConnectionInfo = ConfigurationManager.AppSettings["ConnectionString"];
    public static SqlConnection Db = new SqlConnection(ConnectionInfo);
    //ExecuteActionQuery
    public static void ExecuteActionQuery(string sql)
    {
      SqlCommand cmd = null;
      try
      {
        cmd = new SqlCommand(sql, Db);
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
    public static bool ExecuteLogin(string username, string userPass)
    {
      SqlConnection db = null;
      DataSet       ds = null;
      var       pass = false;

      try
      {
        db = new SqlConnection(ConnectionInfo);
        db.Open();

        string sql = string.Format("select * FROM UserAccounts where UserName = '{0}' ", username);

        var cmd = new SqlCommand(sql, db);
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
          string password = string.Format("{0}", row["Password"].ToString());

          if (password.Equals(userPass))
            pass = true;
        }
      }
      return pass;
    }// end of ExecuteLogin



    //method that executes a registration query
    public static void ExecuteRegistration(string username, string password, string LastName, string FirstName, string answer)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int QID = 1; //Temp
      int PID = 1; //Temp

      try
      {
        db = new SqlConnection(ConnectionInfo);
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

          ExecuteActionQuery(sql);
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
    public static void ExecutePasswordReset(string username, string password)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(ConnectionInfo);
        db.Open();

        string sql = string.Format(@"Update UserAccounts Set Password = '{0}' where Username = '{1}' ",
        password, username);

        ExecuteActionQuery(sql);
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
    public static int CheckUserExsistence(string username)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int count = 0;

      try
      {
        db = new SqlConnection(ConnectionInfo);
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
    public static int getOwnerUserID(string username)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int id = 0;

      try
      {
        db = new SqlConnection(ConnectionInfo);
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
    public static int getProjectID(int ownerID)
    {
      SqlConnection db = null;
      int id = 0;

      try
      {
        db = new SqlConnection(ConnectionInfo);
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
    public static void ExecuteProjectCreation(int ownerID, string title, string releaseEndDate, int timezoneID,
      string projectStartDate, string description, int isPrivate)
    {
      SqlConnection db = null;

      try
      {
        db = new SqlConnection(ConnectionInfo);
        db.Open(); // open connection to database

        //ADD PROJECT INFO
        string sql = string.Format(@"
                          INSERT INTO
                          Projects(OwnerID, Title, Description, Private, TID)
                          Values({0}, '{1}', '{2}', {3}, {4});
                          ", ownerID, title, description, isPrivate, timezoneID);

        ExecuteActionQuery(sql);
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
      int projID = getProjectID(title);
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

    //    ExecuteActionQuery(sql);
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
    public static void loadUserSecurityQuestion(string username, TextBox textBox)
    {
      SqlConnection db = null;
      SqlCommand    cmd = null;
      DataSet       ds = null;

      try
      {
        db = new SqlConnection(ConnectionInfo);
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
          string pass = string.Format("{0}", row["QID"].ToString());

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
    public static bool checkAnswerWithDatabase(string username, string answer)
    {
      bool         isCorrect = false;
      SqlConnection   db = null;
      SqlCommand      cmd = null;
      DataSet         ds = null;

      try
      {
        db = new SqlConnection(ConnectionInfo);
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
      string pass = string.Format("{0}", row["Answer"].ToString());

      if (pass.Equals(answer))
        isCorrect = true;

      return isCorrect;

    }//end checkAnswerWithDatabase


    //method that fills the listboxes in the 'addMembers' form
    public static DataTable getProjectMembersForAddMembers(int projID)
    {
      SqlConnection db = null;
      SqlCommand    cmd = null;
      DataSet       ds = null;

      try
      {
        db = new SqlConnection(ConnectionInfo);
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
    public static void getMembers(ListBox currentUsers, ListBox teamMembers, string username, bool isCreating, int projID)
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
          curr_name = Sql.getFullName(int.Parse(s["UID"].ToString()));

          if (!curr_name.Equals(prev_name))
          {
            teamMembers.Items.Add(curr_name);
            prev_name = curr_name;
          }

        }
      }

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM UserAccounts");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      string fullname, firstName, lastName;

      foreach (DataRow row in dt.Rows)
      {
        firstName = row["FirstName"].ToString();
        lastName = row["LastName"].ToString();
        fullname = string.Format(firstName + " " + lastName);

        if (!fullname.Equals(" "))
        {
          string userFullname = Sql.getFullName(Sql.getOwnerUserID(username));
          if (fullname.Equals(userFullname))
            teamMembers.Items.Add(fullname);

          currentUsers.Items.Add(fullname);
          //teamMembers.Items.Add(row["UID"].ToString());
        }
      }

      db.Close(); // close database connection


    }//end of getMembers


    //method to get the username of a user
    public static string getUsername(string fullname)
    {
      string[] names = fullname.Split(' ');
      string firstName = names[0];
      string lastName = names[1];
      SqlConnection db = null;


      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
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
      string name = string.Format("{0}", row["UserName"].ToString());
      db.Close();

      return name;

    }//end getUsername


    //method to add user to project
    public static void addUserToProject(int userID, int projID, int position)
    {

      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //ADD PROJECT INFO
      string sql = string.Format(@"
                        INSERT INTO
                        ProjectMembers(Proj_ID, UID,PID)
                        Values({0}, {1}, {2});
                        ", projID, userID,position);

      ExecuteActionQuery(sql);

      db.Close(); // close database connection

    }// end addUserToProject


    //method to get the ID of a project
    public static int getProjectID(string projName)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
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
    public static void removeUserFromProject(int userID, int projID)
    {

      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //ADD PROJECT INFO
      string sql = string.Format(@"
                        DELETE FROM
                        ProjectMembers
                        WHERE Proj_ID = {0} AND UID = {1};
                        ", projID, userID);

      ExecuteActionQuery(sql);

      db.Close(); // close database connection

    }// end removeUserFromProject


    //metod to get the ID of a timezone
    public static int getTimeZoneID(string timezone)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
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
    public static void addTimeZonesToForm(ListBox cp)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM TimeZones");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      string timezone;

      foreach (DataRow row in dt.Rows)
      {
        timezone = row["Timezone"].ToString();
        cp.Items.Add(timezone);
      }

      db.Close(); // close database connection

    }//end addTimeZonesToForm


    public static void getDevelopers(ListBox currentUsers, ListBox teamMembers, string username)
    {
      string usersFullName;
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM UserAccounts as u join Positions as p on u.PID = p.PID where Position = 'Developer' ");

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      string fullname, firstName, lastName;

      foreach (DataRow row in dt.Rows)
      {
        firstName = row["FirstName"].ToString();
        lastName = row["LastName"].ToString();
        fullname = string.Format(firstName + " " + lastName);

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


        public static bool isManager(string username, string projName)
        {
            //check if they are a manager
            SqlConnection db = null;
            SqlCommand cmd;
            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database
            //SqlCommand cmd;
            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"
                                  SELECT Position 
                                  FROM UserAccounts 
                                    INNER JOIN ProjectMembers on ProjectMembers.UID = UserAccounts.UID
                                    INNER JOIN Positions on Positions.PID = ProjectMembers.PID
                                  WHERE UserAccounts.UserName = '{0}'
                                  
                                  
                                  ", username, Sql.getProjectID(projName));
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            string id = (string)cmd.ExecuteScalar();

            db.Close();
            return id.Equals("Manager");

        }


        public static bool isOwner(string username, string proj)
        {
            SqlConnection db = null;
            SqlCommand cmd;
            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database
            //SqlCommand cmd;
            //CHECK IF USERNAME EXISTS
            string sql = string.Format(@"
                                  SELECT Position 
                                  FROM UserAccounts 
                                    INNER JOIN ProjectMembers on ProjectMembers.UID = UserAccounts.UID
                                    INNER JOIN Positions on Positions.PID = ProjectMembers.PID
                                  WHERE UserAccounts.UserName = '{0}'
                                  
                                  
                                  ", username, Sql.getProjectID(proj));
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            string id = (string)cmd.ExecuteScalar();
            db.Close();
            return id.Equals("Project Owner");
        }
        public static void getProjectMembers(ListBox teamMembers, string username, string proj)
    {
            //String usersFullName;
            SqlConnection db = null;

            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database

            string sql;
            SqlCommand cmd;

            sql = string.Format(@"select * FROM UserAccounts 
inner join ProjectMembers  on UserAccounts.UID = ProjectMembers.UID 
where ProjectMembers.Proj_ID ='{0}'", Sql.getProjectID(proj));

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            string fullname, firstName, lastName;

            foreach (DataRow row in dt.Rows)
            {
                firstName = row["FirstName"].ToString();
                lastName = row["LastName"].ToString();
                fullname = string.Format(firstName + " " + lastName);

                if (!fullname.Equals(" "))
                {
                    Console.Write(fullname);
                    teamMembers.Items.Add(fullname);
                }
            }

            db.Close(); // close database connection


        }//end of getProjectMembers


    public static void ExecuteChangePosition(int userid, string role,string proj)
    {
            SqlConnection db = null;

            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database

            string sql;

            sql = string.Format(@"Update Positions  
Set Position = '{0}'
FROM Positions
INNER JOIN ProjectMembers on ProjectMembers.PID = Positions.PID
INNER JOIN UserAccounts on UserAccounts.UID = ProjectMembers.UID
where UserAccounts.UID = '{1}' and ProjectMembers.Proj_ID = {2}

",
              role, userid, Sql.getProjectID(proj) //and ProjectMembers.Proj_ID ='{2}'
                                                     //username,
              );

            ExecuteActionQuery(sql);
            Console.Write("woke");
            db.Close(); // close database connection
        } //end of change role button


        public static void getTasks(ComboBox tasks, string proj_id)
        {
            //String usersFullName;
            SqlConnection db = null;

            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database

            string sql;
            SqlCommand cmd;

            sql = string.Format(@"Select * from TaskTable
INNER JOIN SprintTasks on TaskTable.Task_ID = SprintTasks.Task_ID
INNER JOIN Projects on Projects.TID = SprintTasks.Task_ID
INNER JOIN ProjectSprints on ProjectSprints.SprintID = SprintTasks.SprintID
where ProjectSprints.Proj_ID = {0}
            ", Sql.getProjectID(proj_id));

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            string fulldetail, name, detail;

            foreach (DataRow row in dt.Rows)
            {
                name = row["TaskName"].ToString();
                detail = row["TaskDetail"].ToString();
                //maybe get completeness here?
                fulldetail = string.Format(name + " " + detail);

                if (!fulldetail.Equals(" "))
                {
                    tasks.Items.Add(fulldetail);
                }
            }

            db.Close(); // close database connection


        }//end of getTasks


        public static string getPosition(int username, string projID)
        {
            SqlConnection db = null;

            db = new SqlConnection(ConnectionInfo);
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
                                        username, Sql.getProjectID(projID));
            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables["Table"];
            string firstName = "";

            foreach (DataRow row in dt.Rows)
            {
                firstName = row["Position"].ToString();

            }
            db.Close();
            return firstName;
        }


    //method to get the fullname of a user
    public static string getFullName(int userID)
    {
      //String usersFullName;
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
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

      fullname = string.Format(row["FirstName"].ToString() + " " + row["LastName"].ToString());
      db.Close();

      return fullname;
    }

    public static void getProjectNames(ListBox box)
    { 
      SqlConnection db = null;
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
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


    public static string getProjectName(int project_id)
    {
      SqlConnection db = null;
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
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


    public static void getProjUsers(ListBox box)
    { 
      SqlConnection db = null;
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
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
        box.Items.Add(Sql.getFullName(int.Parse(row["UID"].ToString())) + "----->" + row["Proj_ID"].ToString());
      }
      db.Close();
    }
  
    public static void ExecuteStory(string username,string name, string desc)
    {
        SqlConnection db = null;
        //SqlTransaction tx = null;


        db = new SqlConnection(ConnectionInfo);
        db.Open(); // open connection to database
   

        string sql = string.Format(@"
                      INSERT INTO
                      Ideas(UID, IdeaName, IdeaDetail)
                      Values('{0}', '{1}', '{2}');
                      ", Sql.getOwnerUserID(username), name, desc);

        ExecuteActionQuery(sql);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;
            

        db.Close(); // close database connection

    }// end ExecuteRegistration

    public static void getStories(ListBox currentUsers,  string username, int projID)
    {
        SqlConnection db = null;
            

        db = new SqlConnection(ConnectionInfo);
        db.Open(); // open connection to database

        string sql;
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
        string name;

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

    public static string getStoryDesc(string name,string proj)
    {

        SqlConnection db = null;

        db = new SqlConnection(ConnectionInfo);
        db.Open(); // open connection to database

        //CHECK IF USERNAME EXISTS
        string sql = string.Format(@"
                              SELECT IdeaDetail
                              FROM Ideas join ProjectIdeas on ProjectIdeas.IdeaID = Ideas.IdeaID
                              WHERE IdeaName = '{0}' and ProjectIdeas.Proj_ID = {1};
                              ",
                                    name,Sql.getProjectID(proj));

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;

        var id = (string)cmd.ExecuteScalar();

        return id;

    }// end getOwnerID


    public static int getIdeasID(string name)
    {

        SqlConnection db = null;

        db = new SqlConnection(ConnectionInfo);
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


    public static void acceptStory(string projName,string ideaname)
    {
        SqlConnection db = null;
        //SqlTransaction tx = null;


        db = new SqlConnection(ConnectionInfo);
        db.Open(); // open connection to database


        string sql = string.Format(@"
                      INSERT INTO
                      ProjectIdeas(Proj_ID, IdeaID)
                      Values('{0}', '{1}');
                      ", Sql.getProjectID(projName),Sql.getIdeasID(ideaname));

        ExecuteActionQuery(sql);

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = db;
        cmd.CommandText = sql;


        db.Close(); // close database connection
    }

    public static void getIdeasFromProject(string name,int proj,ListBox items)
    {

        SqlConnection db = null;

        db = new SqlConnection(ConnectionInfo);
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
    public static int isInProject(int uid)
    {
      SqlConnection db = null;
      SqlCommand cmd;
      db = new SqlConnection(ConnectionInfo);
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
    public static string getUserPosition(int pid)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
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
        public static void ExecuteAssignTask(int userid, string task, int sprint)
        {
            SqlConnection db = null;

            try
            {
              db = new SqlConnection(ConnectionInfo);
              db.Open(); // open connection to database

              string sql = string.Format(@"Update TaskTable  
                                  Set UID = '{0}'
                                  FROM TaskTable 
                                  where TaskTable.Task_ID = '{1}'
                                  and
                                  TaskTable.TaskName = '{2}' ",
                userid, sprint, task //and ProjectMembers.Proj_ID ='{2}'
                //username,SQL.getProjectID(proj)
                                                             );

              ExecuteActionQuery(sql);
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


        public static void getUndoneTask(ComboBox teamMembers, string username, string proj)
        {
            //String usersFullName;
            SqlConnection db = null;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();

            try
            {
              db = new SqlConnection(ConnectionInfo);
              db.Open(); // open connection to database

              string sql = string.Format(@"select * FROM TaskTable 
                                          
                                          where TaskTable.PID ='{0}'
                                          ", Sql.getProjectID(proj));

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
              string firstName;

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

        

        public static void getUserTask(ListBox teamMembers, int userid, string proj)
        {
            //String usersFullName;
            SqlConnection db = null;
            SqlCommand cmd = new SqlCommand();
            DataSet ds = new DataSet();

            try
            {
              db = new SqlConnection(ConnectionInfo);
              db.Open(); // open connection to database

              string sql = string.Format(@"select * FROM TaskTable 
                                  join UserAccounts  on UserAccounts.UID = TaskTable.UID 
                                  TaskTable.UID = '{1}'
", Sql.getProjectID(proj),userid);

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
              string firstName;

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
        public static void getTimeZones(ComboBox timeBox)
        {
          SqlConnection db = null;
          DataSet ds = new DataSet();
          SqlCommand cmd = new SqlCommand();
          
          try
          {
            db = new SqlConnection(ConnectionInfo);
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
        public static void getProjectDescription(string project_name, TextBox description_box)
        {

          SqlConnection db = null;
          SqlCommand cmd = new SqlCommand();
          DataSet ds = new DataSet();

          try
          {
            db = new SqlConnection(ConnectionInfo);
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
        public static bool isNameUnique(string name)
        {
          bool isTrue = false;
          SqlConnection db = null;
          SqlCommand cmd = new SqlCommand();
          DataSet ds = new DataSet();

          try
          {
            db = new SqlConnection(ConnectionInfo);
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

        public static int getUserID(string firstname, string lastname)
        {
            SqlConnection db = null;
            int id = 0;

            try
            {
                db = new SqlConnection(ConnectionInfo);
                db.Open(); // open connection to database

                //CHECK IF USERNAME EXISTS
                string sql = string.Format(@"select UID FROM UserAccounts 
                                  
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
        public static DataTable getUserProjectIDs(int userID)
        {
          SqlConnection db = null;

          db = new SqlConnection(ConnectionInfo);
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














