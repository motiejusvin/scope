using System;
using System.IO.Ports;
using System.IO;
namespace osillo
{
    class Program
    {
        static int x = 0,prevy = 0;
        static SerialPort sp = new SerialPort();
        static int[] vls = new int[10000];
        static int count = 0;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Clear();
            string data = "";
            sp.PortName = "/dev/ttyUSB0";
            sp.BaudRate = 2000000;
            try
            {
                sp.Open();
            }
            catch
            {
                
            }
            while (true)
            {
                Read();
            }
            sp.Close();
        }

        public static void Read()
        {
            string message;
            try
            {
                message = sp.ReadLine();
            }
            catch (TimeoutException)
            {
                message = "1";
            }

            try
            {
                int conv = Convert.ToInt32(message) / Console.BufferHeight ;
                if (x > Console.BufferWidth)
                {
		    Console.Clear();
                    x = 0;
               	
		}
		
                if (-conv+Console.BufferHeight > prevy)
                {
                    for (; prevy <= -conv+Console.BufferHeight; prevy++)
                    {
                        Console.SetCursorPosition(x,prevy);
                        Console.Write("\u2588");
                    }
                }
		else if(-conv+Console.BufferHeight < prevy)
                {
                    for (; prevy > -conv+Console.BufferHeight; prevy--)
                    {
                        Console.SetCursorPosition(x,prevy);
			Console.Write("\u2588");
                    }
                }
		//prevy = -conv+Console.BufferHeight;
                Console.SetCursorPosition(x, (-conv+Console.BufferHeight));
                Console.Write("\u2588");
                x++;
            }
            catch
            {
                
            }

        }
    }
}
