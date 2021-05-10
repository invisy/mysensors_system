﻿namespace MySensors.ApplicationCore.Constants
{
    public class AuthorizationConstants
    {
        // TODO: Don't use this in production
        public const string DEFAULT_PASSWORD = "Pass@word1";

        // TODO: Change this to an environment variable
        public const string JWT_SECRET_KEY = "mysupersuppeeeeeeerrrrrrrsecret_secretkeyYYY!123";
        
        public const string ISSUER = "MyAuthServer";
        
        public const string AUDIENCE = "http://localhost:5000/"; 
        
        public const int LIFETIME = 60;
    }
}