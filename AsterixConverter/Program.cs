using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterixConverter
{
    class Program
    {
        public static string[] mass = null;
        public static int lastOctet = 0;
        static void Main(string[] args)
        {
            HexConverter myHexConverter = new HexConverter();
            Console.WriteLine("Введите сообщение Asterix cat. 048:");
          //  string inputStr = Console.ReadLine();
            //temp for test
            Console.ReadLine(); //00 09
           // string inputStr = "30 00 1A FF FF FF FE 33 EB 47 99 37 20 35 53 1F 00 00 02 12 60 13 50 01 FF 67 4E A0 D3 42 10 03 00 11 00 10 02";
            string inputStr = "30 00 1E FD 1E 33 EB 47 9B 18 40 74 2F 63 37 0D AB 05 A0 00 0A 25 BB D3 D4 06 E5 A4 75 40 01 CC 10 03 00 11 00 10 02";

            Console.WriteLine("\nВы ввели\n{0}", inputStr);

          /*Console.WriteLine("FA  " + new HexConverter().hexTObin("FA"));
            Console.ReadLine();

            Console.WriteLine("1A FA  " + new HexConverter().hexTObin("1A FA"));
            Console.ReadLine();

            Console.WriteLine("1B 1A FA  " + new HexConverter().hexTObin("1B 1A FA"));
            Console.ReadLine();

            Console.WriteLine("02 1B 1A FA  " + new HexConverter().hexTObin("02 1B 1A FA"));
            Console.ReadLine();

            Console.WriteLine("54 02 1B 1A FA  " + new HexConverter().hexTObin("54 02 1B 1A FA"));
            Console.ReadLine();

            Console.WriteLine("01 54 02 1B 1A FA  " + new HexConverter().hexTObin("01 54 02 1B 1A FA"));
            Console.ReadLine();

            Console.WriteLine("02 00 01 54 02 1B 1A FA  " + new HexConverter().hexTObin("02 00 01 54 02 1B 1A FA"));
            Console.ReadLine();
            */
            //Test replacer'А
            
            string[] myReplacer = new Replacer().ReplacerPRIOR(inputStr);
            Console.WriteLine("Выходное сообщение формата ПРИОРа :");
                Console.WriteLine(String.Join("",myReplacer));


           /* 
            mass = inputStr.Split(' ');
            //вычисление кол-в элементов массива
            int count = 0;
            foreach (string s in mass)
            {
                if (s.Equals("")) count++;
            }
            int lenmass = mass.Length - count;


            Console.WriteLine("\nВ указанной строке найдено {0} октетов. \nAsterix cat. {1} \nКоличество октетов содержащих информацию {2}", lenmass, myHexConverter.hexTOdec(mass[0]), myHexConverter.hexTOdec(mass[1] + mass[2]));
           //косяк прям пиздец :/

            FSPECAnalyzer myFSPEC = new FSPECAnalyzer();
            string fs = myFSPEC.FSPECAnalytics(mass);
            int FSPECcount = myFSPEC.FSPECcount;
            string FSPEC = myFSPEC.FSPEChex;

            Console.WriteLine("\nВ указанной строке найдено {0} октетов FSPEC, FSPEC выглядит так {1}, {2}", FSPECcount, FSPEC, fs);


            
            lastOctet = 3 + FSPECcount;
            Console.WriteLine("\nИсходя из FSPEC, данные используемые в сообщении:");

            Asterix_cat_048 myAsterix048 = new Asterix_cat_048();
            myAsterix048.Asterix_cat_048_in(mass, lastOctet);
            string[,] UAPTable = myAsterix048.UAPTable;

            for (int i = 0; i < fs.Length; i++)
            {
                if (fs.Substring(i,1).Equals("1") && !UAPTable[i,0].Equals("FX"))
                {
                    Console.WriteLine(UAPTable[i,0] + " " + myAsterix048.ConvertAsterixHEX(UAPTable[i,0]));
                  //  Console.WriteLine(UAPTable[i]);
                }

            }
            
            string Appendix = null;
            for (int f = (int)myHexConverter.hexTOdec(mass[1] + mass[2]) - 1; f < lenmass; f++)
            {
                Appendix = Appendix + " " + mass[f];
            }
            Console.WriteLine("Октеты неиспользуемые в сообщении: {0} .",Appendix.Substring(1,Appendix.Length-1));

            Console.ReadLine();

            string[] outMass = null;*/

            Console.ReadLine();

        }

    }
}
