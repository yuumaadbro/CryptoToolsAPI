namespace CryptoToolsAPI.DTOs.Hashing
{
    public class HashPBKDF2RequestDTO
    {
        public string Text { get; set; }
        public string Salt { get; set; }
    }
}
