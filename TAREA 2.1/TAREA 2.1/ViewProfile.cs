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
    public partial class ViewProfile : Form
    {
 
        FrmMenu frm;
        String clave = "123";
        public ViewProfile(Employee emp,FrmMenu form)
        {
            InitializeComponent();


            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee emp2 = employeeDAO.decrypt(emp.ID, clave);
            txtName.Text = "" + emp.F_NAME;
            txtLastname.Text = "" + emp.L_NAME;
            txtEmail.Text = "" + emp.EMAIL;
            txtUsername.Text = "" + emp.USERNAME;
            txtAddress.Text = "" + emp.ADDRESS;
            txtCard.Text = "" + emp2.CARD;
            txtCCV.Text = "" + emp2.CCV;
            txtTtlName.Text = "" + emp2.T_NAME;

            String exp1 = emp2.EXP_DATE.Substring(0, 2);
            String exp2 = emp2.EXP_DATE.Substring(3);

            txtEDate.Text = "" + exp1;
            txtEDate2.Text = "" + exp2;


            frm = form;
        }

        private void ViewProfile_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Close();
        }

        private void ViewProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm.Show();
            
        }

        private void lblLastName_Click(object sender, EventArgs e)
        {

        }
    }
}
