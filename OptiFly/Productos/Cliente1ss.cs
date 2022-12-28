using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace OptiFly
{
    internal class Cliente1ss
    {
        //variable para conectar a la base de datos
        MySqlConnection cn = BdComun.ObtenerConexion();
        //variable para insertar datos a la bd
        MySqlCommand cmd;
        MySqlDataReader dr;
        //creamos una instancia para mostrar los datos
        MySqlDataAdapter da;
        DataTable dt;
        private DataSet ds;

        //se agrega un nuevo usuario a la base de datos
        public string insertar(string codigo, string descripcion, string decProv, string lavoratorio, string departamento, string ultimocos, string costprom, string precio, string preciopubl, string existencia)
        {
            string salida = "Se se inserto";
            try
            {
                cmd = new MySqlCommand("Insert into producto ( codigo, descripcion, decProv, lavoratorio, departamento, ultimocos, costprom, precio, preciopubl, existencia) " +
                    "values('" + codigo + "','" + descripcion + "','" + decProv + "','" + lavoratorio + "','" + departamento + "','" + ultimocos + "','" + costprom + "','" + precio + "','" + preciopubl + "','" + existencia + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se conecto: " + ex.ToString();
            }
            return salida;
        }

        public int ProductoRegistrado(string codigo)
        {
            int contador = 0;
            try
            {
                cmd = new MySqlCommand("Select * from producto where codigo =" + codigo + "", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contador++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo consultar bien: " + ex.ToString());
            }
            return contador;
        }

        public DataTable BuscarBodegaSAMS(string fecha)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("select * from cliente where fecha like '%{0}%'", fecha), cn);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            cn.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarBodegaUS()
        {
            MySqlCommand cmd = new MySqlCommand("select * from cliente ", cn);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            cn.Close();
            return ds.Tables["tabla"];
        }

        public void cargarPersona(DataGridView dgv)
        {
            try
            {
                da = new MySqlDataAdapter("Select * from producto", cn);
                //antes de llenar el datatable se tiene que crear
                dt = new DataTable();
                // todo lo que se capture se mandara a dt = datatable
                da.Fill(dt);
                //y el dt llena a dgv con la consulta correspondiente
                dgv.DataSource = dt;
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar el Datagridview: " + ex, ToString());
            }
        }//aqui termina la consula de los datos para mostrar la info

        //Aqui empieza para actualizar los datos de la base de datos


        public void llenarTexBoxConsulta(string codigo, TextBox descripcion, TextBox decProv, TextBox lavoratorio, TextBox departamento, TextBox ultimocos, TextBox costprom,
            TextBox precio, TextBox preciopubl, TextBox existencia)
        {
            try
            {
                cmd = new MySqlCommand("Select * from producto where codigo=" + codigo + "", cn);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    descripcion.Text = dr["descripcion"].ToString();
                    decProv.Text = dr["decProv"].ToString();
                    lavoratorio.Text = dr["lavoratorio"].ToString();
                    departamento.Text = dr["departamento"].ToString();
                    ultimocos.Text = dr["ultimocos"].ToString();
                    costprom.Text = dr["costprom"].ToString();
                    precio.Text = dr["precio"].ToString();
                    preciopubl.Text = dr["preciopubl"].ToString();
                    existencia.Text = dr["existencia"].ToString();

                }
                dr.Close();
            }
            //Si se produce algun erro este lo cacha para despues mostrarlo
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo llenar los campos: " + ex.ToString());
            }
        }



        public string actualizar(string codigo, string descripcion, string decProv, string lavoratorio, string departamento, string ultimocos, string costprom, string precio, string preciopubl, string existencia)
        {
            string salida = "Se actualizaron los datos";
            try
            {
                cmd = new MySqlCommand("Update producto set " + "descripcion = '" + descripcion + "'," + "decProv = '" + decProv + "'," + " lavoratorio = '" + lavoratorio + "'," + " departamento = '" + departamento + "'," + "ultimocos = '" + ultimocos + "'," +
                    "" + " costprom = '" + costprom + "'," + " precio = '" + precio + "'," + " preciopubl = '" + preciopubl + "'," + " existencia = '" + existencia + "' where codigo = " + codigo + "", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se Actualizo: " + ex.ToString();
            }
            return salida;
        }
        public String eliminar(String id)
        {
            string salida = "Se Elimino El producto";
            try
            {
                MySqlCommand cmd = new MySqlCommand(string.Format("delete from producto where  codigo = {0}", id), cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "No se Elimino al usuario" + ex.ToString();
            }
            return salida;
        }
        public DataTable BuscarVenta(string nombre)
        {
            MySqlCommand cmd = new MySqlCommand(string.Format("select * from producto where codigo like '%{0}%'", nombre), cn);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            cn.Close();
            return ds.Tables["tabla"];
        }
        public DataTable MostrarVenta()
        {
            MySqlCommand cmd = new MySqlCommand("Select codigo, descripcion from producto", cn);
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ds = new DataSet();
            ad.Fill(ds, "tabla");
            cn.Close();
            return ds.Tables["tabla"];
        }
    }
}