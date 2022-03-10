using Splat.Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace HearthStone.WebApi.Tests
{
    public abstract class TestBase
    {
        static TestBase()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        protected IHost AppHost { get; private set; }

        [OneTimeSetUp]
        public void OnStart()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices(services => services.UseMicrosoftDependencyResolver())
                .Build();
            AppHost.StartAsync();
            var configuration = AppHost.Services.GetRequiredService<IConfiguration>();
            var timeOut = configuration.GetValue<double>("Settings:TimeOut");
            TimeOut = TimeSpan.FromSeconds(timeOut);
            Retry = configuration.GetValue<int>("Settings:Retry");
        }
        [OneTimeTearDown]
        public async Task OnStop()
        {
            await AppHost!.StopAsync();
        }

        public static TimeSpan TimeOut { get; private set; }
        public static int Retry { get; private set; }

        private static readonly Type[] SimpleTypes = new[]
        {
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(short),
            typeof(ushort),
            typeof(byte),
            typeof(sbyte),
            typeof(char),
            typeof(string),
            typeof(float),
            typeof(double),
            typeof(decimal),
            typeof(Guid),
            typeof(DateTime),
            typeof(Guid),
            typeof(TimeSpan),
            typeof(Type),
            typeof(Assembly),
        };
        protected void OnNext<T>(T t) => Console.WriteLine(SimpleTypes.Contains(typeof(T))
                                  ? t!.ToString()
                                  : JsonConvert.SerializeObject(t, Formatting.Indented));

        protected void OnError<T>(T t) where T : Exception
        {
            Console.WriteLine(t.Message);
            Console.WriteLine(t.StackTrace);
            Assert.Fail(t.ToString());
        }
    }
}
