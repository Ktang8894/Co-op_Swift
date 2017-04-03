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
  public partial class Form2 : Form
  {
    public Form2()
    {
      InitializeComponent();
      
    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void Form2_Load(object sender, EventArgs e)
    {

    }


    private void button1_Click(object sender, EventArgs e)
    {
      String username = textBox1.Text;
      String password = textBox2.Text;

      /******************************Access and use of database************************************************************/
      string filename, version, connectionInfo;
      SqlConnection db;

      version = "v11.0";
      filename = "Accounts.mdf";

      connectionInfo = String.Format(@"Data Source=(LocalDB)\{0};AttachDbfilename
      =|DataDirectory|\{1};Integrated Security=True;", version, filename);


      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      String sql;
      SqlCommand cmd;

      sql = string.Format("select * FROM users where username = '{0}' ", username);

      cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;

      SqlDataAdapter adapter = new SqlDataAdapter(cmd);
      DataSet ds = new DataSet();
      adapter.Fill(ds);

      DataTable dt = ds.Tables["Table"];

      if (dt.Rows.Count == 0)
      {
        MessageBox.Show("User Not Found. Please Register or choose different username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button1);
        return;

      }
      else
      {
        DataRow row = dt.Rows[0];
        String pass = string.Format("{0}",row["password"].ToString());

        db.Close(); // close database connection

        /*******************************************************************************************************************/

        if (password.Equals(pass))
        {
          
          FormCollection fc = Application.OpenForms;
          bool FormFound = false;
          foreach (Form frm in fc)
          {
            if (frm.Name == "Form1")
            {
              frm.Focus();
              FormFound = true;
              this.Hide();
            }
          }

          if (FormFound == false)
          {
            Form1 frm = new Form1(username);
            frm.Show();
            this.Hide();
          }

        }
        else 
        {
          MessageBox.Show("Password doesn't match the one on record.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
    MessageBoxDefaultButton.Button1);

          return;
        }
      }

    }


    private void button4_Click(object sender, EventArgs e)
    {
      Application.Exit();
    }

        private void button2_Click(object sender, EventArgs e)
        {
          FormCollection fc = Application.OpenForms;
          bool FormFound = false;
          foreach (Form frm in fc)
          {
            if (frm.Name == "RegForm")
            {
              frm.Focus();
              FormFound = true;
              this.Hide();
            }
          }

          if (FormFound == false)
          {
            RegForm form = new RegForm();
            form.Show();
            this.Hide();
          }


        }

        private void button3_Click(object sender, EventArgs e)
        {

      /******************************Access and use of database************************************************************/

      // Initalize login credentials
      string netID = "ddoyle4";
      string dbName = "Co-Op Swift";
      string password = "cAtsaref0n";

      string connectionInfo = String.Format(@"
      Server=tcp:{0}.database.windows.net,1433;Initial Catalog={1};Persist Security Info=False;User ID={2};Password={3};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
      ", netID, dbName, netID, password);

      SqlConnection db = null;
      
      db = new SqlConnection(connectionInfo);
      db.Open(); // open connection to database

      string UserName = textBox1.Text;

      //CHECK IF USERNAME EXISTS
      string sql = string.Format(@"
SELECT COUNT(*) 
FROM UserAccounts
WHERE UserName = '{0}';
",
UserName);

      SqlCommand cmd = new SqlCommand();
      cmd.Connection = db;
      cmd.CommandText = sql;
      int count = (int)cmd.ExecuteScalar();

      //If username does not exist
      if (count == 0)
      {
        System.Windows.Forms.MessageBox.Show("Email/Username already exists");
      }

      else
      {
        FormCollection fc = Application.OpenForms;
        bool FormFound = false;
        foreach (Form frm in fc)
        {
          if (frm.Name == "ResetForm1")
          {
            frm.Focus();
            FormFound = true;
            this.Hide();
          }
        }

        if (FormFound == false)
        {
          ResetForm1 form = new ResetForm1("asd123");
          form.Show();
          this.Hide();
        }
      }
      db.Close();
     } 

    }
}
