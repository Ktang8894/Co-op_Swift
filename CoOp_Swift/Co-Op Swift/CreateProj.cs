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
  public partial class CreateProj : Form
  {
    static string _name;

    public CreateProj(string username)
    {
      InitializeComponent();

      // default values
      projectStartDate.Text = DateTime.Now.ToShortDateString();
      releaseEndDate.Text = DateTime.Now.AddDays(35).ToShortDateString();
      timezoneBox.Text = "Select Timezone";

      //username to carry through to next form
      _name = username;

      // put timezones from TimeZones table in timezone combobox
      Sql.GetTimeZones(timezoneBox);

    }

    private void Form3Load(object sender, EventArgs e)
    {

    }


    private void CreateProjectClick(object sender, EventArgs e)
    {
      //check if form is finished correctly and completely
      if(Conditions.ProjectFormPasses(projectName.Text,projectStartDate.Text,releaseEndDate.Text,timezoneBox.Text,
                              descriptionBox.Text,privateNo,privateYes))
      {
        int isPrivate;

        //check which radio button is checked for 'is project private'
        if (privateYes.Checked)
          isPrivate = 1;
        else
          isPrivate = 0;

        //get ID of the owner(creator) of the poject
        int id = Sql.GetOwnerUserId(_name);

        //get ID of the timezone
        //int tid = SQL.getTimeZoneID(timezoneBox.Text);
        int tid = 1;

      //put the project info in a list to send to 'addMembers' form
      List<object> projectInfo = new List<object>();
      projectInfo.Add(id);
      projectInfo.Add(projectName.Text);
      projectInfo.Add(releaseEndDate.Text);
      projectInfo.Add(tid);
      projectInfo.Add(projectStartDate.Text);
      projectInfo.Add(descriptionBox.Text);
      projectInfo.Add(isPrivate);

      FormCollection fc = Application.OpenForms;
      Form dash = new Form();

      foreach (Form frm1 in fc)
      {
        if (frm1.Name == "Dashboard")
        {
          dash = frm1;
        }
      }

      AddMembers frm = new AddMembers(_name, projectName.Text,dash,this,true,projectInfo);
      frm.ShowDialog();      

      }

    }


    private void CancelClick(object sender, EventArgs e)
    {
      // close the form
      this.Close();
    }

    private void DescriptionBoxMouseClick(object sender, MouseEventArgs e)
    {
      descriptionBox.Clear();
    }

    private void ProjectNameMouseClick(object sender, MouseEventArgs e)
    {
      projectName.Clear();
    }

        
    }
}
