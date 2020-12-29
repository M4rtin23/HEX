using System;

namespace ImaHex{
	class Commands{
		static char[] options = {'h', 'r'};
		static Action[] actions = {help, remove};
		static bool delete = false;
		public static void GetArgs(string[] args, ref string file, ref bool delete){
			for(int i = 0; i < args.Length; i++){
				if(args[i].StartsWith('-')){
					for(int o = 0; o < options.Length; o++){
						if(args[i].Contains(options[o])){
							actions[o]();
						}
					}
					delete = Commands.delete;
				}else{
					file = args[i].Replace("'", "").Trim().Replace(@"\", "");
				}
			}
		}
		
		static void help(){
				Console.WriteLine(
@"Usage: imahex [arguments] [path-to-file]
Options:s
  -h:		Show help
  -r:		Revome image at the end of the process"
  				);
		}
		static void remove(){
			delete = true;	
		}
	}
}