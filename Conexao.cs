using System;
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
            Tables tables = new Tables();
            if (textBox1.Text != null)
            {
                Tables.caminho = textBox1.Text.ToString();
            }
            this.Close();
        }
    }
}
