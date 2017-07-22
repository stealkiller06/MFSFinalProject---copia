using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Model;

namespace MFSFinalProject.Model
{
    public class Measurement
    {
        public Measurement()
        {
            Remove = 0;
            Products = new HashSet<Product>();
        }
        public int MeasurementId { get; set; }
        public string Name { get; set; }
        public int Remove { get; set; }
        [Timestamp]
        public byte[] Row { get; set; }

        #region relationships
        public virtual User User { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}
