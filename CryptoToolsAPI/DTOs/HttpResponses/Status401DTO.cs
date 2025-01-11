namespace CryptoToolsAPI.DTOs.HttpResponses
{
    public class Status401DTO
    {
        public int StatusCode { get; set; } = 401;
        public string StatusMessage { get; set; } = "User unauthorized or not found.";
    }
}
