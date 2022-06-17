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
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);

        public string Tipo { get; set; }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string IDEquipa { get; set; }
        public string Img { get; set; }
        public string Cod { get; set; }
        string querry;
        private void Workers_Load(object sender, EventArgs e)
        {
            // check connection 
            if (connection.State == ConnectionState.Closed)
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
            // Add Data
            if (Tipo == "Add")
            {
                // Get new ID
                querry = "SELECT MAX (ID) FROM tab_workers";
                OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                int maxid = (int)oleDbCommand.ExecuteScalar();
                int currentid = maxid + 1;
                maskedTextBox1.Text = currentid.ToString();
            }
            else
            // Modify data
            {
                maskedTextBox1.Text = ID.ToString();
            }
            DataSet dset = new DataSet();
            OleDbDataAdapter adapter;
            maskedTextBox1.ReadOnly = true;
            maskedTextBox2.Text = Name;
            maskedTextBox4.Text = Img;
            maskedTextBox5.Text = Cod;
            maskedTextBox1.Enabled = false;
            button1.Select();
            querry = "SELECT ID, Descricao FROM tab_teams";
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "idteam");
            DataTable dataTable = dset.Tables["idteam"];
            sfComboBox1.DataSource = dataTable;
            sfComboBox1.DisplayMember = "ID";
            sfComboBox1.Text = IDEquipa;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            // Check if all fields are written
            if (maskedTextBox2.Text == null || maskedTextBox4.Text == null || sfComboBox1.SelectedItem == null
                || maskedTextBox5.Text == null)
            {
                sfToolTip1.Show("Verifique o preenchimento de todos os campos antes de validar dados!");
            }
            else
            {
                // check data type
                bool a = int.TryParse(maskedTextBox5.Text, out int maskedbox5);
                if (a != true)
                {
                    // return if not int / a number
                    sfToolTip1.Show("Foram detetados dados incorretos\n verifique os dados introduzidos");
                    return;
                }
                OleDbCommand oleDbCommand;
                if (Tipo == "Add")
                    //add data
                {
                    querry = "INSERT INTO tab_workers (ID, Nome, IDEquipa, img, Cod) VALUES (@ID, @Nome, @IDEquipa, @img, @Cod)";
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@ID", OleDbType.Integer).Value = maskedTextBox1.Text;
                    oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                    oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                }
                else
                // modify data
                {
                    querry = "UPDATE tab_workers  SET Nome = @Nome, IDEquipa = @IDEequipa, img = @img, Cod = @Cod where ID = "
                        + maskedTextBox1.Text;
                    oleDbCommand = new OleDbCommand(querry, connection);
                    oleDbCommand.Parameters.Add("@Nome", OleDbType.LongVarChar).Value = maskedTextBox2.Text;
                    oleDbCommand.Parameters.Add("@IDEquipa", OleDbType.Integer).Value = sfComboBox1.Text;
                    oleDbCommand.Parameters.Add("@img", OleDbType.LongVarChar).Value = maskedTextBox4.Text;
                    oleDbCommand.Parameters.Add("@Cod", OleDbType.Integer).Value = maskedTextBox5.Text;
                }
                try
                {
                    // execute command
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
        private void Button1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
        private void Workers_FormClosed(object sender, FormClosedEventArgs e)
        {
            sfComboBox1.Text = "";
        }
    }
}
