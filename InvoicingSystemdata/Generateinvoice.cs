using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudarshan_Project.InvoicingSystemdata
{

    public abstract class GenerateInvoice   
    {
    
       
   
        public static string Generateinvoice(string invoicenumber)
        {
             string date=DateTime.Now.ToString();
             int year = DateTime.Now.Year;
             int nxtyear = DateTime.Now.Year + 1;
             String finyear = year.ToString() + "-" + nxtyear;
             invoicenumber = invoicenumber + date + finyear;
             return invoicenumber;
        }
  
    }
}
