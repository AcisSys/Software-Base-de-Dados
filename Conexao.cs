using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Conexao : Form
    {
        public Conexao()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            if (textBox1.Text != "" && textBox1.Text != null)
            {
                try
                {
                    con.Open();
                    Tables.caminho = textBox1.Text.ToString();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na conexão, verifique o caminho do ficheiro\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cancelado", null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
