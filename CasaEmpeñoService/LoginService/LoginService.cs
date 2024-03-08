using CasaEmpeñoRepository.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool IsValidUser(string userName, string password) =>
            _userRepository.Get(userName, password) != null;
    }
}
