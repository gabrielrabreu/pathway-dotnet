﻿namespace Mist.Auth.Infra.Data.Common
{ 
    public class AppSettings
    {
        public string Secret { get; set; }
        public int Expires { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
