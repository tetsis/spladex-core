using WebInfrastructure;

namespace WebInfrastructure
{
    public class ApiKey : IApiKey
    {
        public ApiKey(string value)
        {
            Value = value;
        }

        public string Value { get; }
    }
}
