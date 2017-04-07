namespace Co_Op_Swift
{
    partial class Story
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
      this.nameTB = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.descTB = new System.Windows.Forms.TextBox();
      this.button1 = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(16, 20);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(71, 26);
      this.label1.TabIndex = 0;
      this.label1.Text = "Name:";
      // 
      // nameTB
      // 
      this.nameTB.Location = new System.Drawing.Point(21, 49);
      this.nameTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.nameTB.Multiline = true;
      this.nameTB.Name = "nameTB";
      this.nameTB.Size = new System.Drawing.Size(201, 24);
      this.nameTB.TabIndex = 1;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(16, 86);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(121, 26);
      this.label2.TabIndex = 2;
      this.label2.Text = "Description:";
      // 
      // descTB
      // 
      this.descTB.Location = new System.Drawing.Point(21, 114);
      this.descTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.descTB.Multiline = true;
      this.descTB.Name = "descTB";
      this.descTB.Size = new System.Drawing.Size(201, 94);
      this.descTB.TabIndex = 3;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.Transparent;
      this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.Location = new System.Drawing.Point(21, 226);
      this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(201, 48);
      this.button1.TabIndex = 4;
      this.button1.Text = "Create";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // Story
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small1;
      this.ClientSize = new System.Drawing.Size(241, 298);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.descTB);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.nameTB);
      this.Controls.Add(this.label1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "Story";
      this.Text = "Story";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Button button1;
    }
}