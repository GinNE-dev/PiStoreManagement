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
    public partial class frmClient : Form
    {
       
        public frmClient()
        {
            InitializeComponent();
            PrepareClientGrid();
            ReloadClientGrid();
        }

        private void PrepareClientGrid()
        {
            dataGridViewClients.Columns.Add(TextDictionary.CLIENT_ID_COLUMN_NAME, TextDictionary.CLIENT_ID_COLUMN_TEXT);
            dataGridViewClients.Columns.Add(TextDictionary.CLIENT_NAME_COLUMN_NAME, TextDictionary.CLIENT_NAME_COLUMN_TEXT);
            dataGridViewClients.Columns.Add(TextDictionary.CLIENT_EMAIL_COLUMN_NAME, TextDictionary.CLIENT_EMAIL_COLUMN_TEXT);
            dataGridViewClients.Columns.Add(TextDictionary.CLIENT_PHONE_COLUMN_NAME, TextDictionary.CLIENT_PHONE_COLUMN_TEXT);
            dataGridViewClients.Columns.Add(TextDictionary.CLIENT_ADDRESS_COLUMN_NAME, TextDictionary.CLIENT_ADDRESS_COLUMN_TEXT);

            DataGridViewButtonColumn ButtonPlaceOrder = new DataGridViewButtonColumn();
            ButtonPlaceOrder.Name = TextDictionary.CONTROL_PLACEORDER_BUTTON_NAME;
            ButtonPlaceOrder.Text = TextDictionary.CONTROL_PLACEORDER_BUTTON_TEXT;
            ButtonPlaceOrder.FlatStyle = FlatStyle.Flat;
            ButtonPlaceOrder.UseColumnTextForButtonValue = true;

            if (dataGridViewClients.Columns[TextDictionary.CONTROL_PLACEORDER_COLUMN_NAME] == null)
            {
                dataGridViewClients.Columns.Insert(dataGridViewClients.Columns.Count, ButtonPlaceOrder);
            }

            DataGridViewButtonColumn ButtonInColumn = new DataGridViewButtonColumn();
            ButtonInColumn.Name = TextDictionary.CONTROL_DELETE_BUTTON_NAME;
            ButtonInColumn.Text = TextDictionary.CONTROL_DELETE_BUTTON_TEXT;
            ButtonInColumn.FlatStyle = FlatStyle.Flat;
            ButtonInColumn.UseColumnTextForButtonValue = true;
            if (dataGridViewClients.Columns[TextDictionary.CONTROL_DELETE_COLUMN_NAME] == null)
            {
                dataGridViewClients.Columns.Insert(dataGridViewClients.Columns.Count, ButtonInColumn);
            }
        }

        private void ReloadClientGrid()
        {
            List<Client> clients = ShopDB.GetShopDBEntities().Clients.ToList();
            UpdateClientGridData(clients);
            if(dataGridViewClients.Rows.Count > 0)
            {
                ShowRowCellsData(dataGridViewClients.Rows[0].Cells);
            }
            else
            {

            }
        }

        private void UpdateClientGridData(IEnumerable<Client> clients)
        {
            dataGridViewClients.ClearSelection();
            dataGridViewClients.Rows.Clear();

            string keyFilter = txtSearch.Text.ToString().ToLower();
            foreach (Client client in clients)
            {
                if (
                    client.ID.ToLower().Contains(keyFilter) ||
                    client.Name.ToLower().Contains(keyFilter)
                  )
                {
                    dataGridViewClients.Rows.Add(client.ID, client.Name, client.Email, client.Phone, client.Address);
                }
            }
        }

        private void ShowRowCellsData(DataGridViewCellCollection cells)
        {
            if(cells != null)
            {
                txtID.Text = cells[TextDictionary.CLIENT_ID_COLUMN_NAME].Value.ToString();
                txtName.Text = cells[TextDictionary.CLIENT_NAME_COLUMN_NAME].Value.ToString();
                mtxtPhone.Text = cells[TextDictionary.CLIENT_PHONE_COLUMN_NAME].Value.ToString();
                txtEmail.Text = cells[TextDictionary.CLIENT_EMAIL_COLUMN_NAME].Value.ToString();
                txtAddress.Text = cells[TextDictionary.CLIENT_ADDRESS_COLUMN_NAME].Value.ToString();
            }
            else
            {
                 ClearClientInputInfo();
            }
        }

        private void ClearClientInputInfo()
        {
            txtID.Text = String.Empty;
            txtName.Text = String.Empty;
            mtxtPhone.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtAddress.Text = String.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_UPDATE, TextDictionary.TITLE_COMFIRM_UPDATE, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string ID = txtID.Text;
                Client client = ShopDB.GetShopDBEntities().Clients.FirstOrDefault(c => c.ID.Equals(ID));
                if (client != null)
                {
                    client.Name = txtName.Text;
                    client.Email = txtEmail.Text;
                    client.Phone = mtxtPhone.Text;
                    client.Address = txtAddress.Text;
                    ShopDB.SaveChanges();
                    ReloadClientGrid();
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form root = this.MdiParent != null ? this.MdiParent : this;
            Form formAddNew = new frmNewClient();

            formAddNew.StartPosition = FormStartPosition.Manual;
            formAddNew.Location = DrawingMathHelper.FindSmallPointCenter(root.Location, root.Size, formAddNew.Size);

            formAddNew.ShowDialog();
            ReloadClientGrid();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            string filename = "Clients " + DateTime.Now.ToString().Replace('/', '-').Replace(':', '-');
            List<string> skips = new List<string>() { TextDictionary.CONTROL_PLACEORDER_COLUMN_NAME};
            int res = DataExporter.ExportToCSV(dataGridViewClients, filename, skips);
            MessageBox.Show(res + " row was exported!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

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

        private void dataGridViewClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewClients.Rows[e.RowIndex].Cells;
            switch (dataGridViewClients.Columns[e.ColumnIndex].Name)
            {
                case TextDictionary.CONTROL_DELETE_BUTTON_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_DELETE,
                        TextDictionary.TITLE_COMFIRM_DELETE, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string ID = cells[TextDictionary.CLIENT_ID_COLUMN_NAME].Value.ToString();
                        Client client = ShopDB.GetShopDBEntities().Clients.FirstOrDefault(c => c.ID.Equals(ID));
                        if(client.Bills.Count > 0)
                        {
                            MessageBox.Show(TextDictionary.MESSAGE_CANNOT_REMOVE_CLIENT_BY_BILL);
                        }
                        else if(client.Orders.Count > 0)
                        {
                            MessageBox.Show(TextDictionary.MESSAGE_CANNOT_REMOVE_CLIENT_BY_ORDER);
                        }
                        else
                        {
                            ShopDB.GetShopDBEntities().Clients.Remove(client);
                            ShopDB.SaveChanges();
                            ReloadClientGrid();
                        }
                    }
                    break;
                case TextDictionary.CONTROL_PLACEORDER_BUTTON_NAME:
                    frmPlaceOrder placeOrderForm = frmMain.GetInstance().GetPlaceOrderForm();
                    if(placeOrderForm.IsInOrderProgress)
                    {
                        MessageBox.Show(TextDictionary.MESSAGE_COMPLETE_CURRENT_ORDER);
                    }
                    else
                    {
                        DialogResult dialogPlaceResult = MessageBox.Show(TextDictionary.MESSAGE_CONFIRM_PLACE_ORDER,
                        TextDictionary.TITLE_CONFIRM_PLACE_ORDER, MessageBoxButtons.YesNo);
                        if (dialogPlaceResult == DialogResult.Yes)
                        {
                            string cID = cells[TextDictionary.CLIENT_ID_COLUMN_NAME].Value.ToString();
                            Client client = ShopDB.GetShopDBEntities().Clients.FirstOrDefault(c => c.ID.Equals(cID));
                            Employee employee = frmMain.GetInstance().GetCurrrentStaff();

                            if (client != null && employee != null)
                            {
                                if (placeOrderForm.RegisterOrder(employee, client))
                                {
                                    frmMain.GetInstance().OpenChildByForeign(placeOrderForm);
                                }
                                else
                                {
                                    MessageBox.Show(TextDictionary.MESSAGE_CANNOT_REGISTER_ORDER_ERROR);
                                }
                            }
                        }
                    }
                    break;
                default:
                    
                    break;
            }
        }

        private void dataGridViewClients_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewClients.Rows[e.RowIndex].Cells;
            ShowRowCellsData(cells);
        }

        private void btnAddNew_VisibleChanged(object sender, EventArgs e)
        {
            if(dataGridViewClients.ColumnCount == 0) return;
            ReloadClientGrid();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ReloadClientGrid();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            ReloadClientGrid();
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
                    Client client;

                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        try
                        {
                            client = new Client();
                            client.ID = values[0];
                            client.Name = values[1];
                            client.Email = values[2];
                            client.Phone = values[3];
                            client.Address = values[4];
                            if (ShopDB.GetShopDBEntities().Clients.FirstOrDefault(x => x.ID.Equals(client.ID)) != null)
                            {
                                continue;
                            }
                            ShopDB.GetShopDBEntities().Clients.Add(client);
                        }
                        catch (Exception ex)
                        {
                            ////MessageBox.Show(ex.Message);
                            Console.WriteLine(ex.Message);
                        }
                    }

                    ShopDB.SaveChanges();
                    ReloadClientGrid();
                }
            }
        }
    }
}
