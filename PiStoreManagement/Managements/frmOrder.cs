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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();

            PrepareOrderGrid();
            PrepareOrderedProductGrid();
            ReloadOrderGrid();

        }

        private void PrepareOrderGrid()
        {
            dataGridViewOrders.Columns.Add(TextDictionary.ORDER_ID_COLUMN_NAME, TextDictionary.ORDER_ID_COLUMN_TEXT);
            dataGridViewOrders.Columns.Add(TextDictionary.CLIENT_NAME_COLUMN_NAME, TextDictionary.CLIENT_NAME_COLUMN_TEXT);
            dataGridViewOrders.Columns.Add(TextDictionary.CLIENT_PHONE_COLUMN_NAME, TextDictionary.CLIENT_PHONE_COLUMN_TEXT);
            dataGridViewOrders.Columns.Add(TextDictionary.ORDER_ORDERDATE_COLUMN_NAME, TextDictionary.ORDER_ORDERDATE_COLUMN_TEXT);
            dataGridViewOrders.Columns.Add(TextDictionary.ORDER_TOTALPRICE_COLUMN_NAME, TextDictionary.ORDER_TOTALPRICE_COLUMN_TEXT);

            DataGridViewButtonColumn ButtonInColumn = new DataGridViewButtonColumn();
            ButtonInColumn.Name = TextDictionary.CONTROL_BILL_BUTTON_NAME;
            ButtonInColumn.Text = TextDictionary.CONTROL_BILL_BUTTON_TEXT;
            ButtonInColumn.FlatStyle = FlatStyle.Flat;
            ButtonInColumn.UseColumnTextForButtonValue = true;
            if (dataGridViewOrders.Columns[TextDictionary.CONTROL_BILL_COLUMN_NAME] == null)
            {
                dataGridViewOrders.Columns.Insert(dataGridViewOrders.Columns.Count, ButtonInColumn);
            }
        }

        private void ReloadOrderGrid()
        {
            List<Order> orders = ShopDB.GetShopDBEntities().Orders.ToList();
            UpdateOrderGridData(orders);
        }

        private void UpdateOrderGridData(IEnumerable<Order> orders)
        {
            dataGridViewOrders.ClearSelection();
            dataGridViewOrders.Rows.Clear();
            foreach (Order o in orders)
            {
                dataGridViewOrders.Rows.Add(o.ID, o.Client.Name, o.Client.Phone, o.OrderDate, o.TotalPrice);
            }
            if (dataGridViewOrders.Rows.Count > 0)
            {
                ShowOrderDetail(dataGridViewOrders.Rows[0].Cells[TextDictionary.ORDER_ID_COLUMN_NAME].Value.ToString());
            }
            else
            {

            }
        }

        private void ShowOrderDetail(string orderID)
        {
            if (string.IsNullOrEmpty(orderID)) return;
            
            Order selectedOrder = ShopDB.GetShopDBEntities().Orders.FirstOrDefault(o => o.ID.Equals(orderID));
            if (selectedOrder != null)
            {
                ReloadOrderInfoVisual(selectedOrder);
                UpdateOrderedProductGridData(selectedOrder.OrderItems);
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

        private void ReloadOrderInfoVisual(Order order)
        {
            lblOrderID2.Text = order.ID;
            lblCustomer2.Text = order.Client.Name;
            lblStaff2.Text = order.Employee.Name;
            lblOrderDate2.Text = order.OrderDate.ToString();
            lblTotalPrice2.Text = order.TotalPrice.ToString();
        }

        private void dataGridViewOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmOrder_VisibleChanged(object sender, EventArgs e)
        {
            ReloadOrderGrid();
        }

        private void dataGridViewOrders_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewOrders.Rows[e.RowIndex].Cells;
            string selectedOrderID = cells[TextDictionary.ORDER_ID_COLUMN_NAME].Value.ToString();
            ShowOrderDetail(selectedOrderID);
        }

        private void btnCB_Click(object sender, EventArgs e)
        {
            DataExporter.ExportBill();
        }
    }
}
