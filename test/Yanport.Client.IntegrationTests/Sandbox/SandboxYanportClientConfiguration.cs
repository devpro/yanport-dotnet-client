using System;

namespace Devpro.Yanport.Client.IntegrationTests.Sandbox
{
    public class SandboxYanportClientConfiguration : IYanportClientConfiguration
    {
        public string BaseUrl => Environment.GetEnvironmentVariable("Yanport_Sandbox_BaseUrl");

        public string Token => Environment.GetEnvironmentVariable("Yanport_Sandbox_Token");

        public string HttpClientName => "Yanport";
    }
}
