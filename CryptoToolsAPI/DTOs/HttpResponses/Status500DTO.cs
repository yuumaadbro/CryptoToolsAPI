namespace CryptoToolsAPI.DTOs.HttpResponses
{
    public class Status500DTO
    {
        public int StatusCode { get; set; } = 500;
        public string StatusMessage { get; set; } = "Internal server error.";
        public DateTime Logged { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}
