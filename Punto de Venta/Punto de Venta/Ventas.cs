using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Punto_de_Venta.Servicios;
using System.Collections;

namespace Punto_de_Venta
{
    public partial class Ventas : UserControl
    {
        VentasServices vent = new VentasServices();
        int i = 0;
        protected int no_venta;
        double total = 0;
        public Ventas()
        {
            InitializeComponent();
        }     
        private void Ventas_Load(object sender, EventArgs e)
        {            
            
            //dataGridView1.Rows.Clear();            
            
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea descartar venta?\nLos datos se borraran...", "Descartar venta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                i = 0;
                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                comboBox1.Text = "";
                total = 0;
            }
            else
            {

            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {          
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellValuePushed(object sender, DataGridViewCellValueEventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Hide();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += (double)row.Cells[4].Value;
                textBox3.Text = total.ToString();
                textBox4.Text = (total * 0.16).ToString();
                textBox5.Text = (total * 1.16).ToString();
            }
            System.Threading.Thread.Sleep(1000);
            MessageBox.Show("Revise los datos antes de imprimir","Revisar");            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region useless
            /* int i = 0;
             int j = 0;
             if ((int)e.KeyChar == (int)Keys.Enter)
             {

                 if (textBox1.Text != "")
                 {

                     object[,] prod = vent.BuscarProducto(Convert.ToInt32(textBox1.Text));


                     dataGridView1.Rows.Add();

                     foreach (object ob in prod)
                     {
                         dataGridView1.Rows[i].Cells[j].Value += ob.ToString();
                         j++;
                     }
                     i++;
                     textBox1.Text = "";                    

                 }
                 else
                 {
                     MessageBox.Show("Introduce el codigo de producto!!");
                 }   */
            /*int x = 0;
            foreach(DataRow row in dataGridView1.Rows)
            {

                dataGridView1.Rows[x].Cells[4].Value = Convert.ToDouble(dataGridView1.Rows[x].Cells[2].Value) * Convert.ToDouble(dataGridView1.Rows[x].Cells[3].Value);

                x++;
            }*/
            /*if(dataGridView1.Rows[0].Cells[3].Value==null)
            {
                MessageBox.Show("Introduce la cantidad!!");
            }
            else
            {
                dataGridView1.Rows[0].Cells[4].Value = totales(Convert.ToDouble(dataGridView1.Rows[0].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[0].Cells[3].Value));
            }*/
            #endregion useless         

            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                textBox2.Focus();
            }
        }

        public double totales(double cantidad, double precio)
        {
            double total=0;

            total += cantidad * precio;
            return total;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                button3.Focus();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();

            if (textBox2.Text != "")
            {
                if (comboBox1.SelectedItem.ToString() == "Wichita")
                    dataGridView1.Rows[i].Cells[0].Value = 100;
                dataGridView1.Rows[i].Cells[1].Value = comboBox1.SelectedItem.ToString();
                dataGridView1.Rows[i].Cells[2].Value = textBox1.Text;
                dataGridView1.Rows[i].Cells[3].Value = textBox2.Text;
                dataGridView1.Rows[i].Cells[4].Value = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox2.Text);
                i++;
            }
            else
            {
                dataGridView1.Rows.Clear();
                MessageBox.Show("Ingrese la cantidad!!");
            }            
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numerito = vent.NumeroVenta();
            no_venta = numerito;
            vent.GuardarVenta(no_venta, total, DateTime.Now.Date);
            i = 0;
                       
            MessageBox.Show("Venta Registrada\nNo. de venta:" + no_venta + "\nImprimiendo Ticket");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
            dataGridView1.Rows.Clear();
            total = 0;
            button1.Show();
        }
    }
}
