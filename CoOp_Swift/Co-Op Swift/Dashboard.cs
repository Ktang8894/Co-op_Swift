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
  public partial class Dashboard : Form
  {
    public Dashboard(string username, string projectName)
    {
      InitializeComponent();

      memberNameToolStripMenuItem.Text = username;

      if (projectName.Length >= 1)
      {
        projectNameToolStripMenuItem.Text = projectName;
        dashboardToolStripMenuItem.Visible = true;
        dashboardToolStripMenuItem.Font = new Font(dashboardToolStripMenuItem.Font,FontStyle.Bold);
        ideaBoxToolStripMenuItem.Visible = true;
        releasePlanToolStripMenuItem.Visible = true;
        sprintPlanToolStripMenuItem.Visible = true;
        taskTreeToolStripMenuItem.Visible = true;
        assignRolesToolStripMenuItem.Visible = true;
        assignTasksToolStripMenuItem.Visible = true;
        inviteMembersToolStripMenuItem.Visible = true;

        projectDescriptionEditButton.Visible = true;
        projectDescriptionLabel.Visible = true;
        projectDescriptionTB.Visible = true;
        releaseButton.Visible = true;
        releaseLabel.Visible = true;
        releaseTextBox.Visible = true;
        doneButton.Visible = true;
        doneLabel.Visible = true;
        doneTextBox.Visible = true;
        activitiesTextBox.Visible = true;
        activityLabel.Visible = true;
        noProject.Visible = false;


        //get the project description for the user's project
        Sql.GetProjectDescription(projectName, projectDescriptionTB);

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
      else
      {
        dashboardToolStripMenuItem.Visible = false;
        ideaBoxToolStripMenuItem.Visible = false;
        releasePlanToolStripMenuItem.Visible = false;
        sprintPlanToolStripMenuItem.Visible = false;
        taskTreeToolStripMenuItem.Visible = false;
        assignRolesToolStripMenuItem.Visible = false;
        assignTasksToolStripMenuItem.Visible = false;
        inviteMembersToolStripMenuItem.Visible = false;

        projectDescriptionEditButton.Visible = false;
        projectDescriptionLabel.Visible = false;
        projectDescriptionTB.Visible = false;
        releaseButton.Visible = false;
        releaseLabel.Visible = false;
        releaseTextBox.Visible = false;
        doneButton.Visible = false;
        doneLabel.Visible = false;
        doneTextBox.Visible = false;
        activitiesTextBox.Visible = false;
        activityLabel.Visible = false;
        noProject.Visible = true;
      }
   
    }

    private void Form1Load(object sender, EventArgs e)
    {
        if(!projectNameToolStripMenuItem.Text.Equals("Project"))
            Sql.GetStories(taskNameLB, memberNameToolStripMenuItem.Text, Sql.GetProjectId(projectNameToolStripMenuItem.Text));

    }

    private void MenuStrip1ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void ProjectNameToolStripMenuItemClick(object sender, EventArgs e)
    {

    }

    private void LogoutToolStripMenuItemClick(object sender, EventArgs e)
    {
      Login frm2 = new Login();
      frm2.Show();
      this.Close();

    }

    private void MenuStrip2ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void CreateToolStripMenuItemClick(object sender, EventArgs e)
    {
      // create "create project" form and open it
      CreateProj frm3 = new CreateProj(memberNameToolStripMenuItem.Text);
      frm3.ShowDialog();
            
    }

        private void TextBox1TextChanged(object sender, EventArgs e)
        {
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = this.projectDescriptionTB.GetLineFromCharIndex(this.projectDescriptionTB.TextLength) + 1;
            // get border thickness
            int border = this.projectDescriptionTB.Height - this.projectDescriptionTB.ClientSize.Height;
            // set height (height of one line * number of lines + spacing)
            this.projectDescriptionTB.Height = this.projectDescriptionTB.Font.Height * numLines + padding + border;
        }

        private void ProjectDescriptionEditButtonClick(object sender, EventArgs e)
        {
            if(projectDescriptionTB.Enabled == false)
            {
                projectDescriptionTB.Enabled = true;
            }
            else
            {
                projectDescriptionTB.Enabled = false;
            }
        }

        private void TeamToolStripMenuItemClick(object sender, EventArgs e)
        {
          AddMembers frm = new AddMembers(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
          frm.Show();

        }

        private void TextBox2TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1Click(object sender, EventArgs e)
        {
            if (releaseTextBox.Enabled == false)
            {
                releaseTextBox.Enabled = true;
            }
            else
            {
                releaseTextBox.Enabled = false;
            }
        }

        private void TextBox1TextChanged1(object sender, EventArgs e)
        {
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = this.releaseTextBox.GetLineFromCharIndex(this.releaseTextBox.TextLength) + 1;
            // get border thickness
            int border = this.releaseTextBox.Height - this.releaseTextBox.ClientSize.Height;
            // set height (height of one line * number of lines + spacing)
            this.releaseTextBox.Height = this.releaseTextBox.Font.Height * numLines + padding + border;
        }

        private void Button2Click(object sender, EventArgs e)
        {
            if (doneTextBox.Enabled == false)
            {
                doneTextBox.Enabled = true;
            }
            else
            {
                doneTextBox.Enabled = false;
            }
        }

        private void DoneTextBoxTextChanged(object sender, EventArgs e)
        {
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = this.doneTextBox.GetLineFromCharIndex(this.doneTextBox.TextLength) + 1;
            // get border thickness
            int border = this.doneTextBox.Height - this.doneTextBox.ClientSize.Height;
            // set height (height of one line * number of lines + spacing)
            this.doneTextBox.Height = this.doneTextBox.Font.Height * numLines + padding + border;
        }

        private void IdeaBoxToolStripMenuItemClick(object sender, EventArgs e)
        {
          IdeaBox frm = new IdeaBox(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
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
           ReleasePlan frm = new ReleasePlan(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
           frm.Show();
           this.Close();
        }

        private void SprintPlanToolStripMenuItemClick(object sender, EventArgs e)
        {
          SprintPlan frm = new SprintPlan(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
          frm.Show();
          this.Close();
        }

        private void AssignRolesToolStripMenuItemClick(object sender, EventArgs e)
        {

            if (!Sql.IsManager(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
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

        private void SelectProjectToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          //get the name of the drop down item that was clicked
          //string proj_name = e.ClickedItem.ToString();
          projectNameToolStripMenuItem.Text = e.ClickedItem.ToString();
          Sql.GetProjectDescription(e.ClickedItem.ToString(), projectDescriptionTB);
            taskNameLB.Items.Clear();
            descTB.Text = "";
          Sql.GetStories(taskNameLB, memberNameToolStripMenuItem.Text, Sql.GetProjectId(projectNameToolStripMenuItem.Text));
            /*FormCollection fc = Application.OpenForms;
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
              Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, proj_name);
              frm.Show();
              this.Hide();
            }*/
        }

        private void TaskNameLbSelectedIndexChanged(object sender, EventArgs e)
        {
            if(taskNameLB.SelectedItem != null)
            {
                string name = taskNameLB.GetItemText(taskNameLB.SelectedItem);
                descTB.Text = Sql.GetStoryDesc(name, projectNameToolStripMenuItem.Text);


            }
        }

        private void SelectProjectToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

    private void ProjectDescriptionLabelTextChanged(object sender, EventArgs e)
    {

    }

    private void DoneLabelTextChanged(object sender, EventArgs e)
    {

    }

    private void ActivityLabelTextChanged(object sender, EventArgs e)
    {

    }

    private void Label1Click(object sender, EventArgs e)
    {

    }
  }
}
