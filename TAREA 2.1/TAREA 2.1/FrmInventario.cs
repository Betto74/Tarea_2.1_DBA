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


            this.bandera = false;
            this.inventario = inv;
            this.data = data;

            txtId.Visible = false;
            lblID.Visible = false;

        }
        //add
        public FrmInventario(FrmData data)
        {
            InitializeComponent();
            this.bandera = true;
            this.data = data;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            Inventario inv = new Inventario() { 
                NOMBRECORTO = txtNombre.ToString(),
                DESCRIPCION = txtDescripcion.ToString(),
                SERIE = txtSerie.ToString(),
                COLOR = txtColor.ToString(),
                FECHAADQUISICION = dtpFecha.Text.ToString(),
                TIPOADQUISICION = cbxTipoAd.SelectedItem.ToString(),
                OBSERVACIONES = txtDescripcion.ToString(),
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
            this.Hide();
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


            cbxArea.DataSource = inventario;
            cbxArea.DisplayMember = "NOMRE";

            txtObservaciones.Text = inv.OBSERVACIONES;
        }
    }
}
