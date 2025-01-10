using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CryptoToolsAPI.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public Guid ID { get; set; } = new Guid();
        public string? Name { get; set; }
        public string Password { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }
        public string? IPRange { get; set; }
        public string? Claim {  get; set; }
        public string? Value { get; set; }
        public bool Enabled { get; set; }
    }
}
