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
  public partial class Login : Form
  {
    public Login()
    {
      InitializeComponent();
      
    }

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void Form2_Load(object sender, EventArgs e)
    {

    }


    //Login
    private void button1_Click(object sender, EventArgs e)
    {
      String username = textBox1.Text;
      String password = textBox2.Text;          
      Boolean pass;

      if(username.Equals(""))
      {
         MessageBox.Show("User not entered. Please Register or enter a username.", "ERROR", MessageBoxButtons.OK, 
           MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return;
      }

      //execute query to find user and if found the users password to compare with the input password
      pass = SQL.ExecuteLogin(username,password);
      
      if(pass)
      {
        int projID = SQL.isInProject(SQL.getOwnerUserID(username));
        if(projID != 0)
        {
          string projectName = SQL.getProjectName(projID);

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
            Dashboard frm = new Dashboard(username, projectName);
            frm.Show();
            this.Hide();
          }

        }
        else
        {
          FormCollection fc = Application.OpenForms;
          bool FormFound = false;
          foreach (Form frm in fc)
          {
            if (frm.Name == "Main")
            {
              frm.Focus();
              FormFound = true;
              this.Hide();
            }
          }

          if (FormFound == false)
          {
            Dashboard frm = new Dashboard(username,"");
            frm.Show();
            this.Hide();
          }
        }
      }
      else 
      {
        MessageBox.Show("Password doesn't match the one on record.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
  MessageBoxDefaultButton.Button1);

        return;
      }

    }


     //Register
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
          form.ShowDialog();
        }


      }

      //reset password
      private void button3_Click(object sender, EventArgs e)
      {

        string UserName = textBox1.Text;
        int count = SQL.CheckUserExsistence(UserName);

        //If username does not exist
        if (count == 0)
        {
          System.Windows.Forms.MessageBox.Show("Email/Username does not exist");
        }
        else
        {
          if (textBox1.Text.Equals(""))
          {
            MessageBox.Show("User Not Found. Please enter a username.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
  MessageBoxDefaultButton.Button1);
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
              String username = textBox1.Text;

              ResetForm1 form = new ResetForm1(username);
              form.ShowDialog();
            }
          }
        }
            
      }// end button3_Click


      //method to override the 'x' button on top right corner of form
      protected override void OnFormClosing(FormClosingEventArgs e)
      {

        Application.Exit();

      } // end of OnFormClosing

    }
}
