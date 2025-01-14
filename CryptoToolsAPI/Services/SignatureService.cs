using CryptoToolsAPI.DTOs.Signature;
using System.Security.Cryptography;
using System.Text;

namespace CryptoToolsAPI.Services
{
    public class SignatureService:ISignatureService
    {
        public SignatureService() { }

        public SignDataResponseDTO SignData(SignDataRequestDTO signature) 
        {
            using (RSA rsa = RSA.Create()) 
            { 
                rsa.FromXmlString(signature.PrivateKey);

                byte[] dataBytes = Encoding.UTF8.GetBytes(signature.Data);
                byte[] signatureBytes = rsa.SignData(dataBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

                return new SignDataResponseDTO 
                { 
                    SignatureData = Convert.ToBase64String(signatureBytes)
                };
            }
        }

        public VerifySignatureResponseDTO VerifySignature(VerifySignatureRequestDTO signature) 
        {
            using (RSA rsa = RSA.Create()) 
            { 
                rsa.FromXmlString(signature.PublicKey);

                byte[] dataBytes = Encoding.UTF8.GetBytes(signature.Data);
                byte[] signatureBytes = Convert.FromBase64String(signature.Signature);

                return new VerifySignatureResponseDTO
                {
                    Valid = rsa.VerifyData(dataBytes, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1)
                };
            }
        }
    }
}
