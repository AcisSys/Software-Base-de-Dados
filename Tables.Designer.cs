using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    partial class Tables
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tables));
            this.Add_Button = new System.Windows.Forms.Button();
            this.Modify_Button = new System.Windows.Forms.Button();
            this.Remove_Button = new System.Windows.Forms.Button();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.sfDataGrid2 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // Add_Button
            // 
            this.Add_Button.AccessibleDescription = "Button to add Entries to the Data Chart";
            this.Add_Button.AccessibleName = " Add Entries";
            this.Add_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.Image = ((System.Drawing.Image)(resources.GetObject("Add_Button.Image")));
            this.Add_Button.Location = new System.Drawing.Point(944, 445);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(191, 75);
            this.Add_Button.TabIndex = 1;
            this.Add_Button.Text = "Adicionar";
            this.Add_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Modify_Button
            // 
            this.Modify_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Modify_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Modify_Button.Image = ((System.Drawing.Image)(resources.GetObject("Modify_Button.Image")));
            this.Modify_Button.Location = new System.Drawing.Point(944, 526);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(191, 75);
            this.Modify_Button.TabIndex = 2;
            this.Modify_Button.Text = "Modificar";
            this.Modify_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Modify_Button.UseVisualStyleBackColor = true;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Remove_Button
            // 
            this.Remove_Button.AccessibleDescription = "To delete entries of the Data Chart";
            this.Remove_Button.AccessibleName = "Erase Button";
            this.Remove_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Remove_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_Button.Image = ((System.Drawing.Image)(resources.GetObject("Remove_Button.Image")));
            this.Remove_Button.Location = new System.Drawing.Point(944, 607);
            this.Remove_Button.Name = "Remove_Button";
            this.Remove_Button.Size = new System.Drawing.Size(191, 75);
            this.Remove_Button.TabIndex = 3;
            this.Remove_Button.Text = "Apagar";
            this.Remove_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Remove_Button.UseVisualStyleBackColor = true;
            this.Remove_Button.Click += new System.EventHandler(this.Remove_Button_Click);
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.AllowEditing = false;
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfDataGrid1.Location = new System.Drawing.Point(3, 0);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(938, 426);
            this.sfDataGrid1.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfDataGrid1.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid1.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid1.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid1.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid1.TabIndex = 4;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.sfDataGrid1_SelectionChanged);
            // 
            // sfDataGrid2
            // 
            this.sfDataGrid2.AccessibleName = "Table";
            this.sfDataGrid2.Location = new System.Drawing.Point(0, 432);
            this.sfDataGrid2.Name = "sfDataGrid2";
            this.sfDataGrid2.Size = new System.Drawing.Size(938, 207);
            this.sfDataGrid2.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfDataGrid2.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid2.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid2.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid2.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDataGrid2.TabIndex = 5;
            this.sfDataGrid2.Text = "sfDataGrid2";
            // 
            // Tables
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.sfDataGrid2);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.Remove_Button);
            this.Controls.Add(this.Modify_Button);
            this.Controls.Add(this.Add_Button);
            this.Name = "Tables";
            this.Size = new System.Drawing.Size(1138, 685);
            this.Load += new System.EventHandler(this.Tables_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button Add_Button;
        private Button Modify_Button;
        private Button Remove_Button;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid2;
    }
}
