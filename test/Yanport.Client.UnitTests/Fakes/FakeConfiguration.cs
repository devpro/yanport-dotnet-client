using System;

namespace Devpro.Yanport.Client.UnitTests.Fakes
{
    public class FakeConfiguration : IYanportClientConfiguration
    {
        public string BaseUrl => "http://doesnotexist.nop";

        public string Token => "someuselessstring";

        public string HttpClientName => "MyFakeClient";
    }
}
