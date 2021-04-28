namespace server.Helpers
{
    public class Utility
    {
        public static string GenerateCode(string name, string prefix){
            string code = prefix.ToUpper() + "_";
            char[] separators = new char[] {'_','-',' ','.'};
            string[] nameSplit = name.ToUpper().Split(separators,System.StringSplitOptions.RemoveEmptyEntries);
            foreach(var n in nameSplit) code += n.Substring(0,4);
            return code;
        }
    }
}