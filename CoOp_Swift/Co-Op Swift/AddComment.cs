using System;
using System.Windows.Forms;

namespace Co_Op_Swift
{
  public partial class AddComment : Form
  {
    ListBox userComments;

    public AddComment(ListBox box, ListBox taskBox, string fullName)
    {
      InitializeComponent();
      userComments = box;
      nameBox.Text = fullName;
      taskNameBox.Text = taskBox.SelectedItem.ToString();
    }

    private void cancel_button_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void ok_button_Click(object sender, EventArgs e)
    {
      //get users username
      string username = Sql.getUsername(nameBox.Text);

      //get userID from the name given as input
      int uid = Sql.getOwnerUserID(username);
      
      //insert userID and comment into "Comments" table and retrieve the commentID
      int id = StoryTask.insertComment(uid, commentBox.Text);

      //insert task_id and comment_id into "TaskComments" table
      StoryTask.insertTaskComment(StoryTask.getTaskID(taskNameBox.Text),id);

      //add name to userComments box on taskTree form
      userComments.Items.Add(nameBox.Text);

      Close();
    }
  }
}
