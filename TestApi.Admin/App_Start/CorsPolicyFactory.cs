using System.Net.Http;
using System.Web.Http.Cors;
using TestApi.Admin.Filter;

namespace TestApi.Admin.App_Start
{
    public class CorsPolicyFactory: ICorsPolicyProviderFactory
    {
        private readonly ICorsPolicyProvider _corsPolicyProvider = new CorsPolicyAttribute();
        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return _corsPolicyProvider;
        }
    }
}