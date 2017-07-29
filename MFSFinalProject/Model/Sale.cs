using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Model;

namespace MFSFinalProject.Model
{
    public class Sale
    {
        public int SaleId { get; set; }
        public string CodSale { get; set; }
        public int Remove { get; set; }

        #region RelationShips
        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
        #endregion
    }
}
