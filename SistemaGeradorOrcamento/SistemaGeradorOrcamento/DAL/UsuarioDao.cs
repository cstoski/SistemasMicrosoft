using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class UsuarioDao
    {
        private static Context ctx = SingletonContext.GetInstance();
        private static List<Usuario> usuarios = new List<Usuario>();

        public static bool CadastrarUsuario(Usuario user)
        {
            if (BuscarUsuarioPorMatricula(user) == null)
            {
                ctx.Usuarios.Add(user);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
      

        public static Usuario BuscarUsuarioPorMatricula(Usuario u)
        {
            return ctx.Usuarios.FirstOrDefault(x => x.Matricula.Equals(u.Matricula));
        }

        public static void AlterarUsuario(Usuario u)
        {

            ctx.Entry(u).State = EntityState.Modified;
            ctx.SaveChanges();
        }

        public static void ListarUsuarios(Usuario u)
        {
           
        }
        public static void DeletarUsuarios(Usuario u)
        {         
            ctx.Usuarios.Remove(u);
            ctx.SaveChanges();

        }
    }
}

