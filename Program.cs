using System;
using System.Security.Cryptography;
using System.Text;

namespace HashingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Password Hashing Demo.");

            // Hash and store password 
            Console.Write("Set a password: ");
            string? password = GetValidInput();
            string storedHash = HashPassword(password);
            Console.WriteLine("Password has been hashed and stored.");

            // Verify password 
            Console.Write("Enter password to verify: ");
            string? inputPassword = GetValidInput();

            if (VerifyPassword(storedHash, inputPassword))
            {
                Console.WriteLine("Password is correct!");

            }
            else
            {
                Console.WriteLine("Incorrect Password!");
            }
        }

        static string ComputeSHA256Hash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convert input to bytes
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute Hash
                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                // Convert hash bytes to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }

        }

        static string GetValidInput()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    return input;
                }
                Console.WriteLine("Invalid input! please enter a valid string! ");
            }
        }

        // Hash password for storage
        static string HashPassword(string password)
        {
            return ComputeSHA256Hash(password);

        }

        // Verify password by comparing hash to stored hash
        static bool VerifyPassword(string inputPassword, string storedHash)
        {
            string hashInput = ComputeSHA256Hash(inputPassword);
            return hashInput == storedHash;
        }
    }
}