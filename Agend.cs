﻿using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Agend : Form
    {
        public Agend()
        {
            InitializeComponent();
        }
        DataSet dset = new DataSet();
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        static readonly string caminho = Tables.Caminho;
        string querry;
        public readonly OleDbConnection connection = new OleDbConnection(caminho);
        public string Tipo { get; set; }
        public int Id { get; set; }
        public string Idequipa { get; set; }
        public string Idtask { get; set; }
        private void Agend_Load(object sender, EventArgs e)
        {
            // Abre a conexao se a mesma estiver fechada
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
            // Caso seja para adicionar dados
            if (Tipo == "Add")
            {
                // ID é automatico
                string comand = "SELECT MAX (ID) FROM tab_agend";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            {
                maskedTextBox1.Text = Id.ToString();
            }
            maskedTextBox1.ReadOnly = true;
            maskedTextBox1.Enabled = false;
            // Bloco encarregue de adicionar as opções das 2 comboBox
            // Dados para ComboBox1
            querry = "SELECT * FROM tab_teams";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idteam");
            DataTable dataTable = dset.Tables["idteam"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";
            // Dados para ComboBox2
            querry = "SELECT * FROM tab_tasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            dataTable = dset.Tables["idtask"];
            sfComboBox2.DataSource = dataTable;
            sfComboBox2.DisplayMember = "ID";
            // Texto das ComboBox é o valor do campo ao modificar
            // ou nulo ao adicionar
            sfComboBox1.Text = Idequipa;
            sfComboBox2.Text = Idtask;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Verifica se todos os campos foram preenchidos
            if (sfComboBox1.SelectedItem == null || sfComboBox2.SelectedItem == null)
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");

            }
            else
            {
                if (sfComboBox1.SelectedItem == null)
                {
                    toolStripButton1.ToolTipText = "Verifique o preenchimento de todos os campos antes de validar dados";
                }
                OleDbCommand oleDbCommand;
                // Querry para adicionar dados
                if (Tipo == "Add")
                {
                    querry = "INSERT INTO tab_agend (ID, IDEquipa, IDTask)" +
                          "VALUES (@ID, @IDEquipa, @IDTask)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox2.Text;
                }
                // Cria Querry com o comando para update
                else
                {
                    querry = "UPDATE tab_agend  SET IDEquipa = @IDEquipa, IDTask = @IDTask where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox2.Text;
                }
                // Executa comando e envia feedback para o utilizador
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                // limpa todos os campos e fecha  a janela de introdução de dados
                maskedTextBox1.Text = "";
                sfComboBox1.Text = "";
                sfComboBox2.Text = "";
                this.Close();
            }
        }

        private void ToolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
