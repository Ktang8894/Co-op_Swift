//
//  C# Console Application to build the Co-Op Swift Database
//
//  Co-Op Swift Development Project
//
//  LAST EDITED: 4/28/2017
//
//  TO-DO:
//    - Update Azure account connection information.
//


using System;
using System.Data;
using System.Data.SqlClient;

namespace BuildDB
{
  class Program
  {
    // Initalize login credentials
    static string netID = "ddoyle4";
    static string dbName = "Co-Op Swift";
    static string password = "cAtsaref0n";

    static string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);


    //
    //  Main: runs the basic UI for managing the Co-Op Swift database building and deletion functionalities.
    //
    static void Main(string[] args)
    {
      bool menu = true;
      string input;

      Console.WriteLine();
      Console.WriteLine("** Welcome to the Co-Op Swift Database Manager **");
      Console.WriteLine();

      while (menu)
      {
        Console.WriteLine("1: Delete database");
        Console.WriteLine("2: Initialize database");
        Console.WriteLine("3: Rebuild database");
        Console.WriteLine("4: Help Menu");
        Console.WriteLine("5: Quit");
        Console.WriteLine();

        Console.Write("> ");
        input = Console.ReadLine();

        if (input == "1")
        {
          Console.WriteLine();
          Console.WriteLine("... Deleting database ...");
          DropTables();
          Console.WriteLine("... Database successfully deleted ...");
          Console.WriteLine();
        }
        else if (input == "2")
        {
          Console.WriteLine();
          Console.WriteLine("... Initializing database ...");
          CreateTables();
          Console.WriteLine("... Database successfully created ...");
          Console.WriteLine();
        }
        else if (input == "3")
        {
          Console.WriteLine();
          Console.WriteLine("... Refreshing database ...");
          DropTables();
          Console.WriteLine("... Tables deleted ...");
          CreateTables();
          Console.WriteLine("... Tables re-created ...");
          Console.WriteLine("... Database successfully rebuilt ...");
          Console.WriteLine();
        }
        else if (input == "4")
        {
          Console.WriteLine("Option 1: deletes all tables in the database");
          Console.WriteLine("Option 2: creates all tables in the database and inserts starting data");
          Console.WriteLine("Option 3: refreshes database by dropping all tables, then re-initializes them");
          Console.WriteLine();
        }
        else if (input == "5")
        {
          menu = false;
        }
        else
        {
          Console.WriteLine("Not valid input");
          Console.WriteLine();
        }
      }

      Console.WriteLine();
      Console.WriteLine("** Exiting Co-Op Swift Database Manager");
      Console.WriteLine();
      return;
    } 

    //
    //  DropTables: helper function that deletes all the tables (and data) in the database.
    //
    private static void DropTables ()
    {
      SqlConnection   db = null;
      SqlTransaction  tx = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        tx = db.BeginTransaction();

        string SQL = string.Format(@"
          DROP TABLE ProjectMembers
          DROP TABLE ProjectIdeas
          DROP TABLE SprintTasks  
          DROP TABLE TaskComments
          DROP TABLE ProjectSprints

          DROP TABLE Ideas
          DROP TABLE Comments
          DROP TABLE TaskTable
          DROP TABLE Projects   
          DROP TABLE UserAccounts
          DROP TABLE Sprints

          DROP TABLE Questions
          DROP TABLE Positions
          DROP TABLE TimeZones
          DROP TABLE Colors 
        ");

        SqlCommand cmd = new SqlCommand(SQL, db, tx);
        cmd.ExecuteNonQuery();
        tx.Commit();
      }
      catch (Exception ex)
      {
        Console.WriteLine("** Exception: '{0}'", ex.Message);
        tx.Rollback();
      }
      finally
      {
        if (db != null && db.State == ConnectionState.Open)
          db.Close();
      }
    }

