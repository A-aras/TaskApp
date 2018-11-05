using System.Net.Http;
using System.Web.Http.Cors;

namespace ProjectManager.API.Security
{
    public class CorsPolicyFactory : ICorsPolicyProviderFactory
    {
        private CorsPolicyProvider policyProvider;

        public CorsPolicyFactory()
        {
            policyProvider = new CorsPolicyProvider();
        }

        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return policyProvider;
        }
    }
}