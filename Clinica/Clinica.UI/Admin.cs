using Clinica.Business;
using Clinica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Clinica.UI
{
    public partial class Admin : Form
    {
        AdminBusiness business;
        Doctor doctor;
        public Admin(string user)
        {
            InitializeComponent();
            business = new AdminBusiness();
            try
            {
                doctor = business.FillDataAdmin(user);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool IsValidEmail(string email)
        {
            // Regex
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            // Verificacion
            return Regex.IsMatch(email, pattern);
        }
        private void AutoFillGender()
        {
            List<string> datos = new List<string>();
            datos.Add("Hombre");
            datos.Add("Mujer");
            cbxGender.Items.Clear();
            cbxGender.Items.AddRange(datos.ToArray());
            cbxGender.SelectedIndex = 0;
        }
        private void AutoFillLenguage()
        {
            List<string> datos = new List<string>();
            datos.Add("Español");
            datos.Add("Español-Ingles");
            cbxIdiomas.Items.Clear();
            cbxIdiomas.Items.AddRange(datos.ToArray());
            cbxIdiomas.SelectedIndex = 0;
        }
        private void AutoFillPosition()
        {
            List<string> datos = new List<string>();
            datos.Add("Secretaria");
            datos.Add("Doctor");
            cbxPosition.Items.Clear();
            cbxPosition.Items.AddRange(datos.ToArray());
            cbxPosition.SelectedIndex = 0;
        }
        private void AutoFillRol()
        {
            List<string> datos = new List<string>();
            datos.Add("Admin");
            datos.Add("Doctor");
            datos.Add("Secretary");
            datos.Add("Patient");
            cbxRol.Items.Clear();
            cbxRol.Items.AddRange(datos.ToArray());
            cbxRol.SelectedIndex = 0;
        }
        private void AutoProgramOfimatic()
        {
            List<string> datos = new List<string>();
            datos.Add("Microsoft Office Suite (incluye Word, Excel, PowerPoint, Outlook, Access, Publisher)");
            datos.Add("Google Workspace (incluye Google Docs, Sheets, Slides, Gmail, Drive, Calendar)");
            datos.Add("LibreOffice (incluye Writer, Calc, Impress, Draw, Base)");
            datos.Add("Apple iWork Suite (incluye Pages, Numbers, Keynote)");
            datos.Add("WPS Office (incluye Writer, Spreadsheets, Presentation)");
            datos.Add("Zoho Office Suite (incluye Writer, Sheet, Show)");
            datos.Add("Apache OpenOffice (incluye Writer, Calc, Impress, Draw, Base)");
            datos.Add("Adobe Acrobat (para la creación y edición de archivos PDF)");
            datos.Add("Evernote (para la toma de notas y la organización de información)");
            datos.Add("Microsoft OneNote (para la toma de notas y la organización de información)");
            cbxOfi.Items.Clear();
            cbxOfi.Items.AddRange(datos.ToArray());
            cbxOfi.SelectedIndex = 0;
        }
        private void fillAdmin()
        {

            lNombre.Text = doctor.Name + " " + doctor.MiddleName;
            lApellidos.Text = doctor.LastName + " " + doctor.SecondLastName;
            lCedula.Text = doctor.IdentificationNumber + "";
            lEmail.Text = doctor.Email;
            lPhone.Text = doctor.Phone;
        }
        private void GetEspecialidades()
        {
            List<string> especialidades = new List<string>()
            {
                "Medicina General",
                "Cardiología",
                "Dermatología",
                "Gastroenterología",
                "Neurología",
                "Obstetricia y Ginecología",
                "Pediatría",
                "Psiquiatría",
                "Radiología",
                "Cirugía General",
                "Ortopedia",
                "Oftalmología",
                "Otorrinolaringología",
                "Endocrinología",
                "Nefrología",
                "Administración de la Salud",
            };
            cbxSpeciality.Items.Clear();
            cbxSpeciality.Items.AddRange(especialidades.ToArray());
            cbxSpeciality.SelectedIndex = 0;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            GetEspecialidades();
            AutoFillRol();
            AutoProgramOfimatic();
            AutoFillGender();
            AutoFillPosition();
            fillAdmin();
            AutoFillLenguage();
        }


        private void textBox7_Leave(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            bool isValid = IsValidEmail(email);

            if (!isValid)
            {
                lMessage.Text = "Correo electrónico no válido. Por favor, ingrese un correo electrónico válido.";
                lMessage.BackColor = Color.Red;
                lMessage.ForeColor = Color.White;
                txtEmail.Focus();
            }
            else
            {
                lMessage.Text = string.Empty;
                lMessage.BackColor = SystemColors.Control;
                lMessage.ForeColor = Color.Black;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPosition.SelectedItem.ToString() == "Doctor")
            {
                groupBoxDoctor.Enabled = true;
                groupBoxSecretary.Enabled = false;
            }
            else
            {
                groupBoxDoctor.Enabled = false;
                groupBoxSecretary.Enabled = true;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPrimerNombre.Text))
            {
                lMessage.Text = "El campo 'Primer Nombre' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtSegundoNombre.Text))
            {
                lMessage.Text = "El campo 'Primer Apellido' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtPrimerApellido.Text))
            {
                lMessage.Text = "El campo 'Primer Apellido' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtSegundoApellido.Text))
            {
                lMessage.Text = "El campo 'Primer Apellido' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtCedula.Text))
            {
                lMessage.Text = "El campo 'Cédula' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                lMessage.Text = "El campo 'Email' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
            {
                lMessage.Text = "El campo 'Teléfono' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtSalario.Text))
            {
                lMessage.Text = "El campo 'Salario' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtLicencia.Text))
            {
                lMessage.Text = "El campo 'Licencia' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtCodig.Text))
            {
                lMessage.Text = "El campo 'Codigo' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtUser.Text))
            {
                lMessage.Text = "El campo 'Usuario' se encuentra vacío";
            }
            else if (string.IsNullOrEmpty(txtPass.Text))
            {
                lMessage.Text = "El campo 'Contraseña' se encuentra vacío";
            }
            else
            {
                try
                {
                    switch (cbxPosition.Text)
                    {
                        case "Doctor":
                            Doctor doctor = new Doctor(txtPrimerNombre.Text,
                                                txtSegundoNombre.Text,
                                                txtPrimerApellido.Text,
                                                txtSegundoApellido.Text,
                                                txtEmail.Text,
                                                cbxGender.Text,
                                                int.Parse(txtCedula.Text),
                                                txtTelefono.Text,
                                                DateTime.Parse(dTime.Text),
                                                decimal.Parse(txtSalario.Text),
                                                cbxPosition.Text,
                                                cbxSpeciality.Text,
                                                txtLicencia.Text,
                                                txtCodig.Text);

                            Usuario usario = new Usuario(txtUser.Text, txtPass.Text, cbxRol.Text); 
                            business.saveEmployeeAsDoctor(doctor, usario);
                            break;

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }
    }
}
