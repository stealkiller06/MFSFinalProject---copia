using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFSFinalProject.Model.Help
{
    public static class Company
    {
        public static string Name { get => ConfigurationManager.AppSettings["CompanyName"]; }
        public static string Address { get => ConfigurationManager.AppSettings["Address"]; }
        public static string Phone { get => ConfigurationManager.AppSettings["Phone"]; }
        public static string Slogan { get => ConfigurationManager.AppSettings["Slogan"]; }
    }
}
