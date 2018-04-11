using System;
using System.Windows.Forms;

namespace Co_Op_Swift
{
  public partial class AddComment : Form
  {
    ListBox _userComments;

    public AddComment(ListBox box, ListBox taskBox, string fullName)
    {
      InitializeComponent();
      _userComments = box;
      nameBox.Text = fullName;
      taskNameBox.Text = taskBox.SelectedItem.ToString();
    }

    private void CancelButtonClick(object sender, EventArgs e)
    {
      Close();
    }

    private void OkButtonClick(object sender, EventArgs e)
    {
      //get users username
      string username = Sql.GetUsername(nameBox.Text);

      //get userID from the name given as input
      int uid = Sql.GetOwnerUserId(username);
      
      //insert userID and comment into "Comments" table and retrieve the commentID
      int id = StoryTask.InsertComment(uid, commentBox.Text);

      //insert task_id and comment_id into "TaskComments" table
      StoryTask.InsertTaskComment(StoryTask.GetTaskId(taskNameBox.Text),id);

      //add name to userComments box on taskTree form
      _userComments.Items.Add(nameBox.Text);

      Close();
    }
  }
}
