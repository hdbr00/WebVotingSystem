using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalPrograWeb.Models
{
    public class Votacion
    {
        [Key]
        public int IdVotacion { get; set; }

        [Required]
        [MaxLength(9)]
        [Index("IX_CedulaVotocaion", IsUnique = true)]
        public string Cedula { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Required]
        public int CandidatoId { get; set; }

        public Candidato Candidato { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
    }
}
