using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace HearthStone.WebApi
{
    public class RequestHandler : DelegatingHandler
    {
        public RequestHandler()
        {
            this.InnerHandler = new System.Net.Http.HttpClientHandler();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Trace.WriteLine(request.RequestUri.ToString());
            Trace.WriteLine(request.RequestUri.ToString());
            if (request.Content != null)
            {
                var requestString = await request.Content.ReadAsStringAsync(cancellationToken);
                Trace.WriteLine(requestString);
            }
            Trace.WriteLine(JsonConvert.SerializeObject(request, Formatting.Indented));
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
