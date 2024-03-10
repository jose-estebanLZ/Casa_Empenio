using CasaEmpeñoRepository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoService.LoginService
{
    public class LoginService
    {
        private readonly UserRepository _userRepository;
        public LoginService()
        {
            _userRepository = new UserRepository();
        }

        public bool IsValidUser(string userName, string password)
        {
            var encryptedPassword = Encrypt.GetMD5(password);
            return _userRepository.Get(userName, encryptedPassword) != null;
        }
           
    }
}

public class Encrypt
{
    public static string GetMD5(string str)
    {
        MD5 md5 = MD5CryptoServiceProvider.Create();
        ASCIIEncoding encoding = new ASCIIEncoding();
        StringBuilder sb = new StringBuilder();
        byte[] stream = md5.ComputeHash(encoding.GetBytes(str));
        for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
        return sb.ToString();
    }
}
