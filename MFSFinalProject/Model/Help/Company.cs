using System.Configuration;


namespace MFSFinalProject.Model.Help
{
    public static class Company
    {
        public static string Name { get => ConfigurationManager.AppSettings["CompanyName"]; }
        public static string Address { get => ConfigurationManager.AppSettings["Address"]; }
        public static string Phone { get => ConfigurationManager.AppSettings["Phone"]; }
        public static string Slogan { get => ConfigurationManager.AppSettings["Slogan"]; }
        public static string Logo { get => ConfigurationManager.AppSettings["Logo"]; }
        public static string Image { get => ConfigurationManager.AppSettings["Image"]; }
    }
}
