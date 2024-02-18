using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROYECTO_U3
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
           // FrmData
            FrmData data = new FrmData(true,this);
            data.Show();
            this.Hide();
        }

        private void btnAreas_Click(object sender, EventArgs e)
        {
            FrmData data = new FrmData(false, this);
            data.Show();
            this.Hide();
        }
    }
}
