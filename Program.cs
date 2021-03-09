using System;
using System.IO.Ports;
using System.IO;
namespace osillo
{
    class Program
    {
	static string[] mes = new string[5]; 
	static int freemode = 2;
	static bool wasth = false;
        static bool ground = false;
	static int treshold = 500;
        static int x = 0,prevy = 0,prevy2 = 0;
        static SerialPort sp = new SerialPort();
        static void Main(string[] args)
        {
	    Console.WriteLine("freemode");
	    freemode = Convert.ToInt32(Console.ReadLine());
            Console.CursorVisible = false;
            Console.Clear();
            string data = "";
            
	    sp.BaudRate = 115200;
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
	    if(freemode == 1 && wasth == false){
		    Console.ReadKey();
	    }
	    try
            {
                message = sp.ReadLine();
		mes = message.Split("-");
	    }
            catch
            {
                message = "11";
            	
	    }
            
	    try
            {
		
		    if(ground == false && Convert.ToInt32(mes[ch]) < 10){
			    ground = true;
			    Console.WriteLine("Ground on");
		    }
                int conv = Convert.ToInt32(mes[0]) / Console.BufferHeight * 1;
		int conv2 = Convert.ToInt32(mes[1]) / Console.BufferHeight * 1 + (Console.BufferHeight / 2); //this section is buggy,and i dont know why it works.
                if(Convert.ToInt32(mes[ch]) >= treshold  || freemode == 2 || wasth == true || freemode == 1  )
		{
			if(freemode == 3 || freemode == 1){
				wasth = true;
			}

			if (x > Console.BufferWidth)
			{   
			    if(freemode == 3)
			    {
				System.Environment.Exit(0);	    
			    	Console.SetCursorPosition(Console.BufferWidth,Console.BufferHeight);
			    }
				if(freemode == 1)
			    {
				
				Console.ReadKey();
				x = 0;
			    }
			    else if(freemode == 2){
				x = 0;
			    }
			     
			    wasth = false;
			    message = "";
			}
			for(int y = 0; y < Console.BufferHeight;y++){
				Console.SetCursorPosition(x,y);
				Console.Write(' ');
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
			if (-conv2+Console.BufferHeight > prevy2)
			{
			    for (; prevy2 <= -conv2+Console.BufferHeight; prevy2++)
			    {
				Console.SetCursorPosition(x,prevy2);
				Console.Write("\u2588");
			    }
			}
			else if(-conv2+Console.BufferHeight < prevy2)
			{
			    for (; prevy2 > -conv2+Console.BufferHeight; prevy2--)
			    {
				Console.SetCursorPosition(x,prevy2);
				Console.Write("\u2588");
			    }
			}
			Console.SetCursorPosition(x,-conv2+Console.BufferHeight);
			Console.Write("\u2588");
			Console.SetCursorPosition(x, (-conv+Console.BufferHeight));
			Console.Write("\u2588");
			x++;
		    }
	    }
            
	    catch
            {
                
            }

        }
    }
}