    //
    //  CreateTables: helper function that builds the database and initializes the basic data needed for Co-Op Swift to function properly.
    //
    private static void CreateTables ()
    {
      SqlConnection db = null;
      SqlTransaction tx = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        tx = db.BeginTransaction();

        string SQL = string.Format(@"
          CREATE TABLE Questions (
            QID       INT IDENTITY(1, 1) PRIMARY KEY,
            Question  NVARCHAR(512) NOT NULL
          );

          CREATE TABLE Positions (
            PID       INT IDENTITY(1, 1) PRIMARY KEY,
            Position  NVARCHAR(128) NOT NULL
          );

          CREATE TABLE TimeZones (
            TID       INT IDENTITY(1, 1) PRIMARY KEY,
            Timezone  NVARCHAR(64) NOT NULL
          );

          CREATE TABLE Colors (
            CID       INT IDENTITY(1, 1) PRIMARY KEY,
            Color     NVARCHAR(64) NOT NULL
          );


          CREATE TABLE UserAccounts (
            UID       INT IDENTITY(1000, 1) PRIMARY KEY,
            UserName  NVARCHAR(64) NOT NULL,
            Password  NVARCHAR(64) NOT NULL,
            LastName  NVARCHAR(64) NOT NULL,
            FirstName NVARCHAR(64) NOT NULL,
            QID       INT NOT NULL FOREIGN KEY REFERENCES Questions(QID),
            Answer    NVARCHAR(64) NOT NULL,
            PID       INT NOT NULL FOREIGN KEY REFERENCES Positions(PID)
          );

          CREATE TABLE Projects (
            Proj_ID       INT IDENTITY(1, 1) PRIMARY KEY,
            OwnerID       INT NOT NULL FOREIGN KEY REFERENCES UserAccounts(UID),
            Title         NVARCHAR(256) NOT NULL,
            Description   NVARCHAR(1024) NOT NULL,
            Private       BIT NOT NULL,
            TID           INT NOT NULL FOREIGN KEY REFERENCES TimeZones(TID)      
          );

          CREATE TABLE Ideas (
            IdeaID      INT IDENTITY (1, 1) PRIMARY KEY,
            UID         INT NOT NULL FOREIGN KEY REFERENCES UserAccounts(UID),
            CID         INT FOREIGN KEY REFERENCES Colors(CID),
            IdeaName    NVARCHAR(128) NOT NULL,
            IdeaDetail  NVARCHAR(256)
          );


          CREATE TABLE TaskTable (
            Task_ID       INT IDENTITY(1, 1) PRIMARY KEY,
            UID           INT NOT NULL FOREIGN KEY REFERENCES UserAccounts(UID),
            PID           INT NOT NULL FOREIGN KEY REFERENCES Positions(PID),
            TaskName      NVARCHAR(64) NOT NULL,
            TaskDetail    NVARCHAR(256),
            Completed     BIT NOT NULL
          );

          CREATE TABLE Comments (
            CommentID   INT IDENTITY(1000, 1) PRIMARY KEY,
            UID         INT NOT NULL FOREIGN KEY REFERENCES UserAccounts(UID),
            Comment     NVARCHAR(1024) NOT NULL
          );

          CREATE TABLE Sprints (
            SprintID    INT IDENTITY(1, 1) PRIMARY KEY,
            StartDate   DATE NOT NULL,
            EndDate     DATE NOT NULL,
          );


          CREATE TABLE ProjectMembers (
            Proj_ID   INT NOT NULL FOREIGN KEY REFERENCES Projects(Proj_ID),
            UID       INT NOT NULL FOREIGN KEY REFERENCES UserAccounts(UID), 
            PID       INT NOT NULL FOREIGN KEY REFERENCES Positions(PID)
          );

          CREATE TABLE ProjectIdeas (
            Proj_ID     INT NOT NULL FOREIGN KEY REFERENCES Projects (Proj_ID),
            IdeaID      INT NOT NULL FOREIGN KEY REFERENCES Ideas (IdeaID)
          );

          CREATE TABLE SprintTasks (
            SprintID   INT NOT NULL FOREIGN KEY REFERENCES Sprints(SprintID),
            Task_ID   INT NOT NULL FOREIGN KEY REFERENCES TaskTable (Task_ID)
          );

          CREATE TABLE ProjectSprints (
            Proj_ID   INT NOT NULL FOREIGN KEY REFERENCES Projects(Proj_ID),
            SprintID  INT NOT NULL FOREIGN KEY REFERENCES Sprints(SprintID)
          );

          CREATE TABLE TaskComments (
            Task_ID     INT NOT NULL FOREIGN KEY REFERENCES TaskTable(Task_ID),
            CommentID   INT NOT NULL FOREIGN KEY REFERENCES Comments(CommentID)
          );


          /********************************/
          /*                              */
          /* Available Security Questions */
          /*                              */
          /********************************/
          
          INSERT INTO Questions (Question)
          VALUES ('What is the name of your elementary/primary school?');

          INSERT INTO Questions (Question)
          VALUES ('What is the name of the first person you kissed?');

          INSERT INTO Questions (Question)
          VALUES ('What time of day were you born?');

          INSERT INTO Questions (Question)
          VALUES ('In what city or town does your nearest sibling live?');


          /***********************/
          /*                     */
          /* Available Positions */
          /*                     */
          /***********************/

          INSERT INTO Positions (Position)
          VALUES ('Developer');

          INSERT INTO Positions (Position)
          VALUES ('Manager');

          INSERT INTO Positions (Position)
          VALUES ('Client');

          INSERT INTO Positions (Position)
          VALUES ('Project Owner');


          /***********************/
          /*                     */
          /* Available Timezones */
          /*                     */
          /***********************/

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-11: Samoa Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-10: Hawaii-Aleutian Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-9: Alaska Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-8: Pacific Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-7: Mountain Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-6: Central Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-5: Eastern Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC-4: Atlantic Standard Time');

          INSERT INTO TimeZones (Timezone)
          VALUES ('UTC+10: Chamorro Standard Time'); 
        ");

        SqlCommand cmd = new SqlCommand(SQL, db, tx);
        cmd.ExecuteNonQuery();
        tx.Commit();
      }
      catch (Exception ex)
      {
        Console.WriteLine("** Exception: '{0}'", ex.Message);
        tx.Rollback();
      }
      finally
      {
        if (db != null && db.State == ConnectionState.Open)
          db.Close();
      }
    } // CreateTables

  } // Program class
} // namespace BuildDB
