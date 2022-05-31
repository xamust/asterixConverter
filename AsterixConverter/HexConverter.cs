using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterixConverter
{
    public class HexConverter
    {
        public long hexTOdec(string inputHex)
        {
            return Convert.ToInt32(inputHex, 16);
        }

        public string hexTObin(string hex)
        {

            string strTemp = null;
            string format = "00000000";

   
                string[] massTemp = hex.Split(' ');

            foreach (string s in massTemp)
            {

                strTemp = strTemp + Convert.ToDouble(Convert.ToString(hexTOdec(s), 2)).ToString(format);
            }
            

            return strTemp;
        }

        public int ifFX(int index, string[] mass)
        {
            int result = 0;
            if (hexTObin(mass[index]).Substring(7, 1) == "1" && hexTObin(mass[index]).Substring(7, 1) == "1" && hexTObin(mass[index]).Substring(7, 1) == "1") result = 3;
            else if (hexTObin(mass[index]).Substring(7, 1) == "1" && hexTObin(mass[index + 1]).Substring(7, 1) == "1") result = 2;
            else if (hexTObin(mass[index]).Substring(7, 1) == "1") result = 1;
            else if (hexTObin(mass[index]).Substring(7, 1) == "0") result = 0;
            return result;
        }

        public string binTOhex(string inputBin)
        {
            //выходит с пробелами....
            string format = "00000000";
            string temp = null;
            string tempStr = null;
            string hex = null;
            int count = 0;
            while(true)
            {
                
                temp = null;
                for (int i = 0; i < 8 ; i++)
                    {
                       temp = inputBin.Substring(inputBin.Length - i - count -1, 1) + temp;                      
                    }

                tempStr = Convert.ToInt32(Convert.ToDouble(temp).ToString(format), 2).ToString("X");
                hex = String.Format("{0,2:X2}", Convert.ToInt32(Convert.ToDouble(temp).ToString(format), 2)) + " " + hex;
                count = count + 8;
                if (count == inputBin.Length) { break; }
            }


            return hex;
        }

        public string decTOhex(string inputDec)
        {
            string hex = null;
            hex = int.Parse(inputDec, System.Globalization.NumberStyles.HexNumber).ToString();
            return String.Format("{0,2:X2}", Convert.ToInt32(Convert.ToDouble(inputDec))); 

        }
    }
}
