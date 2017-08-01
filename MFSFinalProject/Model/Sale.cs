using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFSFinalProject.Model
{
    public class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }
        public int SaleId { get; set; }
        public string CodSale { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public int Remove { get; set; }

        #region RelationShips
        public virtual User User { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
        #endregion
    }
}
