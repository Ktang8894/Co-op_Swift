namespace Co_Op_Swift
{
  partial class addMembers
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
      this.label2 = new System.Windows.Forms.Label();
      this.currentUsers = new System.Windows.Forms.ListBox();
      this.teamMembers = new System.Windows.Forms.ListBox();
      this.add_button = new System.Windows.Forms.Button();
      this.remove_button = new System.Windows.Forms.Button();
      this.finalize_button = new System.Windows.Forms.Button();
      this.cancel_buttton = new System.Windows.Forms.Button();
      this.label3 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.usersUsername = new System.Windows.Forms.TextBox();
      this.teamateUsername = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(99, 13);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(167, 29);
      this.label1.TabIndex = 0;
      this.label1.Text = "Current Users";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(779, 11);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(184, 29);
      this.label2.TabIndex = 1;
      this.label2.Text = "Team Members";
      // 
      // currentUsers
      // 
      this.currentUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.currentUsers.FormattingEnabled = true;
      this.currentUsers.ItemHeight = 20;
      this.currentUsers.Location = new System.Drawing.Point(31, 46);
      this.currentUsers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.currentUsers.Name = "currentUsers";
      this.currentUsers.Size = new System.Drawing.Size(311, 244);
      this.currentUsers.Sorted = true;
      this.currentUsers.TabIndex = 2;
      this.currentUsers.SelectedIndexChanged += new System.EventHandler(this.currentUsers_SelectedIndexChanged);
      // 
      // teamMembers
      // 
      this.teamMembers.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.teamMembers.FormattingEnabled = true;
      this.teamMembers.ItemHeight = 20;
      this.teamMembers.Location = new System.Drawing.Point(725, 44);
      this.teamMembers.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.teamMembers.Name = "teamMembers";
      this.teamMembers.Size = new System.Drawing.Size(305, 244);
      this.teamMembers.Sorted = true;
      this.teamMembers.TabIndex = 3;
      this.teamMembers.SelectedIndexChanged += new System.EventHandler(this.teamMembers_SelectedIndexChanged);
      // 
      // add_button
      // 
      this.add_button.BackColor = System.Drawing.Color.Transparent;
      this.add_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.add_button.Location = new System.Drawing.Point(411, 73);
      this.add_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.add_button.Name = "add_button";
      this.add_button.Size = new System.Drawing.Size(256, 66);
      this.add_button.TabIndex = 4;
      this.add_button.Text = "Add To Team    -->";
      this.add_button.UseVisualStyleBackColor = false;
      this.add_button.Click += new System.EventHandler(this.add_button_Click);
      // 
      // remove_button
      // 
      this.remove_button.BackColor = System.Drawing.Color.Transparent;
      this.remove_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.remove_button.Location = new System.Drawing.Point(411, 188);
      this.remove_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.remove_button.Name = "remove_button";
      this.remove_button.Size = new System.Drawing.Size(256, 66);
      this.remove_button.TabIndex = 5;
      this.remove_button.Text = "<-- Remove From Team";
      this.remove_button.UseVisualStyleBackColor = false;
      this.remove_button.Click += new System.EventHandler(this.remove_button_Click);
      // 
      // finalize_button
      // 
      this.finalize_button.BackColor = System.Drawing.Color.Transparent;
      this.finalize_button.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.finalize_button.Location = new System.Drawing.Point(582, 405);
      this.finalize_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.finalize_button.Name = "finalize_button";
      this.finalize_button.Size = new System.Drawing.Size(216, 78);
      this.finalize_button.TabIndex = 6;
      this.finalize_button.Text = "Accept";
      this.finalize_button.UseVisualStyleBackColor = false;
      this.finalize_button.Click += new System.EventHandler(this.finalize_button_Click);
      // 
      // cancel_buttton
      // 
      this.cancel_buttton.BackColor = System.Drawing.Color.Transparent;
      this.cancel_buttton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancel_buttton.Location = new System.Drawing.Point(274, 405);
      this.cancel_buttton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.cancel_buttton.Name = "cancel_buttton";
      this.cancel_buttton.Size = new System.Drawing.Size(221, 78);
      this.cancel_buttton.TabIndex = 7;
      this.cancel_buttton.Text = "Cancel";
      this.cancel_buttton.UseVisualStyleBackColor = false;
      this.cancel_buttton.Click += new System.EventHandler(this.cancel_button_Click);
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(65, 312);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(226, 23);
      this.label3.TabIndex = 8;
      this.label3.Text = "Selected User\'s usermame:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(740, 310);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(275, 23);
      this.label4.TabIndex = 9;
      this.label4.Text = "Selected Teammate\'s usermame:";
      // 
      // usersUsername
      // 
      this.usersUsername.Location = new System.Drawing.Point(39, 335);
      this.usersUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.usersUsername.Name = "usersUsername";
      this.usersUsername.Size = new System.Drawing.Size(295, 22);
      this.usersUsername.TabIndex = 10;
      // 
      // teamateUsername
      // 
      this.teamateUsername.Location = new System.Drawing.Point(728, 335);
      this.teamateUsername.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.teamateUsername.Name = "teamateUsername";
      this.teamateUsername.Size = new System.Drawing.Size(299, 22);
      this.teamateUsername.TabIndex = 11;
      // 
      // addMembers
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.ForestGreen;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Large;
      this.ClientSize = new System.Drawing.Size(1062, 496);
      this.Controls.Add(this.teamateUsername);
      this.Controls.Add(this.usersUsername);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.cancel_buttton);
      this.Controls.Add(this.finalize_button);
      this.Controls.Add(this.remove_button);
      this.Controls.Add(this.add_button);
      this.Controls.Add(this.teamMembers);
      this.Controls.Add(this.currentUsers);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "addMembers";
      this.Text = "Add Team Members";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ListBox currentUsers;
    private System.Windows.Forms.ListBox teamMembers;
    private System.Windows.Forms.Button add_button;
    private System.Windows.Forms.Button remove_button;
    private System.Windows.Forms.Button finalize_button;
    private System.Windows.Forms.Button cancel_buttton;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox usersUsername;
    private System.Windows.Forms.TextBox teamateUsername;
  }
}