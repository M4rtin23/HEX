using System;
using System.IO;
using System.Drawing;

namespace imaHEX{
    class Program{
        static void Main(string[] args){
			Console.WriteLine("Enter File Location:");
			string file = Console.ReadLine();
			createImage(getColors(file));
			replace(file);
		}
		
		static void replace(string file){
			Console.WriteLine("Enter Image Location:");
			string img = Console.ReadLine();
			Bitmap bitmap = new Bitmap(Image.FromFile(img));
			string[] hexValues = new string[bitmap.Height*bitmap.Width];

			for (var x = 0; x < bitmap.Width; x++){
				for (var y = 0; y < bitmap.Height; y++){
					hexValues[y+x*(hexValues.Length/2)] = HexConverter(bitmap.GetPixel(x, y));
				}
			}
			StreamReader reader = new StreamReader(File.OpenRead(file));
			string fileContent = reader.ReadToEnd();
			reader.Close();
			for(int i = 0; i < bitmap.Height; i++){
				fileContent = fileContent.Replace(hexValues[i], hexValues[i + bitmap.Height], StringComparison.InvariantCultureIgnoreCase);
			}
			StreamWriter writer =new StreamWriter(File.OpenWrite(file));
			writer.Write(fileContent);
			writer.Close();
		}

		static string[] getColors(string file){
			string[] lines;
			string[] colors = new string[0];
			lines = File.ReadAllLines(file);
			for(int i = 0; i < lines.Length; i++){
				if(lines[i].Contains('#')){
					string hex = lines[i].Substring(lines[i].IndexOf('#'), 7).ToLower();
					if(isHex(hex)){
						push(ref colors, hex);
					}
				}
			}

			Array.Sort(colors, StringComparer.InvariantCultureIgnoreCase);
			for(int i = 0; i < colors.Length-1; i++){
				if(colors[i] == colors[i+1]){
					colors[i] = "";
				}
			}
			colors = resize(colors);
	    	return colors;
		}
		
		static bool isHex(string str){
			char[] charHex = str.ToCharArray();
			char[] chars = {'0','1','2','3','4','5','6','7','8','9','a','b','c','d','e','f'};
			int num = 0;

			for(int i = 1; i < charHex.Length; i++){
				for(int j = 0; j < chars.Length; j++){
					if(charHex[i] == chars[j]){
						num++;
						break;
					}
				}
			}
			return (num == 6);
		}

		static void push(ref string[] str, string value){
			Array.Resize(ref str, str.Length+1);
			str[str.Length-1] = value;
		}

		static string[] resize(string[] str){
			string[] result = new string[0];
			for(int i = 0; i < str.Length; i++){
				if(str[i] != ""){
					push(ref result, str[i]);
				}
			}
			return result;
		}

		private static String HexConverter(System.Drawing.Color c){
	    	return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
		}

		static void createImage(string[] hexValues){
			Bitmap bitmap = new Bitmap(2, hexValues.Length);
				for (var x = 0; x < bitmap.Width; x++){
					for (var y = 0; y < bitmap.Height; y++){
						bitmap.SetPixel(x, y, System.Drawing.ColorTranslator.FromHtml(hexValues[y]));
					}
				}
				bitmap.Save("image.png");		
		}
    }
}
