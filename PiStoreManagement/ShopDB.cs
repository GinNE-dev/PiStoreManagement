using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStoreManagement
{
    internal class ShopDB
    {
        private static ShopDBEntities dBEntities; 
        public static ShopDBEntities GetShopDBEntities()
        {
            if(dBEntities == null) dBEntities = new ShopDBEntities();
            return dBEntities;
        }

        public static void SaveChanges()
        {
            GetShopDBEntities().SaveChanges();//Make sure ShopDBEntities not null
        }
    }
}
