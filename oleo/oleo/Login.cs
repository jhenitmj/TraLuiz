using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oleo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Usuario obj = new Usuario();
            obj.Email = txtEmail.Text;
            obj.Senha = txtSenha.Text;
            try
            {
                var usuario = new UsuarioDAO().Logar(obj.Email, obj.Senha);
                if (!usuario.Email.Equals(txtEmail.Text))
                {
                    txtEmail.Clear();
                    MessageBox.Show("Eamil inválido", "Alerta", MessageBoxButtons.OK);
                }
                else if (!usuario.Senha.Equals(txtSenha.Text))
                {
                    txtSenha.Clear();
                    MessageBox.Show("Senha inválida", "Alerta", MessageBoxButtons.OK);
                }
                else
                {
                    Cadastros c = new Cadastros();
                    c.Show();
                    this.Hide();
                    MessageBox.Show("Sucesso");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
