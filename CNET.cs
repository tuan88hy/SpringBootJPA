using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;
namespace WindowsFormsApplication1
{
   public class CNET
    {
       private string comName = "COM1";
       private int baudRate = 9600;
       private int dataBits = 8;
       private Parity parity = Parity.None;
       private StopBits stopBits = StopBits.One;
       private SerialPort COM;
       private string RSDATA = "";
       public const string
            Individual = "SS",
            Continuous = "SB";

       const int ENQ = 0x05;
       const int EOT = 0x04;

       private string stationNo = "01";

       public string StationNo
       {
           get { return stationNo; }
           set { stationNo = value; }
       }

       public CNET() {
           COM = new SerialPort(comName, baudRate, parity, dataBits, stopBits);
           COM.DataReceived += new SerialDataReceivedEventHandler(COM_DataReceived);
       }
       public CNET(string comName_) {
           this.comName = comName_;
           COM = new SerialPort(comName, baudRate, parity, dataBits, stopBits);
           COM.DataReceived += new SerialDataReceivedEventHandler(COM_DataReceived);
        }
       public CNET(string comName_, int baudRate_, int dataBits_, Parity parity_, StopBits stopBits_)
       {
           this.comName = comName_;
           this.baudRate = baudRate_;
           this.dataBits = dataBits_;
           this.parity = parity_;
           this.stopBits = stopBits_;
           COM = new SerialPort(comName, baudRate, parity, dataBits, stopBits);
           COM.DataReceived += new SerialDataReceivedEventHandler(COM_DataReceived);
       }

       public bool Open()
       {
           if (!COM.IsOpen)
           {
               COM.Open();
           }
           return COM.IsOpen;
       }
       public void Close()
       {
           if (COM != null)
           {
               if (COM.IsOpen)
               {
                   COM.Close();
                   COM.Dispose();
               }
           }
       }
       public void SendData(string DATA)
       {
           COM.Write(DATA);
       }

       public string ReadData(DeviceType memoryType, DataType dataType, string position)
       {
           var dataB = new List<byte>();
           string command = "";
           string deviceName = "%" + memoryType + dataType + position;
           //byte[] ValAddressByte_6 = Encoding.Default.GetBytes(deviceName);
           //command += ENQ;
           //dataB.Add(ENQ);
           command += StationNo;
           //dataB.Add(Convert.ToByte(StationNo));
           command += Command.R;
           //dataB.Add(Convert.ToByte(Command.R));
           command += Individual;

           command += "01";
           //dataB.Add(Convert.ToByte("01"));
           command += deviceName.Length.ToString("00");
           //dataB.Add(Convert.ToByte(deviceName.Length.ToString("00")));
           command += deviceName;

           byte [] tmpByte = CommandToByteArray(command);
           //command += EOT;
           //dataB.Add(EOT);
           ////SendData(command);
           byte[] bte = Encoding.Default.GetBytes("%DW50");
           bte.ToList().Insert(0, ENQ);
           bte.ToList().Insert(0, ENQ);
           var arr = new List<byte>() { 0x05, 0x30, 0x31, 0x52, 0x53, 0x53, 0x30, 0x31, 0x30, 0x35 };
           arr.Add(bte[0]);
           arr.Add(bte[1]);
           arr.Add(bte[2]);
           arr.Add(bte[3]);
           arr.Add(bte[4]);
           arr.Add(0x04);
           //COM.Write(arr.ToArray(), 0, arr.ToArray().Length);
           Thread.Sleep(50);

           return Encoding.Default.GetString(datars);


       }

       public byte[] CommandToByteArray(string command)
       {
           byte[] result = new byte[command.Length];
           if (command != "")
           {
               for (int i = 0; i < command.Length; i++)
               {
                   result[i] = (byte)command[i];
               }
           }
           return result;
       }





       int bl = 0;
       byte[] datars;

       void COM_DataReceived(object sender, SerialDataReceivedEventArgs e)
       {
           
           Int32 dataLength = COM.BytesToRead;
           datars = new byte[dataLength];
           int nbrDataRead = COM.Read(datars, 0, dataLength);
           if (nbrDataRead == 0)
               return;
           //bl = COM.Read(datars, 0, 1024);   
       }


       public enum Command
       {
           R,
           W
       }
       
       public enum DataType
       {
           X ,  //Bit 
           B ,  //Byte,
           W,   //Word
           D,   //Dword
           L    //Lword
       }
       public enum DeviceType
       {
           P = 'P',
           M = 'M',
           K = 'K',
           F = 'F',
           T = 'T',
           C = 'C',
           L = 'L',
           N = 'N',
           D = 'D',
           U = 'U',
           Z = 'Z',
           R = 'R'
       }

    }
   public class SerialDataEventArgs : EventArgs
   {
       public SerialDataEventArgs(byte[] dataInByteArray)
       {
           Data = dataInByteArray;
       }

       /// <summary>
       /// Byte array containing data from serial port
       /// </summary>
       public byte[] Data;
   }
   
}
