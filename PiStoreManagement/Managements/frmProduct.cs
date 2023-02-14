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
    public partial class frmProduct : Form
    {
        public frmProduct()
        {
            InitializeComponent();
            PrepareProductGrid();
            ReloadProductGrid();
        }

        private void PrepareProductGrid()
        {
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_ID_COLUMN_NAME, TextDictionary.PRODUCT_ID_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_NAME_COLUMN_NAME, TextDictionary.PRODUCT_NAME_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_PRICE_COLUMN_NAME, TextDictionary.PRODUCT_PRICE_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_QUANTYTY_COLUMN_NAME, TextDictionary.PRODUCT_QUANTYTY_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_DESCRIPTION_COLUMN_NAME, TextDictionary.PRODUCT_DESCRIPTION_COLUMN_TEXT);

            DataGridViewButtonColumn DeleteButton = new DataGridViewButtonColumn();
            DeleteButton.Name = TextDictionary.CONTROL_DELETE_BUTTON_NAME;
            DeleteButton.Text = TextDictionary.CONTROL_DELETE_BUTTON_TEXT;
            DeleteButton.UseColumnTextForButtonValue = true;
            if (dataGridViewProducts.Columns[TextDictionary.CONTROL_DELETE_COLUMN_NAME] == null)
            {
                dataGridViewProducts.Columns.Insert(dataGridViewProducts.Columns.Count, DeleteButton);
            }
        }

        private void ReloadProductGrid()
        {
            List<Product> products = ShopDB.GetShopDBEntities().Products.ToList();
            UpdateProductGridData(products);
            if (dataGridViewProducts.Rows.Count > 0)
            {
                ShowRowCellsData(dataGridViewProducts.Rows[0].Cells);
            }
            else
            {

            }
        }

        private void UpdateProductGridData(IEnumerable<Product> products)
        {
            dataGridViewProducts.ClearSelection();
            dataGridViewProducts.Rows.Clear();
            foreach (Product p in products)
            {
                dataGridViewProducts.Rows.Add(p.ID, p.Name, p.Price, p.Quantity, p.Decription);
            }
        }

        private void ShowRowCellsData(DataGridViewCellCollection cells)
        {
            if (cells != null)
            {
                txtID.Text = cells[TextDictionary.PRODUCT_ID_COLUMN_NAME].Value.ToString();
                txtName.Text = cells[TextDictionary.PRODUCT_NAME_COLUMN_NAME].Value.ToString();
                numUDPrice.Text = cells[TextDictionary.PRODUCT_PRICE_COLUMN_NAME].Value.ToString();
                numUDQuantity.Text = cells[TextDictionary.PRODUCT_QUANTYTY_COLUMN_NAME].Value.ToString();
                rtxtDescription.Text = cells[TextDictionary.PRODUCT_DESCRIPTION_COLUMN_NAME].Value.ToString();
            }
            else
            {
                ClearProductInputInfo();
            }
        }

        private void ClearProductInputInfo()
        {
            txtID.Text = String.Empty;
            txtName.Text = String.Empty;
            numUDPrice.Text = numUDPrice.Minimum.ToString();
            numUDQuantity.Text = numUDQuantity.Minimum.ToString();
            rtxtDescription.Text = String.Empty;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_UPDATE, 
                TextDictionary.TITLE_COMFIRM_UPDATE, MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string ID = txtID.Text;
                Product product = ShopDB.GetShopDBEntities().Products.FirstOrDefault(p => p.ID.Equals(ID));
                if (product != null)
                {
                    product.Name = txtName.Text;
                    product.Price = double.Parse(numUDPrice.Value.ToString());
                    product.Quantity = int.Parse(numUDQuantity.Value.ToString());
                    product.Decription = rtxtDescription.Text;
                    ShopDB.SaveChanges();
                    ReloadProductGrid();
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Form root = this.MdiParent != null ? this.MdiParent : this;
            Form formAddNew = new frmNewProduct();
            
            formAddNew.StartPosition = FormStartPosition.Manual;
            formAddNew.Location = DrawingMathHelper.FindSmallPointCenter(root.Location, root.Size, formAddNew.Size);

            formAddNew.ShowDialog();
            ReloadProductGrid();
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

        private void richTextBoxDescription_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(rtxtDescription, 0, 200);
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmProduct_VisibleChanged(object sender, EventArgs e)
        {
            ReloadProductGrid();
        }

        private void dataGridViewProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewProducts.Rows[e.RowIndex].Cells;
            switch (dataGridViewProducts.Columns[e.ColumnIndex].Name)
            {
                case TextDictionary.CONTROL_DELETE_COLUMN_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_COMFIRM_DELETE,
                        TextDictionary.TITLE_COMFIRM_DELETE, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string ID = cells[TextDictionary.PRODUCT_ID_COLUMN_NAME].Value.ToString();
                        Product product = ShopDB.GetShopDBEntities().Products.FirstOrDefault(p => p.ID.Equals(ID));
                        ShopDB.GetShopDBEntities().Products.Remove(product);
                        ShopDB.SaveChanges();
                        ReloadProductGrid();
                    }
                    break;
                default:
                    ShowRowCellsData(cells);
                    break;
            }
        }
    }
}
