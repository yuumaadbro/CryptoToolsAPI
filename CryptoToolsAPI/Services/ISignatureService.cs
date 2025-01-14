using CryptoToolsAPI.DTOs.Signature;

namespace CryptoToolsAPI.Services
{
    public interface ISignatureService
    {
        public SignDataResponseDTO SignData(SignDataRequestDTO signature);
        public VerifySignatureResponseDTO VerifySignature(VerifySignatureRequestDTO signature);
    }
}
