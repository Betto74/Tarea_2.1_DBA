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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PROYECTO_U3
{
    public partial class FrmInventario : Form
    {
        
        
        Boolean bandera; // true : add / false : edit
        
        Inventario inventario;
        FrmData data;
        //edit
        public FrmInventario(Inventario inv, FrmData data)
        {
            InitializeComponent();
            fillData(inv);

            cbxTipoAd.SelectedIndex = 0;
            if (cbxArea.Items.Count > 0) cbxArea.SelectedIndex = 0;
            this.bandera = false;
            this.inventario = inv;
            this.data = data;

            

        }
        //add
        public FrmInventario(FrmData data)
        {
            InitializeComponent();
            this.bandera = true;
            this.data = data;

            cbxTipoAd.SelectedIndex = 0;
            if( cbxArea.Items.Count > 0)cbxArea.SelectedIndex = 0;

            cbxArea.DataSource = new AreaDAO().getAllData();
            cbxArea.DisplayMember = "NOMBRE";

            txtId.Visible = false;
            lblID.Visible = false;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtDescripcion.Text) ||
                string.IsNullOrEmpty(txtSerie.Text) || string.IsNullOrEmpty(txtColor.Text) ||
                string.IsNullOrEmpty(txtObservaciones.Text))
            {
                MessageBox.Show("Ningun campo debe de se estar vacio");
                return;
            }

            if( cbxArea.Items.Count <=0)
            {
                MessageBox.Show("No hay ningun area agregada, favor de volver con una existente");
                return;
            }

            Inventario inv = new Inventario() { 
                NOMBRECORTO = txtNombre.Text,
                DESCRIPCION = txtDescripcion.Text,
                SERIE = txtSerie.Text,
                COLOR = txtColor.Text,
                FECHAADQUISICION = dtpFecha.Text,
                TIPOADQUISICION = cbxTipoAd.SelectedItem.ToString(),
                OBSERVACIONES = txtDescripcion.Text,
                AREAS_ID = ((Area)cbxArea.SelectedItem).ID,

            };

            //add
            if( bandera)
            {
                if (new InventarioDAO().insert(inv)) {
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
                inv.ID = inventario.ID;
                if (new InventarioDAO().update(inv))
                {
                    MessageBox.Show("Se edito correctamente inventario");
                }
                else
                {
                    MessageBox.Show("Ha ocurrido un error");
                }
                

            }
            data.Show();
            data.Initialize(true);
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            data.Show();
            this.Close();
        }

        private void fillData(Inventario inv)
        {
            txtId.Text = inv.ID.ToString();
            txtId.ReadOnly = true;
            txtNombre.Text = inv.NOMBRECORTO;
            txtDescripcion.Text = inv.DESCRIPCION;
            txtSerie.Text = inv.SERIE;
            txtColor.Text = inv.COLOR;
            dtpFecha.Text = inv.FECHAADQUISICION;
            cbxTipoAd.SelectedIndex = cbxTipoAd.FindString(inv.TIPOADQUISICION);
            cbxArea.DataSource = new AreaDAO().getAllData();
            cbxArea.DisplayMember = "NOMBRE";


            txtObservaciones.Text = inv.OBSERVACIONES;
        }

        private void FrmInventario_FormClosed(object sender, FormClosedEventArgs e)
        {
            data.Show();
            
        }

        private void txtSerie_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtColor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
