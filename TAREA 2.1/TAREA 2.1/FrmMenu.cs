using Datos;
using Modelos;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
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
        
        FrmLogin login;
        int ID;
        public FrmMenu(FrmLogin log, String name ,int id)
        {
            InitializeComponent();
            lblName.Text = name;
            login = log;
            ID = id;
            
        }

        public FrmMenu()
        {
            InitializeComponent();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {

            EmployeeDAO employee = new EmployeeDAO();
            Employee empleado = employee.getData(ID);
            if (empleado != null)
            {
                new ViewProfile(empleado, this).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("An error ocurred");
            }
            
        }

        private void btnUpdaate_Click(object sender, EventArgs e)
        {
            EmployeeDAO employee = new EmployeeDAO();
            Employee empleado = employee.getData(ID);
            if (empleado != null) 
            {
                new FrmUpdateProfile(empleado, this).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("An error ocurred");
            }
            
        }

        private void FrmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            login.Show();
            
        }

        private void ptbBackground_Click(object sender, EventArgs e)
        {

        }
    }
}
