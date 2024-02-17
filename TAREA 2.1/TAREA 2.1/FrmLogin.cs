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
using Datos;
using MySql.Data.MySqlClient;



namespace PROYECTO_U3
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            
            if(String.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Enter an username");
                return;
            }
            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Enter a password");
                return;
            }

            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee emp = employeeDAO.login(txtUsername.Text, employeeDAO.decryptPassword(txtPassword.Text));

            //Chechar que sí exista en la DB
            if (emp != null)
            {
                MessageBox.Show("Welcome " + emp.F_NAME + " " + emp.L_NAME + " :)");

                new FrmMenu(this, emp.USERNAME ,emp.ID).Show();
                txtUsername.Text = "";
                txtPassword.Text = "";
                
                this.Hide();

            }
            else
            {
                MessageBox.Show("Username or password incorrect");

            }
        }
    }
}
