using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebVotingSystem.Models
{
    public class Candidato
    {
        [Key]
        public int IdCandidato { get; set; }

        [Required(ErrorMessage ="Debes de digitar un nombre")]
        [MaxLength(25)]
        public string Nombre { get; set; }

        [Required]
        public string Partido { get; set; }

        [Required]
        public string FotoUrl { get; set; }

    }
}
