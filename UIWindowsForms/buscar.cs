using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIWindowsForms
{
    public partial class buscar : Form
    {
        public buscar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cargarComboEstudiantes();
        }

        private void cargarComboEstudiantes()
        {
            this.cmbcedula.DataSource = Acceso_Datos.PersonaDAO.getAll();
            this.cmbcedula.DisplayMember = "estudiante";
            this.cmbcedula.ValueMember = "cedula";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cedula = this.cmbcedula.SelectedValue.ToString();

            Acceso_Datos.Personas p = new Acceso_Datos.Personas();
            p = Acceso_Datos.PersonaDAO.GetPersona(cedula);

            //cargar datos en los cuadros de texto
            this.txtCedula.Text = p.cedula;
            this.txtApellidos.Text = p.apellidos;
            this.txtNombres.Text = p.nombres;
            this.txtsexo.Text = p.sexo;
            this.dtpFecha.Value = Convert.ToDateTime(p.F_Nacimiento);
            this.txtCorreo.Text = p.correo;
            this.txtEstatura.Text = p.estatura.ToString();
            this.txtPeso.Text = p.peso.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(this.txtCedula.Text.Length==0)
            {
                MessageBox.Show("No hay cedula solucionada...");
                return;
            }
            Acceso_Datos.Personas persona = new Acceso_Datos.Personas();
            persona.cedula = this.txtCedula.Text;
            persona.apellidos = this.txtApellidos.Text;
            persona.nombres = this.txtNombres.Text;
            persona.sexo = this.txtsexo.Text;
            persona.F_Nacimiento = dtpFecha.Value;
            persona.correo = this.txtCorreo.Text;
            persona.estatura = int.Parse(this.txtEstatura.Text);
            persona.peso = decimal.Parse(this.txtPeso.Text);
            int x=Acceso_Datos.PersonaDAO.actualizar(persona);
            if (x > 0)
                MessageBox.Show("Registro actualizado con exito");
            else
                MessageBox.Show("No se pudo actualizar el registro");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Confirme", "Esta seguro que desea eliminar este registro?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.No)
            {
                return;
            }
            int x = Acceso_Datos.PersonaDAO.eliminar(this.txtCedula.Text);
            if (x > 0)
            {
                this.encerar();
                this.cargarComboEstudiantes();
                MessageBox.Show(" se borro el registro!");
            }
        }
        private void encerar()
        {
            this.txtCedula.Text = "";
            this.txtApellidos.Text = "";
            this.txtNombres.Text = "";
            this.txtCorreo.Text = "";
            this.txtEstatura.Text = "0";
            this.txtPeso.Text = "0";
            //this.dtFechaNacimiento = "";
        }
    }
}
