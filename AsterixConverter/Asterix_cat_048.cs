using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterixConverter
{
    class Asterix_cat_048
    {
        public string[] mass = null;
        public int lastOctet = 0;
        public HexConverter myHexConv = new HexConverter();

        public string[,] UAPTable = {{"I048/010","Data Source Identifier "},
                                        {"I048/140","Time-of-Day"},
                                        {"I048/020","Target Report Descriptor"},
                                        {"I048/040","Measured Position in Slant Polar Coordinates"},
                                        {"I048/070","Mode-3/A Code in Octal Representation"},
                                        {"I048/090","Flight Level in Binary Representation"},
                                        {"I048/130","Radar Plot Characteristics"},
                                        {"FX","FX"},
                                        {"I048/220","Aircraft Address"},
                                        {"I048/240","Aircraft Identification"},
                                        {"I048/250","Mode S MB Data"},
                                        {"I048/161","Track Number"},
                                        {"I048/042","Calculated Position in Cartesian Coordinates"},
                                        {"I048/200","Calculated Track Velocity in Polar Representation"},
                                        {"I048/170","Track Status"},
                                        {"FX","FX"},
                                        {"I048/210","Track Quality"},
                                        {"I048/030","Warning/Error Conditions"},
                                        {"I048/080","Mode-3/A Code Confidence Indicator"},
                                        {"I048/100","Mode-C Code and Confidence Indicator"},
                                        {"I048/110","Height Measured by 3D Radar"},
                                        {"I048/120","Radial Doppler Speed"},
                                        {"I048/230","Communications / ACAS Capability and Flight Status"},
                                        {"FX","FX"},
                                        {"I048/260","ACAS Resolution Advisory Report"},
                                        {"I048/055","Mode-1 Code in Octal Representation"},
                                        {"I048/050","Mode-2 Code in Octal Representation"},
                                        {"I048/065","Mode-1 Code Confidence Indicator"},
                                        {"I048/060","Mode-2 Code Confidence Indicator"},
                                        {"SP-Data Item","Special Purpose Field"},
                                        {"RE-Data Item","Reserved Expansion Field"},
                                        {"FX","FX"},
                                        {"empty","empty"}
                                   };

        public void Asterix_cat_048_in(string[] mass, int lastOctet)
        {

        }

        public int getLastOctet()
        {
            return lastOctet;
        }

        public string ConvertAsterixHEX(string strAsterix, int lastOctet, string[] mass, bool onlyHEX)
        {
            this.mass = mass;
            this.lastOctet = lastOctet;

            string resultAsterix = null;
            switch (strAsterix)
            {
                case "I048/010":
                    resultAsterix = I048010(onlyHEX);
                    break;
                case "I048/140":
                    resultAsterix = I048140(onlyHEX);
                    break;
                case "I048/020":
                    resultAsterix = I048020(onlyHEX);
                    break;
                case "I048/040":
                    resultAsterix = I048040(onlyHEX);
                    break;
                case "I048/070":
                    resultAsterix = I048070(onlyHEX);
                    break;
                case "I048/090":
                    resultAsterix = I048090(onlyHEX);
                    break;
                case "I048/130":
                    resultAsterix = I048130(onlyHEX);
                    break;
                case "I048/220":
                    resultAsterix = I048220(onlyHEX);
                    break;
                case "I048/240":
                    resultAsterix = I048240(onlyHEX);
                    break;
                case "I048/250":
                    resultAsterix = I048250();
                    break;
                case "I048/161":
                    resultAsterix = I048161(onlyHEX);
                    break;
                case "I048/042":
                    resultAsterix = I048042(onlyHEX);
                    break;
                case "I048/200":
                    resultAsterix = I048200(onlyHEX);
                    break;
                case "I048/170":
                    resultAsterix = I048170(onlyHEX);
                    break;
                case "I048/210":
                    resultAsterix = I048210(onlyHEX);
                    break;
                case "I048/030":
                    resultAsterix = I048030(onlyHEX);
                    break;
                case "I048/080":
                    resultAsterix = I048080(onlyHEX);
                    break;
                case "I048/100":
                    resultAsterix = I048100(onlyHEX);
                    break;
                case "I048/110":
                    resultAsterix = I048110(onlyHEX);
                    break;
                case "I048/120":
                    resultAsterix = I048120(onlyHEX);
                    break;
                case "I048/230":
                    resultAsterix = I048230(onlyHEX);
                    break;
                case "I048/260":
                    resultAsterix = I048260(onlyHEX);
                    break;
                case "I048/055":
                    resultAsterix = I048055(onlyHEX);
                    break;
                case "I048/050":
                    resultAsterix = I048050(onlyHEX);
                    break;
                case "I048/065":
                    resultAsterix = I048065(onlyHEX);
                    break;
                case "I048/060":
                    resultAsterix = I048060(onlyHEX);
                    break;
                case "SP-Data Item":
                    resultAsterix = SPData();
                    break;
                case "RE-Data Item":
                    resultAsterix = REData();
                    break;
            }
            return resultAsterix;
        }

        public string I048010(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                getData1 = "(" +
                                   mass[lastOctet] +
                                   mass[lastOctet + 1] +
                                   " / " +
                                   myHexConv.hexTObin(mass[lastOctet] + mass[lastOctet + 1]) +
                                   ")  \nSAC" + myHexConv.hexTOdec(mass[lastOctet]) +
                                   "/SIC" +
                                   myHexConv.hexTOdec(mass[lastOctet + 1]);

                lastOctet = lastOctet + 2;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }
            return getData1;
        }

        private string I048140(bool onlyHEX)
        {
            //Three-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                long time = myHexConv.hexTOdec(mass[lastOctet] +
                            mass[lastOctet + 1] +
                            mass[lastOctet + 2]);

                time = time / 128;

                int hours = (int)time / 3600;
                int minutes = ((int)time - hours * 3600) / 60;
                int seconds = ((int)time - hours * 3600) - minutes * 60;


                getData1 = "(" +
                                mass[lastOctet] +
                                mass[lastOctet + 1] +
                                mass[lastOctet + 2] +
                                " / " +
                                myHexConv.hexTObin(mass[lastOctet] +
                                mass[lastOctet + 1]) +
                                ")" +
                                "\nTime of day (HH:mm:ss) " +
                                hours + ":" + minutes + ":" + seconds +
                                " (in sec):" +
                                time.ToString();

                lastOctet = lastOctet + 3;

            }
            else
            {
                 getData1 =     mass[lastOctet] + " " +
                                mass[lastOctet + 1] + " " +
                                mass[lastOctet + 2];
                lastOctet = lastOctet + 3;
            }
            return getData1;
        }

        private string I048020(bool onlyHEX)
        {
            //Compound Data Item (one-two octet)
            string getData1 = null;
            string getData2 = null;
            string resultStr1 = null;

            string resultStr3 = null;

            int countG = myHexConv.ifFX(lastOctet,mass);
            // Console.WriteLine("lastOctet {0}, mass[i] = {1} and countG {2}",lastOctet,mass[lastOctet],countG);
            getData2 = mass[lastOctet];
            if (countG > 1)
            {
                countG = 1;
                getData2 = mass[lastOctet] + mass[lastOctet + 1];
            }

                //тут может быть глюк
                for (int i = 0; i <= countG; i++)
                {
                    //1 вариант
                    /*  resultStr1 = resultStr1 + " " + mass[lastOctet + i];
                      resultStr2 = resultStr2 + hexTObin(mass[lastOctet + i]);*/
                    //2 вариант

                    resultStr1 = resultStr1 + mass[lastOctet + i];
                }
                // 1 вариант
                //getData1 = "(" + resultStr1 + " / " + resultStr2 +  ")";
                // 2 вариант
                getData1 = "(" + resultStr1 + " / " + myHexConv.hexTObin(resultStr1) + ")\n";
            

                switch (myHexConv.hexTObin(resultStr1).Substring(0, 3))
                {
                    case "000":
                        resultStr3 = resultStr3 + "(TYP) No detection\n";
                        break;
                    case "001":
                        resultStr3 = resultStr3 + "(TYP) Single PSR detection\n";
                        break;
                    case "010":
                        resultStr3 = resultStr3 + "(TYP) Single SSR detection\n";
                        break;
                    case "011":
                        resultStr3 = resultStr3 + "(TYP) SSR + PSR detection\n";
                        break;
                    case "100":
                        resultStr3 = resultStr3 + "(TYP) Single ModeS All-Call\n";
                        break;
                    case "101":
                        resultStr3 = resultStr3 + "(TYP) Single ModeS Roll-Call\n";
                        break;
                    case "110":
                        resultStr3 = resultStr3 + "(TYP) ModeS All-Call + PSR\n";
                        break;
                    case "111":
                        resultStr3 = resultStr3 + "(TYP) ModeS Roll-Call + PSR\n";
                        break;
                }

                if (myHexConv.hexTObin(resultStr1).Substring(3, 1).Equals("0")) resultStr3 = resultStr3 + "(SIM) Actual target report\n";
                else if (myHexConv.hexTObin(resultStr1).Substring(3, 1).Equals("1")) resultStr3 = resultStr3 + "(SIM) Simulated target report\n";

                if (myHexConv.hexTObin(resultStr1).Substring(4, 1).Equals("0")) resultStr3 = resultStr3 + "(RDP) Report from RDP Chain 1\n";
                else if (myHexConv.hexTObin(resultStr1).Substring(4, 1).Equals("1")) resultStr3 = resultStr3 + "(RDP) Report from RDP Chain 2\n";

                if (myHexConv.hexTObin(resultStr1).Substring(5, 1).Equals("0")) resultStr3 = resultStr3 + "(SPI) Absence of SPI\n";
                else if (myHexConv.hexTObin(resultStr1).Substring(5, 1).Equals("1")) resultStr3 = resultStr3 + "(SPI) Special Position Identification\n";

                if (myHexConv.hexTObin(resultStr1).Substring(6, 1).Equals("0")) resultStr3 = resultStr3 + "(RAB) Report from aircraft transponder";
                else if (myHexConv.hexTObin(resultStr1).Substring(6, 1).Equals("1")) resultStr3 = resultStr3 + "(RAB) Report from field monitor (fixed transponder)";

                lastOctet = lastOctet + 1;

                if (countG > 0)
                {
                    if (myHexConv.hexTObin(resultStr1).Substring(8, 1).Equals("0")) resultStr3 = resultStr3 + "\n(TST) Real target report\n";
                    else if (myHexConv.hexTObin(resultStr1).Substring(8, 1).Equals("1")) resultStr3 = resultStr3 + "\n(TST) Test target report\n";

                    if (myHexConv.hexTObin(resultStr1).Substring(10, 1).Equals("0")) resultStr3 = resultStr3 + "(XPP) NO X-Pulse present\n";
                    else if (myHexConv.hexTObin(resultStr1).Substring(10, 1).Equals("1")) resultStr3 = resultStr3 + "(XPP) X-Pulse present\n";

                    if (myHexConv.hexTObin(resultStr1).Substring(11, 1).Equals("0")) resultStr3 = resultStr3 + "(ME) No military emergency\n";
                    else if (myHexConv.hexTObin(resultStr1).Substring(11, 1).Equals("1")) resultStr3 = resultStr3 + "(ME) Military emergency\n";

                    if (myHexConv.hexTObin(resultStr1).Substring(12, 1).Equals("0")) resultStr3 = resultStr3 + "(MI) No military identification\n";
                    else if (myHexConv.hexTObin(resultStr1).Substring(12, 1).Equals("1")) resultStr3 = resultStr3 + "(MI) Military identification\n";

                    switch (myHexConv.hexTObin(resultStr1).Substring(13, 2))
                    {
                        case "00":
                            resultStr3 = resultStr3 + "(FOE/FRI) No Mode 4 interrogation\n";
                            break;
                        case "01":
                            resultStr3 = resultStr3 + "(FOE/FRI) Friendly  target\n";
                            break;
                        case "10":
                            resultStr3 = resultStr3 + "(FOE/FRI) Unknown target";
                            break;
                        case "11":
                            resultStr3 = resultStr3 + "(FOE/FRI) No reply";
                            break;
                    }
                    lastOctet = lastOctet + 1;
                }
                if (!onlyHEX)
                {
                    return getData1 + resultStr3;
                }
                else
                {
                    return getData2;
                }
        }

        private string I048040(bool onlyHEX)
        {
            //Four-octet fixed length Data Item
            string getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + " "+  mass[lastOctet + 3];

            if (!onlyHEX)
            {
                string resultStr = mass[lastOctet] + mass[lastOctet + 1] + mass[lastOctet + 2] + mass[lastOctet + 3];
                string Foct = myHexConv.hexTObin(mass[lastOctet]);
                string Soct = myHexConv.hexTObin(mass[lastOctet + 1]);
                string Toct = myHexConv.hexTObin(mass[lastOctet + 2]);
                string FRoct = myHexConv.hexTObin(mass[lastOctet + 3]);

                //  Math.IEEERemainder //Здесь нужна математика.... Внизу швах
                long THETA = (360 / 65536) * ((long)myHexConv.hexTOdec(mass[lastOctet + 2] + mass[lastOctet + 3]));

                string getData = "(" + resultStr + " / " + Foct + Soct + Toct + FRoct + ")\n" + "THETA " + THETA + "";

                lastOctet = lastOctet + 4;
                //Console.WriteLine("lastOctet {0}, mass[i] = {1}",lastOctet,mass[lastOctet]);
                return getData;
            }
            else
            {
                lastOctet = lastOctet + 4;
                return getData1;                
            }
        }

        private string I048070(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
	    string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
	    else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048090(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
	    string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
	    else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048130(bool onlyHEX)
        {
            //Compound Data Item
            //Надо делать под VS
            string getData1 = null;
            int count = 1;
            string mainField = mass[lastOctet];

            for (int i = 0; i <= 6; i++)
            {
                if (mainField.Substring(i, 1) == "1") count = count + 1;
            }


                if (!onlyHEX)
                {
                    // нужно доделать, обработать все активные суб поля
                    lastOctet = lastOctet + count;
                }
                else
                {
                    getData1 = mass[lastOctet];
                    for (int j = 1; j < count;j++ )
                    {
                        getData1 = getData1 + " " + mass[lastOctet + j];
                    }
                    lastOctet = lastOctet + count;
                }

            return getData1;
        }

        private string I048220(bool onlyHEX)
        {
            //Three-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 3;
            }
	    else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2];
                lastOctet = lastOctet + 3;
            }

            return getData1;
        }

        private string I048240(bool onlyHEX)
        {
            //Six-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 6;
            }
	    else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + mass[lastOctet + 3] + " " + mass[lastOctet + 4] + " " + mass[lastOctet + 5];
                lastOctet = lastOctet + 6;
            }

            return getData1;
        }

        private string I048250()
        {
            //Надо делать под VS;
            return null;
        }

        private string I048161(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
	    string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
	    else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048042(bool onlyHEX)
        {
            //Four-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 4;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + " " + mass[lastOctet + 3];
                lastOctet = lastOctet + 4;
            }

            return getData1;
        }

        private string I048200(bool onlyHEX)
        {
            //Four-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 4;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + " " + mass[lastOctet + 3];
                lastOctet = lastOctet + 4;
            }

            return getData1;
        }

        private string I048170(bool onlyHEX)
        {
            //Compound Data Item (one-two octet)
            string getData1 = null;
            string getData2 = null;
            string resultStr1 = null;
            string resultStr3 = null;

            int countG = myHexConv.ifFX(lastOctet, mass);
            // Console.WriteLine("lastOctet {0}, mass[i] = {1} and countG {2}",lastOctet,mass[lastOctet],countG);
            getData2 = mass[lastOctet];
            if (countG > 1)
            {
                countG = 1;
                getData2 = mass[lastOctet] +" " + mass[lastOctet + 1];
            }

            //тут может быть глюк
            for (int i = 0; i <= countG; i++)
            {
                //1 вариант
                /*  resultStr1 = resultStr1 + " " + mass[lastOctet + i];
                  resultStr2 = resultStr2 + hexTObin(mass[lastOctet + i]);*/
                //2 вариант

                resultStr1 = resultStr1 + mass[lastOctet + i];
            }
            // 1 вариант
            //getData1 = "(" + resultStr1 + " / " + resultStr2 +  ")";
            // 2 вариант
            getData1 = "(" + resultStr1 + " / " + myHexConv.hexTObin(resultStr1) + ")\n";
            
            if (!onlyHEX)
            {
                return getData1 + resultStr3;
            }
            else
            {
                return getData2;
            }
        }

        private string I048210(bool onlyHEX)
        {
            //Four-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 4;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + mass[lastOctet + 3];
                lastOctet = lastOctet + 4;
            }

            return getData1;
        }

        private string I048030(bool onlyHEX)
        {
            //Compound Data Item (one-two octet)
            string getData1 = null;
            string getData2 = null;
            string resultStr1 = null;
            string resultStr3 = null;

            int countG = myHexConv.ifFX(lastOctet, mass);
            // Console.WriteLine("lastOctet {0}, mass[i] = {1} and countG {2}",lastOctet,mass[lastOctet],countG);
            getData2 = mass[lastOctet];
            if (countG > 1)
            {
                countG = 1;
                getData2 = mass[lastOctet] + mass[lastOctet + 1];
            }

            //тут может быть глюк
            for (int i = 0; i <= countG; i++)
            {
                //1 вариант
                /*  resultStr1 = resultStr1 + " " + mass[lastOctet + i];
                  resultStr2 = resultStr2 + hexTObin(mass[lastOctet + i]);*/
                //2 вариант

                resultStr1 = resultStr1 + mass[lastOctet + i];
            }
            // 1 вариант
            //getData1 = "(" + resultStr1 + " / " + resultStr2 +  ")";
            // 2 вариант
            getData1 = "(" + resultStr1 + " / " + myHexConv.hexTObin(resultStr1) + ")\n";

            if (!onlyHEX)
            {
                return getData1 + resultStr3;
            }
            else
            {
                return getData2;
            }
        }

        private string I048080(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048100(bool onlyHEX)
        {
            //Four-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 4;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + mass[lastOctet + 3];
                lastOctet = lastOctet + 4;
            }

            return getData1;
        }

        private string I048110(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048120(bool onlyHEX)
        {

            //Compound Data Item
            //Надо делать по VS тут неправильно
            string getData1 = null;
            int count = 1;
            string mainField = mass[lastOctet];

            if (mainField.Substring(0, 1) == "1") count = count + 1;
            if (mainField.Substring(1, 1) == "1" && mainField.Substring(0, 1) == "1")
            {
                count = count + 1;
                string subString = mass[lastOctet + 2];
                for (int i = 0; i <= 5; i++)
                {
                    if (mainField.Substring(i, 1) == "1") count = count + 1;
                }
            }

            if (!onlyHEX)
            {
                // нужно доделать, обработать все активные суб поля
                lastOctet = lastOctet + count;
            }
            else
            {
                getData1 = mass[lastOctet];
                for (int j = 1; j < count; j++)
                {
                    getData1 = getData1 + " " + mass[lastOctet + j];
                }
                lastOctet = lastOctet + count;
            }

            return getData1;
        }

        private string I048230(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048260(bool onlyHEX)
        {
            //Seven-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 7;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1] + " " + mass[lastOctet + 2] + mass[lastOctet + 3] + " " + mass[lastOctet + 4] + " " + mass[lastOctet + 5] + mass[lastOctet + 6];
                lastOctet = lastOctet + 7;
            }

            return getData1;
        }

        private string I048055(bool onlyHEX)
        {
            //One-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 1;
            }
            else
            {
                getData1 = mass[lastOctet];
                lastOctet = lastOctet + 1;
            }

            return getData1;
        }

        private string I048050(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string I048065(bool onlyHEX)
        {
            //One-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 1;
            }
            else
            {
                getData1 = mass[lastOctet];
                lastOctet = lastOctet + 1;
            }

            return getData1;
        }

        private string I048060(bool onlyHEX)
        {
            //Two-octet fixed length Data Item
            string getData1 = null;
            if (!onlyHEX)
            {
                // нужно доделать
                lastOctet = lastOctet + 2;
            }
            else
            {
                getData1 = mass[lastOctet] + " " + mass[lastOctet + 1];
                lastOctet = lastOctet + 2;
            }

            return getData1;
        }

        private string SPData()
        {
            return null;
        }

        private string REData()
        {
            return null;
        }
    }
}
