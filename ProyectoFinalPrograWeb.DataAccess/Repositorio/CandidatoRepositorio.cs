using ProyectoFinalPrograWeb.DataAccess.Data;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.DataAccess.Repositorio
{
    public class CandidatoRepositorio : Repositorio<Candidato>, ICandidatoRepositorio
    {
        public  CandidatoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        readonly ApplicationDbContext _db;


        public void Actualizar(Candidato candidato)
        {
            var t = _db.Candidato.FirstOrDefault(s => s.IdCandidato == candidato.IdCandidato);

            if (t != null)
            {
                t.Nombre = candidato.Nombre;
                t.Partido = candidato.Partido;
                t.FotoUrl = candidato.FotoUrl;
            }

        }
    }
}
