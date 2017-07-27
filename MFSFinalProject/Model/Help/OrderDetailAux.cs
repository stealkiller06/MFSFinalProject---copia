using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public class OrderDetailAux
    {
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; }

    }
}
