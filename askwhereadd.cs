using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class askwhereadd : Form
    {
        public askwhereadd()
        {
            InitializeComponent();
        }
        public int answer;

        private void askwhereadd_Load(object sender, EventArgs e)
        {
            // Cria uma lista de entradas para a combobox
            List<string> answers = new List<string>();
            answers.Add("tarefas");
            answers.Add("subtarefas");
            sfComboBox1.DataSource = answers;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            // Caso (Resposta selecionada na combobox)
            if (sfComboBox1.Text == "tarefas")
            {
                answer = 1;
                this.Close();
            }
            else if (sfComboBox1.Text == "subtarefas")
            {
                answer = 2;
                this.Close();
            }
            else
            {
                // Obriga o utilizar a escolher uma das opções da combobox
                sfToolTip1.Show("Selecione a tabela na qual deseja adicionar dados");
            }
        }

        private void toolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
