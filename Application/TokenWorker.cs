namespace StalNoteM.Application
{
    public class TokenWorker
    {
        private static int position = 0;
        private static List<string> AccessTokens = new List<string>();
        public static void Add(string token)
        {
            AccessTokens.Add(token);
        }
        public static void Remove(string token) 
        { 
           AccessTokens.Remove(token);
        }
        private static void Next()
        {
            if (position + 1 < AccessTokens.Count)
            {
                position++;
            }
            else
            {
                position = 0;
            }
        }
        public static string Take() 
        {
            if(position >= AccessTokens.Count)
            {
                position = 0;
            }
            string temp = AccessTokens[position];
            Next();
            return temp;
        }
    }
}
