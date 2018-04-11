using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Co_Op_Swift
{
  public partial class TaskTree : Form
  {
    public TaskTree(string username, string projectName)
    {
      InitializeComponent();

      //get all project related sprint ids
      DataTable sprintIDs = StoryTask.GetProjectSprintIDs(projectName);

      //get tasks and put their names in the corresponding listbox
      foreach (DataRow r in sprintIDs.Rows)
      {
        //get all task ids from the sprint ids
        DataTable taskIDs = StoryTask.GetProjectTaskIDs(int.Parse(r["SprintID"].ToString()));

        //retrieve and add tasks to their correct lists
        foreach (DataRow row in taskIDs.Rows)
          StoryTask.GetTaskName(currentTasks, completedTasks, int.Parse(row["Task_ID"].ToString()));
      }

      projectNameToolStripMenuItem.Text = projectName;
      memberNameToolStripMenuItem.Text = username;
      taskTreeToolStripMenuItem.Font = new Font(taskTreeToolStripMenuItem.Font, FontStyle.Bold);


      // intially make developer panels invisible unitl a task is selected
      develop1.Visible = false;
      develop2.Visible = false;
      commentDetails.Visible = false;
      comments.Visible = false;
      comments2.Visible = false;
      userComments.Visible = false;
      comment.Visible = false;
      hideTaskInfo.Visible = false;

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

    private void IdeaBoxToolStripMenuItemClick(object sender, EventArgs e)
    {
      IdeaBox frm = new IdeaBox(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
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
      AddMembers frm = new AddMembers(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
    }

    private void Panel1Paint(object sender, PaintEventArgs e)
    {

    }

    private void CurrentTasksSelectedIndexChanged(object sender, EventArgs e)
    {
      int id, uid;
      string name;

      if(currentTasks.SelectedItem != null)
      {
        develop1.Visible = false;
        develop2.Visible = false;
        userComments.Items.Clear();

        //get task
        StoryTask.GetTaskInfo(currentTasks.SelectedItem.ToString(), develop1, develop2, develop1Name, develop1Email, develop1Position,
                                                                                        develop2Name, develop2Email, develop2Position);

        //remove the selection of the item in the other box if one was selected
        if (completedTasks.SelectedItem != null)
          completedTasks.SetSelected(completedTasks.Items.IndexOf(completedTasks.SelectedItem), false);

        DataTable commentIDs = StoryTask.GetCommentId(StoryTask.GetTaskId(currentTasks.SelectedItem.ToString()));

        foreach (DataRow row in commentIDs.Rows)
        {
          id = int.Parse(row["CommentID"].ToString());
          uid = StoryTask.GetCommenter(id);
          name = Sql.GetFullName(uid);
          userComments.Items.Add(name);
        }

        comments.Visible = true;
        userComments.Visible = true;
        comment.Visible = true;
        hideTaskInfo.Visible = true;

      }
     
    }

    private void HideTaskInfoClick(object sender, EventArgs e)
    {
      //remove the the selection from the listboxes(the highlight that shows an item was selected)
      if (currentTasks.SelectedItem != null)
        currentTasks.SetSelected(currentTasks.Items.IndexOf(currentTasks.SelectedItem), false);

      if (completedTasks.SelectedItem != null)
        completedTasks.SetSelected(completedTasks.Items.IndexOf(completedTasks.SelectedItem), false);

      develop1.Visible = false;
      develop2.Visible = false;
      commentDetails.Visible = false;
      comments.Visible = false;
      comments2.Visible = false;
      comment.Visible = false;
      userComments.Visible = false;
      hideTaskInfo.Visible = false;
    }

    private void CommentClick(object sender, EventArgs e)
    {
      string fullName = Sql.GetFullName(Sql.GetOwnerUserId(memberNameToolStripMenuItem.Text));
      
      if (currentTasks.SelectedItem != null)
      {
        AddComment frm = new AddComment(userComments, currentTasks,fullName);
        frm.ShowDialog();
      }
      else if (completedTasks.SelectedItem != null)
      {
        AddComment frm = new AddComment(userComments, completedTasks,fullName);
        frm.ShowDialog();
      }
    }

    private void UserCommentsSelectedIndexChanged(object sender, EventArgs e)
    {
      comments2.Visible = true;
      commentDetails.Visible = true;
      int taskId;
      DataTable commentIDs;

      //get the id of the selected task
      if (currentTasks.SelectedItem != null)
        taskId = StoryTask.GetTaskId(currentTasks.SelectedItem.ToString());
      else
        taskId = StoryTask.GetTaskId(completedTasks.SelectedItem.ToString());

      //get the id of the person whose name was selected from comments list
      int userId = Sql.GetOwnerUserId(Sql.GetUsername(userComments.Text));

      //get the comment ids for the selected task
      commentIDs = StoryTask.GetCommentId(taskId);

      //find the correct comment from the userID and commentIDs
      StoryTask.LoadCommentDetail(userId, commentIDs, commentDetails);

    }

    private void CompletedTasksSelectedIndexChanged(object sender, EventArgs e)
    {
      int id, uid;
      string name;

      if(completedTasks.SelectedItem != null)
      {
        userComments.Items.Clear();

        //get task
        StoryTask.GetTaskInfo(completedTasks.SelectedItem.ToString(), develop1, develop2, develop1Name, develop1Email, develop1Position,
                                                                                          develop2Name, develop2Email, develop2Position);

        //remove the selection of the item in the other box if one was selected
        if (currentTasks.SelectedItem != null)
          currentTasks.SetSelected(currentTasks.Items.IndexOf(currentTasks.SelectedItem), false);

        DataTable commentIDs = StoryTask.GetCommentId(StoryTask.GetTaskId(completedTasks.SelectedItem.ToString()));

        foreach (DataRow row in commentIDs.Rows)
        {
          id = int.Parse(row["CommentID"].ToString());
          uid = StoryTask.GetCommenter(id);
          name = Sql.GetFullName(uid);
          userComments.Items.Add(name);
        }

        comments.Visible = true;
        userComments.Visible = true;
        comment.Visible = true;
        hideTaskInfo.Visible = true;
      }
     
    }

    private void CompletedButtonClick(object sender, EventArgs e)
    {
      //grab selected task
      string task = currentTasks.SelectedItem.ToString();

      //mark the task as completed in the TaskTable table
      StoryTask.MarkTaskAsComplete(task);

      bool isFound = false;

      //remove from current tasks list and add to completed tasks list
      foreach (string s in completedTasks.Items)
      {
        if (s.Equals(currentTasks.SelectedItem.ToString()))
        {
          isFound = true;
          break;
        }
      }

      if (!isFound)
        completedTasks.Items.Add(currentTasks.SelectedItem);

      currentTasks.Items.Remove(currentTasks.SelectedItem);
      completedTasks.SetSelected(completedTasks.Items.IndexOf(task), true);

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
    }
}
