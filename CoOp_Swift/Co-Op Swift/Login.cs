using System;
using System.Windows.Forms;
using Co_Op_Swift.Resources;

namespace Co_Op_Swift
{
  public partial class Login : Form
  {
    public Login()
    {
      InitializeComponent();
    }

    private void LoginButtonClick(object sender, EventArgs e)
    {
      var username = unInput.Text;
      var password = pwInput.Text;

      if (username.Equals(""))
      {
        MessageBox.Show(MessageBoxStrings.UserNotEntered, MessageBoxStrings.ERROR, MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        return;
      }

      var pass = Sql.ExecuteLogin(username, password);

      if (pass)
      {
        var projId = Sql.IsInProject(Sql.GetOwnerUserId(username));
        if (projId != 0)
        {
          var projectName = Sql.GetProjectName(projId);
          var fc = Application.OpenForms;
          var isFound = false;
          foreach (Form form in fc)
            if (form.Name == "Main")
            {
              form.Focus();
              isFound = true;
              Hide();
            }

          if (isFound == false)
          {
            var form = new Dashboard(username, projectName);
            form.Show();
            Hide();
          }
        }
        else
        {
          var fc = Application.OpenForms;
          var formFound = false;
          foreach (Form form in fc)
            if (form.Name == "Main")
            {
              form.Focus();
              formFound = true;
              Hide();
            }

          if (formFound == false)
          {
            var form = new Dashboard(username, "");
            form.Show();
            Hide();
          }
        }
      }
      else
      {
        MessageBox.Show(MessageBoxStrings.PasswordNotMatch, MessageBoxStrings.IncorrectPassword, MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1);
      }
    }

    private void RegisterButtonClick(object sender, EventArgs e)
    {
      var fc = Application.OpenForms;
      var formFound = false;
      foreach (Form form in fc)
        if (form.Name == "RegForm")
        {
          form.Focus();
          formFound = true;
          Hide();
        }

      if (formFound == false)
      {
        var form = new RegForm();
        form.ShowDialog();
      }
    }

    private void ResetPasswordButtonClick(object sender, EventArgs e)
    {
      var userName = unInput.Text;
      var count = Sql.CheckUserExsistence(userName);

      if (count == 0)
      {
        MessageBox.Show(MessageBoxStrings.EmailUsernameDNE);
      }
      else
      {
        if (unInput.Text.Equals(""))
        {
          MessageBox.Show(MessageBoxStrings.UserNotFound, MessageBoxStrings.ERROR, MessageBoxButtons.OK,
            MessageBoxIcon.Exclamation,
            MessageBoxDefaultButton.Button1);
        }
        else
        {
          var fc = Application.OpenForms;
          var formFound = false;
          foreach (Form form in fc)
            if (form.Name == "ResetForm1")
            {
              form.Focus();
              formFound = true;
              Hide();
            }

          if (formFound == false)
          {
            var username = unInput.Text;

            var form = new SecurityQuestion(username);
            form.ShowDialog();
          }
        }
      }
    }

    //method to override the 'x' button on top right corner of form
    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      Application.Exit();
    } 
  }
}