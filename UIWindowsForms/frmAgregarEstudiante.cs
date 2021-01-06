using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace UIWindowsForms
{
    public partial class frmAgregarEstudiante : Form
    {
        public frmAgregarEstudiante()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtcedula.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debes ingresar la cedula");
                this.txtcedula.Focus();
                return;
            }
            if (this.txtapellido.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debes ingresar los apellidos");
                this.txtapellido.Focus();
                return;
            }
            if (this.txtnombre.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debes ingresar sus nombres");
                this.txtnombre.Focus();
                return;
            }
            if (this.sexo.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debe seleccionar su sexo");
                this.sexo.Focus();
                return;
            }

            if (this.txtcorreo.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debe ingresar el correo");
                this.txtcorreo.Focus();
                return;
            }
            if (this.txtestatura.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debe su estatura");
                this.txtestatura.Focus();
                return;
            }
            if (this.txtpeso.Text.Length == 0)
            {
                MessageBox.Show("Por Favor debe ingresar su peso");
                this.txtpeso.Focus();
                return;
            }
            try
            {
                Acceso_Datos.Personas persona = new Acceso_Datos.Personas();
                persona.cedula = this.txtcedula.Text;
                persona.apellidos = this.txtapellido.Text;
                persona.nombres = this.txtnombre.Text;
                persona.sexo = this.sexo.Text;
                persona.F_Nacimiento = dtFecha.Value;
                persona.correo = this.txtcorreo.Text;
                persona.estatura = int.Parse(this.txtestatura.Text);
                persona.peso = decimal.Parse(this.txtpeso.Text);
                int x = Acceso_Datos.PersonaDAO.crear(persona);
                if (x > 0)
                    MessageBox.Show("Registro agregado");
                else
                    MessageBox.Show("Registro no agregado");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txtcedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        public static bool ComprobarEmail(string MailAComprobar)
        {
            String Formato;
            Formato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(MailAComprobar, Formato))
            {
                if (Regex.Replace(MailAComprobar, Formato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (ComprobarEmail(txtcorreo.Text) == false)
            {
                MessageBox.Show("Dirección no valida");
                txtcorreo.ForeColor = Color.Red;
            }
            else
            {
                MessageBox.Show("Dirección valida");
                txtcorreo.ForeColor = Color.Blue;
            }
        }

        private void txtestatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtpeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo numeros", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64)||(e.KeyChar >= 91 && e.KeyChar <= 96)||(e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtapellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                MessageBox.Show("Solo letras", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
