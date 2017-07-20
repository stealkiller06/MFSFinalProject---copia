using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MFSFinalProject.Model
{
    public class User
    {
        public User()
        {
        }

        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(20)]
        public string PassWord { get; set; }
        [Required]
        public int Remove { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }

        //Relationships
        public virtual List<Category> Category { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}
