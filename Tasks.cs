using System;
using System.Data;
using System.Data.OleDb;
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

        static readonly string caminho = Tables.Caminho;

        // Conexão

        public readonly OleDbConnection connection = new OleDbConnection(caminho);

        // DataSet para as tabelas

        DataSet dset = new DataSet();

        // Adaptador para o DataSet

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        // String publica para dar a conhecer a table que está a ser visualisada

        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Descricao { get; set; }
        public string IDPlace { get; set; }
        public bool Active { get; set; }
        public string RefTag { get; set; }
        string querry;

        private void Tasks_Load(object sender, EventArgs e)
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
                // ID é automatico
                string comand = "SELECT MAX (ID) FROM tab_tasks";
                OleDbCommand oleDbCommand = new OleDbCommand(comand, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();

            }
            else
            {
                maskedTextBox1.Text = ID.ToString();
                maskedTextBox2.Text = Descricao;
                if (Active == true)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
            }

            // Dados para ComboBox1
            querry = "SELECT * FROM tab_places";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idtask");
            DataTable dataTable = dset.Tables["idtask"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";

            // Dados para ComboBox2
            querry = "SELECT Ref FROM tab_tags WHERE taken = 'Não'";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "type");
            dataTable = dset.Tables["type"];
            sfComboBox2.DataSource = dataTable;
            sfComboBox2.DisplayMember = "Ref";
            sfComboBox1.Text = IDPlace;
            sfComboBox2.Text = RefTag;
            maskedTextBox1.ReadOnly = true;
            Button1.Select();
            maskedTextBox1.Enabled = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox2.Text == "" || sfComboBox1.SelectedItem == null || sfComboBox2.SelectedItem == null)
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {

                OleDbCommand oleDbCommand;
                string active;
                if (checkBox1.Checked == true)
                {
                    active = "Sim";
                }
                else
                {
                    active = "Não";
                }
                if (Tipo == "Add")
                {
                    // querry para adicionar dados a tabela
                    querry = "INSERT INTO tab_tasks (ID, Descricao, IDPlace, Active, RefTag)" +
                            "VALUES (@ID, @Descricao, @IDPlace, @Active, @RefTag)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Descricao", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDPlace", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = active;
                    oleDbCommand.Parameters.Add("@RefTag", OleDbType.Integer).Value = sfComboBox2.Text;

                }
                else
                {
                    querry = "UPDATE tab_tasks  Descricao = @Descricao, IDPlace = @IDPlace, Active = @Active, RefTag = @RefTag" +
                       " where ID = " + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    // Recebe os dados
                    oleDbCommand.Parameters.Add("@Descricao", OleDbType.Integer).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDPlace", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = active;
                    oleDbCommand.Parameters.Add("@RefTag", OleDbType.Integer).Value = sfComboBox2.Text;
                }
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
                querry = "UPDATE tab_tags SET taken = @taken WHERE Ref = " + sfComboBox2.Text;
                OleDbCommand ole = new OleDbCommand(querry, connection);
                ole.Parameters.Add("@taken", OleDbType.LongVarChar).Value = "Sim";
                ole.ExecuteNonQuery();
                // FeedBack de sucesso ou erro
                MessageBox.Show("Dados modificados com sucesso", "",
                    MessageBoxButtons.OK
                    , MessageBoxIcon.Information);
                // limpa todos os campos e fecha  a janela de introdução de dados
                maskedTextBox1.Text = "";
                sfComboBox1.Text = "";
                sfComboBox2.Text = "";
                this.Close();
            }
        }

        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
