using CryptoToolsAPI.DTOs.SecureKeyGenerator;
using System.Security.Cryptography;
using System.Text;

namespace CryptoToolsAPI.Services
{
    public class SecureKeyGeneratorService:ISecureKeyGeneratorService
    {
        public SecureKeyGeneratorService() { }

        public GenerateSecurePasswordResponseDTO GenerateSecurePassword(GenerateSecurePasswordRequestDTO keySettings) 
        {
            const string lowerChars = "abcdefghijklmnopqrstuvwxyz";
            const string upperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string specialChars = "!@#$%^&*()-_=+<>?/|";

            string charPool = string.Empty;
            if (keySettings.IncludeLowercase) charPool += lowerChars;
            if (keySettings.IncludeUppercase) charPool += upperChars;
            if (keySettings.IncludeNumbers) charPool += numbers;
            if (keySettings.IncludeSpecialCharacters) charPool += specialChars;

            if (charPool.Length == 0)
                throw new ArgumentException("At least one character type must be selected.");

            using (var rng = new RNGCryptoServiceProvider())
            {
                StringBuilder password = new StringBuilder(keySettings.Length);
                byte[] randomBytes = new byte[1];

                for (int i = 0; i < keySettings.Length; i++)
                {
                    rng.GetBytes(randomBytes);
                    int index = randomBytes[0] % charPool.Length;
                    password.Append(charPool[index]);
                }

                return new GenerateSecurePasswordResponseDTO 
                { 
                    SecureKey = password.ToString()
                };
            }
        }

        public GenerateAESKeysResponseDTO GenerateAESKeys() 
        {
            using (var rng = new RNGCryptoServiceProvider()) 
            {
                byte[] key = new byte[32];
                byte[] IV = new byte[16];

                rng.GetBytes(key);
                rng.GetBytes(IV);

                return new GenerateAESKeysResponseDTO
                { 
                    AESKey = Convert.ToBase64String(key),
                    IV = Convert.ToBase64String(IV)
                };
            }
        }
    }
}
