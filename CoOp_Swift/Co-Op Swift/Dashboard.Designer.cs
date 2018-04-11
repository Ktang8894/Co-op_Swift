namespace Co_Op_Swift
{
  partial class Dashboard
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
      this.projectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.inviteMembersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ideaBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.taskTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.releasePlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sprintPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.memberNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.projectDescriptionTB = new System.Windows.Forms.TextBox();
      this.projectDescriptionEditButton = new System.Windows.Forms.Button();
      this.releaseTextBox = new System.Windows.Forms.TextBox();
      this.releaseButton = new System.Windows.Forms.Button();
      this.doneTextBox = new System.Windows.Forms.TextBox();
      this.doneButton = new System.Windows.Forms.Button();
      this.activitiesTextBox = new System.Windows.Forms.TextBox();
      this.taskNameLB = new System.Windows.Forms.ListBox();
      this.descTB = new System.Windows.Forms.TextBox();
      this.projectDescriptionLabel = new System.Windows.Forms.Label();
      this.releaseLabel = new System.Windows.Forms.Label();
      this.doneLabel = new System.Windows.Forms.Label();
      this.activityLabel = new System.Windows.Forms.Label();
      this.ideaLabel = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.noProject = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // projectNameToolStripMenuItem
      // 
      this.projectNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.selectProjectToolStripMenuItem,
            this.inviteMembersToolStripMenuItem,
            this.assignRolesToolStripMenuItem,
            this.assignTasksToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.settingsToolStripMenuItem});
      this.projectNameToolStripMenuItem.Name = "projectNameToolStripMenuItem";
      this.projectNameToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
      this.projectNameToolStripMenuItem.Text = "Project";
      this.projectNameToolStripMenuItem.Click += new System.EventHandler(this.ProjectNameToolStripMenuItemClick);
      // 
      // createToolStripMenuItem
      // 
      this.createToolStripMenuItem.Name = "createToolStripMenuItem";
      this.createToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.createToolStripMenuItem.Text = "Create Project";
      this.createToolStripMenuItem.Click += new System.EventHandler(this.CreateToolStripMenuItemClick);
      // 
      // selectProjectToolStripMenuItem
      // 
      this.selectProjectToolStripMenuItem.Name = "selectProjectToolStripMenuItem";
      this.selectProjectToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.selectProjectToolStripMenuItem.Text = "Select Project";
      this.selectProjectToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SelectProjectToolStripMenuItemDropDownItemClicked);
      this.selectProjectToolStripMenuItem.Click += new System.EventHandler(this.SelectProjectToolStripMenuItemClick);
      // 
      // inviteMembersToolStripMenuItem
      // 
      this.inviteMembersToolStripMenuItem.Name = "inviteMembersToolStripMenuItem";
      this.inviteMembersToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.inviteMembersToolStripMenuItem.Text = "Invite Members";
      this.inviteMembersToolStripMenuItem.Click += new System.EventHandler(this.TeamToolStripMenuItemClick);
      // 
      // assignRolesToolStripMenuItem
      // 
      this.assignRolesToolStripMenuItem.Name = "assignRolesToolStripMenuItem";
      this.assignRolesToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.assignRolesToolStripMenuItem.Text = "Assign Roles";
      this.assignRolesToolStripMenuItem.Click += new System.EventHandler(this.AssignRolesToolStripMenuItemClick);
      // 
      // assignTasksToolStripMenuItem
      // 
      this.assignTasksToolStripMenuItem.Name = "assignTasksToolStripMenuItem";
      this.assignTasksToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.assignTasksToolStripMenuItem.Text = "Assign Tasks";
      this.assignTasksToolStripMenuItem.Click += new System.EventHandler(this.AssignTasksToolStripMenuItemClick);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.deleteToolStripMenuItem.Text = "Delete";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // ideaBoxToolStripMenuItem
      // 
      this.ideaBoxToolStripMenuItem.Name = "ideaBoxToolStripMenuItem";
      this.ideaBoxToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
      this.ideaBoxToolStripMenuItem.Text = "IdeaBox";
      this.ideaBoxToolStripMenuItem.Click += new System.EventHandler(this.IdeaBoxToolStripMenuItemClick);
      // 
      // taskTreeToolStripMenuItem
      // 
      this.taskTreeToolStripMenuItem.Name = "taskTreeToolStripMenuItem";
      this.taskTreeToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
      this.taskTreeToolStripMenuItem.Text = "Task View";
      this.taskTreeToolStripMenuItem.Click += new System.EventHandler(this.TaskTreeToolStripMenuItemClick);
      // 
      // releasePlanToolStripMenuItem
      // 
      this.releasePlanToolStripMenuItem.Name = "releasePlanToolStripMenuItem";
      this.releasePlanToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
      this.releasePlanToolStripMenuItem.Text = "Release Plan";
      this.releasePlanToolStripMenuItem.Click += new System.EventHandler(this.ReleasePlanToolStripMenuItemClick);
      // 
      // sprintPlanToolStripMenuItem
      // 
      this.sprintPlanToolStripMenuItem.Name = "sprintPlanToolStripMenuItem";
      this.sprintPlanToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
      this.sprintPlanToolStripMenuItem.Text = "Sprint Plan";
      this.sprintPlanToolStripMenuItem.Click += new System.EventHandler(this.SprintPlanToolStripMenuItemClick);
      // 
      // memberNameToolStripMenuItem
      // 
      this.memberNameToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.memberNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.logoutToolStripMenuItem});
      this.memberNameToolStripMenuItem.Name = "memberNameToolStripMenuItem";
      this.memberNameToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
      this.memberNameToolStripMenuItem.Text = "Member Name";
      // 
      // accountToolStripMenuItem
      // 
      this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
      this.accountToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
      this.accountToolStripMenuItem.Text = "Account";
      // 
      // logoutToolStripMenuItem
      // 
      this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
      this.logoutToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
      this.logoutToolStripMenuItem.Text = "Logout";
      this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItemClick);
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectNameToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.ideaBoxToolStripMenuItem,
            this.taskTreeToolStripMenuItem,
            this.releasePlanToolStripMenuItem,
            this.sprintPlanToolStripMenuItem,
            this.memberNameToolStripMenuItem});
      this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(1012, 28);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1ItemClicked);
      // 
      // dashboardToolStripMenuItem
      // 
      this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
      this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
      this.dashboardToolStripMenuItem.Text = "Dashboard";
      // 
      // projectDescriptionTB
      // 
      this.projectDescriptionTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.projectDescriptionTB.BackColor = System.Drawing.Color.White;
      this.projectDescriptionTB.Enabled = false;
      this.projectDescriptionTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectDescriptionTB.Location = new System.Drawing.Point(25, 88);
      this.projectDescriptionTB.MinimumSize = new System.Drawing.Size(292, 77);
      this.projectDescriptionTB.Multiline = true;
      this.projectDescriptionTB.Name = "projectDescriptionTB";
      this.projectDescriptionTB.Size = new System.Drawing.Size(292, 77);
      this.projectDescriptionTB.TabIndex = 1;
      this.projectDescriptionTB.Text = "No description currently defined";
      this.projectDescriptionTB.TextChanged += new System.EventHandler(this.TextBox1TextChanged);
      // 
      // projectDescriptionEditButton
      // 
      this.projectDescriptionEditButton.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectDescriptionEditButton.Location = new System.Drawing.Point(264, 136);
      this.projectDescriptionEditButton.Name = "projectDescriptionEditButton";
      this.projectDescriptionEditButton.Size = new System.Drawing.Size(53, 26);
      this.projectDescriptionEditButton.TabIndex = 3;
      this.projectDescriptionEditButton.Text = "Edit";
      this.projectDescriptionEditButton.UseVisualStyleBackColor = true;
      this.projectDescriptionEditButton.Click += new System.EventHandler(this.ProjectDescriptionEditButtonClick);
      // 
      // releaseTextBox
      // 
      this.releaseTextBox.BackColor = System.Drawing.Color.White;
      this.releaseTextBox.Enabled = false;
      this.releaseTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.releaseTextBox.Location = new System.Drawing.Point(25, 211);
      this.releaseTextBox.MinimumSize = new System.Drawing.Size(292, 77);
      this.releaseTextBox.Multiline = true;
      this.releaseTextBox.Name = "releaseTextBox";
      this.releaseTextBox.Size = new System.Drawing.Size(292, 77);
      this.releaseTextBox.TabIndex = 4;
      this.releaseTextBox.Text = "No description currently defined";
      this.releaseTextBox.TextChanged += new System.EventHandler(this.TextBox1TextChanged1);
      // 
      // releaseButton
      // 
      this.releaseButton.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.releaseButton.Location = new System.Drawing.Point(264, 262);
      this.releaseButton.Name = "releaseButton";
      this.releaseButton.Size = new System.Drawing.Size(53, 26);
      this.releaseButton.TabIndex = 6;
      this.releaseButton.Text = "Edit";
      this.releaseButton.UseVisualStyleBackColor = true;
      this.releaseButton.Click += new System.EventHandler(this.Button1Click);
      // 
      // doneTextBox
      // 
      this.doneTextBox.BackColor = System.Drawing.Color.White;
      this.doneTextBox.Enabled = false;
      this.doneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.doneTextBox.Location = new System.Drawing.Point(25, 340);
      this.doneTextBox.MinimumSize = new System.Drawing.Size(292, 77);
      this.doneTextBox.Multiline = true;
      this.doneTextBox.Name = "doneTextBox";
      this.doneTextBox.Size = new System.Drawing.Size(292, 86);
      this.doneTextBox.TabIndex = 7;
      this.doneTextBox.Text = "No description currently defined";
      this.doneTextBox.TextChanged += new System.EventHandler(this.DoneTextBoxTextChanged);
      // 
      // doneButton
      // 
      this.doneButton.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.doneButton.Location = new System.Drawing.Point(264, 400);
      this.doneButton.Name = "doneButton";
      this.doneButton.Size = new System.Drawing.Size(53, 26);
      this.doneButton.TabIndex = 9;
      this.doneButton.Text = "Edit";
      this.doneButton.UseVisualStyleBackColor = true;
      this.doneButton.Click += new System.EventHandler(this.Button2Click);
      // 
      // activitiesTextBox
      // 
      this.activitiesTextBox.BackColor = System.Drawing.Color.White;
      this.activitiesTextBox.Enabled = false;
      this.activitiesTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.activitiesTextBox.Location = new System.Drawing.Point(349, 89);
      this.activitiesTextBox.Multiline = true;
      this.activitiesTextBox.Name = "activitiesTextBox";
      this.activitiesTextBox.Size = new System.Drawing.Size(292, 337);
      this.activitiesTextBox.TabIndex = 10;
      this.activitiesTextBox.Text = "No description currently defined";
      // 
      // taskNameLB
      // 
      this.taskNameLB.FormattingEnabled = true;
      this.taskNameLB.ItemHeight = 20;
      this.taskNameLB.Location = new System.Drawing.Point(673, 87);
      this.taskNameLB.Name = "taskNameLB";
      this.taskNameLB.Size = new System.Drawing.Size(305, 164);
      this.taskNameLB.TabIndex = 12;
      this.taskNameLB.SelectedIndexChanged += new System.EventHandler(this.TaskNameLbSelectedIndexChanged);
      // 
      // descTB
      // 
      this.descTB.Location = new System.Drawing.Point(673, 289);
      this.descTB.Multiline = true;
      this.descTB.Name = "descTB";
      this.descTB.Size = new System.Drawing.Size(305, 137);
      this.descTB.TabIndex = 16;
      // 
      // projectDescriptionLabel
      // 
      this.projectDescriptionLabel.AutoSize = true;
      this.projectDescriptionLabel.BackColor = System.Drawing.Color.Transparent;
      this.projectDescriptionLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.projectDescriptionLabel.ForeColor = System.Drawing.Color.White;
      this.projectDescriptionLabel.Location = new System.Drawing.Point(21, 65);
      this.projectDescriptionLabel.Name = "projectDescriptionLabel";
      this.projectDescriptionLabel.Size = new System.Drawing.Size(165, 23);
      this.projectDescriptionLabel.TabIndex = 17;
      this.projectDescriptionLabel.Text = "Project Description";
      // 
      // releaseLabel
      // 
      this.releaseLabel.AutoSize = true;
      this.releaseLabel.BackColor = System.Drawing.Color.Transparent;
      this.releaseLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.releaseLabel.ForeColor = System.Drawing.Color.White;
      this.releaseLabel.Location = new System.Drawing.Point(21, 188);
      this.releaseLabel.Name = "releaseLabel";
      this.releaseLabel.Size = new System.Drawing.Size(137, 23);
      this.releaseLabel.TabIndex = 18;
      this.releaseLabel.Text = "Release Version";
      // 
      // doneLabel
      // 
      this.doneLabel.AutoSize = true;
      this.doneLabel.BackColor = System.Drawing.Color.Transparent;
      this.doneLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.doneLabel.ForeColor = System.Drawing.Color.White;
      this.doneLabel.Location = new System.Drawing.Point(21, 317);
      this.doneLabel.Name = "doneLabel";
      this.doneLabel.Size = new System.Drawing.Size(123, 23);
      this.doneLabel.TabIndex = 19;
      this.doneLabel.Text = "End Objective";
      // 
      // activityLabel
      // 
      this.activityLabel.AutoSize = true;
      this.activityLabel.BackColor = System.Drawing.Color.Transparent;
      this.activityLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.activityLabel.ForeColor = System.Drawing.Color.White;
      this.activityLabel.Location = new System.Drawing.Point(345, 67);
      this.activityLabel.Name = "activityLabel";
      this.activityLabel.Size = new System.Drawing.Size(85, 23);
      this.activityLabel.TabIndex = 20;
      this.activityLabel.Text = "Activities";
      // 
      // ideaLabel
      // 
      this.ideaLabel.AutoSize = true;
      this.ideaLabel.BackColor = System.Drawing.Color.Transparent;
      this.ideaLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ideaLabel.ForeColor = System.Drawing.Color.White;
      this.ideaLabel.Location = new System.Drawing.Point(669, 64);
      this.ideaLabel.Name = "ideaLabel";
      this.ideaLabel.Size = new System.Drawing.Size(51, 23);
      this.ideaLabel.TabIndex = 21;
      this.ideaLabel.Text = "Ideas";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(669, 268);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(140, 23);
      this.label1.TabIndex = 22;
      this.label1.Text = "Idea Description";
      this.label1.Click += new System.EventHandler(this.Label1Click);
      // 
      // noProject
      // 
      this.noProject.AutoSize = true;
      this.noProject.BackColor = System.Drawing.Color.Transparent;
      this.noProject.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.noProject.ForeColor = System.Drawing.Color.White;
      this.noProject.Location = new System.Drawing.Point(163, 225);
      this.noProject.Name = "noProject";
      this.noProject.Size = new System.Drawing.Size(313, 43);
      this.noProject.TabIndex = 23;
      this.noProject.Text = "No Project Loaded";
      // 
      // Dashboard
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Peru;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Large;
      this.ClientSize = new System.Drawing.Size(1012, 469);
      this.Controls.Add(this.noProject);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.ideaLabel);
      this.Controls.Add(this.activityLabel);
      this.Controls.Add(this.doneLabel);
      this.Controls.Add(this.releaseLabel);
      this.Controls.Add(this.doneButton);
      this.Controls.Add(this.projectDescriptionEditButton);
      this.Controls.Add(this.projectDescriptionLabel);
      this.Controls.Add(this.descTB);
      this.Controls.Add(this.taskNameLB);
      this.Controls.Add(this.activitiesTextBox);
      this.Controls.Add(this.doneTextBox);
      this.Controls.Add(this.releaseButton);
      this.Controls.Add(this.projectDescriptionTB);
      this.Controls.Add(this.menuStrip1);
      this.Controls.Add(this.releaseTextBox);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.Color.Black;
      this.MainMenuStrip = this.menuStrip1;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Dashboard";
      this.Text = "Co-Op Swift";
      this.Load += new System.EventHandler(this.Form1Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem projectNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem inviteMembersToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ideaBoxToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem taskTreeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem releasePlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sprintPlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem memberNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.TextBox projectDescriptionTB;
        private System.Windows.Forms.Button projectDescriptionEditButton;
        private System.Windows.Forms.TextBox releaseTextBox;
        private System.Windows.Forms.Button releaseButton;
        private System.Windows.Forms.TextBox doneTextBox;
        private System.Windows.Forms.Button doneButton;
        private System.Windows.Forms.TextBox activitiesTextBox;
        private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignTasksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectProjectToolStripMenuItem;
        private System.Windows.Forms.ListBox taskNameLB;
        private System.Windows.Forms.TextBox descTB;
    private System.Windows.Forms.Label projectDescriptionLabel;
    private System.Windows.Forms.Label releaseLabel;
    private System.Windows.Forms.Label doneLabel;
    private System.Windows.Forms.Label activityLabel;
    private System.Windows.Forms.Label ideaLabel;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label noProject;
  }
}

