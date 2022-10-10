using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
					
public class Program
{
	public static void Main()
	{
		//char[] test = {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p'};
		string pruebaF = "¡Hola! ¿Que tal? Buenas tardes. ¿Como estas?";
		string finalB64;
		Random rand = new Random();
		List<byte> byt1 = new List<byte>();
		List<int> size = new List<int>();
		List<int> newSize = new List<int>();
		List<int> randUsed = new List<int>();
		int cont = 0;
		int testeo = rand.Next(1,20);
		Console.WriteLine(testeo);
		foreach(char str in pruebaF.ToCharArray()){
			if(cont==0)
				randUsed.Add(testeo);
			if(cont%5==0){
				testeo = rand.Next(1,20);
				randUsed.Add(testeo);
			}
			byt1.Add(Convert.ToByte(str));
			size.Add(Convert.ToInt32(str));
			newSize.Add((Convert.ToInt32(str)-testeo));
			cont++;
		}
		Console.WriteLine("Start byte check");
		if(byt1 != null){
			Console.WriteLine("Byte:");
			foreach(byte b in byt1){
				Console.Write(b+" ");
			}
			finalB64 = Convert.ToBase64String(byt1.ToArray());
			Console.WriteLine("\nString final: "+finalB64.Count() + ":\t" + finalB64);
		}
		Console.WriteLine();
		if(size != null){
			Console.WriteLine("Size:");
			foreach(int b in size){
				Console.Write(Convert.ToChar(b));
			}
		}
		Console.WriteLine("\n");
		if(newSize != null){
			Console.WriteLine("NewSize:");
			foreach(int b in newSize){
				Console.Write(Convert.ToChar(b));
			}
		}
		Console.WriteLine("\n");
		foreach(int b in randUsed){
				Console.Write(b+" ");
			}
		Console.WriteLine("\n" + cont);
	}
}