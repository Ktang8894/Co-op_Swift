namespace Co_Op_Swift
{
  partial class SprintPlan
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
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.projectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.teamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ideaBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.taskTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.releasePlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sprintPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.memberNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createTask = new System.Windows.Forms.Button();
      this.descriptionBox = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.taskNameBox = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.taskBox = new System.Windows.Forms.ListBox();
      this.infoBox = new System.Windows.Forms.ListBox();
      this.label5 = new System.Windows.Forms.Label();
      this.sprintBox = new System.Windows.Forms.ListBox();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
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
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(1151, 28);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // projectNameToolStripMenuItem
      // 
      this.projectNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.selectProjectToolStripMenuItem,
            this.importToolStripMenuItem,
            this.teamToolStripMenuItem,
            this.assignRolesToolStripMenuItem,
            this.assignTasksToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.settingsToolStripMenuItem});
      this.projectNameToolStripMenuItem.Name = "projectNameToolStripMenuItem";
      this.projectNameToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
      this.projectNameToolStripMenuItem.Text = "Project";
      // 
      // createToolStripMenuItem
      // 
      this.createToolStripMenuItem.Name = "createToolStripMenuItem";
      this.createToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.createToolStripMenuItem.Text = "Create Project";
      // 
      // selectProjectToolStripMenuItem
      // 
      this.selectProjectToolStripMenuItem.Name = "selectProjectToolStripMenuItem";
      this.selectProjectToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.selectProjectToolStripMenuItem.Text = "Select Project";
      this.selectProjectToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.SelectProjectToolStripMenuItemDropDownItemClicked);
      // 
      // importToolStripMenuItem
      // 
      this.importToolStripMenuItem.Name = "importToolStripMenuItem";
      this.importToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.importToolStripMenuItem.Text = "Import";
      // 
      // teamToolStripMenuItem
      // 
      this.teamToolStripMenuItem.Name = "teamToolStripMenuItem";
      this.teamToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.teamToolStripMenuItem.Text = "Team Members";
      this.teamToolStripMenuItem.Click += new System.EventHandler(this.TeamToolStripMenuItemClick);
      // 
      // assignRolesToolStripMenuItem
      // 
      this.assignRolesToolStripMenuItem.Name = "assignRolesToolStripMenuItem";
      this.assignRolesToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.assignRolesToolStripMenuItem.Text = "Assign Roles";
      this.assignRolesToolStripMenuItem.Click += new System.EventHandler(this.AssignRolesToolStripMenuItemClick);
      // 
      // assignTasksToolStripMenuItem
      // 
      this.assignTasksToolStripMenuItem.Name = "assignTasksToolStripMenuItem";
      this.assignTasksToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.assignTasksToolStripMenuItem.Text = "Assign Tasks";
      this.assignTasksToolStripMenuItem.Click += new System.EventHandler(this.AssignTasksToolStripMenuItemClick);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.deleteToolStripMenuItem.Text = "Delete";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // dashboardToolStripMenuItem
      // 
      this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
      this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
      this.dashboardToolStripMenuItem.Text = "Dashboard";
      this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.DashboardToolStripMenuItemClick);
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
      // createTask
      // 
      this.createTask.Location = new System.Drawing.Point(221, 449);
      this.createTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.createTask.Name = "createTask";
      this.createTask.Size = new System.Drawing.Size(173, 75);
      this.createTask.TabIndex = 4;
      this.createTask.Text = "Create Task";
      this.createTask.UseVisualStyleBackColor = true;
      this.createTask.Click += new System.EventHandler(this.CreateTaskClick);
      // 
      // descriptionBox
      // 
      this.descriptionBox.Location = new System.Drawing.Point(221, 121);
      this.descriptionBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.descriptionBox.Multiline = true;
      this.descriptionBox.Name = "descriptionBox";
      this.descriptionBox.Size = new System.Drawing.Size(175, 322);
      this.descriptionBox.TabIndex = 5;
      this.descriptionBox.Text = "Add Task Description";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(252, 101);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(113, 18);
      this.label1.TabIndex = 6;
      this.label1.Text = "Task Description";
      // 
      // taskNameBox
      // 
      this.taskNameBox.Location = new System.Drawing.Point(225, 71);
      this.taskNameBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.taskNameBox.Name = "taskNameBox";
      this.taskNameBox.Size = new System.Drawing.Size(171, 22);
      this.taskNameBox.TabIndex = 7;
      this.taskNameBox.Text = "Add Task";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(243, 44);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(114, 26);
      this.label2.TabIndex = 8;
      this.label2.Text = "Task Name";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(521, 44);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(64, 26);
      this.label3.TabIndex = 11;
      this.label3.Text = "Tasks";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(899, 44);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(48, 26);
      this.label4.TabIndex = 12;
      this.label4.Text = "Info";
      // 
      // taskBox
      // 
      this.taskBox.FormattingEnabled = true;
      this.taskBox.ItemHeight = 16;
      this.taskBox.Location = new System.Drawing.Point(413, 71);
      this.taskBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.taskBox.Name = "taskBox";
      this.taskBox.Size = new System.Drawing.Size(295, 452);
      this.taskBox.TabIndex = 13;
      this.taskBox.SelectedIndexChanged += new System.EventHandler(this.TaskBoxSelectedIndexChanged);
      // 
      // infoBox
      // 
      this.infoBox.FormattingEnabled = true;
      this.infoBox.ItemHeight = 16;
      this.infoBox.Location = new System.Drawing.Point(725, 71);
      this.infoBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.infoBox.Name = "infoBox";
      this.infoBox.Size = new System.Drawing.Size(403, 228);
      this.infoBox.TabIndex = 14;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.BackColor = System.Drawing.Color.Transparent;
      this.label5.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.Color.White;
      this.label5.Location = new System.Drawing.Point(61, 44);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(78, 26);
      this.label5.TabIndex = 15;
      this.label5.Text = "Sprints";
      // 
      // sprintBox
      // 
      this.sprintBox.FormattingEnabled = true;
      this.sprintBox.ItemHeight = 16;
      this.sprintBox.Location = new System.Drawing.Point(13, 71);
      this.sprintBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.sprintBox.Name = "sprintBox";
      this.sprintBox.Size = new System.Drawing.Size(191, 452);
      this.sprintBox.TabIndex = 16;
      this.sprintBox.SelectedIndexChanged += new System.EventHandler(this.SprintBoxSelectedIndexChanged);
      // 
      // sprintPlan
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Navy;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Large;
      this.ClientSize = new System.Drawing.Size(1151, 544);
      this.Controls.Add(this.sprintBox);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.infoBox);
      this.Controls.Add(this.taskBox);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.taskNameBox);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.descriptionBox);
      this.Controls.Add(this.createTask);
      this.Controls.Add(this.menuStrip1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "SprintPlan";
      this.Text = "Co-Op Swift";
      this.Load += new System.EventHandler(this.SprintPlanLoad);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem projectNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem teamToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ideaBoxToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem taskTreeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem releasePlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sprintPlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem memberNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    private System.Windows.Forms.Button createTask;
    private System.Windows.Forms.TextBox descriptionBox;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox taskNameBox;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ListBox taskBox;
    private System.Windows.Forms.ListBox infoBox;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ListBox sprintBox;
    private System.Windows.Forms.ToolStripMenuItem selectProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignTasksToolStripMenuItem;
    }
}