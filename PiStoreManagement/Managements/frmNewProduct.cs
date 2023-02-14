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
    public partial class frmNewProduct : Form
    {
        public frmNewProduct()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(txtName, 0, 50);
        }

        private void rtxtDescription_TextChanged(object sender, EventArgs e)
        {
            InputValidateHelper.ValidateTextBoxLength(rtxtDescription, 0, 200);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string ID = Guid.NewGuid().ToString();
            string Name = txtName.Text;
            double price = double.Parse(numUDPrice.Value.ToString());
            int quantity = int.Parse(numUDQuantity.Value.ToString());
            string descripion = rtxtDescription.Text;


            Product product = new Product();
            product.ID = ID;
            product.Name = Name;
            product.Price = price;
            product.Quantity = quantity;
            product.Decription = descripion;

            ShopDB.GetShopDBEntities().Products.Add(product);
            ShopDB.GetShopDBEntities().SaveChanges();

            MessageBox.Show("Success!");
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
