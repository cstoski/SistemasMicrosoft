using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class UsuarioDao
    {
        private static Context ctx = new Context();

        public static bool CadastrarUsuario(Usuario user)
        {
            if (BuscarUsuarioPorNome(user) == null)
            {
                ctx.Usuarios.Add(user);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario BuscarUsuarioPorNome(Usuario user)
        {
            return ctx.Usuarios.FirstOrDefault
                (x => x.Nome.Equals(user.Nome));
        }
    }
}
