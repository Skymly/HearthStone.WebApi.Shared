using Newtonsoft.Json;
using Refit;
using HearthStone.WebApi;
using System.Reactive.Linq;

namespace HearthStone
{
    public class ApiService
    {
        public ApiService(string authAddress, string apiAddress, string clientId, string clientSecret) : this(authAddress, apiAddress)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        public ApiService(string authAddress, string apiAddress)
        {
            AuthAddress = authAddress;
            ApiAddress = apiAddress;
            ApiHttpClient = new HttpClient(new RequestHandler())
            {
                BaseAddress = new Uri(this.ApiAddress),
            };
            AuthClient = new HttpClient(new RequestHandler())
            {
                BaseAddress = new Uri(this.AuthAddress),
            };
            RefitSettings settings = new RefitSettings
            {
                ContentSerializer = new NewtonsoftJsonContentSerializer(new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                })
            };
            HearthStoneApi = RestService.For<IHearthStoneApi>(ApiHttpClient, settings);
            AuthApi = RestService.For<IAuthApi>(AuthClient, settings);
        }


        public string AuthAddress { get; init; }
        public string ApiAddress { get; init; }
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }
        internal HttpClient ApiHttpClient { get; init; }
        internal HttpClient AuthClient { get; init; }
        public IAuthApi AuthApi { get; init; }
        public IHearthStoneApi HearthStoneApi { get; init; }
        public string Token { get; private set; }
        public async Task Auth() => Token = await AuthApi.GetTokenBasic(ClientId, ClientSecret);
        public async Task Auth(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Token = await AuthApi.GetTokenBasic(ClientId, ClientSecret);
        }
    }
}
