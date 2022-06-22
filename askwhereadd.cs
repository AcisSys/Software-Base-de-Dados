using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            List<string> answers = new List<string>();
            answers.Add("tarefas");
            answers.Add("subtarefas");
            sfComboBox1.DataSource = answers;
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
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
                sfToolTip1.Show("Selecione a tabela na qual deseja adicionar dados");
            }
        }

        private void toolStripButton1_MouseLeave(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
    }
}
