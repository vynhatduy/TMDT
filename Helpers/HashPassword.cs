using System.Security.Cryptography;
using System.Text;

namespace TMDT.Helpers
{
    public class HashPassword
    {
        public static string Hasherpass(string passoword)
        {
            try
            {
                using (MD5 md5 = MD5.Create())
                {
                    byte[] input = Encoding.UTF8.GetBytes(passoword);
                    byte[] hashBytes = md5.ComputeHash(input);
                    StringBuilder output = new StringBuilder();
                    foreach (byte b in hashBytes)
                    {
                        output.Append(b.ToString("x2"));

                    }
                    return output.ToString();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
