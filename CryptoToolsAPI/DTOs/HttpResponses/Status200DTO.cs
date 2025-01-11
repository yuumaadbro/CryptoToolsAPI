namespace CryptoToolsAPI.DTOs.HttpResponses
{
    public class Status200DTO
    {
        public int StatusCode { get; set; } = 200;
        public string StatusMessage { get; set; } = "Request completed successfully.";
        public object Response {  get; set; }
    }
}
