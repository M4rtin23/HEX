namespace ImaHex{
	static class ExtendedArray{
		public static void Push(ref string[] str, string value){
			System.Array.Resize(ref str, str.Length+1);
			str[str.Length-1] = value;
		}

		public static string[] Resize(string[] str){
			string[] result = new string[0];
			for(int i = 0; i < str.Length; i++){
				if(str[i] != ""){
					Push(ref result, str[i]);
				}
			}
			return result;
		}
	}
}