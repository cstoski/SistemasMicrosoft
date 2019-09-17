using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class MaterialDao
    {
        private static Context ctx = new Context();

        public static bool CadastrarMaterial(Material mat)
        {
            if (BuscarMaterialPorCodigo(mat) == null)
            {
                ctx.Materiais.Add(mat);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static Material BuscarMaterialPorNome(Material mat)
        {
            return ctx.Materiais.FirstOrDefault
                (x => x.Nome.Equals(mat.Nome));
        }

        public static Material BuscarMaterialPorCodigo(Material mat)
        {
            return ctx.Materiais.FirstOrDefault
                (x => x.Codigo.Equals(mat.Codigo));
        }
    }
}
