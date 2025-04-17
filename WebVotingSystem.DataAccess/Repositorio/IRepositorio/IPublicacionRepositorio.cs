using WebVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingSystem.DataAccess.Repositorio.IRepositorio
{
    public interface IPublicacionRepositorio : IRepositorio<Publicacion>
    {

        void Actualizar(Publicacion publicacion);
    }
}
