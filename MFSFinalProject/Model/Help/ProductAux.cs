using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public class ProductAux
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; }
        public int MinStock { get; set; }
        public decimal SellPrice { get; set; }
        public int MeasurementId { get; set; }
        public string Measurementname { get; set; }
        public decimal Cost { get; set; }
        public int Stock { get; set; }
    }
}
