using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_Venta.Servicios;
using System.Collections;

namespace Punto_de_Venta
{
    public partial class compras : UserControl
    {
        VentasServices ventas = new VentasServices();
        protected int codigo;
        int i = 0;
        protected int no_compra;
        double total = 0;
        //DateTime fecha = DateTime.Now.ToShortDateString();

        public compras()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.ToString() == "Wichita")
            {
                codigo += 100;
                textBox2.Text = "50";
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
            
            if (textBox1.Text!="")
            {
                if(comboBox1.SelectedItem.ToString()=="Wichita")
                dataGridView1.Rows[i].Cells[0].Value = 100;
                dataGridView1.Rows[i].Cells[1].Value += comboBox1.SelectedItem.ToString();
                dataGridView1.Rows[i].Cells[2].Value += textBox2.Text;
                dataGridView1.Rows[i].Cells[3].Value += textBox1.Text;
                dataGridView1.Rows[i].Cells[4].Value = Convert.ToDouble(textBox2.Text)* Convert.ToDouble(textBox1.Text);                
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           

            int numerito=ventas.NumeroCompra();
            no_compra = numerito;
            ventas.GuardarCompra(no_compra, total,DateTime.Now.Date);
            i = 0;
            //System.Threading.Thread.Sleep(3000);
            dataGridView1.Rows.Clear();
            MessageBox.Show("Compra Registrada\nNo. de compra:"+no_compra+"\nImprimiendo Ticket");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            total = 0;
            button4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Desea descartar compra?\nLos datos se borraran...","Descartar Compra", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                i = 0;
                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
            }
            else
            {

            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Hide();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += (double)row.Cells[4].Value;
                textBox3.Text = total.ToString();
            }
            MessageBox.Show("Revise los datos antes de guardar", "Revisar");
        }
    }
}
