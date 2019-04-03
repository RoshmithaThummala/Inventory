using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using InventoryTools;
using ProductCategory;

namespace projectIntegration
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new ProductInfoorNewProduct());
            Application.Run(new Customer());
        }
    }
}
