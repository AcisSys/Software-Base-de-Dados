using System;
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


        // String do caminho do ficheiro

        static readonly string caminho = @"Provider = Microsoft.ACE.OLEDB.12.0;
                        Data Source = WORK2GOData.accdb;
        Jet OLEDB:Database Password = ogednom ";

        // Conexão

        public readonly OleDbConnection connection = new OleDbConnection(caminho);

        // DataSet para as tabelas

        DataSet dset = new DataSet();

        // Adaptador para o DataSet

        OleDbDataAdapter adapter = new OleDbDataAdapter();


        // String publica para dar a conhecer a table que está a ser visualisada

        public string tipo { get; set; }



        private void Agend_Load(object sender, EventArgs e)
        {

            // Abre a conexao se a mesma estiver fechada
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel connectar á base de dados\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Caso seja para adicionar dados
            if (tipo == "Add")
            {
                button1.Text = "Guardar";

                // ID é automatico


                string comand = "SELECT MAX (ID) FROM tab_agend";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();

                // Disable campo ID

                maskedTextBox1.ReadOnly = true;
                comboBox1.Select();
                maskedTextBox1.Enabled = false;
            }
            else
            {

                // Case seja para modificar dados
                button1.Text = "Modificar";

                // Utilizador necessita de introduzir o ID
                maskedTextBox1.ReadOnly = false;
            }



            // Bloco encarregue de adicionar as opções das 2 comboBox

            // Dados para ComboBox1
            string querry = "SELECT * FROM tab_teams";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idteam");
            DataTable dataTable = dset.Tables["idteam"];
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "ID";

            // Dados para ComboBox2
            querry = "SELECT * FROM tab_tasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            dataTable = dset.Tables["idtask"];
            comboBox2.DataSource = dataTable;
            comboBox2.DisplayMember = "ID";

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tipo == "Add")
            {

                // Querry para adicionar dados
                string querry = "INSERT INTO tab_agend (ID, IDEquipa, IDTask)" +
                       "VALUES (@ID, @IDEquipa, @IDTask)";

                // Parametros com dados a adicionar

                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = comboBox1.Text;
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = comboBox2.Text;

                // Executa comando
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // mostra mensagem de erro caso necessário
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // mostra feedback caso os dados sejam adicionados
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else
            {
                // Cria Querry com o comando para UPDATe

                string querry = "UPDATE tab_agend  SET IDEquipa = @IDEquipa," +
                    " IDTask = @IDTask where ID = " + maskedTextBox1.Text;

                // Cria comando
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);

                // Recebe os dados
                oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = comboBox1.Text;
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = comboBox2.Text;

                // Executa o Comando
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel modificar dados\n" + ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // FeedBack de sucesso ou erro
                MessageBox.Show("Dados modificados com sucesso", "",
                    MessageBoxButtons.OK
                    , MessageBoxIcon.Information);

            }

            // limpa todos os campos e fecha  a janela de introdução de dados
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
