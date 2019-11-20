using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using NetworkTolerance.Framework.Keys;

namespace NetworkTolerance.Connectivity.HTTPClients
{
    internal class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        protected AuthenticatedHttpClientHandler()
        {
            if (string.IsNullOrEmpty(Global.Token)) throw new ArgumentNullException(nameof(Global.Token));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, Global.Token);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}