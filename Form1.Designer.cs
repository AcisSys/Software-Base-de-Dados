﻿using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ToolStripButton Workers_Button;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Agend_Button = new System.Windows.Forms.ToolStripButton();
            this.Places_Button = new System.Windows.Forms.ToolStripButton();
            this.Tags_Button = new System.Windows.Forms.ToolStripButton();
            this.Teams_Button = new System.Windows.Forms.ToolStripButton();
            this.Tasks_Button = new System.Windows.Forms.ToolStripButton();
            this.SubTasks_Button = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            Workers_Button = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Workers_Button
            // 
            Workers_Button.AccessibleDescription = "A button leading for the table \"Workers\" from the database";
            Workers_Button.AccessibleName = "Workers Button";
            Workers_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            Workers_Button.AutoSize = false;
            Workers_Button.Image = ((System.Drawing.Image)(resources.GetObject("Workers_Button.Image")));
            Workers_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            Workers_Button.Name = "Workers_Button";
            Workers_Button.Size = new System.Drawing.Size(60, 40);
            Workers_Button.Text = "Workers";
            Workers_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            Workers_Button.Click += new System.EventHandler(this.Workers_Button_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AccessibleDescription = "A bar with buttons leading to each table of the database";
            this.toolStrip1.AccessibleName = "Menu Bar";
            this.toolStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Agend_Button,
            this.Places_Button,
            this.Tags_Button,
            Workers_Button,
            this.Teams_Button,
            this.Tasks_Button,
            this.SubTasks_Button});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1138, 60);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Agend_Button
            // 
            this.Agend_Button.AccessibleDescription = "A button leading for the table \"Agend\" from the database";
            this.Agend_Button.AccessibleName = "Agend Button";
            this.Agend_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Agend_Button.AutoSize = false;
            this.Agend_Button.Image = ((System.Drawing.Image)(resources.GetObject("Agend_Button.Image")));
            this.Agend_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Agend_Button.Name = "Agend_Button";
            this.Agend_Button.Size = new System.Drawing.Size(60, 40);
            this.Agend_Button.Text = "Agend";
            this.Agend_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Agend_Button.Click += new System.EventHandler(this.Agend_Button_Click);
            // 
            // Places_Button
            // 
            this.Places_Button.AccessibleDescription = "A button leading for the table \"Places\" from the database";
            this.Places_Button.AccessibleName = "Places Button";
            this.Places_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Places_Button.AutoSize = false;
            this.Places_Button.Image = ((System.Drawing.Image)(resources.GetObject("Places_Button.Image")));
            this.Places_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Places_Button.Name = "Places_Button";
            this.Places_Button.Size = new System.Drawing.Size(60, 40);
            this.Places_Button.Text = "Places";
            this.Places_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Places_Button.Click += new System.EventHandler(this.Places_Button_Click);
            // 
            // Tags_Button
            // 
            this.Tags_Button.AccessibleDescription = "A button leading for the table \"Tags\" from the database";
            this.Tags_Button.AccessibleName = "Tags Button";
            this.Tags_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Tags_Button.AutoSize = false;
            this.Tags_Button.Image = ((System.Drawing.Image)(resources.GetObject("Tags_Button.Image")));
            this.Tags_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tags_Button.Name = "Tags_Button";
            this.Tags_Button.Size = new System.Drawing.Size(60, 40);
            this.Tags_Button.Text = "Tags";
            this.Tags_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Tags_Button.Click += new System.EventHandler(this.Tags_Button_Click);
            // 
            // Teams_Button
            // 
            this.Teams_Button.AccessibleDescription = "A button leading for the table \"Teams\" from the database";
            this.Teams_Button.AccessibleName = "Teams button";
            this.Teams_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Teams_Button.AutoSize = false;
            this.Teams_Button.Image = ((System.Drawing.Image)(resources.GetObject("Teams_Button.Image")));
            this.Teams_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Teams_Button.Name = "Teams_Button";
            this.Teams_Button.Size = new System.Drawing.Size(60, 40);
            this.Teams_Button.Text = "Teams";
            this.Teams_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Teams_Button.Click += new System.EventHandler(this.Teams_Button_Click);
            // 
            // Tasks_Button
            // 
            this.Tasks_Button.AccessibleDescription = "A button leading for the table \"Tasks\" from the database";
            this.Tasks_Button.AccessibleName = "Tasks button";
            this.Tasks_Button.AutoSize = false;
            this.Tasks_Button.Image = ((System.Drawing.Image)(resources.GetObject("Tasks_Button.Image")));
            this.Tasks_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tasks_Button.Name = "Tasks_Button";
            this.Tasks_Button.Size = new System.Drawing.Size(60, 40);
            this.Tasks_Button.Text = "Tasks";
            this.Tasks_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Tasks_Button.Click += new System.EventHandler(this.Tasks_Button_Click);
            // 
            // SubTasks_Button
            // 
            this.SubTasks_Button.AccessibleDescription = "A button leading for the table \"SubTasks\" from the database";
            this.SubTasks_Button.AccessibleName = "Subtasks Button";
            this.SubTasks_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.SubTasks_Button.AutoSize = false;
            this.SubTasks_Button.Image = ((System.Drawing.Image)(resources.GetObject("SubTasks_Button.Image")));
            this.SubTasks_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SubTasks_Button.Name = "SubTasks_Button";
            this.SubTasks_Button.Size = new System.Drawing.Size(60, 40);
            this.SubTasks_Button.Text = "SubTasks";
            this.SubTasks_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.SubTasks_Button.Click += new System.EventHandler(this.SubTasks_Button_Click);
            // 
            // panel1
            // 
            this.panel1.AccessibleDescription = "Panel that changes according to button pressed on the MenuBar";
            this.panel1.AccessibleName = "Panel 1";
            this.panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(0, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1138, 685);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Software Base de Dados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton Agend_Button;
        private ToolStripButton Places_Button;
        private ToolStripButton Tags_Button;
        private ToolStripButton Teams_Button;
        private ToolStripButton Tasks_Button;
        private ToolStripButton SubTasks_Button;
        private Panel panel1;
        
    }
}