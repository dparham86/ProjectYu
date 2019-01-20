using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectYu.Models
{
    public class LoginedUserModel
    {
        public UserModel UserModel { get; set; }

        public NewVideosModel NewVideosModel { get; set; }

        public bool loggedIn { get; set; }
    }
}
