using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    partial class Subtasks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Subtasks));
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sfComboBox2 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.button1 = new System.Windows.Forms.ToolStripButton();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(85, 19);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(220, 20);
            this.maskedTextBox1.TabIndex = 0;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(84, 72);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(221, 20);
            this.maskedTextBox2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "IDTask:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Desc:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label4.Location = new System.Drawing.Point(12, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Type:";
            // 
            // sfComboBox2
            // 
            this.sfComboBox2.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBox2.Location = new System.Drawing.Point(85, 98);
            this.sfComboBox2.Name = "sfComboBox2";
            this.sfComboBox2.Size = new System.Drawing.Size(220, 21);
            this.sfComboBox2.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBox2.TabIndex = 10;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.button1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 147);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(328, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // button1
            // 
            this.button1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 22);
            this.button1.Text = "toolStripButton1";
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            this.button1.MouseLeave += new System.EventHandler(this.Button1_MouseLeave);
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(85, 45);
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(220, 20);
            this.maskedTextBox3.TabIndex = 12;
            // 
            // Subtasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 172);
            this.Controls.Add(this.maskedTextBox3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.sfComboBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Subtasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subtasks";
            this.Load += new System.EventHandler(this.Subtasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBox2;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
        private ToolStrip toolStrip1;
        private ToolStripButton button1;
        private MaskedTextBox maskedTextBox3;
    }
}