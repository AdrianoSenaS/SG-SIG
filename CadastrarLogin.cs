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
    public partial class CadastrarLogin : Form
    {
        bool Cadastro;
        string Email;
        string database = "Data Source = C:\\SG-SIG setup informatica\\DATABASE\\DATABASE.db";
        public CadastrarLogin()
        {
            InitializeComponent();
            if (Properties.Settings.Default.database == string.Empty)
            {
                Properties.Settings.Default.database = database;
                Properties.Settings.Default.Save();
            }

            Cadastro = Properties.Settings.Default.Cadastro;
            if (Cadastro == true && Email != string.Empty)
            {
                panelCadastrar.Visible = true;
                panelCodigo.Visible = true;
                panelLogin.Visible = true;
                

            }
           
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
           var result = MessageBox.Show("Tem certeza que deseja fechar o sistema?", "Alerta!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void gunaTextBoxEmailIns_Click(object sender, EventArgs e)
        {
            gunaTextBoxEmailIns.Text = string.Empty;
        }

        private void gunaButtonCadastrar_Click(object sender, EventArgs e)
        {
            if (gunaTextBoxEmailIns.Text == string.Empty || gunaTextBoxEmailIns.Text == "Digite seu email")
            {
                MessageBox.Show("Digite seu código para continuar", "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                Properties.Settings.Default.email = gunaTextBoxEmailIns.Text;
                Properties.Settings.Default.Save();
                panelCodigo.Visible = true;
            }
        }

        private void gunaButtonFacaLogin_Click(object sender, EventArgs e)
        {
            panelinicio.Visible = true;
            panelCadastrar.Visible = true;
            panelCodigo.Visible = true;
            panelLogin.Visible = true;
        }

        private void gunaTextBoxCodigo_Enter(object sender, EventArgs e)
        {
            gunaTextBoxCodigo.Text = string.Empty;
        }

        private void gunaButtonCodigo_Click(object sender, EventArgs e)
        {
            if (gunaTextBoxCodigo.Text == string.Empty||gunaTextBoxCodigo.Text== "Digite seu Código")
            {
                MessageBox.Show("Digite seu código para continuar", "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                panelCadastrar.Visible = true;
            }
        }

        private void gunaButtonReenviar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Foi enviado um novo código para seu email", "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gunaTextBoxUsuario_Enter(object sender, EventArgs e)
        {
            gunaTextBoxUsuario.Text = string.Empty;
        }

        private void gunaTextBoxSenha_Enter(object sender, EventArgs e)
        {
            gunaTextBoxSenha.Text = string.Empty;
        }

        private void gunaButtonCadastrarUsuario_Click(object sender, EventArgs e)
        {
            if(gunaTextBoxUsuario.Text == string.Empty && gunaTextBoxSenha.Text == string.Empty)
            {
                
                MessageBox.Show("Preencha todos os campos", "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Properties.Settings.Default.usuario = gunaTextBoxUsuario.Text;
                Properties.Settings.Default.senha = gunaTextBoxSenha.Text;
                Properties.Settings.Default.Cadastro = true;
                Properties.Settings.Default.Save();
                panelLogin.Visible = true;
            }
        }

        private void gunaTextBoxUsuarioLogin_Enter(object sender, EventArgs e)
        {
            gunaTextBoxUsuarioLogin.Text = string.Empty;
        }

        private void gunaTextBoxSenhaLogin_Enter(object sender, EventArgs e)
        {
            gunaTextBoxSenhaLogin.Text = string.Empty;
        }

        private void gunaButtonlogin_Click(object sender, EventArgs e)
        {

            var result = Banco.GetAll(database, "USUARIOS").AsEnumerable().ToList();

            foreach (var item in result)
            {
                if (gunaTextBoxUsuarioLogin.Text == item.Field<string>("USUARIO") && gunaTextBoxSenhaLogin.Text == item.Field<string>("SENHA"))
                {
                    Properties.Settings.Default.usuario = gunaTextBoxUsuarioLogin.Text+" "+ item.Field<string>("SOBRE_NOME");
                    Properties.Settings.Default.senha = gunaTextBoxSenhaLogin.Text;
                    Properties.Settings.Default.Cadastro = true;
                    Properties.Settings.Default.Save();
                    Inicio inicio =
                   new Inicio();
                    this.Hide();
                    inicio.ShowDialog();
                    this.Close();
                }
               
            }
            MessageBox.Show("Usuário ou senha inválidos", "Notificação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
