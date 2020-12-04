using PharmacyDBCore.Database;
using PharmacyDBCore.Database.Models;
using PharmacyDBCore.ViewModels;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PharmacyDBCore.Services
{
    public class UserManager
    {
        private static string MD5Hash(string str)
        {
            MD5 mD5 = MD5.Create();
            byte[] hash = mD5.ComputeHash(Encoding.ASCII.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static void RegisterUser(UserViewModel user)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                db.Users.Add(new User() { Login = user.Login, Password = MD5Hash(user.Password) });
                db.SaveChanges();
            }
        }
        public static bool LoginUser(UserViewModel user)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                User finded = db.Users.FirstOrDefault(t => t.Login == user.Login);
                if (finded == null)
                {
                    return false;
                }
                if (finded.Password == MD5Hash(user.Password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
