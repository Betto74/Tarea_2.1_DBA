using Datos;
using Modelos;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public partial class FrmArea : Form
    {
        Boolean bandera; // true : add / false : edit

        Area area;
        FrmData data;
        //aditar
        public FrmArea(Area area, FrmData data)
        {
            InitializeComponent();
            fillData(area);

            this.area = area;
            this.data = data;
            this.bandera = false;
         

        }
        //agregar
        public FrmArea(FrmData data)
        {
            InitializeComponent();
            this.data = data;
            this.bandera = true;
            txtId.Visible = false;
            lblId.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtUbicacion.Text))
            {
                MessageBox.Show("Ningun campo debe de se estar vacio");
                return;
            }
            Area ar = new Area()
            {
                //ID = Convert.ToInt32(fila["ID"]),
                NOMBRE = txtNombre.Text,
                UBICACION = txtUbicacion.Text,


            };

            //add
            if (bandera)
            {
                if (new AreaDAO().insert(ar))
                {
                    MessageBox.Show("Se agrego correctamente al inventario");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }

            }
            //edit
            else
            {
                ar.ID = area.ID;
                if (new AreaDAO().update(ar))
                {
                    MessageBox.Show("Se edito correctamente inventario");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }


            }
            data.Show();
            data.Initialize(false);
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            data.Show();
            this.Close();
        }

        private void fillData(Area area)
        {
            txtId.Text = area.ID.ToString();
            txtId.ReadOnly = true;
            txtNombre.Text = area.NOMBRE;
            txtUbicacion.Text = area.UBICACION;
        }

        private void FrmArea_FormClosed(object sender, FormClosedEventArgs e)
        {
            data.Show();
            this.Hide();
        }
    }
}
