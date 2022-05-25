using System;
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

        private void Workers_Load(object sender, EventArgs e)
        {
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


                string comand = "SELECT MAX (ID) FROM tab_workers";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();

                // Disable campo ID

                maskedTextBox1.ReadOnly = true;
                maskedTextBox2.Select();
                maskedTextBox1.Enabled = false;
            }
            else
            {
                button1.Text = "Modificar";
            }

            // Dados para ComboBox1
            string querry = "SELECT * FROM tab_tasks";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "ID";
        }


        private void Button1_Click(object sender, EventArgs e)
        {
            if (Tipo == "Add")
            {
                string querry = "INSERT INTO tab_workers (ID, Nome, IDEquipa, img, Cod)" +
                        "VALUES (@ID, @Nome, @IDEquipa, @img, @Cod)";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = comboBox1.Text;
                oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel inserir dados\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados adicionados com sucesso", "", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                string querry = "UPDATE tab_workers  SET Nome = @Nome," +
                        " IDEquipa = @IDEequipa, img = @img, Cod = @Cod where ID = " + maskedTextBox1.Text;
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = comboBox1.Text;
                oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel modificar dados\n" + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Dados modificados com sucesso", "",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }


    }
}
