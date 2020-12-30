using System;

namespace ImaHex{
	class Commands{
		static char[] options = {'h', 'd', 'v', 'k'};
		static string[] optionsLarge = {"help", "delete","version"};
		static Action[] actions = {help, remove, version, keep};
		static bool delete = true;
		public static void GetArgs(string[] args, ref string file, ref bool delete){
			for(int i = 0; i < args.Length; i++){
				if(args[i].StartsWith("--")){
					for(int o = 0; o < optionsLarge.Length; o++){
						if(args[i].Contains(optionsLarge[o])){
							actions[o]();
						}
					}
				}else if(args[i].StartsWith('-')){
					for(int o = 0; o < options.Length; o++){
						if(args[i].Contains(options[o])){
							actions[o]();
						}
					}
					if(args[i].Contains('l')){
						later(ref file);
					}
				}else{
					file = args[i].Replace("'", "").Trim().Replace(@"\", "");
				}
			}
			delete = Commands.delete;
		}
		
		static void help(){
				Console.WriteLine(
@"Usage: imahex [arguments] [path-to-file]
Options:
  -d, --delete		Delete image at the end of the process (default)
  -h, --help		Show help
  -k				Keep edited image
  -l				Ask for the path after the command is executed
  -v, --version		Show ImaHEX version"
  				);
		}
		static void remove(){
			delete = true;	
		}
		static void keep(){
			delete = false;
		}
		static void later(ref string file){
			Console.WriteLine("Enter File Location:");
			file = Console.ReadLine().Replace("'", "").Trim().Replace(@"\", "");
		}
		static void version(){
			Console.WriteLine("ImaHEX v1.2.2");
		}
	}
}