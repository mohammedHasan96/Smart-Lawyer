using SmartLawyer.Models.Classes;
using SmartLawyer.Models.Values;
using SmartLawyer.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Classes = SmartLawyer.Models.Classes;
using Values = SmartLawyer.Models.Values;

namespace SmartLawyer.Utils
{
    public static class Extentions
    {

        public static void ReFill<T>(this ObservableCollection<T> dst, IEnumerable<T> items)
        {   
            App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
            {
                dst.Clear();
                foreach (var item in items)
                    dst.Add(item);
            });
            
        }
        public static bool ToBool(this int i)
        {
            return i == 1 ? true : false;
        }

        public static int ToActiveState(this bool active)
        {
            return active ? 1 : 0;
        }

        public static string MD5(this string value)
        {
            var bytes = Encoding.UTF8.GetBytes(value);
            var hash = System.Security.Cryptography.MD5.Create().ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", "");
        }


        public static String GetPasswordHashSha1(this String password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            var sha1 = new SHA1CryptoServiceProvider();
            var sha1data = sha1.ComputeHash(data);

            ASCIIEncoding encoding = new ASCIIEncoding();

            return encoding.GetString(sha1data);
        }

        public static string ComputeHash(this Stream src)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var ms = new MemoryStream();
            var stream = new CryptoStream(ms, md5, CryptoStreamMode.Write);
            src.CopyTo(stream);
            stream.FlushFinalBlock();
            var hash = ms.ToArray();
            return BitConverter.ToString(hash).Replace("-", "");
        }

        public static String GetPasswordHashMd5(this String password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);




            ASCIIEncoding encoding = new ASCIIEncoding();

            return encoding.GetString(md5data);
        }

        public static String GetPasswordHashSalt(this String password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);

            return savedPasswordHash;
        }

        public static String GetPasswordHashSHA256(this String password)
        {
            using (var sha256Hash = SHA256.Create())
            {
                var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                    builder.Append(bytes[i].ToString("x2"));
                return builder.ToString();
            }
        }

        public static ImageSource ToImageSource(this string value)
        {
            ImageSource imageSource = new BitmapImage(new Uri($"pack://application:,,,/SmartLawyer;component/Resources/Images/{value}.png"));
            return imageSource;
        }

        public static String GetDictionaryValue(this String value)
        {
            return VMMainWindow.rm.GetString(value);
        }

        public static UsersModel ToUsersModel(this DataRowView item)
        {
            UsersModel user = new UsersModel();

            if (!item[UsersTable.UUserName].GetType().Name.Equals("DBNull"))
                user.UUserName = item[UsersTable.UUserName].ToString();

            if (!item[UsersTable.UPIdFk].GetType().Name.Equals("DBNull"))
                user.UPIdFk = Convert.ToInt64(item[UsersTable.UPIdFk]);

            if (!item[UsersTable.UEmail].GetType().Name.Equals("DBNull"))
                user.UEmail = item[UsersTable.UEmail].ToString();

            if (!item[UsersTable.UPassword].GetType().Name.Equals("DBNull"))
                user.UPassword = item[UsersTable.UPassword].ToString();

            if (!item[UsersTable.UpdatedBy].GetType().Name.Equals("DBNull"))
                user.UpdatedBy = Convert.ToInt64(item[UsersTable.UpdatedBy]);

            if (!item[UsersTable.UIsActive].GetType().Name.Equals("DBNull"))
                user.UIsActive = Convert.ToInt32(item[UsersTable.UIsActive]);

            return user;
        }

        public static PersonsModel ToPersons(this DataRow item)
        {
            PersonsModel person = new PersonsModel();

            if (!item[PersonsTable.PeName].GetType().Name.Equals("DBNull"))
                person.PeName = item[PersonsTable.PeName].ToString();

            if (!item[PersonsTable.PeId].GetType().Name.Equals("DBNull"))
                person.PeId = Convert.ToInt64(item[PersonsTable.PeId]);

            if (!item[PersonsTable.PeAddress].GetType().Name.Equals("DBNull"))
                person.PeAddress = Convert.ToInt64(item[PersonsTable.PeAddress]);

            if (!item[PersonsTable.PeIdentity].GetType().Name.Equals("DBNull"))
                person.PeIdentity = Convert.ToInt32(item[PersonsTable.PeIdentity]);

            if (!item[PersonsTable.PeType].GetType().Name.Equals("DBNull"))
                person.PeType = Convert.ToInt32(item[PersonsTable.PeType]);

            return person;
        }

    }
}
