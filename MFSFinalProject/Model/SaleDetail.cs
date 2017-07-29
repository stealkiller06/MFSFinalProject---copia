using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model
{
    public class SaleDetail
    {
        public int SaleDetailId { get; set; }
        public int Quantity { get; set; }
        public Decimal SellPrice { get; set; }
        public int Remove { get; set; }

        #region Relationships
        public virtual Product Product { get; set; }
        public virtual Sale Sale { get; set; }
        #endregion
    }
}
