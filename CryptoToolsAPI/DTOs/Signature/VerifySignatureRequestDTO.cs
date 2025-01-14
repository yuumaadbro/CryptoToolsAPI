namespace CryptoToolsAPI.DTOs.Signature
{
    public class VerifySignatureRequestDTO
    {
        public string Data { get; set; }
        public string Signature { get; set; }
        public string PublicKey { get; set; }
    }
}
