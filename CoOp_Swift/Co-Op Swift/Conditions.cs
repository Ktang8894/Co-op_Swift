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
  class Conditions
  {

    //method that checks if the 'create project form' is answered completely and correctly
    static public Boolean projectFormPasses(String title, String projectStartDate, String releaseEndDate, String timezone, 
                            String description, RadioButton no, RadioButton yes)
    {
      Boolean pass = false;
      Boolean notUnique = SQL.isNameUnique(title);

      // check if all text fields are filled in
      if (title.Equals("") || projectStartDate.Equals("") || releaseEndDate.Equals("") || 
                                                      timezone.Equals("Select Timezone") || (!no.Checked && !yes.Checked))
      {
        MessageBox.Show("Please make sure all fields are filled in.", "Empty Box Error", MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

      }
      else if(notUnique)
      {
         MessageBox.Show("Your project name is already taken. Please choose another name.", "Namer Error", MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      else
        pass = true;

      return pass;

    }//end of projectFormPasses 


    //method that checks if the 'registration form' is answered completely and correctly
    static public Boolean regFormPasses(String firstName, String lastName, String password, String confirmPassword, 
                                                                                                     String answer)
    {
      Boolean accept = false;

      if (password.Equals(confirmPassword) != true)
      {
        MessageBox.Show("Make sure passwords are the same", "Different Passwords", MessageBoxButtons.OK,
MessageBoxIcon.Exclamation,
MessageBoxDefaultButton.Button1);
      }
      else if (firstName.Equals("") || lastName.Equals("") || password.Equals("") || confirmPassword.Equals("")
          || answer.Equals(""))
      {
        MessageBox.Show("Please fill in something for everything", "Empty Text", MessageBoxButtons.OK,
MessageBoxIcon.Exclamation,
MessageBoxDefaultButton.Button1);
      }
      else if (password.Length < 5 || confirmPassword.Length < 5)
      {
        MessageBox.Show("Make sure password is at least 5 characters long", "Password length", MessageBoxButtons.OK,
MessageBoxIcon.Exclamation,
MessageBoxDefaultButton.Button1);
      }
      else
        accept = true;

      return accept;

    }//end of regFormPasses


    //method that checks 'ResetForm2' for correctness and completeness
    static public Boolean resetform2Passes(String password, String confirmPassword)
    {
      Boolean accept = false;

      if (!password.Equals(confirmPassword))
      {
        MessageBox.Show("Make sure passwords are the same", "Different Passwords", MessageBoxButtons.OK,
                                              MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

      }
      else if (password.Length < 5 || confirmPassword.Length < 5)
      {
        MessageBox.Show("Make sure password is at least 5 characters long", "Password length", MessageBoxButtons.OK,
                                                        MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      else
        accept = true;

      return accept;

    }//end of resetform2Passes

  }
}
