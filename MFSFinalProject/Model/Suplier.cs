using MFSFinalProject.Infra;
using MFSFinalProject.Model;

namespace MFSFinalProject.Model
{
    public class Suplier : NotificationClass
    {
        #region atributes
        private int suplierId;
        private string name;
        private string address;
        private string phone;
        #endregion

        #region Properties
        public int SuplierId
        {

            get => suplierId;

            set
            {
                suplierId = value;
                OnPropertyChanged();
            }


        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged();
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                phone = value;
                OnPropertyChanged();
            }
        }

        public int Remove { get; set; }
        #endregion

        #region Relationship
        public virtual User User { get; set; }
        #endregion

    }
}
