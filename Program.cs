using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace Cryptography
{
    internal class Program
    {
        static void Main()
        {
            int choice;

            bool stop = false;
            string test;

            string plaintext;
            string ciphertext;

            string key;

            string encryptedText;
            string decryptedText;

            do
            {
                Console.Clear();

                Console.WriteLine("What do you want to do? (Enter 1 or 2) \n\tOption 1 : Encryption \n\tOption 2 : Decryption \n");
                Console.Write("Your choice : ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter your plaintext: ");
                        plaintext = Console.ReadLine();

                        Console.Write("Enter the key: ");
                        key = Console.ReadLine();

                        Console.WriteLine();

                        encryptedText = Encryption(plaintext, key);
                        Console.Write("Ciphertext: " + encryptedText);

                        Console.WriteLine("\n");

                        break;

                    case 2:
                        Console.Write("Enter your ciphertext: ");
                        ciphertext = Console.ReadLine();

                        Console.Write("Enter the key: ");
                        key = Console.ReadLine();

                        Console.WriteLine();

                        decryptedText = Decryption(ciphertext, key);
                        Console.Write("Decrypted Text: " + decryptedText);

                        Console.WriteLine("\n");

                        break;
                }

                Console.WriteLine("Do you want to continue? Enter yes or no.");
                test = Console.ReadLine();
                if (test == "no")
                {
                    stop = true;
                }

            } while (stop != true);
        }

        static string Encryption(string plaintext, string key)
        {
            int blockSize = key.Length;
            string ciphertext = "";

            for (int i = 0; i < plaintext.Length; i += blockSize)
            {
                string block = plaintext.Substring(i, Math.Min(blockSize, plaintext.Length - i));

                string encryptedBlock = Substitution(block, key);

                ciphertext += (encryptedBlock);
            }

            return ciphertext;
        }

        static string Decryption(string ciphertext, string key)
        {
            int blockSize = key.Length;
            string decryptedText = "";

            for (int i = 0; i < ciphertext.Length; i += blockSize)
            {
                string block = ciphertext.Substring(i, Math.Min(blockSize, ciphertext.Length - i));

                string decryptedBlock = Reverse_Substitution(block, key);

                decryptedText+=decryptedBlock;
            }

            return decryptedText;            
        }

        static string Substitution(string block, string key)
        {
            string result = "";

            for (int i = 0; i < block.Length; i++)
            {
                char plainChar = block[i];
                char keyChar = key[i % key.Length];

                char encryptedChar = (char)(plainChar + keyChar);

                result+=encryptedChar;
            }

            return result;
        }

        static string Reverse_Substitution(string block, string key)
        {
            string result = "";

            for (int i = 0; i < block.Length; i++)
            {
                char encryptedChar = block[i];
                char keyChar = key[i % key.Length];

                char decryptedChar = (char)(encryptedChar - keyChar);

                result+=decryptedChar;
            }

            return result;
        }
    }
}