﻿using System;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Tags : Form
    {
        public Tags()
        {
            InitializeComponent();
        }
       
         readonly OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        public string Tipo { get; set; }
        public int ID { get; set; }
        public int Ref { get; set; }
        public bool Taken { get; set; }
        string querry;
        private void Tags_Load(object sender, EventArgs e)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.ConnectionString = Tables.Caminho;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel connectar á base de dados\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (Tipo == "Add")
            {
                querry = "SELECT MAX (ID) FROM tab_tags";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Ref.ToString();
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            button1.Select();
        }
        private void Button1_Click(object sender, EventArgs e)
        {



            if (int.TryParse(maskedTextBox2.Text, out _) == false)
            {
                sfToolTip1.Show("Verifique se todos os campos estão \ncorretos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                {
                    querry = "INSERT INTO tab_tags (ID, Ref, taken) " +
                               "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@Taken",
                        OleDbType.LongVarChar).Value = "Não";
                }
                else
                {







                    //-----------------------------------------

                    querry = "SELECT * FROM tab_tasks WHERE RefTag = '" + Ref + "'";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    string taken = (string)oleDbCommand.ExecuteScalar();
                    if (taken != null)
                    {
                        taken = "Não";
                    }
                    else
                    {
                        taken = "sim";
                    }


                    //--------------------------------------








                    querry = "UPDATE tab_tags  SET Ref = @Ref," +
                       " taken = @taken where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Ref", OleDbType.Integer).Value = maskedTextBox2.Text;
                    if (Taken == true)
                    {
                        oleDbCommand.Parameters.Add("@taken", OleDbType.LongVarChar).Value = taken;
                    }
                    else
                    {
                        oleDbCommand.Parameters.Add("@taken", OleDbType.LongVarChar).Value = taken;
                    }
                }
                try
                 {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                maskedTextBox1.Text = "";
                maskedTextBox2.Text = "";
                this.Close();
            }
        }
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
