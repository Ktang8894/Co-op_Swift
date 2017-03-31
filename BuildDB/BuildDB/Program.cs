//
//  C# Console Application to build the Co-Op Swift Database
//
//  Daniel Doyle [ddoyle]
//  U. of Illinois, Chicago
//  CS 440 | Fall 2016
//  Co-Op Swift Development Project
//
//  LAST EDITED: 11/27/2016 @ 6:26PM
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BuildDB
{
  class Program
  {
    //
    // Main:
    //    This function creates a database connection to our cloud database hosted by Azure and runs an SQL script to build our software's database
    //
    static void Main(string[] args)
    {
      Console.WriteLine();
      Console.WriteLine("** Building Co-Op Swift Database **");
      Console.WriteLine();

      // Initalize login credentials
      string netID    = "ddoyle4";
      string dbName   = "Co-Op Swift";
      string password = "cAtsaref0n";

      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection  db = null;
      SqlTransaction tx = null;

      try
      {
        // Connect to Azure and open a database connection
        db = new SqlConnection(connectionInfo);
        db.Open();
        tx = db.BeginTransaction();

        // Create our query
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

        // Execute the SQL that creates the database
        SqlCommand cmd = new SqlCommand(SQL, db, tx);
        cmd.ExecuteNonQuery();

        // If we get to this point, we connected to Azure and our SQL executed properly, so we commit our changes
        tx.Commit();
      }
      catch (Exception ex)
      {
        // If an exception is thrown, rollback any changes
        Console.WriteLine("** Exception: '{0}'", ex.Message);
        tx.Rollback();
      }
      finally
      {
        // If a successful database connection was made, close it
        if (db != null && db.State == ConnectionState.Open)
          Console.WriteLine("** Closing database connection **");
          db.Close();
      }

    } // Main function
  } // Program class
} // namespace BuildDB
