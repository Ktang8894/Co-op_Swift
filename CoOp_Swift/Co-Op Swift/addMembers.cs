using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Co_Op_Swift
{
  public partial class AddMembers : Form
  {
    //Lists to keep track of added/removed users during each use of the form
    List<string> _addedUsernames = new List<string>();
    List<string> _removedUsernames = new List<string>();
    CreateProj _cp;
    Form _d;
    string _projectName, _userName;
    bool _isCreating = false;
    List<object> _pInfo = new List<object>();

    //constructor if coming from project creation
    public AddMembers(string username, string projName, Form dash, CreateProj frm, bool isTrue, 
                                                                           List<object> projInfo)
    {
      InitializeComponent();
      Sql.GetMembers(currentUsers,teamMembers,username,isTrue,1);
      _projectName = projName;
      _userName = username;
      _isCreating = isTrue;
      _pInfo = projInfo;
      _cp = frm;
      _d = dash;
    }

    //constructor if coming from any of the menu strips
    public AddMembers(string username, string projectName)
    {
      InitializeComponent();
      _projectName = projectName;
      _userName = username;
      int id = Sql.GetProjectId(projectName);
      Sql.GetMembers(currentUsers, teamMembers, username,false,id);
    }

    private void TeamMembersSelectedIndexChanged(object sender, EventArgs e)
    {
      if (teamMembers.SelectedItem != null)
      {
        //get username
        string username = Sql.GetUsername(teamMembers.SelectedItem.ToString());

        //display username in textbox
        teamateUsername.Text = username;
      }
    }

    private void CancelButtonClick(object sender, EventArgs e)
    {
      this.Close();
    }

    private void AddButtonClick(object sender, EventArgs e)
    {
      //check if list contains anything
      if(_removedUsernames.Count > 0)
      {
        //check if username is in list of users to be removed
        foreach (string s in _removedUsernames)
        {
          if (s.Equals(usersUsername.Text))
          {
            _removedUsernames.Remove(s);
            break;
          }
        }
      }

      // add name to team member listbox
      teamMembers.Items.Add(currentUsers.SelectedItem);

      //add to addMembers list
      string str = usersUsername.Text;
      _addedUsernames.Add(str);

      // remove name from current users listbox
      currentUsers.Items.Remove(currentUsers.SelectedItem);

    }

    private void RemoveButtonClick(object sender, EventArgs e)
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
        if (_addedUsernames.Count > 0)
        {
          //check if username is in list of users to be added
          foreach (string s in _addedUsernames)
          {
            if (s.Equals(teamateUsername.Text))
            {
              _addedUsernames.Remove(s);
              break;
            }
          }
        }

        // add name to current users listbox
        currentUsers.Items.Add(teamMembers.SelectedItem);

        //add to removedMembers list
        string str = teamateUsername.Text;
        _removedUsernames.Add(str);

        // remove name from team member listbox
        teamMembers.Items.Remove(teamMembers.SelectedItem);
      }

    }

        private void FinalizeButtonClick(object sender, EventArgs e)
        {
          //check if this is initial member additions (i.e. user is creating project)
          if (_isCreating)
          {
            //create the project with the given information
            Sql.ExecuteProjectCreation((int)_pInfo[0], (string)_pInfo[1], (string)_pInfo[2], (int)_pInfo[3],
              (string)_pInfo[4], (string)_pInfo[5], (int)_pInfo[6]);

          }

          //check if user is a manager
          if(Sql.IsManager(_userName,_projectName) || _isCreating)
          {
            int uid = 0;

            // add users to project (if any)
            if(_addedUsernames.Count > 0)
            {
              //get the ID of the project
              int id = Sql.GetProjectId(_projectName);

              // add members to projectMembers table                                    
              foreach (string s in _addedUsernames)
              {
                uid = Sql.GetOwnerUserId(s);
                Sql.AddUserToProject(uid,id,2);
              }

            }
          
            //remove users from project (if any)
            if(_removedUsernames.Count > 0)
            {
              //get the ID of the project
              int id = Sql.GetProjectId(_projectName);

              // remove members from projectMembers table                                    
              foreach (string s in _removedUsernames)
              {
                uid = Sql.GetOwnerUserId(s);
                Sql.RemoveUserFromProject(uid, id);
              }

            }

            //close appropriate forms depending on how you got to this form(AddMembers)
            if (_isCreating)
            {
              Dashboard frm = new Dashboard(_userName, _projectName);
              frm.Show();
              _cp.Close();
              _d.Close();
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


        private void CurrentUsersSelectedIndexChanged(object sender, EventArgs e) 
        {
          if (currentUsers.SelectedItem != null)
          {
            //get username
            string username = Sql.GetUsername(currentUsers.SelectedItem.ToString());

            //display username in textbox
            usersUsername.Text = username;
          }
          
        }
        
    }
}
