await Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddSingleton(s =>
        {
            var configuration = context.Configuration;
            var authAddress = configuration.GetValue<string>(nameof(ApiService.AuthAddress));
            var apiAddress = configuration.GetValue<string>(nameof(ApiService.ApiAddress));
            var client_id = configuration.GetValue<string>(nameof(ApiService.ClientId));
            var client_secret = configuration.GetValue<string>(nameof(ApiService.ClientSecret));
            Console.WriteLine(authAddress);
            Console.WriteLine(apiAddress);
            Console.WriteLine(client_id);
            Console.WriteLine(client_secret);
            return new ApiService(authAddress, apiAddress, client_id, client_secret);
        });
        services.AddHostedService<SampleService>();
    })
    .Build()
    .RunAsync();