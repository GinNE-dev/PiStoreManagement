using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStoreManagement.Tools
{
    public class TestingTool
    {
        public static void GenerateRandomOrderForTest()
        {
            var random = new Random();
            Order order;
            Client client;
            double total;
            for(int i=1; i<5; i++)
            {
                total = 0;
                order = new Order();
                order.ID = Guid.NewGuid().ToString();
                order.OrderDate = DateTime.Parse("01/01/2022");
                client = ShopDB.GetShopDBEntities().Clients.OrderBy(c => SqlFunctions.Rand()).FirstOrDefault();
                //client = ShopDB.GetShopDBEntities().Clients.OrderBy(c => random.Next()).AsNoStra.FirstOrDefault();
                order.ClientID = client.ID;
                order.Client = client;
                order.Employee = frmMain.GetInstance().GetCurrrentStaff();
                order.EmployeeID = order.Employee.ID;

                OrderItem oi;
                Product product;
                int quantity = 0;
                for(int nP=0; nP<random.Next(2, 10); nP++)
                {
                    
                    product = ShopDB.GetShopDBEntities().Products.OrderBy(p=> SqlFunctions.Rand()).FirstOrDefault();
                    if (product.Quantity == 0) continue;
                    quantity = random.Next(1, product.Quantity);
                    oi = new OrderItem();
                    oi.ID = Guid.NewGuid().ToString();
                    oi.OrderID = order.ID;
                    oi.ProductID = product.ID;
                    oi.Order = order;
                    oi.Product = product;
                    oi.Quantity = quantity;
                    product.Quantity-=quantity;
                    order.OrderItems.Add(oi);

                    total += oi.Quantity * product.Price;
                }

                
                order.TotalPrice = total;

                ShopDB.GetShopDBEntities().Orders.Add(order);
                ShopDB.SaveChanges();
            }

            Bill bill;
            foreach(Order od in ShopDB.GetShopDBEntities().Orders)
            {
                var start = new DateTime(2022, 1, 1);
                var range = (DateTime.Today - start).Days;

                bill = ShopDB.GetShopDBEntities().Bills.FirstOrDefault(b => b.OrderID.Equals(od.ID));
                if (bill == null)
                {
                    bill = new Bill();
                    bill.ID = Guid.NewGuid().ToString();
                    bill.OrderID = od.ID;
                    bill.ClientID = od.ClientID;
                    bill.EmployeeID = od.EmployeeID;
                    bill.BillDate = start.AddDays(random.Next(range));
                    bill.TotalPrice = od.TotalPrice;
                    bill.Client = od.Client;
                    bill.Employee = od.Employee;
                    bill.Order = od;
                    od.Bills.Add(bill);
                }
            }
            ShopDB.SaveChanges();
        }
    }
}
