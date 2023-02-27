using PiStoreManagement.Managements;
using PiStoreManagement.Statistics;
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

        private static frmMain Instance = new frmMain();
        private Form _currentChildForm;
        private Form employeeManagerForm = new frmEmployees();
        private Form clientManagerForm = new frmClient();
        private Form productManagerForm = new frmProduct();
        private Form orderManagerForm = new frmOrder();
        private Form statisticForm = new frmStatistic();
        private Form billManagerForm = new frmBill();
        private frmPlaceOrder placeOrder = new frmPlaceOrder();
        private Employee currentStaff;

        public frmMain()
        {
            Instance = this;
            InitializeComponent();
        }

        public static frmMain GetInstance()
        {
            return Instance;
        }

        public Employee GetCurrrentStaff()
        {
            if(currentStaff == null)
            {
                currentStaff = new Employee();
            }

            return currentStaff;
        }

        public bool RegisterStaff(Employee staff)
        {
            if(staff == null) return false;
            if(currentStaff == null)
            {
                currentStaff = staff;
            }
            return false;
        }
        public frmPlaceOrder GetPlaceOrderForm()
        {
            return placeOrder;
        }

        public void OpenChildByForeign(Form child)
        {
            //Processs before
           // MessageBox.Show("opening child");
            OpenChildForm(child);
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
            if(placeOrder.IsInOrderProgress)
            {
                OpenChildForm(placeOrder);
            }
            else
            {
                MessageBox.Show(TextDictionary.MESSAGE_NOT_ORDERING_NOW);
            }
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(orderManagerForm);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin loginForm = new frmLogin();
            this.Hide();
            loginForm.ShowDialog();
        }

        private void reveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(statisticForm);
        }

        private void billsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(billManagerForm);
        }
    }
}
