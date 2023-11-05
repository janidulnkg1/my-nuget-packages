using encryption_cl.Key;
using Microsoft.Extensions.Configuration;
using System;
using System.Text;

public class Program
{


    public static void Main()
    {

        // Get the encryption key from the configuration
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("config.json")
            .Build();

        string encryptionKey = configuration["EncryptionKey"];

        IKeyProvider.SetKey(encryptionKey);

        // Create an instance of the CryptoED class.
        CryptoED crypto = new CryptoED(keyProvider); 

        // Sample data to encrypt.
        string plaintext = "Hello, World!";
        byte[] inputData = Encoding.UTF8.GetBytes(plaintext);

        // Encrypt the data.
        byte[] encryptedData = crypto.Encrypt(inputData);

        // Decrypt the data.
        byte[] decryptedData = crypto.Decrypt(encryptedData);

        // Convert the decrypted data back to a string.
        string decryptedText = Encoding.UTF8.GetString(decryptedData);

        // Display the results.
        Console.WriteLine("Original Text: " + plaintext);
        Console.WriteLine("Encrypted Data: " + BitConverter.ToString(encryptedData));
        Console.WriteLine("Decrypted Text: " + decryptedText);
    }
}
