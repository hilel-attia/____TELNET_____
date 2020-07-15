using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class BesoinFormationModel
    {
        [Column(TypeName = "nvarchar(150)")]
        public string Id { get; set; }
        [Required]
        public string Activite { get; set; }
        [Required]
        public string Intitule_Formation { get; set; }
        [Required]
        public string Priorite { get;  set; }
        [Required]
        public string Justification_du_besoin { get; set; }
        [Required]
        public string Nombre_de_participants { get; set; }
        public List<ParticipantFormation> ParticipantFormations { get; set; }
        public List<ParticipantToFormationModel> ParticipantToFormations { get; set; } = new List<ParticipantToFormationModel>();


    }
}
