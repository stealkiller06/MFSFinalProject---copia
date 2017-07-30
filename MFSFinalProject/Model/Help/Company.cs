using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public class Company
    {
        public string Name { get => ConfigurationManager.AppSettings["CompanyName"]; }
        public string Address { get => ConfigurationManager.AppSettings["Address"]; }
        public string Phone { get => ConfigurationManager.AppSettings["Phone"]; }
    }
}
