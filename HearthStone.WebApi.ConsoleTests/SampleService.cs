using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HearthStone.WebApi
{
    public class SampleService : IHostedService
    {
        private readonly ILogger<SampleService> logger;
        private readonly ApiService api;
        public SampleService(ApiService api, ILogger<SampleService> logger)
        {
            this.api = api;
            this.logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"SampleService Started!!!");
            await api.Auth();
            var input = new CardSearchInput
            {

                Attack = 7,
                Health = 4,
                ManaCost = 4
            };
            api.HearthStoneApi.SearchCard(RegionLocale.zh_CN, api.Token, input)
                                .Timeout(TimeSpan.FromSeconds(3))
                                .Retry(3)
                                .Do(x => Console.WriteLine(JsonConvert.SerializeObject(x)))
                                .Subscribe();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation($"SampleService Stopped!!!");
            return Task.CompletedTask;
        }
    }
}
