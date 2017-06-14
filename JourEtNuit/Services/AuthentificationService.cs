using Common;
using Common.Entities;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace JourEtNuit.Services
{
    public static class AuthentificationService
    {
        public static void RegisterUser(string name, string password, int userRoleId)
        {
            User dbUser = null;
            using (SqlConnector connector = new SqlConnector())
            {
                byte[] byteSalt = ASCIIEncoding.ASCII.GetBytes(StringHelper.GetRandomString(15));
                byte[] bytePwd = ASCIIEncoding.ASCII.GetBytes(password);

                byte[] hashPwd = GenerateSaltedHash(bytePwd, byteSalt);

                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {"userName", name },
                    {"passWord", hashPwd },
                    {"passWordSalt", byteSalt },
                    {"userRoleId", userRoleId }
                };

                connector.ExecuteCommand("CreateUser", parameters);
            }
        }

        public static bool CheckUserValidity(string username, string password)
        {
            #region Get user salt

            User dbUser = null;
            using (SqlConnector connector = new SqlConnector())
            {
                
                Dictionary<string, object> parameters = new Dictionary<string, object>() { { "userName", username } };

                connector.ExecuteCommand("GetUserSalt", parameters);
                while (connector.Reader.Read())
                {
                    dbUser = new User(connector.Reader);
                }
                connector.Reader.Close();

                #region Validate stored procedure return values

                if (dbUser == null || string.IsNullOrEmpty(dbUser.UserName))
                {
                    throw new Exception(String.Format("Impossible de trouver l'utilisateur '{0}'", username));
                }

                #endregion 
                
            }

            #endregion

            #region Check user credentials

            using (SqlConnector connector = new SqlConnector())
            {
                byte[] byteSalt = dbUser.PassWordSalt;
                byte[] bytePwd = ASCIIEncoding.ASCII.GetBytes(password);
                byte[] hashPwd = GenerateSaltedHash(bytePwd, byteSalt);

                Dictionary<string, object> parameters = new Dictionary<string, object>() { { "userName", username }, { "userPassWord", hashPwd } };
                connector.ExecuteCommand("CheckUserCredentials", parameters);
                while (connector.Reader.Read())
                {
                    dbUser.SetProperties(connector.Reader);
                }

                if (dbUser == null && string.IsNullOrEmpty(dbUser.UserRole))
                {
                    return false;
                }
            }

            #endregion
            HttpContext.Current.Session[Constants.Session.UserName] = dbUser.UserName;
            HttpContext.Current.Session[Constants.Session.UserRole] = dbUser.UserRole;
            return true;
        }

        /// <summary>
        /// Create password with unique salt
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static byte[] GenerateSaltedHash(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            plainText = ResizeByteArray(plainText);
            salt = ResizeByteArray(salt);

            byte[] plainTextWithSaltBytes = new byte[plainText.Length + salt.Length];

            for (int i = 0, length = plainText.Length; i < length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }

            for (int i = 0, length = salt.Length; i < length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        private static byte[] ResizeByteArray(byte[] array)
        {
            int lastIndex = Array.FindLastIndex(array, b => b != 0);

            Array.Resize(ref array, lastIndex + 1);

            return array;

        }

        /// <summary>
        /// Compare to password as byte array
        /// </summary>
        /// <param name="array1"></param>
        /// <param name="array2"></param>
        /// <returns></returns>
        private static bool CompareByteArrays(byte[] array1, byte[] array2)
        {
            if (array1.Length != array2.Length)
            {
                return false;
            }

            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}