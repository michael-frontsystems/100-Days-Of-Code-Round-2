using System;
namespace PrismDemoR2.Services.Interface
{
    public interface IAuthenticationService
    {
        void LoginWithEmailAndPassword(string email, string password);
    }
}
