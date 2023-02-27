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
    public partial class frmPlaceOrder : Form
    {
        private Order _currentOrder;
        private Employee _currentStaff = new Employee();
        private Client _currentClient = new Client();

        public bool IsInOrderProgress { get; private set; } = false;

        public frmPlaceOrder()
        {
            InitializeComponent();
            //
            PrepareProductGrid();
            PrepareOrderedProductGrid();
        }

        public bool RegisterOrder(Employee currentStaff, Client client)
        {
            if (IsInOrderProgress)
            {
                return false;
            }

            _currentStaff = currentStaff;
            _currentClient = client;

            GetNotNullCurrentOrder();
            UpdateOrderVisualInfo();
            ReloadOrderedProductGrid();
            ReloadProductGrid();

            IsInOrderProgress = true;

            return true;
        }

        private void ConfirmOrderProgress()
        {
            ShopDB.GetShopDBEntities().Orders.Add(GetNotNullCurrentOrder());
            ShopDB.SaveChanges();

            _currentOrder = null;
            IsInOrderProgress = false;
        }

        private void CancelOrderProgress()
        {
            foreach(OrderItem oi in GetNotNullCurrentOrder().OrderItems)
            {
                var product = ShopDB.GetShopDBEntities().Products.FirstOrDefault(p => p.ID.Equals(oi.ProductID));
                if(product != null)
                {
                    product.Quantity += oi.Quantity;
                    ShopDB.SaveChanges();
                }
            }

            _currentOrder = null;
            IsInOrderProgress = false;
        }

        private Order GetNotNullCurrentOrder()
        {
            if(_currentOrder == null)
            {
                _currentOrder = new Order();
                _currentOrder.Employee = _currentStaff;
                _currentOrder.Client = _currentClient;

                _currentOrder.ID = Guid.NewGuid().ToString();
                _currentOrder.ClientID = _currentOrder.Client.ID;
                _currentOrder.EmployeeID = _currentOrder.Employee.ID;
                _currentOrder.OrderDate = DateTime.Now;
                _currentOrder.TotalPrice = 0;
            }

            return _currentOrder;
        }

        private void UpdateOrderVisualInfo()
        {
            txtOrderID.Text = GetNotNullCurrentOrder().ID;
            txtCustomerName.Text = GetNotNullCurrentOrder().Client.Name;
            txtStaffName.Text = GetNotNullCurrentOrder().Employee.Name;
        }
        
        private void PrepareProductGrid()
        {
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_ID_COLUMN_NAME, TextDictionary.PRODUCT_ID_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_NAME_COLUMN_NAME, TextDictionary.PRODUCT_NAME_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_PRICE_COLUMN_NAME, TextDictionary.PRODUCT_PRICE_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_QUANTYTY_COLUMN_NAME, TextDictionary.PRODUCT_QUANTYTY_COLUMN_TEXT);
            dataGridViewProducts.Columns.Add(TextDictionary.PRODUCT_DESCRIPTION_COLUMN_NAME, TextDictionary.PRODUCT_DESCRIPTION_COLUMN_TEXT);

            DataGridViewButtonColumn OrderButton = new DataGridViewButtonColumn();
            OrderButton.Name = TextDictionary.CONTROL_ORDER_BUTTON_NAME;
            OrderButton.Text = TextDictionary.CONTROL_ORDER_BUTTON_TEXT;
            OrderButton.UseColumnTextForButtonValue = true;
            if (dataGridViewProducts.Columns[TextDictionary.CONTROL_ORDER_COLUMN_NAME] == null)
            {
                dataGridViewProducts.Columns.Insert(dataGridViewProducts.Columns.Count, OrderButton);
            }
        }

        private void ReloadProductGrid()
        {
            List<Product> products = ShopDB.GetShopDBEntities().Products.ToList();
            UpdateProductGridData(products);
        }

        private void UpdateProductGridData(IEnumerable<Product> products)
        {
            dataGridViewProducts.ClearSelection();
            dataGridViewProducts.Rows.Clear();

            string keyFilter = txtSearch.Text.ToString().ToLower();
            foreach (Product p in products)
            {
                if (
                    p.ID.ToLower().Contains(keyFilter) ||
                    p.Name.ToLower().Contains(keyFilter)
                  )
                {
                   dataGridViewProducts.Rows.Add(p.ID, p.Name, p.Price, p.Quantity, p.Decription);
                }
            }
        }

        private void PrepareOrderedProductGrid()
        {
            dataGridViewOrderdProducts.Columns.Add(TextDictionary.PRODUCT_ID_COLUMN_NAME, TextDictionary.PRODUCT_ID_COLUMN_TEXT);
            dataGridViewOrderdProducts.Columns.Add(TextDictionary.PRODUCT_NAME_COLUMN_NAME, TextDictionary.PRODUCT_NAME_COLUMN_TEXT);
            //dataGridViewOrderdProducts.Columns.Add(TextDictionary.PRODUCT_PRICE_COLUMN_NAME, TextDictionary.PRODUCT_PRICE_COLUMN_TEXT);
            dataGridViewOrderdProducts.Columns.Add(TextDictionary.PRODUCT_QUANTYTY_COLUMN_NAME, TextDictionary.PRODUCT_QUANTYTY_COLUMN_TEXT);
            dataGridViewOrderdProducts.Columns.Add(TextDictionary.ORDERITEM_TOTALCOST_COLUMN_NAME, TextDictionary.ORDERITEM_TOTALCOST_COLUMN_TEXT);

            DataGridViewButtonColumn CancelButton = new DataGridViewButtonColumn();
            CancelButton.Name = TextDictionary.CONTROL_CANCEL_BUTTON_NAME;
            CancelButton.Text = TextDictionary.CONTROL_CANCEL_BUTTON_TEXT;
            CancelButton.UseColumnTextForButtonValue = true;
            if (dataGridViewProducts.Columns[TextDictionary.CONTROL_CANCEL_COLUMN_NAME] == null)
            {
                dataGridViewOrderdProducts.Columns.Insert(dataGridViewOrderdProducts.Columns.Count, CancelButton);
            }
        }

        private void ReloadOrderedProductGrid()
        {
           
           UpdateOrderedProductGridData(GetNotNullCurrentOrder().OrderItems.ToList());
           
        }

        private void UpdateOrderedProductGridData(IEnumerable<OrderItem> orderItems)
        {
            dataGridViewOrderdProducts.ClearSelection();
            dataGridViewOrderdProducts.Rows.Clear();
            Product p;
            foreach (OrderItem oi in orderItems)
            {
                p = oi.Product;
                if(p != null)
                {
                    dataGridViewOrderdProducts.Rows.Add(p.ID, p.Name, oi.Quantity, oi.Quantity*p.Price);
                }
                
            }
        }

        private DialogResult NumericInputDialog(string title, string message, ref int inputValue)
        {

            Form dialog = new Form();
            Label label = new Label();
            NumericUpDown numInput = new NumericUpDown();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            dialog.Text = title;
            label.Text = message;
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(10, 40, 90, 16);
            numInput.SetBounds(10, 59, 123, 22);
            numInput.Minimum = 1;
            numInput.Maximum = 1000;
            buttonOk.SetBounds(10, 117, 75, 23);
            buttonCancel.SetBounds(127, 117, 75, 23);

            label.AutoSize = true;
            dialog.ClientSize = new Size(208, 150);
            dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            dialog.StartPosition = FormStartPosition.Manual;
            dialog.Location = DrawingMathHelper.FindSmallPointCenter(this.Location, this.Size, dialog.Size);
            dialog.MinimizeBox = false;
            dialog.MaximizeBox = false;

            dialog.Controls.AddRange(new Control[] { label, numInput, buttonOk, buttonCancel });
            dialog.AcceptButton = buttonOk;
            dialog.CancelButton = buttonCancel;

            DialogResult dialogResult = dialog.ShowDialog();
            inputValue = int.Parse(numInput.Value.ToString());

            return dialogResult;
        }

        private void dataGridViewProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewProducts.Rows[e.RowIndex].Cells;
            switch (dataGridViewProducts.Columns[e.ColumnIndex].Name)
            {
                case TextDictionary.CONTROL_ORDER_COLUMN_NAME:
                    string pID = cells[TextDictionary.PRODUCT_ID_COLUMN_NAME].Value.ToString();
                    int quantity = 1;
                    if (NumericInputDialog(TextDictionary.TITLE_ORDER_QUANTITY_DIALOG,
                        TextDictionary.MESSAGE_ORDER_QUANTITY_DIALOG,ref quantity) == DialogResult.OK)
                    {
                        var product = ShopDB.GetShopDBEntities().Products.FirstOrDefault(p => p.ID.Equals(pID));
                        if (product != null)
                        {
                            if (product.Quantity >= quantity)
                            {
                                string currentOrderID = GetNotNullCurrentOrder().ID;
                                OrderItem orderitem;
                                orderitem = GetNotNullCurrentOrder().OrderItems.FirstOrDefault
                                    (
                                    oi => oi.OrderID.Equals(currentOrderID)
                                    && oi.ProductID.Equals(pID)
                                    );

                                if(orderitem == null)
                                {
                                    orderitem = new OrderItem();
                                    orderitem.ID = Guid.NewGuid().ToString();
                                    orderitem.Order = GetNotNullCurrentOrder();
                                    orderitem.Product = product;
                                    orderitem.OrderID = orderitem.Order.ID;
                                    orderitem.ProductID = product.ID;
                                    orderitem.Quantity = quantity;
                                }
                                else
                                {
                                    orderitem.Quantity+=quantity;
                                }
                                product.Quantity -= quantity;

                                GetNotNullCurrentOrder().TotalPrice += quantity * product.Price;

                                GetNotNullCurrentOrder().OrderItems.Add(orderitem);

                                ShopDB.SaveChanges();

                                ReloadProductGrid();
                                ReloadOrderedProductGrid();
                            }
                            else
                            {
                                MessageBox.Show(TextDictionary.MESSAGE_NOT_ENOUGH_PRODUCT);
                            }
                        }
                    }
                    break;
                case TextDictionary.CONTROL_CANCEL_COLUMN_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_CONFIRM_CANCEL_PRODUCT,
                        TextDictionary.TITLE_CONFIRM_CANCEL_PRODUCT, MessageBoxButtons.YesNo);
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
                     
                    
                    break;
            }
        }

        private void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            ConfirmOrderProgress();
            this.Hide();
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            CancelOrderProgress();
            this.Hide();
        }

        private void dataGridViewOrderdProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            DataGridViewCellCollection cells = dataGridViewOrderdProducts.Rows[e.RowIndex].Cells;
            switch (dataGridViewOrderdProducts.Columns[e.ColumnIndex].Name)
            {
                case TextDictionary.CONTROL_CANCEL_COLUMN_NAME:
                    DialogResult dialogResult = MessageBox.Show(TextDictionary.MESSAGE_CONFIRM_CANCEL_PRODUCT,
                        TextDictionary.TITLE_CONFIRM_CANCEL_PRODUCT, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        string ID = cells[TextDictionary.PRODUCT_ID_COLUMN_NAME].Value.ToString();
                        OrderItem orderItem = GetNotNullCurrentOrder().OrderItems.FirstOrDefault(oi => oi.ProductID.Equals(ID));
                        var dbProduct = ShopDB.GetShopDBEntities().Products.FirstOrDefault(p => p.ID.Equals(ID));

                        if(orderItem != null && dbProduct != null)
                        {
                            dbProduct.Quantity += orderItem.Quantity;
                            GetNotNullCurrentOrder().TotalPrice -= orderItem.Quantity * dbProduct.Price;
                            GetNotNullCurrentOrder().OrderItems.Remove(orderItem);
                        }

                        ShopDB.SaveChanges();

                        ReloadProductGrid();
                        ReloadOrderedProductGrid();
                    }
                    break;
                default:
                    break;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            ReloadProductGrid();
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            ReloadProductGrid();
        }
    }


}
