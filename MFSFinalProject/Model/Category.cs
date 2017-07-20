using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MFSFinalProject.Infra;

namespace MFSFinalProject.Model
{
    public class Category : NotificationClass
    {
        private string categoryName;
        public Category()
        {
            Products = new List<Product>();
        }

        
        public int CategoryId { get; set; }
        [Required]
        [StringLength(50)]
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged();
            }
        }
        public int CategoryRemove { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }


        //RelationShips
        public virtual User User { get; set; }
        public virtual List<Product> Products { get; set; }

        
    }
}
