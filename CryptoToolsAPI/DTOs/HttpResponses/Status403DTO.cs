namespace CryptoToolsAPI.DTOs.HttpResponses
{
    public class Status403DTO
    {
        public int StatusCode { get; set; } = 403;
        public string StatusMessage { get; set; } = "Forbidden, your user does not have acces to this resource.";
    }
}
