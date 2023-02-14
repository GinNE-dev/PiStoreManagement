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

            DataGridViewButtonColumn DeleteButton = new DataGridViewButtonColumn();
            DeleteButton.Name = TextDictionary.CONTROL_DELETE_BUTTON_NAME;
            DeleteButton.Text = TextDictionary.CONTROL_DELETE_BUTTON_TEXT;
            DeleteButton.UseColumnTextForButtonValue = true;
            if (dataGridViewClients.Columns[TextDictionary.CONTROL_DELETE_COLUMN_NAME] == null)
            {
                dataGridViewClients.Columns.Insert(dataGridViewClients.Columns.Count, DeleteButton);
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
            foreach(Client client in clients)
            {
                dataGridViewClients.Rows.Add(client.ID, client.Name, client.Email, client.Phone, client.Address);
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
            
        }

        private void dataGridViewClients_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewClients.Rows[e.RowIndex].Cells;
            switch (dataGridViewClients.Columns[e.ColumnIndex].Name)
            {
                case TextDictionary.CONTROL_DELETE_COLUMN_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_DELETE,
                        TextDictionary.TITLE_COMFIRM_DELETE, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string ID = cells[TextDictionary.CLIENT_ID_COLUMN_NAME].Value.ToString();
                        Client client = ShopDB.GetShopDBEntities().Clients.FirstOrDefault(c => c.ID.Equals(ID));
                        ShopDB.GetShopDBEntities().Clients.Remove(client);
                        ShopDB.SaveChanges();
                        ReloadClientGrid();
                    }
                    break;
                default:
                    ShowRowCellsData(cells);
                    break;
            }
        }
    }
}
