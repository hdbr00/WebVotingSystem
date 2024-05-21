using ProyectoFinalPrograWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.DataAccess.Repositorio.IRepositorio
{
    public interface ICandidatoRepositorio : IRepositorio<Candidato>
    {
        void Actualizar(Candidato candidato);
    
    }
}
