namespace CryptoToolsAPI.DTOs.Signature
{
    public class SignDataRequestDTO
    {
        public string Data { get; set; }
        public string PrivateKey { get; set; }
    }
}
