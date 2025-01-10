using CryptoToolsAPI.Enumerables;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoToolsAPI.Models
{
    [Table("Log")]
    public class Log
    {
        [Key]
        public int ID { get; set; }
        public string UserID { get; set; }
        public DateTime Date { get; set; }
        public string Origin { get; set; }
        public LogCategory Category { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
