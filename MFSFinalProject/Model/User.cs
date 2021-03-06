﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MFSFinalProject.Model
{
    public class User
    {
        public User()
        {
            Category = new HashSet<Category>();
            Products = new HashSet<Product>();
            Remove = 0;
        }

        public int UserId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(20)]
        public string UserName { get; set; }
        [StringLength(20)]
        public string PassWord { get; set; }
        public int Remove { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }


        #region Relagionships
        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }
        public virtual ICollection<Suplier> Supliers { get; set; }
        public virtual Role Role { get; set; }
        #endregion

    }
}
