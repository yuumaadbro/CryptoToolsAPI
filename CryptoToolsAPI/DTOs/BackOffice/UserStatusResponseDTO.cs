namespace CryptoToolsAPI.DTOs.BackOffice
{
    public class UserStatusResponseDTO
    {
        public Guid ID { get; set; }
        public string Email { get; set; }
        public bool Enabled { get; set; }
    }
}
