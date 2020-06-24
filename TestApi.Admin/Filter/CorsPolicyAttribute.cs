using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace TestApi.Admin.Filter
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class CorsPolicyAttribute: Attribute, ICorsPolicyProvider
    {
        private readonly CorsPolicy _corsPolicy;
        public CorsPolicyAttribute()
        {
            _corsPolicy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = false,
                AllowAnyOrigin = false,
                //SupportsCredentials = true,
                Methods = { "get", "post" },
                Origins =
                {
                    "http://localhost:62401"
                }

            };

            //_corsPolicy.ExposedHeaders.Add("X-Custom-Header");
        }

        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request
            , CancellationToken cancellationToken)
        {
            return Task.FromResult(_corsPolicy);
        }
    }
}