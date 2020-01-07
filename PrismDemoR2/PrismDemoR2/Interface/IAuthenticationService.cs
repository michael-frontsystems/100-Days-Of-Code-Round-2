using System;
namespace PrismDemoR2.Interface
{
    public interface AuthenticationService
    {
        void LoginWithEmailAndPassword(string email, string password);
    }
}
