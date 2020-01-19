using System;
using PrismDemoR2.Services.Interface;

namespace PrismDemoR2.Services.Interface
{
    public class AuthenticationService : IAuthenticationService
    {
        public AuthenticationService()
        {
            Console.WriteLine("Initializing AuthenticationService");
        }

        public void LoginWithEmailAndPassword(string email, string password)
        {
            Console.WriteLine($"Email: {email} Password: {password}");
        }
    }
}
