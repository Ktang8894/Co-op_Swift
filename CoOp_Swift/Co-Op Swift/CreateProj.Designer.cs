namespace Co_Op_Swift
{
  partial class CreateProj
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.label1 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.projectName = new System.Windows.Forms.TextBox();
      this.projectStartDate = new System.Windows.Forms.TextBox();
      this.releaseEndDate = new System.Windows.Forms.TextBox();
      this.confirmContinue = new System.Windows.Forms.Button();
      this.cancel = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.timezoneBox = new System.Windows.Forms.ComboBox();
      this.privateYes = new System.Windows.Forms.RadioButton();
      this.privateNo = new System.Windows.Forms.RadioButton();
      this.descriptionBox = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(89, 21);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(119, 23);
      this.label1.TabIndex = 0;
      this.label1.Text = "Project Name:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(50, 60);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(154, 23);
      this.label3.TabIndex = 2;
      this.label3.Text = "Project Start Date:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.BackColor = System.Drawing.Color.Transparent;
      this.label6.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.ForeColor = System.Drawing.Color.White;
      this.label6.Location = new System.Drawing.Point(51, 102);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(147, 23);
      this.label6.TabIndex = 5;
      this.label6.Text = "Release End Date:";
      // 
      // projectName
      // 
      this.projectName.BackColor = System.Drawing.SystemColors.Window;
      this.projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectName.Location = new System.Drawing.Point(224, 18);
      this.projectName.Name = "projectName";
      this.projectName.Size = new System.Drawing.Size(270, 26);
      this.projectName.TabIndex = 6;
      this.projectName.Text = "Enter a name for your project";
      this.projectName.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projectName_MouseClick);
      // 
      // projectStartDate
      // 
      this.projectStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectStartDate.Location = new System.Drawing.Point(224, 57);
      this.projectStartDate.Name = "projectStartDate";
      this.projectStartDate.Size = new System.Drawing.Size(270, 26);
      this.projectStartDate.TabIndex = 8;
      // 
      // releaseEndDate
      // 
      this.releaseEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.releaseEndDate.Location = new System.Drawing.Point(224, 96);
      this.releaseEndDate.Name = "releaseEndDate";
      this.releaseEndDate.Size = new System.Drawing.Size(270, 26);
      this.releaseEndDate.TabIndex = 11;
      // 
      // confirmContinue
      // 
      this.confirmContinue.BackColor = System.Drawing.Color.Transparent;
      this.confirmContinue.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.confirmContinue.Location = new System.Drawing.Point(276, 248);
      this.confirmContinue.Name = "confirmContinue";
      this.confirmContinue.Size = new System.Drawing.Size(143, 51);
      this.confirmContinue.TabIndex = 12;
      this.confirmContinue.Text = "Confirm";
      this.confirmContinue.UseVisualStyleBackColor = false;
      this.confirmContinue.Click += new System.EventHandler(this.createProject_Click);
      // 
      // cancel
      // 
      this.cancel.BackColor = System.Drawing.Color.Transparent;
      this.cancel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancel.Location = new System.Drawing.Point(93, 248);
      this.cancel.Name = "cancel";
      this.cancel.Size = new System.Drawing.Size(143, 51);
      this.cancel.TabIndex = 13;
      this.cancel.Text = "Cancel";
      this.cancel.UseVisualStyleBackColor = false;
      this.cancel.Click += new System.EventHandler(this.cancel_Click);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(122, 140);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(90, 23);
      this.label2.TabIndex = 14;
      this.label2.Text = "TimeZone:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.BackColor = System.Drawing.Color.Transparent;
      this.label7.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.ForeColor = System.Drawing.Color.White;
      this.label7.Location = new System.Drawing.Point(144, 173);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(71, 23);
      this.label7.TabIndex = 16;
      this.label7.Text = "Private:";
      // 
      // timezoneBox
      // 
      this.timezoneBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.timezoneBox.DropDownWidth = 500;
      this.timezoneBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.timezoneBox.FormattingEnabled = true;
      this.timezoneBox.Location = new System.Drawing.Point(224, 136);
      this.timezoneBox.Name = "timezoneBox";
      this.timezoneBox.Size = new System.Drawing.Size(270, 28);
      this.timezoneBox.TabIndex = 17;
      // 
      // privateYes
      // 
      this.privateYes.AutoSize = true;
      this.privateYes.BackColor = System.Drawing.Color.Transparent;
      this.privateYes.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.privateYes.ForeColor = System.Drawing.Color.White;
      this.privateYes.Location = new System.Drawing.Point(238, 171);
      this.privateYes.Name = "privateYes";
      this.privateYes.Size = new System.Drawing.Size(58, 27);
      this.privateYes.TabIndex = 18;
      this.privateYes.TabStop = true;
      this.privateYes.Text = "Yes";
      this.privateYes.UseVisualStyleBackColor = false;
      // 
      // privateNo
      // 
      this.privateNo.AutoSize = true;
      this.privateNo.BackColor = System.Drawing.Color.Transparent;
      this.privateNo.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.privateNo.ForeColor = System.Drawing.Color.White;
      this.privateNo.Location = new System.Drawing.Point(336, 171);
      this.privateNo.Name = "privateNo";
      this.privateNo.Size = new System.Drawing.Size(51, 27);
      this.privateNo.TabIndex = 19;
      this.privateNo.TabStop = true;
      this.privateNo.Text = "No";
      this.privateNo.UseVisualStyleBackColor = false;
      // 
      // descriptionBox
      // 
      this.descriptionBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.descriptionBox.Location = new System.Drawing.Point(224, 203);
      this.descriptionBox.Name = "descriptionBox";
      this.descriptionBox.Size = new System.Drawing.Size(270, 26);
      this.descriptionBox.TabIndex = 21;
      this.descriptionBox.Text = "Enter a description of your project";
      this.descriptionBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.descriptionBox_MouseClick);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.BackColor = System.Drawing.Color.Transparent;
      this.label8.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label8.ForeColor = System.Drawing.Color.White;
      this.label8.Location = new System.Drawing.Point(106, 206);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(102, 23);
      this.label8.TabIndex = 20;
      this.label8.Text = "Description:";
      // 
      // CreateProj
      // 
      this.AcceptButton = this.confirmContinue;
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(523, 326);
      this.Controls.Add(this.descriptionBox);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.privateNo);
      this.Controls.Add(this.privateYes);
      this.Controls.Add(this.timezoneBox);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.cancel);
      this.Controls.Add(this.confirmContinue);
      this.Controls.Add(this.releaseEndDate);
      this.Controls.Add(this.projectStartDate);
      this.Controls.Add(this.projectName);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label1);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "CreateProj";
      this.Text = "Create New Project";
      this.Load += new System.EventHandler(this.Form3_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.TextBox projectName;
    private System.Windows.Forms.TextBox projectStartDate;
    private System.Windows.Forms.TextBox releaseEndDate;
    private System.Windows.Forms.Button confirmContinue;
    private System.Windows.Forms.Button cancel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.ComboBox timezoneBox;
    private System.Windows.Forms.RadioButton privateYes;
    private System.Windows.Forms.RadioButton privateNo;
    private System.Windows.Forms.TextBox descriptionBox;
    private System.Windows.Forms.Label label8;
    }
}