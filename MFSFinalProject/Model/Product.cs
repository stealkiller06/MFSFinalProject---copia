using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MFSFinalProject.Model
{
    public class Product
    {
        public Product() { }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal SellPrice { get; set; }
        public int MinStock { get; set; }
        public int Remove { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        //RelationShips
        public virtual Category Category { get; set; }
        public virtual User User { get; set; }


    }
}
