using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray_Sanaa_Final_Project
{
    public static class ShoppingCart
    {
         public static DataTable cart = CreateCart();
         private static DataTable CreateCart()
         {
             DataTable dt = new DataTable();
            dt.Columns.Add("ProductID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Price",typeof(decimal));
             dt.Columns.Add("Quantity",typeof(int));
             dt.Columns.Add("Total",typeof(decimal));
             return dt;
         }
    
    }
}
