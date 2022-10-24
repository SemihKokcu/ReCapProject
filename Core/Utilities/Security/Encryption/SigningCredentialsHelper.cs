using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {//sisteme girmek için anahtar
        public static SigningCredentials CreateSigningCredentials(SecurityKey security)
        {
            //anahtar olarak security keyi al, şifreleme olarak HmacSha512signature
            return new SigningCredentials(security, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}