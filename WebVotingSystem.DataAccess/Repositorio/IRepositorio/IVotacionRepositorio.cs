using WebVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingSystem.DataAccess.Repositorio.IRepositorio
{
    public interface IVotacionRepositorio : IRepositorio<Votacion>
    {
        void Actualizar(Votacion votacion);
    }
}
