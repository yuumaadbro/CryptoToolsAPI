
# CryptoToolsAPI 🚀🔒

CryptoToolsAPI is a powerful .NET 8-based API dedicated to cryptographic operations. This API provides a variety of cryptographic utilities such as encryption, decryption, hashing, key generation, file management, and more. It is designed to be secure, offering JWT authentication, claims-based access control, and IP range restrictions. 🔐

## Features 🌟

- **Authentication & Authorization** 🔑
  - JWT Token-based authentication.
  - Claims-based user access control.
  - Role-based access control for different operations.
  - Restricted IP ranges for enhanced security.

- **Cryptographic Functions** 🔒
  - AES encryption and decryption.
  - RSA encryption and decryption.
  - Base64 encoding and decoding.
  - SHA-256, bcrypt, and PBKDF2 hashing.

- **File Management** 📂
  - Encrypt and decrypt files securely.
  - Verify file integrity.

- **Secure Key Generation** 🔑
  - Generate secure passwords.
  - Generate AES and RSA keys.

- **Digital Signatures** ✍️
  - Sign data with private keys.
  - Verify digital signatures with public keys.

## API Endpoints 🛠️

Below is a list of available API endpoints:

### Authorization 🔑

- **POST** `/Authorization/auth`:  
  Authenticate a user and retrieve a JWT token.

### BackOffice 🏢

- **POST** `/BackOffice/createUsers`:  
  Create new users with associated roles and permissions.
  
- **PUT** `/BackOffice/updateUsersStatus`:  
  Update user account statuses (e.g., enabled/disabled).

### Encrypter 🔐

- **POST** `/Encrypter/encryptAESText`:  
  Encrypt text using AES encryption.

- **POST** `/Encrypter/decryptAESText`:  
  Decrypt AES-encrypted text.

- **POST** `/Encrypter/encodeBase64Text`:  
  Encode text to Base64.

- **POST** `/Encrypter/decodeBase64Text`:  
  Decode Base64-encoded text.

- **POST** `/Encrypter/encryptRSAText`:  
  Encrypt text using RSA encryption.

### FileManager 📁

- **POST** `/FileManager/encryptFile`:  
  Encrypt a file.

- **POST** `/FileManager/decryptFile`:  
  Decrypt a file.

- **POST** `/FileManager/fileIntegrity`:  
  Verify the integrity of a file.

### Hashing 🧮

- **POST** `/Hashing/hashSHA256`:  
  Hash text using SHA-256.

- **POST** `/Hashing/hashBCrypt`:  
  Hash text using bcrypt.

- **POST** `/Hashing/hashPBKDF2`:  
  Hash text using PBKDF2.

### SecureKeyGenerator 🔐

- **POST** `/SecureKeyGenerator/generateSecurePassword`:  
  Generate a secure password.

- **POST** `/SecureKeyGenerator/generateAESKeys`:  
  Generate AES keys.

- **POST** `/SecureKeyGenerator/generateRSAKeys`:  
  Generate RSA keys.

### Signature 🖋️

- **POST** `/Signature/signData`:  
  Sign data using a private key.

- **POST** `/Signature/verifySignature`:  
  Verify data using a public key and signature.

## Security 🔒

The CryptoToolsAPI utilizes **JWT** (JSON Web Token) authentication to secure endpoints. All requests to the API require the inclusion of a valid JWT token in the `Authorization` header.

Example:

```
Authorization: Bearer <your-token-here>
```

### Claims-based Authorization 📜

Certain API endpoints require specific claims. Claims are part of the user’s JWT token and can be used to enforce roles, permissions, or restrictions on actions.

### IP Range Restriction 🌍

For added security, certain operations may be restricted to a specified range of IP addresses. Ensure that your requests are coming from an allowed IP range.

## How to Use 🚀

1. **Obtain a JWT Token** 🔑:  
   First, you need to authenticate using the `/Authorization/auth` endpoint to get a JWT token.

2. **Make Requests** 🔄:  
   Use the obtained JWT token to access any of the available API endpoints. Include the token in the `Authorization` header as shown above.

3. **Secure Operations** 🔐:  
   The API provides secure cryptographic operations, such as encryption, decryption, and hashing, using well-established algorithms like AES, RSA, SHA-256, bcrypt, and PBKDF2.

## Example Request 📝

### Encrypt Text Using AES 🔒

**POST** `/Encrypter/encryptAESText`

**Request Body**:
```json
{
  "text": "Sensitive Information"
}
```

**Response**:
```json
{
  "encryptedText": "Encrypted_Text_Here"
}
```

### Hash Text Using SHA-256 🔑

**POST** `/Hashing/hashSHA256`

**Request Body**:
```json
{
  "text": "This is a message"
}
```

**Response**:
```json
{
  "hashedText": "SHA256_Hashed_Text_Here"
}
```

## Installation 🛠️

### Prerequisites 📋

- .NET 8 SDK
- A web server capable of running .NET 8 applications (e.g., IIS, Kestrel, etc.)

### Steps to Run the API Locally 🏡

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/yuumaadbro/CryptoToolsAPI.git
   cd CryptoToolsAPI
   ```

2. Restore the dependencies:

   ```bash
   dotnet restore
   ```

3. Build the project:

   ```bash
   dotnet build
   ```

4. Run the API locally:

   ```bash
   dotnet run
   ```

   The API will be available on `http://localhost:5000`.

