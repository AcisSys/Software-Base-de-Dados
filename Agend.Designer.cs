using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    partial class Agend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agend));
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable1 = new Syncfusion.Windows.Forms.MetroColorTable();
            Syncfusion.Windows.Forms.MetroColorTable metroColorTable2 = new Syncfusion.Windows.Forms.MetroColorTable();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(this.components);
            this.sfComboBox1 = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.sfComboBox2 = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(95, 37);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.ReadOnly = true;
            this.maskedTextBox1.Size = new System.Drawing.Size(46, 20);
            this.maskedTextBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(12, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Equipa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tarefa:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 176);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(345, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.AutoToolTip = false;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "button1";
            this.toolStripButton1.Click += new System.EventHandler(this.Button1_Click);
            this.toolStripButton1.MouseLeave += new System.EventHandler(this.ToolStripButton1_MouseLeave);
            // 
            // sfComboBox1
            // 
            this.sfComboBox1.AllowFiltering = false;
            this.sfComboBox1.BeforeTouchSize = new System.Drawing.Size(238, 21);
            this.sfComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sfComboBox1.Filter = null;
            this.sfComboBox1.Location = new System.Drawing.Point(97, 77);
            this.sfComboBox1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.sfComboBox1.Name = "sfComboBox1";
            this.sfComboBox1.ScrollMetroColorTable = metroColorTable1;
            this.sfComboBox1.Size = new System.Drawing.Size(238, 21);
            this.sfComboBox1.TabIndex = 12;
            // 
            // sfComboBox2
            // 
            this.sfComboBox2.AllowFiltering = false;
            this.sfComboBox2.BeforeTouchSize = new System.Drawing.Size(238, 21);
            this.sfComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sfComboBox2.Filter = null;
            this.sfComboBox2.Location = new System.Drawing.Point(97, 117);
            this.sfComboBox2.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.sfComboBox2.Name = "sfComboBox2";
            this.sfComboBox2.ScrollMetroColorTable = metroColorTable2;
            this.sfComboBox2.Size = new System.Drawing.Size(238, 21);
            this.sfComboBox2.TabIndex = 13;
            // 
            // Agend
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 201);
            this.Controls.Add(this.sfComboBox2);
            this.Controls.Add(this.sfComboBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar / Modificar Programas";
            this.Load += new System.EventHandler(this.Agend_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaskedTextBox maskedTextBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox sfComboBox1;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox sfComboBox2;
    }
}