//  
//  SQL Execution Class:
//
//  Methods in this class take SQL Queries as strings and returns the result
//  depending on which of the three execution methods are used. 
// 
//  
//  TO-DOs (4/28):
//    - Clarify which accessibility level to use for class & methods
//    - Decide if TestConnection() is necessary
//

using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Co_Op_Swift
{
  public class ExecuteSQL
  {
    //  Initialize DB connection info
    static string netID     = "co-op-swift";
    static string dbName    = "Co-op_Swift";
    static string account   = "ktang";
    static string password  = "PublicPass1";

    string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, account, password);

    //
    //  TestConnection: returns true if a database connection can be opened, returns false if not.
    //
    public bool TestConnection ()
    {
      SqlConnection db = new SqlConnection(connectionInfo);
      bool state = false;

      try
      {
        db.Open();
        state = (db.State == ConnectionState.Open);
      }
      catch
      {
        //  Discard. Maybe add an exception Messagebox in case of a failed connection.
      }
      finally
      {
        db.Close();
      }

      return state;
    } 

    //
    //  ExecuteScalarQuery: runs a scalar Select query and returns a single value as an object.
    //
    public object ExecuteScalarQuery (string SQL)
    {
      SqlConnection db = null;
      SqlCommand cmd   = null;
      object value     = null;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        cmd = new SqlCommand(SQL, db);
        value = cmd.ExecuteScalar();
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

      return value;
    }

    //
    //  ExecuteNonScalarQuery: runs Select query returns a temporary data table as a DataSet.
    //
    public DataSet ExecuteNonScalarQuery (string SQL)
    {
      SqlConnection db = null;
      SqlCommand cmd   = null;
      DataSet ds       = null;

      try
      {
        ds = new DataSet();
        db = new SqlConnection(connectionInfo);
        db.Open();

        cmd = new SqlCommand(SQL, db);
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

      return ds;
    }

    //
    //  ExecuteActionQuery: runs an action query (UPDATE, DELETE, INSERT) and returns the number of rows affected.
    //
    public int ExecuteActionQuery(string SQL)
    {
      SqlConnection db = null;
      SqlCommand cmd = null;
      int numRows = 0;

      try
      {
        db = new SqlConnection(connectionInfo);
        db.Open();

        cmd = new SqlCommand(SQL, db);
        numRows = cmd.ExecuteNonQuery();
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

      return numRows;
    }
  }
}
