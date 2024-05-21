using ProyectoFinalPrograWeb.DataAccess.Data;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.DataAccess.Repositorio
{
    public class Controlador : IControlador
    {

        public Controlador(ApplicationDbContext db)
        {
            _db = db;
            Candidato = new CandidatoRepositorio(_db);
            Publicacion = new PublicacionRepositorio(_db);
            Votacion = new VotacionRepositorio(_db);
        }

        readonly ApplicationDbContext _db;


        public ICandidatoRepositorio Candidato { get; private set; }
        public IPublicacionRepositorio Publicacion { get; private set; }
        public IVotacionRepositorio Votacion { get; private set;}
       

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Guardar()
        {
            _db.SaveChanges();
        }
    }
}
