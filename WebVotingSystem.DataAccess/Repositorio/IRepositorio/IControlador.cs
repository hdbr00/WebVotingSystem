using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingSystem.DataAccess.Repositorio.IRepositorio
{
    public interface IControlador : IDisposable
    {
        ICandidatoRepositorio Candidato { get; }

        IPublicacionRepositorio Publicacion { get; }

        IVotacionRepositorio Votacion { get; }

        void Guardar();

    }
}
