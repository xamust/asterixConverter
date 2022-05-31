using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AsterixConverter;

namespace AsterixConverter
{
    public class FSPECAnalyzer
    {
        public int FSPECcount = 0;
        private string FSPEC = null;
        public string FSPEChex = null;

        public string FSPECAnalytics(string[] mass)
        {
            HexConverter myHexConverter = new HexConverter();
      
            if (myHexConverter.hexTObin(mass[3]).Substring(7, 1) == "1" && myHexConverter.hexTObin(mass[4]).Substring(7, 1) == "1" && myHexConverter.hexTObin(mass[5]).Substring(7, 1) == "1")
            {
                FSPEC = myHexConverter.hexTObin(mass[3].ToString()) + myHexConverter.hexTObin(mass[4].ToString()) + myHexConverter.hexTObin(mass[5].ToString()) + myHexConverter.hexTObin(mass[6].ToString());
                FSPEChex = mass[3].ToString() + mass[4].ToString() + mass[5].ToString() + mass[6].ToString();
                FSPECcount = +4;
            }
            else if (myHexConverter.hexTObin(mass[3]).Substring(7, 1) == "1" && myHexConverter.hexTObin(mass[4]).Substring(7, 1) == "1")
            {
                FSPEC = myHexConverter.hexTObin(mass[3].ToString()) + myHexConverter.hexTObin(mass[4].ToString()) + myHexConverter.hexTObin(mass[5].ToString());
                FSPEChex = mass[3].ToString() + mass[4].ToString() + mass[5].ToString();
                FSPECcount = +3;
            }
            else if (myHexConverter.hexTObin(mass[3]).Substring(7, 1) == "1")
            {
                FSPEC = myHexConverter.hexTObin(mass[3].ToString()) + myHexConverter.hexTObin(mass[4].ToString());
                FSPEChex = mass[3].ToString() + mass[4].ToString();
                FSPECcount = +2;
            }
            else if (myHexConverter.hexTObin(mass[3]).Substring(7, 1) == "0")
            {
                FSPEC = myHexConverter.hexTObin(mass[3].ToString());
                FSPEChex = mass[3].ToString();
                FSPECcount = +1;
            }
            return FSPEC;
        }

    }
}
