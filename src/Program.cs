namespace ImaHex{
	class Program{
		static void Main(string[] args){
			string file ="";
			bool delete = false;
			Commands.GetArgs(args, ref file, ref delete);
			if(file != ""){
				Hex.CreateImage(Hex.GetHexValues(file));
				Hex.Replace(file, delete);
			}
		}
	}
}
