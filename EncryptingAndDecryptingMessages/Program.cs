using System;

namespace EncryptingAndDecryptingMessages
{
    class Program
    {
        

        //public static void Cypher()
        //{






        //    //var shift = key.ToString;

        //    char[] output = new char[password.Length];
        //    var newString = password.ToCharArray();
        //    string answer = "";

        //    //char[] result = new char[];
        //    int length = password.Length;

        //    for (var i = 0; i < password.Length; i++)
        //    {
        //        char letter = newString[i];
        //        letter = (char)(letter - key);

        //        answer += letter.ToString();
        //    }

        //    Add(userName, answer);


        //    output.ToString();

        //    int placeholder;
        //    foreach (var item in newString)
        //    {
        //        item

        //    }


        //    Console.WriteLine($"Your username: {userName} | Your password: {password} | Encrypted password: {answer} | Your encryption key: {key}");
        //}
        public static string Decrypt(string input, string key)
        {
            char cKey = char.Parse(key);

            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += DecryptcharMethod(input[i], cKey);
            }

            return result;

        }
        public static char DecryptcharMethod(char c1, char c2)
        {
            int one = c1;
            int key = c2 - 64;

            int newKey = (one - key);

            if (newKey < 65)
            {
                newKey += 26;
            }
            else if (newKey > 90)
            {
                newKey -= 26;
            }

            return (char)newKey;
        }
        public static string SingleKey(string input, string key)
        {
            char cKey = char.Parse(key);
            //string newKey = key+input;
            //int[] encrypt = new int[int.MaxValue];
            //int i = 0;
            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                result += charMethod(input[i], cKey);
            }
            //foreach (var c in input) 
            //{
            //    int uni = c;
            //    var change  = uni + newKey;
            //    result += newKey[i];
            //    i++;
            //}
            return result;
        }
        public static char charMethod(char c1, char c2)
        {
            int one = c1;
            int key = c2 - 64;

            int newKey = (one + key);

            if (newKey >90)
            {
                newKey -= 26;
            }
            else if (newKey <65)
            {
                newKey += 26;
            }

            return (char)newKey;
        }
        public static string MultiDecrypt(string input, string key)
        {
            //string newKey = "";
            string result = "";
            while (key.Length <= input.Length)
            {
                key += key;
            }
            for (int i = 0; i < input.Length; i++)
            {
                result += DecryptcharMethod(input[i], key[i]);
            }

            return result;

        }
        public static string MultiEncrypt(string input, string key)
        {
           //string newKey = "";
           string result = "";
           //int count = 0;
            while (key.Length <= input.Length)
            {
                key += key;
            }

            for (int i = 0; i < input.Length; i++)
            {
                result += charMethod(input[i], key[i]);
            }



            return result;
        }
        public static string ContinuousEncrypt(string input, string key)
        {
            string baseword = key+input;
            string result = "";
            string newWord = "";
            for (int i = 0; i <= input.Length; i++)
            {
                newWord += baseword[i];
            }
            for (int i = 0; i < input.Length; i++)
            {
                result += charMethod(input[i], newWord[i]);
            }

            return result;
        }

        public static string ContinuousDecrypt(string input, string key)
        {
            string baseword = key + input;
            string result = "";
            string newWord = "";
            for (int i = 0; i <= input.Length; i++)
            {
                newWord += baseword[i];
            }
            for (int i = 0; i < input.Length; i++)
            {
                result += DecryptcharMethod(input[i], newWord[i]);
            }

            return result;
        }

        public static void UserInterface()
        {
            Console.Write("Enter plain text message: ");
            string plainText = Console.ReadLine().ToUpper();
            Console.Write("Enter your single key as an alpha character: ");
            string singleKey = Console.ReadLine().ToUpper();
            Console.Write("Enter your multi-key as alpha characters: ");
            string multiKey = Console.ReadLine().ToUpper();

            Console.WriteLine($"You entered {plainText} as plain text");
            Console.WriteLine($"You entered {singleKey} as your single key");
            Console.WriteLine($"You entered {multiKey} as your multi key");

            string encryptedMessage = SingleKey(plainText, singleKey);
            string multiEncrypt = MultiEncrypt(plainText, multiKey);
            string continuousEncrypt = ContinuousEncrypt(plainText, multiKey);
            Console.WriteLine($"\nEncrypted message with single key is {encryptedMessage}");
            Console.WriteLine($"Encrypted message with multi key is {multiEncrypt} ");
            Console.WriteLine($"Encrypted message with continuous key is {continuousEncrypt} ");
            Console.WriteLine($"\nDecrypted message with single key is {Decrypt(encryptedMessage, singleKey)}");
            Console.WriteLine($"Decrypted message with multi key is {MultiDecrypt(multiEncrypt,multiKey)} ");
            Console.WriteLine($"Decrypted message with continious key is {ContinuousDecrypt(continuousEncrypt, multiKey)}");
        }
        static void Main(string[] args)
        {
             
             UserInterface();


        }
    }
}
