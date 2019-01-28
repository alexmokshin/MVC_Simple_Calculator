
using System.ComponentModel;
using System.Web;

namespace MVC_Simple_Calculator.Models.Service.UserClass
{
    public class User
    {
        [DisplayName("IP пользователя")]
        public string UserIp { get; private set; }

        public User()
        {
            UserIp = GetUserIPAddress();
        }
        public User(string ip_adress)
        {
            UserIp = ip_adress;
        }
        public string GetUserIP()
        {
            return UserIp;
        }

        public void SetUserIp(string user_ip)
        {
            this.UserIp = user_ip;
        }

        protected string GetUserIPAddress()
        {
            HttpContext context = HttpContext.Current;
            string ip_address = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ip_address))
            {
                string[] addresses = ip_address.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}