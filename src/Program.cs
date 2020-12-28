namespace ImaHex{
	class Program{
		static void Main(string[] args){
			string file ="";
			Commands.GetArgs(args, ref file);
			if(file == ""){
				System.Console.WriteLine("Enter File Location:");
				file = System.Console.ReadLine().Replace("'", "").Trim().Replace(@"\", "");
			}
			Hex.CreateImage(Hex.GetHexValues(file));
			Hex.Replace(file);
		}
	}
}
