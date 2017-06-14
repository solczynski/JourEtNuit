using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class User
    {
        public string UserName { get; set; }

        public byte[] PassWordSalt { get; set; }

        public string UserRole { get; set; }


        public User(SqlDataReader reader)
        {
            SetProperties(reader);
        }

        public void SetProperties(SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                switch (reader.GetName(i))
                {
                    case "UserName":
                        this.UserName = reader.GetString(i);
                        break;
                    case "RoleName":
                        this.UserRole = reader.GetString(i);
                        break;
                    case "PassWordSalt":
                        this.PassWordSalt = reader[i] as byte[];
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
