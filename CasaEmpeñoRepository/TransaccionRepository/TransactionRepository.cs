using CasaEmpeñoModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaEmpeñoRepository.TransaccionRepository
{
    public class TransactionRepository
    {
        public void Add(Transaccion transaction)
        {
            using (var context = new CasaEmpeñoEntities())
            {
                context.Transaccion.Add(transaction);
                context.SaveChanges();
            }
        }
    }
}
