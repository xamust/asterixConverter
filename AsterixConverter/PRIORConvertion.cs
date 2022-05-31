using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AsterixConverter
{
    class PRIORConvertion
    {
        private string inputData;
        private string dataField;
        private int AsterixCat;
        private string ANT_RDPC = "0";
        public string mainStr = null;



      public PRIORConvertion(string inputData,string dataField, int AsterixCat)
      {
          //Console.WriteLine("InputData = {0}, DataField = {1}, AsterixCat = {2}",inputData, dataField, AsterixCat);

          this.inputData = inputData;
          this.dataField = dataField;
          this.AsterixCat = AsterixCat;
          if (AsterixCat == 48)
          {
              PRIOR48Convertion();
          }
      }
     public string PRIOR48Convertion()
      {
              switch (dataField)
              {
                  case "I048/010":
                      dataField = I048010();
                      break;
                  case "I048/140":
                      dataField = I048140();
                      break;
                  case "I048/020":
                      dataField = I048020();
                      break;
                  case "I048/040":
                      dataField = I048040();
                      break;
                  case "I048/070":
                      dataField = I048070();
                      break;
                  case "I048/090":
                      dataField = I048090();
                      break;
                  case "I048/130":
                      dataField = I048130();
                      break;
                  case "I048/220":
                      dataField = I048220();
                      break;
                  case "I048/240":
                      dataField = I048240();
                      break;
                  case "I048/250":
                      dataField = I048250();
                      break;
                  case "I048/161":
                      dataField = I048161();
                      break;
                  case "I048/042":
                      dataField = I048042();
                      break;
                  case "I048/200":
                      dataField = I048200();
                      break;
                  case "I048/170":
                      dataField = I048170();
                      break;
                  case "I048/210":
                      dataField = I048210();
                      break;
                  case "I048/030":
                      dataField = I048030();
                      break;
                  case "I048/080":
                      dataField = I048080();
                      break;
                  case "I048/100":
                      dataField = I048100();
                      break;
                  case "I048/110":
                      dataField = I048110();
                      break;
                  case "I048/120":
                      dataField = I048120();
                      break;
                  case "I048/230":
                      dataField = I048230();
                      break;
                  case "I048/260":
                      dataField = I048260();
                      break;
                  case "I048/055":
                      dataField = I048055();
                      break;
                  case "I048/050":
                      dataField = I048050();
                      break;
                  case "I048/065":
                      dataField = I048065();
                      break;
                  case "I048/060":
                      dataField = I048060();
                      break;
                  case "SP-Data Item":
                      dataField = SPData();
                      break;
                  case "RE-Data Item":
                      dataField = REData();
                      break;
              }
          
          return dataField;
      }

      private string REData()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string SPData()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048060()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048065()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048050()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048055()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048260()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048230()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048120()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048110()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048100()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048080()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048030()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048210()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048170()
      {
          string data = new HexConverter().hexTObin(inputData);
          string temp1 = null;

          //CON 
          temp1 = temp1 + data.Substring(0,1);
          //RAD
          //Primary (PSR)
          if (data.Substring(2, 1) == "0" && data.Substring(3, 1) == "1") temp1 = temp1 + "0";
          //SSR or Combined
          else temp1 = temp1 + "1";
          //MAN
          temp1 = temp1 + data.Substring(4, 1);
          //DOU
          temp1 = temp1 + data.Substring(3,1);
          //RDPC
          temp1 = temp1 + ANT_RDPC;
          //Sparce bit
          temp1 = temp1 + "0";
          //GHO
          if ((inputData.Length <= 4 && inputData.Length > 2)) temp1 = temp1 + data.Substring(9, 1);
          else temp1 = temp1 + "0";
          //FX
          temp1 = temp1 + data.Substring(7, 1);

          if (inputData.Length <= 4 && inputData.Length > 2)
          {
              //TRE
              temp1 = temp1 + data.Substring(8, 1);
              //SpareBits,FX
              temp1 = temp1 + "0000000";
          }
          return temp1;
      }

      private string I048200()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048042()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048161()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048250()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048240()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048220()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048130()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048090()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048070()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048040()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048140()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048010()
      {
          return new HexConverter().hexTObin(inputData);
      }

      private string I048020()
      {
          //if(inputData==null) return "FX";
          string data = new HexConverter().hexTObin(inputData);
          string temp1 = null;

          //TYP 0-plot, 1-track
          temp1 = temp1 + "0";
          //SIM
          temp1 = temp1 + data.Substring(3,1);
          //SSR/PSR
          temp1 = temp1 + data.Substring(1,2);
          //ANT
          ANT_RDPC = data.Substring(4, 1);
          temp1 = temp1 + data.Substring(4,1);
          //SPI,RAB,FX
          temp1 = temp1 + data.Substring(5,3);

             if (inputData.Length <= 4 && inputData.Length > 2)
          {
              //TST
              temp1 = temp1 + data.Substring(8,1);
              //DS1/DS2
              temp1 = temp1 + "00";
              //ME,MI
              temp1 = temp1 + data.Substring(11,2);
              //SpareBits,FX
              temp1 = temp1 + "000";
          }
          return temp1;
      }

    }
}
