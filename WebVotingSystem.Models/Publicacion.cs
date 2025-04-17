using WebVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingSystem.Models
{
    public class Publicacion
    {
        [Key]
        public int IdPublicacion { get; set; }
        public string UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Contenido { get; set; }
    }
}
