using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Punto_de_Venta.Servicios;

namespace Punto_de_Venta
{
    public partial class agregarArticulos : UserControl
    {
        VentasServices prod = new VentasServices();  
        
        public agregarArticulos()
        {
            InitializeComponent();
        }

        private void agregarArticulos_Load(object sender, EventArgs e)
        {
           /* object[,] obi=prod.BuscarVentas();
           // int i = 0;
            for(int i=0;i<obi.Length;i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = obi[0,0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = obi[1,1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = obi[2,2].ToString();
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            
        }
        private void agregarProducto(int codigo,string nombre,string unidad,double precio)
        {
            /*object[] produ = prod.AgregarProducto(codigo, nombre, unidad, precio);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {

            }*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }
    }
}
