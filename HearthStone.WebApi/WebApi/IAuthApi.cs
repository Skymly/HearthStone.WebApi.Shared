using HearthStone.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;
using System.Reactive.Linq;
using System.Text;

namespace HearthStone.WebApi
{
    public interface IAuthApi
    {
#if NETCOREAPP3_1_OR_GREATER
        IObservable<string> GetTokenBasic(string client_id, string client_secret)
        {
            var base64authorization = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes($"{client_id}:{client_secret}"));
            var x = GetToken(base64authorization).Wait();
            return Observable.Return(JsonConvert.DeserializeObject<JObject>(x)["access_token"].ToObject<string>());
        }
#endif

        [Post("/oauth/token")]
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        IObservable<string> GetToken([Header("Authorization")] string base64authorization, [Body(BodySerializationMethod.Default)] string body = "grant_type=client_credentials");
    }
}
