using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiStoreManagement.Managements
{
    internal struct TextDictionary
    {
        //DON'T CHANGE ANYTHING
        public const string PRODUCT_ID_COLUMN_NAME = "ProductID";
        public const string PRODUCT_NAME_COLUMN_NAME = "ProductName";
        public const string PRODUCT_QUANTYTY_COLUMN_NAME = "Quantity";
        public const string PRODUCT_PRICE_COLUMN_NAME = "Price";
        public const string PRODUCT_DESCRIPTION_COLUMN_NAME = "Description";

        public const string ORDER_ID_COLUMN_NAME = "OrderID";
        public const string ORDER_ORDERDATE_COLUMN_NAME = "OrderDate";
        public const string ORDER_TOTALPRICE_COLUMN_NAME = "OrderTotalPrice";

        public const string BILL_ID_COLUMN_NAME = "BillID";
        public const string BILL_BILLDATE_COLUMN_NAME = "BillDate";
        public const string BILL_TOTALPRICE_COLUMN_NAME = "BillTotalCost";

        public const string EMPLOYEE_ID_COLUMN_NAME = "EmployeeID";
        public const string EMPLOYEE_NAME_COLUMN_NAME = "EName";
        public const string EMPLOYEE_EMAIL_COLUMN_NAME = "EEmail";
        public const string EMPLOYEE_PHONE_COLUMN_NAME = "EPhone";   
        public const string EMPLOYEE_ADDRESS_COLUMN_NAME = "EAddress";
        public const string EMPLOYEE_SALARY_COLUMN_NAME = "ESalary";
        public const string EMPLOYEE_HIREDATE_COLUMN_NAME = "EHire_Date";
        
        public const string CLIENT_ID_COLUMN_NAME = "ClientID";
        public const string CLIENT_NAME_COLUMN_NAME = "ClientName";
        public const string CLIENT_EMAIL_COLUMN_NAME = "ClientEmail";
        public const string CLIENT_PHONE_COLUMN_NAME = "ClientPhone";
        public const string CLIENT_ADDRESS_COLUMN_NAME = "ClientAddress";
        
        public const string CONTROL_DELETE_BUTTON_NAME = "Delete";
        public const string CONTROL_DELETE_COLUMN_NAME = "Delete";
        public const string CONTROL_ORDER_COLUMN_NAME = "Order";
        public const string CONTROL_ORDER_BUTTON_NAME = "Order";
        public const string CONTROL_EXPORTBILL_COLUMN_NAME = "Export";
        public const string CONTROL_EXPORTBILL_BUTTON_NAME = "Export";

        public const string CONTROL_CANCEL_COLUMN_NAME = "Cancel";
        public const string CONTROL_CANCEL_BUTTON_NAME = "Cancel";
        public const string CONTROL_BILL_COLUMN_NAME = "Bill";
        public const string CONTROL_BILL_BUTTON_NAME = "Bill";
        public const string CONTROL_PLACEORDER_COLUMN_NAME = "Place Order";
        public const string CONTROL_PLACEORDER_BUTTON_NAME = "PlaceOrder";

        public const string ORDERITEM_TOTALCOST_COLUMN_NAME = "ODTotal";

        //Column display text
        public const string PRODUCT_ID_COLUMN_TEXT = "ID";
        public const string PRODUCT_NAME_COLUMN_TEXT = "Name";
        public const string PRODUCT_QUANTYTY_COLUMN_TEXT = "Quantity";
        public const string PRODUCT_PRICE_COLUMN_TEXT = "Unit Price";
        public const string PRODUCT_DESCRIPTION_COLUMN_TEXT = "Description";

        public const string ORDER_ID_COLUMN_TEXT = "Order ID";
        public const string ORDER_ORDERDATE_COLUMN_TEXT = "Order Date";
        public const string ORDER_TOTALPRICE_COLUMN_TEXT = "Total Price";

        public const string BILL_ID_COLUMN_TEXT = "Bill ID";
        public const string BILL_BILLRDATE_COLUMN_TEXT = "Bill Date";
        public const string BILL_TOTALPRICE_COLUMN_TEXT = "Total Price";

        public const string EMPLOYEE_ID_COLUMN_TEXT = "Employee ID";
        public const string EMPLOYEE_NAME_COLUMN_TEXT = "Name";
        public const string EMPLOYEE_EMAIL_COLUMN_TEXT = "Email";
        public const string EMPLOYEE_PHONE_COLUMN_TEXT = "Phone";
        public const string EMPLOYEE_ADDRESS_COLUMN_TEXT = "Address";
        public const string EMPLOYEE_SALARY_COLUMN_TEXT = "Salary";
        public const string EMPLOYEE_HIREDATE_COLUMN_TEXT = "Hire Date";

        public const string CLIENT_ID_COLUMN_TEXT = "Client ID";
        public const string CLIENT_NAME_COLUMN_TEXT = "Name";
        public const string CLIENT_EMAIL_COLUMN_TEXT = "Email";
        public const string CLIENT_PHONE_COLUMN_TEXT = "Phone";
        public const string CLIENT_ADDRESS_COLUMN_TEXT = "Address";

        public const string CONTROL_DELETE_BUTTON_TEXT = "Delete";
        public const string CONTROL_ORDER_BUTTON_TEXT = "Order";
        public const string CONTROL_CANCEL_BUTTON_TEXT = "Cancel";
        public const string CONTROL_BILL_BUTTON_TEXT = "Generate Bill";
        public const string CONTROL_PLACEORDER_BUTTON_TEXT = "Place Order";
        public const string CONTROL_EXPORTBILL_BUTTON_TEXT = "Export";

        public const string ORDERITEM_TOTALCOST_COLUMN_TEXT = "Total Cost";


        //Messages
        public const string MESSAGE_TEXT_LENGH_LIMITED = "Text lengh limited !";
        public const string TITLE_COMFIRM_DELETE = "Make sure that you want to delete";
        public const string MESSAGE_COMFIRM_DELETE = "";
        public const string TITLE_COMFIRM_UPDATE = "Make sure that you want to change employee info!";
        public const string MESSAGE_COMFIRM_UPDATE = "";
        public const string TITLE_ORDER_QUANTITY_DIALOG = "Quantity";
        public const string MESSAGE_ORDER_QUANTITY_DIALOG = "Please enter quantity!";
        public const string MESSAGE_NOT_ENOUGH_PRODUCT = "Not enough items!";
        public const string MESSAGE_NOT_ORDERING_NOW = "Does not have any order in progress!";
        public const string MESSAGE_CONFIRM_CANCEL_PRODUCT = "Cancel this product?";
        public const string TITLE_CONFIRM_CANCEL_PRODUCT = "Cancel product";
        public const string TITLE_CONFIRM_BILL = "Generate Bill?";
        public const string MESSAGE_CONFIRM_BILL = "Generate bill for this order";
        public const string TITLE_CONFIRM_PLACE_ORDER = "Place order?";
        public const string MESSAGE_CONFIRM_PLACE_ORDER = "Place order for this customer";
        public const string MESSAGE_COMPLETE_CURRENT_ORDER = "Please complete current order";
        public const string MESSAGE_CANNOT_REGISTER_ORDER_ERROR = "Can't register order!";
        public const string MESSAGE_CANNOT_REMOVE_YOURSELF = "Can't remove yourself!";
        public const string MESSAGE_CANNOT_REMOVE_EMPLOYEE_BY_BILL = "Can't remove, you need to remove the bill generated by this employee first!";
        public const string MESSAGE_CANNOT_REMOVE_EMPLOYEE_BY_ORDER = "Can't remove, you need to remove the order placed by this employee first!";
        public const string MESSAGE_CANNOT_REMOVE_CLIENT_BY_BILL = "Can't remove, you need to remove the bill generated by this client first!";
        public const string MESSAGE_CANNOT_REMOVE_CLIENT_BY_ORDER = "Can't remove, you need to remove the order placed by this client first!";
        public const string MESSAGE_CANNOT_REMOVE_PRODUCT_BY_ORDER = "Can't remove, this product was ordered!";
        public const string MESSAGE_CANNOT_REMOVE_ORDER_BY_BILL = "Can't remove , the bill for this order was generated!";

        public static string MESSAGE_CONFIRM_EXPORTBILL = "Export Bill";
        public static string TITLE_CONFIRM_EXPORTBILL = "Export Bill to pdf?";

        
    }
}
