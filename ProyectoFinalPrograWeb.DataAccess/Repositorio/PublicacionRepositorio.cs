using ProyectoFinalPrograWeb.DataAccess.Data;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.DataAccess.Repositorio
{
    public class PublicacionRepositorio : Repositorio<Publicacion>, IPublicacionRepositorio
    {

        public PublicacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;


        public void Actualizar(Publicacion publicacion)
        {

            var t = _db.Publicacion.FirstOrDefault(s => s.IdPublicacion == publicacion.IdPublicacion);
            if (t != null)
            {
                t.Titulo = publicacion.Titulo;
                t.Contenido = publicacion.Contenido;

            }
        }
    }
}
