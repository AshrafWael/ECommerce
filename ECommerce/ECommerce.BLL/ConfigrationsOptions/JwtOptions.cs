
namespace ECommerce.BLL.ConfigrationsOptions
{
    public class JwtOptions
    {
        public string Key { get; set; }
        public string Audince { get; set; }
        public string issuer { get; set; }
        public int lifeTime { get; set; }
    }
}
