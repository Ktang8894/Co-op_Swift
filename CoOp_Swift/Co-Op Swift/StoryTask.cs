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
  // StoryTask extends the SQL class
  // this class holds all sql methods for database access having to do with stories and tasks
  public class StoryTask : SQL
  {
    string creator, name, details;


    public StoryTask(DataRow story)
    { 
      creator = story["Creator"].ToString();
      name = story["Title"].ToString();
      details = story["Details"].ToString();
    }


    static public void createStory(string creator, string name, string description)
    {

      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //ADD PROJECT INFO
      string sql = string.Format(@"
                        INSERT INTO
                        ProjectStories(Creator, Title, Description)
                        Values({0}, {1}, {2});
                        ", creator, name, description);

      ExecuteActionQuery(db, sql);

      db.Close(); // close database connection

    
    }//end createStory


    //Method to take dataRow and create 'story' object to put in List<story> for easy access
    //(this is for the 'ideabox' and 'sprintPlan' forms)
    static public List<StoryTask> getProjectStories(DataTable t)
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



    static public void getTaskName(ListBox currBox, ListBox completedBox, int id)
    { 
      SqlConnection db = null;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM TaskTable WHERE Task_ID = {0}",id);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];
      Boolean isFound;

      foreach (DataRow row in dt.Rows)
      {
        isFound = false;
        if (Boolean.Parse(row["Completed"].ToString()))
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

        static public void getTaskNameForAssign(ComboBox currBox, ListBox completedBox, int id)
        {
            SqlConnection db = null;
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            String sql;
            SqlCommand cmd;

            sql = string.Format("select * FROM TaskTable WHERE Task_ID = {0}", id);

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            Boolean isFound;

            foreach (DataRow row in dt.Rows)
            {
                isFound = false;
                if (Boolean.Parse(row["Completed"].ToString()))
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
        static public void getTaskNameForUser(ListBox currBox, ListBox completedBox, int userID, int id)
        {
            SqlConnection db = null;
            db = new SqlConnection(connectionInfo);
            db.Open(); // open connection to database

            String sql;
            SqlCommand cmd;

            sql = string.Format("select * FROM TaskTable WHERE Task_ID = {0} and UID = {1}", id,userID);

            cmd = new SqlCommand();
            cmd.Connection = db;
            cmd.CommandText = sql;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            DataTable dt = ds.Tables["Table"];
            Boolean isFound;

            foreach (DataRow row in dt.Rows)
            {
                isFound = false;
                if (Boolean.Parse(row["Completed"].ToString()))
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
        static public DataTable getProject_sprintIDs(string projName)
    {
      SqlConnection db = null;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      int projID = SQL.getProjectID(projName);

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM ProjectSprints WHERE Proj_ID = {0}", projID);

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
    static public DataTable getProject_taskIDs(int sprintID)
    {
      SqlConnection db = null;
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM SprintTasks WHERE SprintID = {0}", sprintID);

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
    static public int insertComment(int uid, string comment)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      string sql = string.Format(@"
                          INSERT INTO
                          Comments(UID,Comment)
                          Values({0}, '{1}');
                          ", uid, comment);


      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      ExecuteActionQuery(db, sql);

      //get id from previous query
      sql =string.Format("select CommentID FROM Comments WHERE Comment = '{0}'",comment);
      cmd.CommandText = sql;

      int id = (int)cmd.ExecuteScalar();
      db.Close();

      return id;

    }//end insertComment


    /********** this was added on 11/22/2016 by Mike **************/
    //method to get the ID of a task
    static public int getTaskID(string taskName)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
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
    static public void getTaskInfo(string taskName, Panel p1, Panel p2, TextBox d1_name, TextBox d1_email,TextBox d1_pos,
                                                                          TextBox d2_name,TextBox d2_email,TextBox d2_pos)
    {
      //task info fields
      string full_name;
      string email;
      string position;

      SqlConnection db = null;    
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
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
        full_name = SQL.getFullName(uid);

        //get the users email from the user id
        email = SQL.getUsername(full_name);

        //get the users position from the pid
        position = SQL.getUserPosition(pid);

        if (x == 1)
        {
          d1_name.Text = full_name;
          d1_email.Text = email;
          d1_pos.Text = position;
          p1.Visible = true;
          x++;
        }
        else if(x == 2) //if there is a second developer on this task
        {
          d2_name.Text = full_name;
          d2_email.Text = email;
          d2_pos.Text = position;
          p2.Visible = true;
        }

      }

    }//end getProject_TaskIDs


    /********this was added on 11/22/2016 by Mike ***********************/
    //method to insert a comment into the "TaskComments" table
    static public void insertTaskComment(int task_id, int comment_id)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      string sql = string.Format(@"
                          INSERT INTO
                          TaskComments(Task_ID,CommentID)
                          Values({0}, {1});
                          ", task_id, comment_id);


      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      ExecuteActionQuery(db, sql);
      db.Close();

    }//end insertComment


    //method to get the id of a comment
    static public DataTable getCommentID(int task_id)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT CommentID
                                  FROM TaskComments
                                  WHERE Task_ID = {0};
                                  ", task_id);

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
    static public void loadCommentDetail(int userID, DataTable comment_IDs, TextBox details)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@" SELECT * FROM Comments WHERE UID = {0}; ", userID);

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

        foreach (DataRow c in comment_IDs.Rows)
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
    static public void mark_task_as_complete(string task_name)
    {
      SqlConnection db = null;
      SqlCommand cmd = new SqlCommand();

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open(); // open connection to database

        string sql = string.Format(@"UPDATE TaskTable SET Completed = 0 WHERE TaskName = '{0}'", task_name);

        cmd.Connection = db;
        cmd.CommandText = sql;

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

    }//end mark_task_as_complete


    //method to get the id of a comment
    static public int getCommenter(int comment_id)
    {
      SqlConnection db = null;

      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
                                  SELECT UID
                                  FROM Comments
                                  WHERE CommentID = {0};
                                  ", comment_id);

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
