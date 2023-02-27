using PiStoreManagement.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

            string keyFilter = txtSearch.Text.ToString().ToLower();
            foreach (Employee e in employees)
            {
                if(
                    e.ID.ToLower().Contains(keyFilter) ||
                    e.Name.ToLower().Contains (keyFilter)
                  )
                {
                    dataGridViewEmployees.Rows.Add(e.ID, e.Name, e.Email, e.Phone, e.Address, e.Salary, e.HireDate);
                }
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

            DataGridViewButtonColumn ButtonInColumn = new DataGridViewButtonColumn();
            ButtonInColumn.Name = TextDictionary.CONTROL_DELETE_BUTTON_NAME;
            ButtonInColumn.Text = TextDictionary.CONTROL_DELETE_BUTTON_TEXT;
            ButtonInColumn.FlatStyle = FlatStyle.Flat;
            ButtonInColumn.UseColumnTextForButtonValue = true;
            if (dataGridViewEmployees.Columns[TextDictionary.CONTROL_DELETE_COLUMN_NAME] == null)
            {
                dataGridViewEmployees.Columns.Insert(dataGridViewEmployees.Columns.Count, ButtonInColumn);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtName, 0, 50);
        }

        private void btnAddEmployee_Click(object sender, EventArgs e)
        {
            Form root = (this.MdiParent != null) ? this.MdiParent : this;
            Form formAddNew = new frmNewEmployee();

            formAddNew.StartPosition = FormStartPosition.Manual;
            formAddNew.Location = DrawingMathHelper.FindSmallPointCenter(root.Location, root.Size, formAddNew.Size);
            
            formAddNew.ShowDialog();
            LoadEmployeeGrid();
        }

        private void dataGridViewEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewEmployees.Rows[e.RowIndex].Cells;
            string selectedColumnName = dataGridViewEmployees.Columns[e.ColumnIndex].Name;
            switch (selectedColumnName)
            {
                case TextDictionary.CONTROL_DELETE_BUTTON_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_DELETE, 
                        TextDictionary.TITLE_COMFIRM_DELETE, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string eID = cells[TextDictionary.EMPLOYEE_ID_COLUMN_NAME].Value.ToString();
                        Employee employee = ShopDB.GetShopDBEntities().Employees.FirstOrDefault(em => em.ID.Equals(eID));
                        var currentStaff = frmMain.GetInstance().GetCurrrentStaff();
                        if(employee.ID.Equals(currentStaff.ID))
                        {
                            MessageBox.Show(TextDictionary.MESSAGE_CANNOT_REMOVE_YOURSELF);
                        }
                        else
                        {
                            if(employee.Bills.Count > 0)
                            {
                                MessageBox.Show(TextDictionary.MESSAGE_CANNOT_REMOVE_EMPLOYEE_BY_BILL);
                            }
                            else if (employee.Orders.Count > 0)
                            {
                                MessageBox.Show(TextDictionary.MESSAGE_CANNOT_REMOVE_EMPLOYEE_BY_ORDER);
                            }
                            else
                            {
                                ShopDB.GetShopDBEntities().Employees.Remove(employee);
                                ShopDB.SaveChanges();
                                LoadEmployeeGrid();
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
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
            LoadEmployeeGrid();
        }

        private void dataGridViewEmployees_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewEmployees.Rows[e.RowIndex].Cells;
            choseCells(cells);
        }

        private void btnAddEmployee_VisibleChanged(object sender, EventArgs e)
        {
            if(dataGridViewEmployees.Rows.Count == 0) return;
            LoadEmployeeGrid();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadEmployeeGrid();
        }

        private void btnImportTestData_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                using (var reader = new StreamReader(filePath))
                {
                    Employee employee;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        try
                        {
                            
                            employee = new Employee();
                            employee.ID = values[0];
                            employee.Name = values[1];
                            employee.Email = values[2];
                            employee.Phone = values[3];
                            employee.Salary = double.Parse(values[4]);
                            employee.Address = values[5];
                            employee.HireDate = DateTime.Parse(values[6]);

                            if(ShopDB.GetShopDBEntities().Employees.FirstOrDefault(em=>em.ID.Equals(employee.ID))!=null)
                            {
                                continue;
                            }

                            ShopDB.GetShopDBEntities().Employees.Add(employee);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            //MessageBox.Show(ex.Message);
                        }
                    }

                    
                    ShopDB.SaveChanges();
                    LoadEmployeeGrid();
                }
            }
        }
    }
}
