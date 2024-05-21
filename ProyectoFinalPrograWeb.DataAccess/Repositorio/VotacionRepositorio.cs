using ProyectoFinalPrograWeb.DataAccess.Data;
using ProyectoFinalPrograWeb.Models;
using ProyectoFinalPrograWeb.DataAccess.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.DataAccess.Repositorio
{
        public class VotacionRepositorio : Repositorio<Votacion>, IVotacionRepositorio
    {



        public VotacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        readonly ApplicationDbContext _db;
          

        public void Actualizar(Votacion votacion)
        {
            var t = _db.Votacion.FirstOrDefault(s => s.CandidatoId == votacion.CandidatoId);

            if (t!=null)
            {
                t.Fecha = votacion.Fecha;
            }



           
        }



        }
    }
