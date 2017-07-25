using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Model;

namespace MFSFinalProject.Model
{
    public class OrderDetail
    {
        #region Properties
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal SellPrice { get; set; }
        public int Remove { get; set; }
        #endregion

        #region RelationShips
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
        #endregion
    }
}
