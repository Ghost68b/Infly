using System;
using System.Data;
using System.Windows.Forms;

namespace OptiFly
{
    public partial class Inventario : Form
    {
        Validacion v = new Validacion();
        Cliente1ss c = new Cliente1ss();
        DataTable dt = new DataTable();
        public Inventario()
        {
            InitializeComponent();
        }
        private void FormClientes_Load(object sender, EventArgs e)
        {
            button7.Enabled = false;
            button8.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox10.Enabled = false;
            Cliente1ss c = new Cliente1ss();
            c.cargarPersona(dgv);
        }
       
        public void limpiar()
        {
            textBox2.Text = "";  textBox3.Text = "";  textBox4.Text = ""; textBox5.Text = ""; textBox6.Text = ""; textBox7.Text = ""; textBox8.Text = ""; 
            textBox9.Text = ""; textBox10.Text = "";
            c.cargarPersona(dgv);
        }
        private void BtnAgregar_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox9.Text == "")
            {
                MessageBox.Show("debes llenar el campo");

            }
            else
            {
                if (c.ProductoRegistrado(Convert.ToString(textBox1.Text)) == 0)
                {
                    //optiene todos los datos que se ingresaron mediante el formulario
                    MessageBox.Show(c.insertar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text));
                    //para que se actualize los datos automaticamente en el data gribio despues de ser agregados
                    c.cargarPersona(dgv);
                    //al agregar los datos se limpian los texbox
                    limpiar();
                    textBox1.Text = "";

                }
                else 
                {
                    MessageBox.Show("El Producto Ya esta Registrado");
                }
            }
        }
        private void txtId_TextChanged(object sender, EventArgs e)
        {
              
        }
        private void txtId_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
           
            if (textBox1.Text == "")
            {
                MessageBox.Show("debes llenar el campo");

            }
            else
            {
                MessageBox.Show(c.eliminar(Convert.ToString(textBox1.Text)));
                limpiar();
                textBox1.Text = "";
            }
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("debes llenar el campo");

            }
            else
            {
                MessageBox.Show(c.actualizar(Convert.ToString(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, textBox10.Text));
                limpiar();
                textBox1.Text = "";
            }
        }
        Cliente1ss sql = new Cliente1ss();
        private void fecha_ValueChanged(object sender, EventArgs e)
        {
           
        }
        private void domicilio_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            BuscarClie obj = new BuscarClie();
            obj.ShowDialog();
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GbOpcion_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                limpiar();
            }
            else
            {
                if (c.ProductoRegistrado(Convert.ToString(textBox1.Text)) > 0)
                {
                    c.llenarTexBoxConsulta(Convert.ToString(textBox1.Text), textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10);
                }
                else
                {
                    limpiar();
                }
            }
        }
        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            v.SoloNumeros(e);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}


