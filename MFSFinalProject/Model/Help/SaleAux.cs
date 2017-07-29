using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public class SaleAux
    {
        public int SaleID { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime Date { get; set; }
        public string CodSale { get; set; }
    }
}
