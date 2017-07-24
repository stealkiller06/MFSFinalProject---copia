using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;

namespace MFSFinalProject.Model
{
    public class Order 
    {

        #region Properties
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public string CodOrder { get; set; }
        #endregion

        #region Relationships
        public virtual Suplier Suplier { get; set; }
        public virtual User User { get; set; }
        #endregion


    }
}
