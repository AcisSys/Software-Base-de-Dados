using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Subtasks : Form
    {
        public Subtasks()
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

        public string Tipo { get; set; }

        // String / Int para cada campo da tabela
        public int ID { get; set; }
        public string IDTask { get; set; }
        public string Desc { get; set; }
        public string Type { get; set; }
        private void Subtasks_Load(object sender, EventArgs e)
        {

            // Verifica conexao
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
            if (Tipo == "Add")
            {
                button1.Text = "Guardar";

                // ID é automatico


                string comand = "SELECT MAX (ID) FROM tab_tasks";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();

                // Disable campo ID

                maskedTextBox1.ReadOnly = true;
                maskedTextBox1.Enabled = false;
            }
            else
            {
                button1.Text = "Modificar";

                maskedTextBox1.Text = ID.ToString();
                sfComboBox1.Text = IDTask;
                maskedTextBox2.Text = Desc;
                sfComboBox2.Text = Type;


                maskedTextBox1.ReadOnly = true;
                maskedTextBox1.Enabled = false;
            }


            // Dados para ComboBox1
            string querry = "SELECT * FROM tab_tasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";

            // Dados para ComboBox2
            querry = "SELECT DISTINCT Type FROM tab_subtasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "type");
            dataTable = dset.Tables["type"];
                sfComboBox2.DataSource = dataTable;
            sfComboBox2.DisplayMember = "Type";

            button1.Select();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Tipo == "Add")
            {
                // querry para adicionar dados
                string querry = "INSERT INTO tab_subtasks (ID, IDTask, Desc, Type)" +
                         "VALUES (@ID, @IDTask, @Desc, @Type)";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox1.Text;
                oleDbCommand.Parameters.Add("@Desc", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@Type", OleDbType.LongVarChar).Value = sfComboBox2.Text;
                // tenta executar o comando e envia mensagem de sucesso / erro
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {

                // string para atualizar dados
                string querry = "UPDATE tab_subtasks IDTask = @IDTask, Desc = @Desc, Type = @Type" +
                         "WHERE ID =" + maskedTextBox1.Text;
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@IDTask", OleDbType.Integer).Value = sfComboBox1.Text;
                oleDbCommand.Parameters.Add("@Desc", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@Type", OleDbType.LongVarChar).Value = sfComboBox2.Text;
                // tenta executar o comando e envia mensagem de erro / sucesso
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message,
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Select();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Select();
        }
    }
}
