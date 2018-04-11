using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Co_Op_Swift
{
  public partial class IdeaBox : Form
  {
    string _userName, _pn;
    public IdeaBox(string username, string projectName)
    {
        InitializeComponent();
        Sql.GetStories(storyLB, username, Sql.GetProjectId(projectName));
        projectNameToolStripMenuItem.Text = projectName;
        _pn = projectName;
        _userName = username;
        memberNameToolStripMenuItem.Text = username;
        ideaBoxToolStripMenuItem.Font = new Font(ideaBoxToolStripMenuItem.Font, FontStyle.Bold);

        /***************************** this is for select a project drop down menu **********************************/

        //get all project ids associated with the user ids
        DataTable projIds = Sql.GetUserProjectIDs(Sql.GetOwnerUserId(memberNameToolStripMenuItem.Text));

        string projName;

        // get all project names associated with the project ids
        foreach (DataRow row in projIds.Rows)
        {
          //put project names in select project drop down menu
          projName = Sql.GetProjectName(int.Parse(row["Proj_ID"].ToString()));
          selectProjectToolStripMenuItem.DropDownItems.Add(projName);
        }
      /*************************************************************************************************************/
    
    }


    private void DashboardToolStripMenuItemClick(object sender, EventArgs e)
    {
      Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void TaskTreeToolStripMenuItemClick(object sender, EventArgs e)
    {
      TaskTree frm = new TaskTree(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void ReleasePlanToolStripMenuItemClick(object sender, EventArgs e)
    {
      ReleasePlan frm = new ReleasePlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void SprintPlanToolStripMenuItemClick(object sender, EventArgs e)
    {
      SprintPlan frm = new SprintPlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void LogoutToolStripMenuItemClick(object sender, EventArgs e)
    {
      Login frm2 = new Login();
      frm2.Show();
      this.Close();
    }

    private void TeamToolStripMenuItemClick(object sender, EventArgs e)
    {
      AddMembers frm = new AddMembers(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
    }

        

        private void IdeaBoxLoad(object sender, EventArgs e)
        {

        }

        private void RightClickMenuStripOpening(object sender, CancelEventArgs e)
        {

        }

        private void IdeaBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //do something
            }
            if (e.Button == MouseButtons.Right)
            {
                rightClickMenuStrip.Show(this, new Point(e.X, e.Y));
                //Console.Write("work");
            }
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            /*
            TextBox lb = new TextBox();
            lb.Width = 75;
            lb.Height = 150;
            lb.Multiline = true;
            lb.Location = this.PointToClient(Cursor.Position);
            this.Controls.Add(lb);
            */
            Story frm = new Story(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
            frm.Show();

        }

        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = storyLB.GetItemText(storyLB.SelectedItem);
            descTB.Text = Sql.GetStoryDesc(name, _pn);
        }

        private void Button1Click(object sender, EventArgs e)
        {
            //does stuff to send it to the sprint plan.
            string name = storyLB.GetItemText(storyLB.SelectedItem);
            Sql.AcceptStory(projectNameToolStripMenuItem.Text, name);
        }

        private void RefreshButtonClick(object sender, EventArgs e)
        {
            storyLB.Items.Clear();
            Sql.GetStories(storyLB, _userName, Sql.GetProjectId(_pn));

        }

        private void AssignRolesToolStripMenuItemClick(object sender, EventArgs e)
        {
            if (!Sql.IsOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
            {

                MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
            else
            {
                AssignRole frm = new AssignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
                frm.Show();
            }
        }

        private void AssignTasksToolStripMenuItemClick(object sender, EventArgs e)
        {
            AssignTask frm = new AssignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
            frm.Show();
        }

    private void Button1Click1(object sender, EventArgs e)
    {
      Story frm = new Story(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();

    }

    private void SelectProjectToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          //get the name of the drop down item that was clicked
          string projName = e.ClickedItem.ToString();

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
            Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, projName);
            frm.Show();
            this.Hide();
          }
        }
    }
}
