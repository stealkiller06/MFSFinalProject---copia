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
            Products = new HashSet<Product>();
        }

        #region Properties
        public int CategoryId { get; set; }
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
        #endregion

        #region Relationships
        public virtual ICollection<Product> Products { get; set; }
        #endregion



    }
}
