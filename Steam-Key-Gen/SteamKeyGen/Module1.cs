using System;
using System.IO;
using Microsoft.VisualBasic.CompilerServices;

namespace SteamKeyGen
{
	// Token: 0x02000008 RID: 8
	[StandardModule]
	internal sealed class Module1
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000021B4 File Offset: 0x000003B4
		[STAThread]
		public static void Main()
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("SteamKeyGen v1 - Zeth Community");
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("Discord: Cuck#0001");
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("How many keys would you like to generate? ");
			int num = Conversions.ToInteger(Console.ReadLine());
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
			FileStream stream = new FileStream(folderPath + "\\" + Conversions.ToString(num) + " Steam Keys.txt", FileMode.Create);
			TextWriter @out = Console.Out;
			StreamWriter streamWriter = new StreamWriter(stream);
			Console.SetOut(streamWriter);
			RandomKeyGenerator randomKeyGenerator = new RandomKeyGenerator();
			randomKeyGenerator.KeyLetters = "ABCDEFGHIJKLMNOPQRSTUVWYZ";
			randomKeyGenerator.KeyNumbers = "0123456789";
			randomKeyGenerator.KeyChars = 5;
			int num2 = num;
			checked
			{
				for (int i = 1; i <= num2; i++)
				{
					string text = randomKeyGenerator.Generate();
					Console.WriteLine(string.Concat(new string[]
					{
						randomKeyGenerator.Generate(),
						"-",
						randomKeyGenerator.Generate(),
						"-",
						randomKeyGenerator.Generate()
					}));
				}
				Console.SetOut(@out);
				streamWriter.Close();
				Console.Clear();
				Console.ForegroundColor = ConsoleColor.Green;
				Console.WriteLine(Conversions.ToString(num) + " Keys has been generated.");
				Console.ForegroundColor = ConsoleColor.White;
				Console.WriteLine("Press enter to exit...");
				Console.Read();
			}
		}
	}
}
