using PiStoreManagement.Managements;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStoreManagement
{
    public partial class frmMain : Form
    {
        private Form _currentChildForm;

        private Form employeeManagerForm = new frmEmployees();
        private Form clientManagerForm = new frmClient();
        private Form productManagerForm = new frmProduct();
        private frmPlaceOrder placeOrder = new frmPlaceOrder();
        private Form orderManagerForm = new frmOrder();


        public frmMain()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form child)
        {
            if (_currentChildForm != null)
            {
                _currentChildForm.Hide();
            }
            _currentChildForm = child;
            child.MdiParent = this;
            child.TopLevel = false;
            child.FormBorderStyle = FormBorderStyle.None;
            child.Dock = DockStyle.Fill;
            child.Show();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(employeeManagerForm);
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(clientManagerForm);
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(productManagerForm);
        }

        private void placeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee employee = ShopDB.GetShopDBEntities().Employees.FirstOrDefault();
            Client client = ShopDB.GetShopDBEntities().Clients.FirstOrDefault();
            placeOrder.RegisterOrder(employee, client);
            OpenChildForm(placeOrder);
            //placeOrder.
            /*
            if(placeOrder.IsInOrderProgress)
            {
                OpenChildForm(placeOrder);
            }
            else
            {
                MessageBox.Show(TextDictionary.MESSAGE_NOT_ORDERING_NOW);
            }
            */
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(orderManagerForm);
        }
    }
}
