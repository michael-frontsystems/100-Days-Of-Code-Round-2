using System;
namespace PrismDemoR2.Interface
{
    public interface IAuthenticationService
    {
        void LoginWithEmailAndPassword(string email, string password);
    }
}
