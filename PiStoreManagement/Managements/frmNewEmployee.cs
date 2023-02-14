using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStoreManagement.Managements
{
    public partial class frmNewEmployee : Form
    {
        public frmNewEmployee()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string eID = Guid.NewGuid().ToString();
            string eName = txtName.Text;
            string ePhone = mtxtPhone.Text;
            string eEmail = txtEmail.Text;
            string eAddress = txtAddress.Text;
            float eSalary = float.Parse(nUDSalary.Text);
            DateTime eHireDate = dateTimePickerHireDate.Value;


            Employee newE = new Employee();
            newE.ID = eID;
            newE.Name = eName;
            newE.Phone = ePhone;
            newE.Email = eEmail;
            newE.Address = eAddress;
            newE.Salary = eSalary;
            newE.HireDate = eHireDate;

            ShopDB.GetShopDBEntities().Employees.Add(newE);
            ShopDB.GetShopDBEntities().SaveChanges();

            MessageBox.Show("Success!");
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = String.Empty;
            txtEmail.Text = String.Empty;
            mtxtPhone.Text = String.Empty;
            nUDSalary.Text = nUDSalary.Minimum.ToString();
            txtAddress.Text = String.Empty;
            dateTimePickerHireDate.Value = DateTime.Now;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtName, 0, 50);
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtEmail, 0, 50);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtAddress, 0, 50);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
