namespace ImaHex{
	class Program{
		static void Main(string[] args){
			string[] files = new string[0];
			bool delete = false;

			Commands.GetArgs(args, ref files, ref delete);
			
			if(files.Length != 0){
				string[] hexValues = new string[0];
				
				for(int i = 0; i < files.Length; i++){
					string[] temp = Hex.GetHexValues(files[i]);

					for(int o = 0; o < temp.Length; o++){
						ExtendedArray.Push(ref hexValues, temp[o]);
					}
				}
				Hex.removeDuplicate(ref hexValues);
				Hex.CreateImage(hexValues);
				System.Console.WriteLine("Press Enter after editing image");
				System.Console.ReadLine();
				
				for(int i = 0; i < files.Length; i++){
					Hex.Replace(files[i]);
				}
				if(delete){
					System.IO.File.Delete("image.png");
				}
			}
		}
	}
}
