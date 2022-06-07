﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }
        static readonly string caminho = Tables.Caminho;
        public readonly OleDbConnection connection = new OleDbConnection(caminho);
        DataSet dset = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string IDEquipa { get; set; }
        public string Img { get; set; }
        public string Cod { get; set; }
        string querry;
        private void Workers_Load(object sender, EventArgs e)
        {
            // verifica conexao
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
                // ID é automatico
                querry = "SELECT MAX (ID) FROM tab_workers";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox4.Text = Img;
                maskedTextBox5.Text = Cod;
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.Select();
            maskedTextBox1.Enabled = false;
            // Dados para ComboBox1
            //string querry = "SELECT tab_workers.IDEquipa, tab_teams.Descricao FROM tab_teams INNER JOIN tab_workers ON tab_teams.ID = tab_workers.IDEquipa;";
            querry = "SELECT tab_workers.IDEquipa, tab_teams.Descricao FROM tab_teams, tab_workers WHERE tab_workers.IDEquipa = '3';";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";
            sfComboBox1.Text = IDEquipa;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // Verifica o preenchimento de todos os campos
            if (maskedTextBox2.Text == null || maskedTextBox4.Text == null || sfComboBox1.SelectedItem == null
                || maskedTextBox5.Text == null)
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                // querry e parametros para adicionar dados
                {
                    querry = "INSERT INTO tab_workers (ID, Nome, IDEquipa, img, Cod)" +
                           "VALUES (@ID, @Nome, @IDEquipa, @img, @Cod)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                    oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                }
                else
                {
                    // querry e parametros para modificar dados
                    querry = "UPDATE tab_workers  SET Nome = @Nome," +
                           " IDEquipa = @IDEequipa, img = @img, Cod = @Cod where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                    oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                }
                // Executa Comando e envia feedback ao utilizador (erro ou sucesso)
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel atualizar dados\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados atualizados com sucesso", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedTextBox4.Select();
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
