
using System.ComponentModel.DataAnnotations;

namespace EFCorePostgreSQL.Models
{
    public class m_Connection
    {
        [Key]
        public string company { get; set; }
        public string dbLink { get; set; }
        public string dbName { get; set; }
        public string dbUser { get; set; }
        public string dbPassword { get; set; }
        public string dbServerSBO { get; set; }
        public string dbLicenceServerSBO { get; set; }
        public string dbServerTypeSBO { get; set; }
        public string dbUserSBO { get; set; }
        public string dbPasswordSBO { get; set; }
    }
}