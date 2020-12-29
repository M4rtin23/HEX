namespace ImaHex{
	class Program{
		static void Main(string[] args){
			string file ="";
			bool delete = false;
			Commands.GetArgs(args, ref file, ref delete);
			if(file != ""){
				Hex.CreateImage(Hex.GetHexValues(file));
				System.Console.WriteLine("Press Enter after editing image");
				System.Console.ReadLine();
				Hex.Replace(file, delete);
			}
		}
	}
}
