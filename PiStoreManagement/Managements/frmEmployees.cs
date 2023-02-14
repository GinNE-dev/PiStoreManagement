using PiStoreManagement.Tools;
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
    public partial class frmEmployees : Form
    {

        public frmEmployees()
        {
            InitializeComponent();

            InitEmployeeGrid();
            LoadEmployeeGrid();
        }

        private void choseCells(DataGridViewCellCollection cells)
        {
            if (cells == null) return;
            txtID.Text =  cells[TextDictionary.EMPLOYEE_ID_COLUMN_NAME].Value.ToString();
            txtName.Text = cells[TextDictionary.EMPLOYEE_NAME_COLUMN_NAME].Value.ToString();
            mtxtPhone.Text = cells[TextDictionary.EMPLOYEE_PHONE_COLUMN_NAME].Value.ToString();
            txtEmail.Text = cells[TextDictionary.EMPLOYEE_EMAIL_COLUMN_NAME].Value.ToString();
            txtAddress.Text =  cells[TextDictionary.EMPLOYEE_ADDRESS_COLUMN_NAME].Value.ToString();
            nUDSalary.Text = cells[TextDictionary.EMPLOYEE_SALARY_COLUMN_NAME].Value.ToString();
            dateTimePickerHireDate.Value = (DateTime)cells[TextDictionary.EMPLOYEE_HIREDATE_COLUMN_NAME].Value;
        }

        private void ClearInfo()
        {
            txtID.Text = String.Empty;
            txtName.Text = String.Empty;
            mtxtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtAddress.Text = String.Empty;
            nUDSalary.Text = nUDSalary.Minimum.ToString();
            dateTimePickerHireDate.Value = DateTime.Now ;
        }

        private void LoadEmployeeGrid ()
        {
            ShopDBEntities shopDBEntities = ShopDB.GetShopDBEntities();
            List<Employee> employees = shopDBEntities.Employees.ToList();

            UpdateEmployeeGrid(employees);

            if (dataGridViewEmployees.Rows.Count > 0)
            {
                choseCells(dataGridViewEmployees.Rows[0].Cells);
            }else
            {
                ClearInfo();
            }
        }

        private void UpdateEmployeeGrid(IEnumerable<Employee> employees)
        {
            dataGridViewEmployees.Rows.Clear();
            foreach (Employee e in employees)
            {
                dataGridViewEmployees.Rows.Add(e.ID, e.Name, e.Email, e.Phone, e.Address, e.Salary, e.HireDate);
            }
        }
        
        private void InitEmployeeGrid()
        {
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_ID_COLUMN_NAME, TextDictionary.EMPLOYEE_ID_COLUMN_TEXT);
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_NAME_COLUMN_NAME, TextDictionary.EMPLOYEE_NAME_COLUMN_TEXT);
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_EMAIL_COLUMN_NAME, TextDictionary.EMPLOYEE_EMAIL_COLUMN_TEXT);
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_PHONE_COLUMN_NAME, TextDictionary.EMPLOYEE_PHONE_COLUMN_TEXT);
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_ADDRESS_COLUMN_NAME, TextDictionary.EMPLOYEE_ADDRESS_COLUMN_TEXT);
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_SALARY_COLUMN_NAME, TextDictionary.EMPLOYEE_SALARY_COLUMN_TEXT);
            dataGridViewEmployees.Columns.Add(TextDictionary.EMPLOYEE_HIREDATE_COLUMN_NAME, TextDictionary.EMPLOYEE_HIREDATE_COLUMN_TEXT);

            DataGridViewButtonColumn DeleteButton = new DataGridViewButtonColumn();
            DeleteButton.Name = TextDictionary.CONTROL_DELETE_BUTTON_NAME;
            DeleteButton.Text = TextDictionary.CONTROL_DELETE_BUTTON_TEXT;
            DeleteButton.UseColumnTextForButtonValue = true;
            if (dataGridViewEmployees.Columns[TextDictionary.CONTROL_DELETE_COLUMN_NAME] == null)
            {
                dataGridViewEmployees.Columns.Insert(dataGridViewEmployees.Columns.Count, DeleteButton);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtName, 0, 50);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Form root = this.MdiParent !=null ? this.MdiParent : this;
            Form formAddNew = new frmNewEmployee();

            formAddNew.StartPosition = FormStartPosition.Manual;
            formAddNew.Location = DrawingMathHelper.FindSmallPointCenter(root.Location, root.Size, formAddNew.Size);
            
            formAddNew.ShowDialog();
            LoadEmployeeGrid();
        }

        private void dataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_UPDATE, TextDictionary.TITLE_COMFIRM_UPDATE, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string eID = txtID.Text;
                Employee employee = ShopDB.GetShopDBEntities().Employees.FirstOrDefault(em => em.ID.Equals(eID));
                if(employee != null)
                {
                    employee.Name = txtName.Text;
                    employee.Email = txtEmail.Text;
                    employee.Salary = float.Parse(nUDSalary.Value.ToString());
                    employee.Phone = mtxtPhone.Text;
                    employee.Address = txtAddress.Text;
                    employee.HireDate = dateTimePickerHireDate.Value;
                    ShopDB.SaveChanges();
                    LoadEmployeeGrid();
                }    
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtEmail, 0, 50);
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtAddress, 0, 50);
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            string filename = "Employees " + DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
            List<string> skips = new List<string>() { TextDictionary.CONTROL_DELETE_COLUMN_NAME };
            int res = DataExporter.ExportToCSV(dataGridViewEmployees, filename, skips);
            MessageBox.Show(res + " row was exported!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewEmployees_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewEmployees.Rows[e.RowIndex].Cells;
            string selectedColumnName = dataGridViewEmployees.Columns[e.ColumnIndex].Name;
            switch (selectedColumnName)
            {
                case TextDictionary.CONTROL_DELETE_COLUMN_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_DELETE, TextDictionary.TITLE_COMFIRM_DELETE, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string eID = cells[TextDictionary.EMPLOYEE_ID_COLUMN_NAME].Value.ToString();
                        Employee employee = ShopDB.GetShopDBEntities().Employees.FirstOrDefault(em => em.ID.Equals(eID));
                        ShopDB.GetShopDBEntities().Employees.Remove(employee);
                        ShopDB.SaveChanges();
                        LoadEmployeeGrid();
                    }
                    break;
                default:
                    choseCells(cells);
                    break;
            }
        }
    }
}
