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
  public partial class addMembers : Form
  {
    //Lists to keep track of added/removed users during each use of the form
    List<string> addedUsernames = new List<string>();
    List<string> removedUsernames = new List<string>();
    CreateProj cp;
    Form d;
    string projectName, userName;
    Boolean isCreating = false;
    List<object> p_info = new List<object>();

    //constructor if coming from project creation
    public addMembers(String username, String projName, Form dash, CreateProj frm, Boolean isTrue, 
                                                                           List<object> proj_info)
    {
      InitializeComponent();
      SQL.getMembers(currentUsers,teamMembers,username,isTrue,1);
      projectName = projName;
      userName = username;
      isCreating = isTrue;
      p_info = proj_info;
      cp = frm;
      d = dash;
    }

    //constructor if coming from any of the menu strips
    public addMembers(string username, string project_name)
    {
      InitializeComponent();
      projectName = project_name;
      userName = username;
      int id = SQL.getProjectID(project_name);
      SQL.getMembers(currentUsers, teamMembers, username,false,id);
    }

    private void teamMembers_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (teamMembers.SelectedItem != null)
      {
        //get username
        String username = SQL.getUsername(teamMembers.SelectedItem.ToString());

        //display username in textbox
        teamateUsername.Text = username;
      }
    }

    private void cancel_button_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void add_button_Click(object sender, EventArgs e)
    {
      //check if list contains anything
      if(removedUsernames.Count > 0)
      {
        //check if username is in list of users to be removed
        foreach (string s in removedUsernames)
        {
          if (s.Equals(usersUsername.Text))
          {
            removedUsernames.Remove(s);
            break;
          }
        }
      }

      // add name to team member listbox
      teamMembers.Items.Add(currentUsers.SelectedItem);

      //add to addMembers list
      String str = usersUsername.Text;
      addedUsernames.Add(str);

      // remove name from current users listbox
      currentUsers.Items.Remove(currentUsers.SelectedItem);

    }

    private void remove_button_Click(object sender, EventArgs e)
    {
      //check if user is trying to remove last person on team
      if(teamMembers.Items.Count - 1 == 0)
      {
        MessageBox.Show("The team must always have one member on it. To empty the team, you need to delete the project.", "Empty Team Error!", 
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
      }
      else 
      {
        //check if list contains anything
        if (addedUsernames.Count > 0)
        {
          //check if username is in list of users to be added
          foreach (string s in addedUsernames)
          {
            if (s.Equals(teamateUsername.Text))
            {
              addedUsernames.Remove(s);
              break;
            }
          }
        }

        // add name to current users listbox
        currentUsers.Items.Add(teamMembers.SelectedItem);

        //add to removedMembers list
        String str = teamateUsername.Text;
        removedUsernames.Add(str);

        // remove name from team member listbox
        teamMembers.Items.Remove(teamMembers.SelectedItem);
      }

    }

        private void finalize_button_Click(object sender, EventArgs e)
        {
          //check if this is initial member additions (i.e. user is creating project)
          if (isCreating)
          {
            //create the project with the given information
            SQL.ExecuteProjectCreation((int)p_info[0], (string)p_info[1], (string)p_info[2], (int)p_info[3],
              (string)p_info[4], (string)p_info[5], (int)p_info[6]);

          }

          //check if user is a manager
          if(SQL.isManager(userName,projectName) || isCreating)
          {
            int uid = 0;

            // add users to project (if any)
            if(addedUsernames.Count > 0)
            {
              //get the ID of the project
              int id = SQL.getProjectID(projectName);

              // add members to projectMembers table                                    
              foreach (string s in addedUsernames)
              {
                uid = SQL.getOwnerUserID(s);
                SQL.addUserToProject(uid,id,2);
              }

            }
          
            //remove users from project (if any)
            if(removedUsernames.Count > 0)
            {
              //get the ID of the project
              int id = SQL.getProjectID(projectName);

              // remove members from projectMembers table                                    
              foreach (string s in removedUsernames)
              {
                uid = SQL.getOwnerUserID(s);
                SQL.removeUserFromProject(uid, id);
              }

            }

            //close appropriate forms depending on how you got to this form(AddMembers)
            if (isCreating)
            {
              Dashboard frm = new Dashboard(userName, projectName);
              frm.Show();
              cp.Close();
              d.Close();
              this.Close();
            }
            else
              this.Close();
          }
          else
          {
            MessageBox.Show("Only managers can add or remove members from their team. ", "PERMISSIONS ERROR", 
                            MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
          }

        }


        private void currentUsers_SelectedIndexChanged(object sender, EventArgs e) 
        {
          if (currentUsers.SelectedItem != null)
          {
            //get username
            String username = SQL.getUsername(currentUsers.SelectedItem.ToString());

            //display username in textbox
            usersUsername.Text = username;
          }
          
        }
        
    }
}
