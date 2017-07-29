using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model
{
    public class Customer
    {
        #region Propiedades
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int Remove { get; set; }
        #endregion

        #region Relationships
        public virtual User User { get; set; }
        #endregion


    }
}
