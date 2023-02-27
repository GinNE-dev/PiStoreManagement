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
    public partial class frmBill : Form
    {
        public frmBill()
        {
            InitializeComponent();

            PrepareBillGrid();
            PrepareOrderedProductGrid();
            ReloadBillGrid();
        }

        private void PrepareBillGrid()
        {
            dataGridViewBills.Columns.Add(TextDictionary.BILL_ID_COLUMN_NAME, TextDictionary.BILL_ID_COLUMN_TEXT);
            dataGridViewBills.Columns.Add(TextDictionary.CLIENT_NAME_COLUMN_NAME, TextDictionary.CLIENT_NAME_COLUMN_TEXT);
            dataGridViewBills.Columns.Add(TextDictionary.CLIENT_PHONE_COLUMN_NAME, TextDictionary.CLIENT_PHONE_COLUMN_TEXT);
            dataGridViewBills.Columns.Add(TextDictionary.BILL_BILLDATE_COLUMN_NAME, TextDictionary.BILL_BILLDATE_COLUMN_NAME);
            dataGridViewBills.Columns.Add(TextDictionary.BILL_TOTALPRICE_COLUMN_NAME, TextDictionary.BILL_TOTALPRICE_COLUMN_TEXT);

            
            DataGridViewButtonColumn ButtonInColumn = new DataGridViewButtonColumn();
            ButtonInColumn.Name = TextDictionary.CONTROL_EXPORTBILL_BUTTON_NAME;
            ButtonInColumn.Text = TextDictionary.CONTROL_EXPORTBILL_BUTTON_TEXT;
            ButtonInColumn.FlatStyle = FlatStyle.Flat;
            ButtonInColumn.UseColumnTextForButtonValue = true;
            if (dataGridViewBills.Columns[TextDictionary.CONTROL_EXPORTBILL_COLUMN_NAME] == null)
            {
                dataGridViewBills.Columns.Insert(dataGridViewBills.Columns.Count, ButtonInColumn);
            }
        }

        private void ReloadBillGrid()
        {
            List<Bill> bills = ShopDB.GetShopDBEntities().Bills.ToList();
            UpdateOrderGridData(bills);
        }

        private void UpdateOrderGridData(IEnumerable<Bill> bills)
        {
            dataGridViewBills.ClearSelection();
            dataGridViewBills.Rows.Clear();

            string keyFilter = txtSearch.Text.ToString().ToLower();
            foreach (Bill b in bills)
            {
                if (
                    b.ID.ToLower().Contains(keyFilter) ||
                    b.Client.Name.ToLower().Contains(keyFilter) ||
                    b.Employee.Name.ToLower().Contains(keyFilter)
                  )
                    dataGridViewBills.Rows.Add(b.ID, b.Client.Name, b.Client.Phone, b.BillDate, b.TotalPrice);
            }
            if (dataGridViewBills.Rows.Count > 0)
            {
                ShowBillDetail(dataGridViewBills.Rows[0].Cells[TextDictionary.BILL_ID_COLUMN_NAME].Value.ToString());
            }
            else
            {

            }
        }

        private void ShowBillDetail(string billID)
        {
            if (string.IsNullOrEmpty(billID)) return;

            Bill selectedBill = ShopDB.GetShopDBEntities().Bills.FirstOrDefault(b => b.ID.Equals(billID));
            if (selectedBill != null)
            {
                ReloadBillInfoVisual(selectedBill);
                UpdateOrderedProductGridData(selectedBill.Order.OrderItems);
            }
        }

        private void PrepareOrderedProductGrid()
        {
            dataGridViewOderedProducts.Columns.Add(TextDictionary.PRODUCT_ID_COLUMN_NAME, TextDictionary.PRODUCT_ID_COLUMN_TEXT);
            dataGridViewOderedProducts.Columns.Add(TextDictionary.PRODUCT_NAME_COLUMN_NAME, TextDictionary.PRODUCT_NAME_COLUMN_TEXT);
            dataGridViewOderedProducts.Columns.Add(TextDictionary.PRODUCT_PRICE_COLUMN_NAME, TextDictionary.PRODUCT_PRICE_COLUMN_TEXT);
            dataGridViewOderedProducts.Columns.Add(TextDictionary.PRODUCT_QUANTYTY_COLUMN_NAME, TextDictionary.PRODUCT_QUANTYTY_COLUMN_TEXT);
            dataGridViewOderedProducts.Columns.Add(TextDictionary.ORDERITEM_TOTALCOST_COLUMN_NAME, TextDictionary.ORDERITEM_TOTALCOST_COLUMN_TEXT);
        }

        private void UpdateOrderedProductGridData(IEnumerable<OrderItem> orderItems)
        {
            dataGridViewOderedProducts.ClearSelection();
            dataGridViewOderedProducts.Rows.Clear();
            Product p;
            foreach (OrderItem oi in orderItems)
            {
                p = oi.Product;
                if (p != null)
                {
                    dataGridViewOderedProducts.Rows.Add(p.ID, p.Name, p.Price, oi.Quantity, oi.Quantity * p.Price);
                }
            }
        }

        private void ReloadBillInfoVisual(Bill bill)
        {
            lblOrderID2.Text = bill.ID;
            lblCustomer2.Text = bill.Client.Name;
            lblStaff2.Text = bill.Employee.Name;
            lblOrderDate2.Text = bill.BillDate.ToString();
            lblTotalPrice2.Text = bill.TotalPrice.ToString();
        }

        private void dataGridViewBills_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewBills.Rows[e.RowIndex].Cells;
            string selectedBillID = cells[TextDictionary.BILL_ID_COLUMN_NAME].Value.ToString();
            Bill bill = ShopDB.GetShopDBEntities().Bills.FirstOrDefault(b => b.ID.Equals(selectedBillID));
            if(bill != null)
            {
                ShowBillDetail(bill.ID);
            }
        }

        private void frmBill_VisibleChanged(object sender, EventArgs e)
        {
            ReloadBillGrid();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = String.Empty;
            ReloadBillGrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ReloadBillGrid();
        }

        private void dataGridViewBills_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewBills.Rows[e.RowIndex].Cells;
            switch (dataGridViewBills.Columns[e.ColumnIndex].Name)
            {
                case TextDictionary.CONTROL_EXPORTBILL_COLUMN_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_CONFIRM_EXPORTBILL,
                        TextDictionary.TITLE_CONFIRM_EXPORTBILL, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string ID = cells[TextDictionary.BILL_ID_COLUMN_NAME].Value.ToString();
                        //MessageBox.Show(ID);
                        Bill bill = ShopDB.GetShopDBEntities().Bills.FirstOrDefault(b => b.ID.Equals(ID));
                        if (bill != null)
                        {
                            DataExporter.ExportBill(bill);
                        }

                        ReloadBillGrid();
                    }
                    break;
                default:

                    break;
            }
        }
    }
}
