using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Punto_de_Venta
{
    public partial class Admin : Form
    {
        

        public Admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ventas ven = new Ventas();
            panel1.Controls.Clear();
            panel1.Controls.Add(ven);            
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new agregarArticulos());            
        }
        private void CambiarModulo(UserControl uc)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uc);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            compras compra = new compras();
            panel1.Controls.Clear();            
            CambiarModulo(compra);
        }
        private void AbrirVentas()
        {
            Ventas ven = new Ventas();
            panel1.Controls.Clear();
            CambiarModulo(ven);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label34.Text = DateTime.Now.ToLongTimeString().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clientes cli = new Clientes();
            panel1.Controls.Clear();
            panel1.Controls.Add(cli);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void adrianaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se borraran los datos no guardados\nDesea continuar?", "Cierre de sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.close_window_xxl__2_;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Reportes rep = new Reportes();
            panel1.Controls.Clear();
            panel1.Controls.Add(rep);
        }

        private void salirToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Se borraran los datos no guardados\nDesea continuar?", "Cierre de sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.xwin1;
        }
    }
}
