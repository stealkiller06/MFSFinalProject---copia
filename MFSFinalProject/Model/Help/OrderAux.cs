using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public class OrderAux
    {
        public int OrderID { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int SuplierId { get; set; }
        public string SuplierName { get; set; }
        public DateTime Date { get; set; }
        public string CodOrder { get; set; }
    }
}
