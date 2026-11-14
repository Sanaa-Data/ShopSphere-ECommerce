using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Ray_Sanaa_Final_Project
{
    internal static  class CurrentUser
    {
        public static int CustomerID;
        public static string CustomerName;
        public static string Username;
    }
    //If everything inside is static
    // The class should also be static
    //👉 We want all forms in the app to share the SAME logged-in use
}
