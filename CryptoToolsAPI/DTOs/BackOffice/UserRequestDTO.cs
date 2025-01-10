namespace CryptoToolsAPI.NewFolder.NewFolder
{
    public class UserRequestDTO
    {
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }
        public string? IPRange { get; set; }
        public string? Claim { get; set; }
        public string? Value { get; set; }
        public bool Enabled { get; set; }
    }
}
