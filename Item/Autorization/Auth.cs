﻿namespace StalNoteM.Item.Autorization
{
    public class Auth
    {
        public string token_type { get; set; }
        public string expires_in { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set;}
    }
}
