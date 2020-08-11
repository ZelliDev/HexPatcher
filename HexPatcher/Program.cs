using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hex_Patcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tapez le chemin et le nom du .exe a extraire l'Hexadécimal");
            string Filename = Console.ReadLine();
            byte[] Bytes1 = File.ReadAllBytes(Filename);
            
            Console.WriteLine("CONVERTED BYTES TO STRING : "+Environment.NewLine);
            string text = ASCIIEncoding.ASCII.GetString(Bytes1);
            var t = File.Create("hex1_string");
            t.Dispose();
            t.Close();
            File.WriteAllBytes("hex1_string",Bytes1);
            Console.WriteLine(text);
           // Console.ReadLine();
            Console.WriteLine("CONVERTED BYTES TO HEXADECIMAL");
            Console.WriteLine(ConvertByteToHex(Bytes1));
            Console.WriteLine("Modifiez le fichier hex1_string et appuyez sur une touche");
            Console.ReadLine();
            Console.WriteLine(Environment.NewLine+"Editez le fichier hex1_string et entrez 'oui' pour appliquer le patch?");
            string input = Console.ReadLine();
            if (input.ToLower() == "oui")
            {
                File.WriteAllBytes((@"C:\test\Test2.exe"), File.ReadAllBytes("hex1_string"));

            }
            if (input.ToLower() == "non")
            {
                Environment.Exit(0);
            }
        }

        public static string ConvertByteToHex(byte[] byteData)
        {
            string hexValues = BitConverter.ToString(byteData).Replace("-", "");

            return hexValues;
        }
        public static byte[] ConvertHexToByteArray(string hexString)
        {
            byte[] byteArray = new byte[hexString.Length / 2];

            for (int index = 0; index < byteArray.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                byteArray[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return byteArray;
        }


    }
}
