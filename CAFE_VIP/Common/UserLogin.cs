using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAFE_VIP.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public string PassWord { set; get; }
    }
}