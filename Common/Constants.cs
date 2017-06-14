using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Constants
    {
        public static class Session
        {
            public const string UserName = "UserName";
            public const string UserRole = "UserRole";
        }

        public enum UserRoles { Admin, User};
    }
}
