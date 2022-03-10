
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace HearthStone.WebApi.Tests
{
    [TestFixture]
    [Order(3)]
    public class ApiServiceTests : TestBase
    {
        public ApiServiceTests()
        {
        }
        protected ApiService? Api { get; private set; }

        [Test]
        [Order(0)]
        public void CreateService()
        {
            var configuration = AppHost.Services.GetService<IConfiguration>();
            var authAddress = configuration.GetValue<string>(nameof(ApiService.AuthAddress));
            var apiAddress = configuration.GetValue<string>(nameof(ApiService.ApiAddress));
            var client_id = configuration.GetValue<string>(nameof(ApiService.ClientId));
            var client_secret = configuration.GetValue<string>(nameof(ApiService.ClientSecret));
            Console.WriteLine(authAddress);
            Console.WriteLine(apiAddress);
            Console.WriteLine(client_id);
            Console.WriteLine(client_secret);
            Api = new ApiService(authAddress, apiAddress, client_id, client_secret);
            Api.ShouldNotBeNull();
            Api.HearthStoneApi.ShouldNotBeNull();
            Api.AuthApi.ShouldNotBeNull();
            Api.ApiHttpClient.ShouldNotBeNull();
            Api.AuthClient.ShouldNotBeNull();
        }

        [Test]
        [Order(2)]
        public async Task AuthTest()
        {
            Api!.Token.ShouldBeNullOrEmpty();
            await Should.NotThrowAsync(async () => await Api.Auth());
            Api.Token.ShouldNotBeNullOrEmpty();
            Console.WriteLine(Api.Token);
        }


        [Test]
        [Order(3)]
        [TestCase(RegionLocale.zh_CN, 6, 6, 6)]
        [TestCase(RegionLocale.zh_CN, null, null, null)]
        [TestCase(RegionLocale.zh_CN, null, 8, 8)]
        [TestCase(RegionLocale.zh_CN, 4, 7, null)]
        public async Task GetCardsTest(RegionLocale locale, int? manaCost, int? health, int? attack)
        {
            var input = new CardSearchInput
            {
                ManaCost = manaCost,
                Health = health,
                Attack = attack,
            };
            await Should.NotThrowAsync(async () => await Api!.HearthStoneApi.SearchCard(locale, Api.Token, input)
                                   .Timeout(TimeOut)
                                   .Do(OnNext, OnError)
                                   .Do(x =>
                                   {
                                       if (x.Cards != null && x.Cards.Any())
                                       {
                                           if (health.HasValue)
                                               x.Cards.ShouldAllBe(x => x.Health == health);
                                           if (manaCost.HasValue)
                                               x.Cards.ShouldAllBe(x => x.ManaCost == manaCost);
                                           if (attack.HasValue)
                                               x.Cards.ShouldAllBe(x => x.Attack == attack);
                                       }
                                   })
                                   .Retry(Retry));
        }

        [Test]
        [Order(4)]
        [TestCase(RegionLocale.zh_CN)]
        [TestCase(RegionLocale.zh_TW)]
        [TestCase(RegionLocale.en_US)]
        public async Task GetCardbackTest(RegionLocale locale)
        {
            var input = new CardBackSearchInput()
            {
                PageSize = 200
            };
            await Should.NotThrowAsync(async () => await Api!.HearthStoneApi.SearchCardback(locale, Api.Token, input)
                                   .Timeout(TimeOut)
                                   .Do(OnNext, OnError)
                                   .Retry(Retry));
        }

        [Order(5)]
        [Test]
        public void GetTokenTest()
        {

            Api!.AuthApi.GetTokenBasic(Api.ClientId, Api.ClientSecret)
                .Retry(Retry)
                .Do(OnNext, OnError)
                .Wait();
        }




    }
}
