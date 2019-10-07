using SistemaGeradorOrcamento.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace SistemaGeradorOrcamento.DAL
{
    class ClienteDao
    {
        private static Context ctx = SingletonContext.GetInstance();


        public static bool CadastrarCliente(Cliente c)
        {
            if (BuscarClientePorNome(c) == null)
            {
                ctx.Clientes.Add(c);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool AlterarCliente(Cliente c)
        {
            if (BuscarClientePorNome(c) != null)
            {
                ctx.Entry(c).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }


        public static Cliente BuscarClientePorNome(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.NomeCliente.Equals(c.NomeCliente));
        }

        public static Cliente BuscarClientePorId(int id)
        {
            return ctx.Clientes.Find(id);
        }

       
        public static List<Cliente> ListarClientes()
        {
            return ctx.Clientes.ToList();
        }

    }
}
