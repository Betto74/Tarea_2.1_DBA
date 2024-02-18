using Datos;
using Modelos;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections;
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
    public partial class FrmData : Form
    {
        FrmMenu menu;
        Boolean bandera; //True : Inventario / False : Area
        List<Inventario> inventarioList;
        List<Area> areaList;
        public FrmData(Boolean bandera, FrmMenu menu)
        {
            InitializeComponent();
            this.bandera = bandera;
            this.menu = menu;
            Initialize(bandera);
            
        }
      

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (bandera) { 
                FrmInventario inv = new FrmInventario(this);
                inv.Show();
                this.Hide();
            }
            else
            {
                FrmArea area = new FrmArea(this);
                area.Show();
                this.Hide();
            }
        }

      
        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dgvData.SelectedRows.Count > 0)
            {
                // Obtener la primera fila seleccionada (en caso de que haya múltiples filas seleccionadas)
                int index = dgvData.SelectedRows[0].Index;
                if (bandera)
                {
                    FrmInventario inv = new FrmInventario(inventarioList[index], this);
                    inv.Show();
                    this.Hide();
                }
                else
                {
                    FrmArea area = new FrmArea(areaList[index], this);
                    area.Show();
                    this.Hide();
                }

            }
            else
            {
                // Si no hay filas seleccionadas, manejar el caso en consecuencia
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Verificar si hay al menos una fila seleccionada
            if (dgvData.SelectedRows.Count > 0)
            {

                // Obtener la primera fila seleccionada (en caso de que haya múltiples filas seleccionadas)
                int index = dgvData.SelectedRows[0].Index;
                if (bandera)
                {
                    if (new InventarioDAO().delete(inventarioList[index].ID))
                    {
                        MessageBox.Show("Se ha eliminado correctamente");
                        Initialize(true);
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }
                else
                {
                    if (new AreaDAO().delete(areaList[index].ID))
                    {
                        MessageBox.Show("Se ha eliminado correctamente");
                        Initialize(false);
                    }
                    else
                    {
                        MessageBox.Show("Ha ocurrido un error");
                    }
                }

            }
            else
            {
                // Si no hay filas seleccionadas, manejar el caso en consecuencia
                MessageBox.Show("No se ha seleccionado ninguna fila.");
            }
        }

        public void Initialize(Boolean bandera)
        {

            if (bandera)
            {
                inventarioList = new InventarioDAO().getAllData();
                dgvData.DataSource = inventarioList;
                dgvData.AllowUserToDeleteRows = false;
                dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvData.Columns["ID"].Visible = false;
            }
            else
            {
                areaList = new AreaDAO().getAllData();
                dgvData.DataSource = areaList;
                dgvData.AllowUserToDeleteRows = false;
                dgvData.EditMode = DataGridViewEditMode.EditProgrammatically;
                dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvData.Columns["ID"].Visible = false;
                foreach (DataGridViewColumn column in dgvData.Columns)
                {
                    // Establecer el modo de tamaño automático de la columna en Fill
                    column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            menu.Show();
            this.Close();
        }

        private void FrmData_FormClosed(object sender, FormClosedEventArgs e)
        {
            menu.Show();
        }
    }
}
