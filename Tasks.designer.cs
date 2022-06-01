using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    partial class Tasks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tasks));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.sfComboBox1 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.sfComboBox2 = new Syncfusion.WinForms.ListView.SfComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Button1 = new System.Windows.Forms.ToolStripButton();
            this.sfToolTip1 = new Syncfusion.Windows.Forms.SfToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(88, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(88, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descricao:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label3.Location = new System.Drawing.Point(88, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "IDPlace";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(88, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "RefTag:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(215, 31);
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(107, 20);
            this.maskedTextBox1.TabIndex = 5;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(215, 57);
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(107, 20);
            this.maskedTextBox2.TabIndex = 6;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(215, 135);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 25);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "Active";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // sfComboBox1
            // 
            this.sfComboBox1.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBox1.Location = new System.Drawing.Point(215, 83);
            this.sfComboBox1.Name = "sfComboBox1";
            this.sfComboBox1.Size = new System.Drawing.Size(107, 21);
            this.sfComboBox1.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBox1.TabIndex = 11;
            // 
            // sfComboBox2
            // 
            this.sfComboBox2.DropDownPosition = Syncfusion.WinForms.Core.Enums.PopupRelativeAlignment.Center;
            this.sfComboBox2.Location = new System.Drawing.Point(215, 107);
            this.sfComboBox2.Name = "sfComboBox2";
            this.sfComboBox2.Size = new System.Drawing.Size(107, 22);
            this.sfComboBox2.Style.TokenStyle.CloseButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sfComboBox2.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Button1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 192);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(373, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Button1
            // 
            this.Button1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.Button1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Button1.Image = ((System.Drawing.Image)(resources.GetObject("Button1.Image")));
            this.Button1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(23, 22);
            this.Button1.Text = "toolStripButton1";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            this.Button1.MouseLeave += new System.EventHandler(this.Button1_MouseLeave);
            // 
            // Tasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 217);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.sfComboBox2);
            this.Controls.Add(this.sfComboBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Tasks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar / Remover Tarefas";
            this.Load += new System.EventHandler(this.Tasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfComboBox2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label5;
        private MaskedTextBox maskedTextBox1;
        private MaskedTextBox maskedTextBox2;
        private CheckBox checkBox1;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBox1;
        private Syncfusion.WinForms.ListView.SfComboBox sfComboBox2;
        private ToolStrip toolStrip1;
        private ToolStripButton Button1;
        private Syncfusion.Windows.Forms.SfToolTip sfToolTip1;
    }
}