using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Simple_Calculator.Models.Service.UserClass
{
    public class User
    {
        public string UserIp { get; set; }

        public override string ToString()
        {
            return UserIp.ToString();
        }
    }
}