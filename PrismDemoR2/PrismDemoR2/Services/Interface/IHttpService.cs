using System;
using System.Threading;
using System.Threading.Tasks;

namespace PrismDemoR2.Services.Interface
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string resource, CancellationToken? ct);
        void SetTimeOut(int seconds);
    }
}
