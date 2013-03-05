
namespace Website.Models
{
    public class SocialConnectConnector
    {
        public string NetworkName { get; set; }
        public string NetworkDisplayName { get; set; }
        public bool IsAuthenticated { get; set; }
        public string LoginText { get; set; }
    }
}