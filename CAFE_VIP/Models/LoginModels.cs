using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CAFE_VIP.Models
{
    
    public class LoginModels
    {
        [Required(ErrorMessage = "Again enter username")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Again enter username")]
        public string PassWord { set; get; }

        public bool RememberMe { set; get; }
    }
}