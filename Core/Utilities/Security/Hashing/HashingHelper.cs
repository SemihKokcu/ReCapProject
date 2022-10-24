using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {//out => dışarıya verilecek depğer
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;  //saltta hmac in key ini kullanıyoruz
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  // byte karşılığını hasliyor

            }
        }
        // veri tabdan gelen hashi ve saltı alıyoruz
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {                                                               //key ver
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));  //salta göre yapıyor
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }

                }
            }

            return true;
        }
    }
}