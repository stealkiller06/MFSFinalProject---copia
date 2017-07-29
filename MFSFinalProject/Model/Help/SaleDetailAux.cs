using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public class SaleDetailAux
    {
        public int SaleDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int SaleId { get; set; }
    }
}
