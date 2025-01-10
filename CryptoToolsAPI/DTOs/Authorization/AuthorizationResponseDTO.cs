namespace CryptoToolsAPI.DTOs.Authorization
{
    public class AuthorizationResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public string Claims { get; set; }
    }
}
