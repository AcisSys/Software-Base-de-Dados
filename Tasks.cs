using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Tasks : Form
    {
        public Tasks()
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
        private void Tasks_Load(object sender, EventArgs e)
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
            if (tipo == "Add")
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
                comboBox1.Select();
                maskedTextBox1.Enabled = false;
            }
            else
            {
                button1.Text = "Modificar";
            }


            // Dados para ComboBox1
            string querry = "SELECT * FROM tab_places";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            comboBox1.DataSource = dataTable;
            comboBox1.DisplayMember = "ID";

            // Dados para ComboBox2
            querry = "SELECT DISTINCT Ref FROM tab_tags";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "type");
            dataTable = dset.Tables["type"];
            comboBox2.DataSource = dataTable;
            comboBox2.DisplayMember = "Ref";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string active;
            if (checkBox1.Checked == true)
            {
                active = "Sim";
            }
            else
            {
                active = "Não";
            }
            if (tipo == "Add")
            {

                string querry = "INSERT INTO tab_tasks (ID, Descricao, IDPlace, Active, RefTag)" +
                         "VALUES (@ID, @Descricao, @IDPlace, @Active, @RefTag)";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                oleDbCommand.Parameters.Add("@Descricao", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                oleDbCommand.Parameters.Add("@IDPlace", OleDbType.Integer).Value = comboBox1.Text;
                oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = active;
                oleDbCommand.Parameters.Add("@RefTag", OleDbType.Integer).Value = comboBox2.Text;
                
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
    }
}
