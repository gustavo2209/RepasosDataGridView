using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RepasosDataGridView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
    }
}
