using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;

namespace RepasosDataGridView
{
    public partial class Form1 : Form
    {

        private int index;
        private Random random;
        private NumberFormatInfo nfi;
        private DataTable table;

        public Form1()
        {
            InitializeComponent();

            index = 1;
            random = new Random();
            
            nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = ",";
            nfi.NumberDecimalSeparator = ".";

            table = new DataTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            table.Columns.Add("idcliente", System.Type.GetType("System.Int32"));
            table.Columns.Add("Cliente", System.Type.GetType("System.String"));
            table.Columns.Add("Correo", System.Type.GetType("System.String"));

            table.Rows.Add(1, "Juan Pérez", "jperez@gmail.com");
            table.Rows.Add(2, "Kina Malpartida", "kmalpartida@yahoo.es");
            table.Rows.Add(3, "Jorge Risco", "jrisco@hotmail.com");
            table.Rows.Add(4, "Katya Ruiz", "kruiz@gmail.com");
            table.Rows.Add(5, "Carlos Valencia", "cvalencia@yahoo.es");

            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PintaGrilla();
        }

        private void PintaGrilla()
        {
            table.Columns.Add("ID", System.Type.GetType("System.Int32"));
            table.Columns.Add("Producto", System.Type.GetType("System.String"));
            table.Columns.Add("Stock", System.Type.GetType("System.Int32"));
            table.Columns.Add("Precio", System.Type.GetType("System.String"));

            for (int i = 0; i < 10; i++)
            {
                string producto = string.Format("Producto {0:000}", index);
                int stock = random.Next(10, 100);
                double precio = random.Next(100, 200);

                table.Rows.Add(index, producto, stock, precio.ToString("#,###.00", nfi));
                index++;
            }

            dataGridView2.DataSource = table;

            // JUSTIFICACIONES
            dataGridView2.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["Stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView2.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // ANCHO
            dataGridView2.Columns[0].Width = 50;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string producto = string.Format("Producto {0:000}", index);
            int stock = random.Next(10, 100);
            double precio = random.Next(100, 200);

            table.Rows.Add(index, producto, stock, precio.ToString("#,###.00", nfi));
            index++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ctas_fils_sel = dataGridView2.Rows.GetRowCount(DataGridViewElementStates.Selected);
            if (ctas_fils_sel > 0)
            {
                if(MessageBox.Show("¿Retirar producto(s)?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach(DataGridViewRow row in dataGridView2.SelectedRows)
                    {
                        dataGridView2.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione fila a retirar");
            }
        }
    }
}
