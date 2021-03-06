﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFSFinalProject.Infra;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFSFinalProject.Model
{
    public class Order 
    {
        public Order()
        {
            OrderDetail = new HashSet<OrderDetail>();
        }
        #region Properties
        public int OrderId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public string CodOrder { get; set; }
        public int Remove { get; set; }
        #endregion

        #region Relationships
        public virtual Suplier Suplier { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        #endregion


    }
}
