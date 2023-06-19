using Clinica.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinica.UI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void ValidateUser(string user, string pass)
        {
            bool result;
            LoginBusiness business = new LoginBusiness();
            result = business.ValidateUserCredentials(user, pass);
            if (result)
            {
                this.Hide();
                string rol = business.getRol();
                // Verificar el tipo de rol
                switch (rol)
                {
                    case "Admin":
                        Admin admin = new Admin(user);
                        admin.FormClosed += (sender, e) => Application.Exit();
                        admin.Show();
                        break;

                    case "Doctor":
                        //Crear formulario para doctor normal donde pueda ver su agenda y crear diagnosticos
                        break;

                    case "Secretary":
                        //Mostrar un formulario para que la secretaria pueda agregar citas y horarios de los doctores
                        break;

                    case "Patient":
                        //Mostrar un formulario donde el paciente pueda ver toda su informacion y agendar una cita
                        break;
                }
            }
            else
            {
                lMessageUser.Text = business.getMensaje();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                lMessageUser.Text = "El campo 'usuario' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                lMessageUser.Text = "El campo 'contraseña' se encuentra vacío";
            }
            else
            {
                try
                {
                    ValidateUser(txtUser.Text, txtPassword.Text);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
