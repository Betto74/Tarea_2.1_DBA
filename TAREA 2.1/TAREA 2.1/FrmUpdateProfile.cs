using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PROYECTO_U3
{
    public partial class FrmUpdateProfile : Form
    {
        FrmMenu frm;
        Employee empleado;
        String clave = "123";
        String validMes = "^(0[1-9]|1[0-2])$";
        String valiAnio = "^([2-9][0-9])$";
        String valiCCV = "^([0-9]{3})$";
        String valiCard = "^([0-9]{16})$";
        String valiText = "^([a-zA-Z]{2,50})$";
        String valiEmail = "^[a-zA-Z0-9_]{2,30}(@)[a-zA-Z0-9-]{1,15}(.)[a-zA-Z]{2,}$";
        public FrmUpdateProfile(Employee emp, FrmMenu form)
        {
            InitializeComponent();

            EmployeeDAO employeeDAO = new EmployeeDAO();
            Employee emp2 = employeeDAO.decrypt(emp.ID, clave);
            lblUsername.Text = emp.USERNAME;
            txtF_Name.Text = emp.F_NAME;
            txtL_Name.Text = emp.L_NAME;
            txtEmail.Text = emp.EMAIL;
            txtAddress.Text = emp.ADDRESS;
            txtCard.Text = emp2.CARD;
            txtT_Name.Text = emp2.T_NAME;
            txtCCV.Text = emp2.CCV;
            
            String exp1 = emp2.EXP_DATE.Substring(0,2);
            String exp2 = emp2.EXP_DATE.Substring(3);

            txtExp_Date.Text = exp1;
            txtExp_Date2.Text = exp2;
            frm = form;
            empleado = emp;
            
        }

        private void FrmUpdateProfile_Load(object sender, EventArgs e)
        {

        }

        private void FrmUpdateProfile_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            frm.Show();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frm.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeDAO employeeDAO = new EmployeeDAO();

            if (!(Regex.IsMatch(txtF_Name.Text, valiText)) )
            {
                // MessageBox.Show("Name or Lastname fields are invalid");
                txtF_Name.Focus();
                errorProviderUpdate.SetError(txtF_Name, "Name field is invalid");
                return;
            }
            else errorProviderUpdate.Clear();

            if ( !(Regex.IsMatch(txtL_Name.Text, valiText)))
            {
                // MessageBox.Show("Name or Lastname fields are invalid");
                txtL_Name.Focus();
                errorProviderUpdate.SetError(txtL_Name, "Lastname field is invalid");
                return;
            }
            else errorProviderUpdate.Clear();

            if (!(Regex.IsMatch(txtEmail.Text, valiEmail)))
            {
                // MessageBox.Show("Name or Lastname fields are invalid");
                txtEmail.Focus();
                errorProviderUpdate.SetError(txtF_Name, "Email field is invalid");
                return;
            }
            else errorProviderUpdate.Clear();

            if (String.IsNullOrEmpty(txtAddress.Text))
            {
                //MessageBox.Show("You have to confirm/update your password to continue");
                txtAddress.Focus();
                errorProviderUpdate.SetError(txtEmail, "You have to confirm/update your address to continue");
                return;
            }
            else errorProviderUpdate.Clear();


            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                //MessageBox.Show("You have to confirm/update your password to continue");
                txtPassword.Focus();
                errorProviderUpdate.SetError(txtPassword, "You have to confirm/update your password to continue");
                return;
            }
            else errorProviderUpdate.Clear();


            if (!Regex.IsMatch(txtCard.Text, valiCard))
            {
                //MessageBox.Show("Card number is invaid");
                txtCard.Focus();
                errorProviderUpdate.SetError(txtCard, "Card number is invalid");
                return;
            }
            else errorProviderUpdate.Clear();

            if (!Regex.IsMatch(txtCCV.Text,valiCCV))
            {
                // MessageBox.Show("CVV code is invalid");
                txtCCV.Focus();
                errorProviderUpdate.SetError(txtCCV, "CVV code is invalid");
                return;

            }
            else errorProviderUpdate.Clear();

            if (!(Regex.IsMatch(txtExp_Date.Text, validMes)) && !(Regex.IsMatch(txtExp_Date2.Text, valiAnio)))
            {
                // MessageBox.Show("Expiration date is invalid");
                txtExp_Date.Focus();
                errorProviderUpdate.SetError(txtExp_Date2, "Expiration date is invalid");
                return;
            }
            else errorProviderUpdate.Clear();

            if (!(Regex.IsMatch(txtT_Name.Text.Trim(), valiText)))
            {
                // MessageBox.Show("Name or Lastname fields are invalid");
                txtT_Name.Focus();
                errorProviderUpdate.SetError(txtT_Name, "Titutal Name field is invalid");
                return;
            }
            else errorProviderUpdate.Clear();

            Employee empl = new Employee()
            {
                ID = empleado.ID,
                F_NAME = txtF_Name.Text,
                L_NAME = txtL_Name.Text,
                EMAIL = txtEmail.Text,
                ADDRESS = txtAddress.Text,
                PASSWORD = txtPassword.Text,
                CARD = txtCard.Text,
                CCV = txtCCV.Text,
                EXP_DATE = txtExp_Date.Text + "/" + txtExp_Date2.Text,
                T_NAME = txtT_Name.Text.Trim()

            };




            if (employeeDAO.update(empl, clave))
            {
                MessageBox.Show("Data was updated correctly");
                this.Close();
            }
            else
            {
                MessageBox.Show("An error ocurred");

            }
                            
                        
                    
                
            
        }
    }
}
