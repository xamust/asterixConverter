using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterixConverter
{
    //Replacer for PRIOR
    //Формат посылки "Приор" (asterix cat. 001/002)
    //
    // Example:
    //        
    //  cat.001 : 01 11 F8 52 03 31 00 07 57 02 90 C2 31 0D B8 00 73 10 03 10 02 
    // 01 - cat. of Asterix, 11 - length, F8 - FSPEC, Data - 52 .... 73, ??? - 10 03 10 02
    //
    //
    //  cat.002 : 02 0A F0 52 03 82 58 47 C2 97 10 03 10 02 
    //02 - cat. of Asterix, 0A - length, F8 - FSPEC, Data - 52 .... 97, ??? - 10 03 10 02

   
    class Replacer
    {
        int[,] EqualsUAPTable = { { 1, 1 },   { 2, 10 },   { 3, 2 },   { 4, 4 },   { 5, 7 },   { 6, 9 },  { 7, 11 },   { 8, 8 }, 
                                 { 9, 26 },  { 10, 26 },  { 11, 26 },  { 12, 3 },  { 13, 5 }, { 14, 6 }, { 15, 14 }, { 16, 16 }, 
                                { 17, 15 },  { 18, 21 }, { 19, 18 }, { 20, 19 },  { 21, 26 }, { 22, 13 }, { 23, 26 }, { 24, 24 },
                                 { 25, 26 },   { 26, 26 }, { 27, 17 },  { 28, 26 }, { 29, 20 }, { 30, 22 }, { 31, 26 }, { 32, 32 }}; 

        string[] result;
        static int realLen = 0;
        private int lastOctet = 0;
        private int count = 0;
        int countFSPECconvert = 0;

        //КОСТЫЛИ.....

        public string[] FSPECmass = {"0","0","0","0","0",
                                   "0","0","0","0","0",
                                   "0","0","0","0","0",
                                   "0","0","0","0","0",
                                   "0","0","0","0","0"};

        private void FSPEC_Create(string input)
        {
            count++;
            switch (input)
            {
                case "I048/010":
                    FSPECmass[0] = "1";
                    break;
                case "I048/140":
                    FSPECmass[9] = "1";
                    break;
                case "I048/020":
                    FSPECmass[1] = "1";
                    break;
                case "I048/040":
                    FSPECmass[3] = "1";
                    break;
                case "I048/070":
                    FSPECmass[6] = "1";
                    break;
                case "I048/090":
                    FSPECmass[8] = "1";
                    break;
                case "I048/130":
                    FSPECmass[10] = "1";
                    break;
                case "I048/161":
                    FSPECmass[2] = "1";
                    break;
                case "I048/042":
                    FSPECmass[4] = "1";
                    break;
                case "I048/200":
                    FSPECmass[5] = "1";
                    break;
                case "I048/170":
                    FSPECmass[13] = "1";
                    break;
                case "I048/210":
                    FSPECmass[14] = "1";
                    break;
                case "I048/030":
                    FSPECmass[20] = "1";
                    break;
                case "I048/080":
                    FSPECmass[17] = "1";
                    break;
                case "I048/100":
                    FSPECmass[18] = "1";
                    break;
                case "I048/120":
                    FSPECmass[12] = "1";
                    break;
                case "I048/050":
                    FSPECmass[16] = "1";
                    break;
                case "I048/060":
                    FSPECmass[19] = "1";
                    break;
                case "SP-Data Item":
                    FSPECmass[21] = "1";
                    break;
                    
            }
            if (count == 8) FSPECmass[7] = "1";
            else if (count == 16) FSPECmass[15] = "1";
            else if (count == 24) FSPECmass[23] = "1";
        }

        private string ByteSlicer(string[] inputByte)
        {
            string output = null;
            string firstOct = new HexConverter().binTOhex(String.Join("", inputByte).Substring(0, 8));
            string secOct = new HexConverter().binTOhex(String.Join("", inputByte).Substring(7, 8));
            string thirdOct = new HexConverter().binTOhex(String.Join("", inputByte).Substring(15, 8));
            if (secOct == "00 " && thirdOct == "00 ")
            {
                output = String.Join("", inputByte).Substring(0, 8);
                countFSPECconvert = 1;

            }
            else if (secOct != "00 " && thirdOct == "00 ")
            {
                output = String.Join("", inputByte).Substring(0, 8) + String.Join("", inputByte).Substring(7, 8);
                countFSPECconvert = 2;
            }
            else if (secOct != "00 " && thirdOct != "00 ")
            {
                output = String.Join("", inputByte).Substring(0, 8) + String.Join("", inputByte).Substring(7, 8) + String.Join("", inputByte).Substring(15, 8);
                countFSPECconvert = 2;
            }

//           Console.WriteLine(output);
                return output;
        }
        

        public string[] ReplacerPRIOR(string inputStr)
        {
            HexConverter myHexConv = new HexConverter();
            string[,] UAPTableIn = new string[32,2];
            string[,] UAPTableOut = new string[32,2];
            

            string[] mass = new string[inputStr.Length];
            mass = inputStr.Split(' ');

            result = new string[inputStr.Length];

            //правим версию Asterix
            if (mass[0].Equals("30"))
            { 
                result[0] = "01 ";
                UAPTableIn =  new Asterix_cat_048().UAPTable;
                UAPTableOut =  new Asterix_cat_001().UAPTable;
            }
            else if (mass[0].Equals("22"))
            {
                result[0] = "02 ";
                UAPTableIn =  new Asterix_cat_034().UAPTable;
                UAPTableOut =  new Asterix_cat_002().UAPTable;
            }

            realLen = (int)myHexConv.hexTOdec(mass[1] + mass[2]);
            //For debug
           // Console.WriteLine("Исходная длина сообщения {0} (октетов)",realLen);

            FSPECAnalyzer myFSPEC = new FSPECAnalyzer();
            string FSPEC = myFSPEC.FSPECAnalytics(mass);
            lastOctet = 3 + myFSPEC.FSPECcount;

            int countOctet = 0;

            int countCAT = 1;
            int countLEN = 1;
            int count = 0 ;
            string temp4 = null;

            //Тут вычисляем/конвертируем кол-во FSPEC


            for (int i = 0; i < FSPEC.Length; i++)
            {
                
            //    if (FSPEC.Substring(i, 1).Equals("1") && !UAPTableIn[i, 0].Equals("FX"))
                if (FSPEC.Substring(i, 1).Equals("1"))
                {
                    if (UAPTableIn[i, 0] != "FX")
                    {
                        Asterix_cat_048 myAster48 = new Asterix_cat_048();
                        PRIORConvertion myPRIOR = new PRIORConvertion(myAster48.ConvertAsterixHEX(UAPTableIn[i, 0], lastOctet, mass, true),UAPTableIn[i, 0], 48);
                      //  Console.WriteLine("Кол-во октет инф-и: {0}", countOctet = countOctet - 1 + new HexConverter().binTOhex(myPRIOR.PRIOR48Convertion()).Split(' ').Length);
                        //if (!UAPTableIn[i, 0].Equals("FX") )
                        // Console.WriteLine("UAPTableIn {0}  =  UAPTableOut {1}  =  значению  {2}",UAPTableIn[i,0],UAPTableOut[EqualsUAPTable[i,1]-1,0] ,myAster48.ConvertAsterixHEX(UAPTableIn[i,0],lastOctet,mass,true));
                       // Console.WriteLine("Поле сообщения = {0}",UAPTableIn[i, 0]); 
                     /*   Console.WriteLine("Input={0}, HEX={4}, Output={1}, HEX={2}, dataField= {3}",
                            new HexConverter().hexTObin(myAster48.ConvertAsterixHEX(UAPTableIn[i, 0], lastOctet, mass, true)),
                            myPRIOR.PRIOR48Convertion(),
                                new HexConverter().binTOhex(myPRIOR.PRIOR48Convertion()),
                                UAPTableIn[i, 0],
                                myAster48.ConvertAsterixHEX(UAPTableIn[i, 0], lastOctet, mass, true));*/
                       // Console.WriteLine(UAPTableIn[i, 0]);
                        FSPEC_Create(UAPTableIn[i, 0]);
                        temp4 = temp4 + " " + new HexConverter().binTOhex(myPRIOR.PRIOR48Convertion());
                        count = count + (new HexConverter().binTOhex(myPRIOR.PRIOR48Convertion()).Split(' ').Length-1);
                        lastOctet = myAster48.getLastOctet();

                    }
                }

            }
            string temp3 = ByteSlicer(FSPECmass);
            countOctet = countCAT + countLEN + countFSPECconvert + count;
            result[1] = new HexConverter().decTOhex(countOctet.ToString()) + " ";
            result[2] = new HexConverter().binTOhex(temp3);
            result[3] = temp4;
            result[4] = " 10 03 10 02";
                return result;
        }
    }
}
