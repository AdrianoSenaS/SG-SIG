using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG_SIG
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            string database = Properties.Settings.Default.database;
            InitializeComponent();
            var value = Banco.SelectSum(database,  "VALOR", "CONTAS_PAGAR");
            labelContasPagar.Text = string.Format("{0:c}", value);
            value = Banco.SelectSum(database, "VALOR", "CONTAS_RECEBER");
            labelContasReceber.Text = string.Format("{0:c}", value);
            value = Banco.SelectSum(database, "VALOR", "CONTAS_ATRASADAS");
            labelContasAtrasadas.Text = string.Format("{0:c}", value);
            labelBoasVindas.Text = "Bem vindo(a) " + Properties.Settings.Default.usuario;
        }

        private void gunaCircleButtonFechar_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Tem certeza que deseja fechar o sistema?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void gunaCircleButtonMinimizar_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;
        }

        private void gunaCircleButtonSair_Click(object sender, EventArgs e)
        {
            CadastrarLogin cadastrarLogin = new CadastrarLogin();
            this.Hide();
            cadastrarLogin.ShowDialog();
            this.Close();
        }
    }
}
