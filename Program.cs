using System;
using System.Security.Cryptography;
using System.Text;

namespace HashingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hashing Demo Compare two strings!");

            // First string to compute
            Console.Write("Enter first string to hash: ");
            string? input1 = Console.ReadLine();
            if (string.IsNullOrEmpty(input1))
            {
                Console.WriteLine("Invalid input! please enter a valid string");
                return;
            }
            string hash1 = ComputeSHA256Hash(input1);

            // Second string to compute
            Console.WriteLine("Enter second string to compute");
            string? input2 = Console.ReadLine();
            if (string.IsNullOrEmpty(input2))
            {
                Console.WriteLine("Invalid input! please enter a valid string!");
                return;
            }
            string hash2 = ComputeSHA256Hash(input2);

            Console.WriteLine($"\nHash 1: {hash1}");
            Console.WriteLine($"Hash 2: {hash2}");

            // Comapre hashes
            if (hash1 == hash2)
            {
                Console.WriteLine("The hashes are identical. The strings are the same.");
            }
            else
            {
                {
                    Console.WriteLine("The hashes are different. The strings are not the same.");
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

            static string HashPassword(string password)
            {
                return ComputeSHA256Hash(password);

            }
        }

    }
}