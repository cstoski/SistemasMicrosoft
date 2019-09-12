using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFVendas.Model;

namespace SistemaGeradorOrcamento.DAL
{
    class ClienteDao
    {
        private static Context ctx = new Context();

        /// <summary>
        /// Cadastro de Cliente
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Busca de Cliente Por Nome
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Cliente BuscarClientePorNome(Cliente c)
        {
            return ctx.Clientes.FirstOrDefault
                (x => x.nomeCliente.Equals(c.nomeCliente));
        }

    }
}
