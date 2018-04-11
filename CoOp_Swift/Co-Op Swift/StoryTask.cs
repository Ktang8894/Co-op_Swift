using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Co_Op_Swift
{
  // StoryTask extends the SQL class
  // this class holds all sql methods for database access having to do with stories and tasks
  public class StoryTask : Sql
  {
    string _creator, _name, _details;


    public StoryTask(DataRow story)
    { 
      _creator = story["Creator"].ToString();
      _name = story["Title"].ToString();
      _details = story["Details"].ToString();
    }


    public static void CreateStory(string creator, string name, string description)
    {

      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //ADD PROJECT INFO
      string sql = string.Format(@"
                        INSERT INTO
                        ProjectStories(Creator, Title, Description)
                        Values({0}, {1}, {2});
                        ", creator, name, description);

      Sql.ExecuteActionQuery(sql);

      db.Close(); // close database connection

    
    }//end createStory


    //Method to take dataRow and create 'story' object to put in List<story> for easy access
    //(this is for the 'ideabox' and 'sprintPlan' forms)
    public static List<StoryTask> GetProjectStories(DataTable t)
    {
      List<StoryTask> stories = new List<StoryTask>();
      StoryTask story;

      foreach (DataRow row in t.Rows)
      {
        story = new StoryTask(row);
        stories.Add(story);
      }

      return stories;

    }//end getStory



    public static void GetTaskName(ListBox currBox, ListBox completedBox, int id)
    { 
      SqlConnection db = null;
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM TaskTable WHERE Task_ID = {0}",id);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      bool isFound;

      foreach (DataRow row in dt.Rows)
      {
        isFound = false;
        if (bool.Parse(row["Completed"].ToString()))
        {
          foreach (string s in completedBox.Items)
          {
            if (s.Equals(row["TaskName"].ToString()))
            {
              isFound = true;
              break;
            }
          }

          if (!isFound)
            completedBox.Items.Add(row["TaskName"].ToString());
        }
        else
        {
          foreach (string s in currBox.Items)
          {
            if (s.Equals(row["TaskName"].ToString()))
            {
              isFound = true;
              break;
            }
          }

          if (!isFound)
            currBox.Items.Add(row["TaskName"].ToString());
        }

      }
      db.Close();

    }//end getTasks

        public static void GetTaskNameForAssign(ComboBox currBox, ListBox completedBox, int id)
        {
            SqlConnection db = null;
            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database

            string sql;
            SqlCommand cmd;

            sql = string.Format("select * FROM TaskTable WHERE Task_ID = {0}", id);

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            bool isFound;

            foreach (DataRow row in dt.Rows)
            {
                isFound = false;
                if (bool.Parse(row["Completed"].ToString()))
                {
                    foreach (string s in completedBox.Items)
                    {
                        if (s.Equals(row["TaskName"].ToString()))
                        {
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                        completedBox.Items.Add(row["TaskName"].ToString());
                }
                else
                {
                    foreach (string s in currBox.Items)
                    {
                        if (s.Equals(row["TaskName"].ToString()))
                        {
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                        currBox.Items.Add(row["TaskName"].ToString());
                }

            }
            db.Close();

        }//end getTasks
        public static void GetTaskNameForUser(ListBox currBox, ListBox completedBox, int userId, int id)
        {
            SqlConnection db = null;
            db = new SqlConnection(ConnectionInfo);
            db.Open(); // open connection to database

            string sql;
            SqlCommand cmd;

            sql = string.Format("select * FROM TaskTable WHERE Task_ID = {0} and UID = {1}", id,userId);

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            bool isFound;

            foreach (DataRow row in dt.Rows)
            {
                isFound = false;
                if (bool.Parse(row["Completed"].ToString()))
                {
                    foreach (string s in completedBox.Items)
                    {
                        if (s.Equals(row["TaskName"].ToString()))
                        {
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                        completedBox.Items.Add(row["TaskName"].ToString());
                }
                else
                {
                    foreach (string s in currBox.Items)
                    {
                        if (s.Equals(row["TaskName"].ToString()))
                        {
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                        currBox.Items.Add(row["TaskName"].ToString());
                }

            }
            db.Close();

        }//end getTasks

        /********this was added on 11/22/2016 by Mike ***********************/
        //method to get all the sprintID's related to a project
        public static DataTable GetProjectSprintIDs(string projName)
    {
      SqlConnection db = null;
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      int projId = Sql.GetProjectId(projName);

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM ProjectSprints WHERE Proj_ID = {0}", projId);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];

      return dt;
    
    }//end getProject_TaskIDs


    /********this was added on 11/26/2016 by Mike ***********************/
    //method to get all the taskID's related to a sprint
    public static DataTable GetProjectTaskIDs(int sprintId)
    {
      SqlConnection db = null;
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM SprintTasks WHERE SprintID = {0}", sprintId);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];

      return dt;

    }//end getProject_TaskIDs


    /********this was added on 11/22/2016 by Mike ***********************/
    //method to insert a comment into the "Comments" table
    public static int InsertComment(int uid, string comment)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql = string.Format(@"
                          INSERT INTO
                          Comments(UID,Comment)
                          Values({0}, '{1}');
                          ", uid, comment);


      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      Sql.ExecuteActionQuery(sql);

      //get id from previous query
      sql =string.Format("select CommentID FROM Comments WHERE Comment = '{0}'",comment);
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();
      db.Close();

      return id;

    }//end insertComment


    /********** this was added on 11/22/2016 by Mike **************/
    //method to get the ID of a task
    public static int GetTaskId(string taskName)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT Task_ID 
                                  FROM TaskTable
                                  WHERE TaskName = '{0}';
                                  ", taskName);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();

      return id;

    }//end getTaskID


    /********this was added on 11/26/2016 by Mike ***********************/
    //method to get developer information related to a task
    public static void GetTaskInfo(string taskName, Panel p1, Panel p2, TextBox d1Name, TextBox d1Email,TextBox d1Pos,
                                                                          TextBox d2Name,TextBox d2Email,TextBox d2Pos)
    {
      //task info fields
      string fullName;
      string email;
      string position;

      SqlConnection db = null;    
      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM TaskTable WHERE TaskName = '{0}' ", taskName);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      int x = 1;

      foreach (DataRow r in dt.Rows)
      {
        int uid = int.Parse(r["UID"].ToString());
        int pid = int.Parse(r["PID"].ToString());

        //get users name from the user id
        fullName = Sql.GetFullName(uid);

        //get the users email from the user id
        email = Sql.GetUsername(fullName);

        //get the users position from the pid
        position = Sql.GetUserPosition(pid);

        if (x == 1)
        {
          d1Name.Text = fullName;
          d1Email.Text = email;
          d1Pos.Text = position;
          p1.Visible = true;
          x++;
        }
        else if(x == 2) //if there is a second developer on this task
        {
          d2Name.Text = fullName;
          d2Email.Text = email;
          d2Pos.Text = position;
          p2.Visible = true;
        }

      }

    }//end getProject_TaskIDs


    /********this was added on 11/22/2016 by Mike ***********************/
    //method to insert a comment into the "TaskComments" table
    public static void InsertTaskComment(int taskId, int commentId)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      string sql = string.Format(@"
                          INSERT INTO
                          TaskComments(Task_ID,CommentID)
                          Values({0}, {1});
                          ", taskId, commentId);


      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      Sql.ExecuteActionQuery(sql);
      db.Close();

    }//end insertComment


    //method to get the id of a comment
    public static DataTable GetCommentId(int taskId)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT CommentID
                                  FROM TaskComments
                                  WHERE Task_ID = {0};
                                  ", taskId);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];

      return dt;
    }// end getCommentID


    //method to find and load a comment into a textbox
    public static void LoadCommentDetail(int userId, DataTable commentIDs, TextBox details)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@" SELECT * FROM Comments WHERE UID = {0}; ", userId);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      int x, y;

      foreach (DataRow r in dt.Rows)
      {
        x = int.Parse(r["CommentID"].ToString());

        foreach (DataRow c in commentIDs.Rows)
        {
          y = int.Parse(c["CommentID"].ToString());

          if (y == x)
          {
            details.Text = r["Comment"].ToString();
            return;
          }
        }
      }

    
    }//end loadCommentDetail


    //method to mark a task as comnplete
    public static void MarkTaskAsComplete(string taskName)
    {
      SqlConnection db = null;
      SqlCommand cmd = new SqlCommand();

      try
      {
        db = new SqlConnection(ConnectionInfo);
        db.Open(); // open connection to database

        string sql = string.Format(@"UPDATE TaskTable SET Completed = 0 WHERE TaskName = '{0}'", taskName);

        cmd.Connection = db;
        cmd.CommandText = sql;

        Sql.ExecuteActionQuery(sql);
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

    }//end mark_task_as_complete


    //method to get the id of a comment
    public static int GetCommenter(int commentId)
    {
      SqlConnection db = null;

      db = new SqlConnection(ConnectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT UID
                                  FROM Comments
                                  WHERE CommentID = {0};
                                  ", commentId);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      DataRow row = dt.Rows[0];
      int uid = int.Parse(row["UID"].ToString());

      return uid;
    }// end getCommentID

  }//end SQL class

}//end namespace
