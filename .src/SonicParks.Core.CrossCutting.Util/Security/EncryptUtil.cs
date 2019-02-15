using System;
using System.Security.Cryptography;
using System.Text;

namespace SonicParks.Core.CrossCutting.Util.Security {

    public static class EncryptUtil {

        public static string EncryptMD5(this string text, string key) {

            StringBuilder result = new StringBuilder();

            using (MD5 md5 = MD5.Create()) {

                foreach (byte item in md5.ComputeHash(Encoding.UTF8.GetBytes(text + key))) {

                    result.Append(item.ToString("x2"));

                }

            }

            return result.ToString().ToUpper();

        }

        public static string EncryptMD5(this string text) {
          
            return EncryptMD5(text, string.Empty);

        }

        public static string EncryptSHA256(this string text, string key) {

            StringBuilder result = new StringBuilder();

            using (SHA256Managed crypt = new SHA256Managed()) {

                foreach (byte theByte in crypt.ComputeHash(Encoding.ASCII.GetBytes(text + key), 0, Encoding.ASCII.GetByteCount(text + key))) {

                    result.Append(theByte.ToString("x2"));

                }

            }

            return result.ToString().ToUpper();

        }


    }

}
