using System;

namespace ImaHex{
	class Commands{
		static char[] options = {'h'};
		static Action[] actions = {help};
		public static void GetArgs(string[] args, ref string file){
			for(int i = 0; i < args.Length; i++){
				if(args[i].StartsWith('-')){
					if(args[i].Contains(options[0])){
						actions[0]();
					}
				}else{
					file = args[i].Replace("'", "").Trim().Replace(@"\", "");
				}
			}
		}
		
		static void help(){
				Console.WriteLine(
@"Usage: imahex [arguments] [path-to-file]
Options:
  -h:		Show help"
  				);
		}
	}
}