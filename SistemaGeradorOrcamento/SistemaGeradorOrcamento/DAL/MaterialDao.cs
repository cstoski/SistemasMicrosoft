using SistemaGeradorOrcamento.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGeradorOrcamento.DAL
{
    class MaterialDao
    {
        private static Context ctx = SingletonContext.GetInstance();

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

        public static Material buscarMaterialPorFabricante (Material mat)
        {
            return ctx.Materiais.FirstOrDefault(x => x.Fabricante.Equals(mat.Fabricante));
        }

        public static List<Material> ListarMaterial()
        {
            return ctx.Materiais.ToList();
        }

        public static Material BuscarMaterialPorId(int id)
        {
            return ctx.Materiais.Find(id);
        }

        public static void EditarMaterial(Material m)       
        {
            ctx.Entry(m).State = EntityState.Modified;
            ctx.SaveChanges();
        }
        public static void DeletarMaterial(Material m)
        {
            //ctx.Materiais.Remove(m);
            //ctx.SaveChanges();

        }
    }
}
