# Secure Password Manager

## Summary
This secure Password Manager is designed to store login credentials safely while offering a user-friendly interface. Key features include:

- Secure encryption and hashing mechanisms 
- Light and Dark theme modes  
- Password strength indicator  
- Search functionality  
- Password generation (random or easy-to-remember words)   

## Usage
To use the password manager, first register an account. After logging in, you can add entries for your login credentials. Each entry consists of a title, username, and encrypted password. 

### `Form3_Main::Show` & `Form3_Main::Copy`
Select the password you want to view or copy straigth to your clipboard, by selecting the password cell or the entire row. Click the **Copy** button to copy the stored password or the **Show** button to reveal the entire row’s content.

## Cryptography

### Storing Master Credentials
User passwords are stored securely using **SHA-256 hashing with a random salt**. The hashing process involves:

- Generating a **128-bit (16-byte) salt** using `RandomNumberGenerator`  
- Concatenating the password with the generated salt  
- Hashing the resulting string using **SHA-256**  
- Storing both the hashed password and salt for future verification  

When a user attempts to log in, the input password is concatenated with the stored salt, hashed again, and compared with the stored hash. If they match, authentication is successful.

### Login Pair Entry Encryption
Passwords are encrypted using **AES-256 in CBC (Cipher Block Chaining) mode** with a **PKCS7 padding scheme**. The encryption process follows these steps:

- A **16-byte random salt** is generated.  
- A **256-bit key** and a **128-bit IV** (seed) are derived using **PBKDF2 (Rfc2898DeriveBytes)** with **100,000 iterations** and **SHA-256** as the hash function.  
- The plaintext password is encrypted using AES-256 in CBC mode with the derived key and IV.  
- The encrypted output is stored in a format: `Base64(salt):Base64(cipherText)`.  

Decryption follows the reverse process:

- Extracting the salt from the stored format  
- Deriving the same key and IV using PBKDF2 with the extracted salt and the user’s password  
- Decrypting the ciphertext using AES-256 in CBC mode  
- Returning the original plaintext password  

## Algorithms
This password manager employs:

- **RandomNumberGenerator** for cryptographic randomness in salt and IV generation [¹](#ref1)
- **SHA-256** for hashing user passwords [²](#ref2)
- **AES-256** (Advanced Encryption Standard) for password encryption [³](#ref3)
  - **AES CBC mode** CBC mode (Block cipher mode of operation) [⁴](#ref4)
  - **AES PKCS 7 padding** for getting the desired number of bits [⁵](#ref5)
- **PBKDF2**  with SHA-256 for key derivation from the user's password with 100,000 iterations. Used through Rfc2898DeriveBytes. [⁶](#ref6)


## References
1. <a name="ref1"></a>[RandomNumberGenerator - Microsoft](https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.randomnumbergenerator?view=net-9.0)
2. <a name="ref2"></a>[SHA-2 - Wikipedia](https://en.wikipedia.org/wiki/SHA-2)
3. <a name="ref3"></a>[AES - Wikipedia](https://en.wikipedia.org/wiki/Advanced_Encryption_Standard)
4. <a name="ref4"></a>[CBC - Wikipedia](https://en.wikipedia.org/wiki/Block_cipher_mode_of_operation)
5. <a name="ref5"></a>[PKCS 7 - Wikipedia](https://en.wikipedia.org/wiki/PKCS_7)
6. <a name="ref6"></a>[PBKDF2 - Wikipedia](https://en.wikipedia.org/wiki/PBKDF2)


