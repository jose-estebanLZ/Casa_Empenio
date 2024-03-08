using CasaEmpeñoModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoRepository.UserRepository
{
    public class UserRepository
    {
        public Usuario Get(string userName, string password)
        {
            using(var context = new CasaEmpeñoEntities())
            {
                return context.Usuario
                    .Where(x => x.NombreUsuario == userName && x.Contraseña == password)
                    .FirstOrDefault();
            }
        }
    }
}
