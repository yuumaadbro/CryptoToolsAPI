namespace CryptoToolsAPI.Identity
{
    /// <summary>
    /// ClaimsData used to give access to our enpoints
    /// </summary>
    public class ClaimsData
    {
        /// <summary>
        /// Admin user claim
        /// </summary>
        public const string adminUserClaim = "admin";

        /// <summary>
        /// Partner claim, values are specified in BBDD
        /// </summary>
        public const string partnerClaim = "partner";
    }
}
