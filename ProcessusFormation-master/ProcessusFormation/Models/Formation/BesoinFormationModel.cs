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
        [Key]
        public string BesoinFormationId { get; set; }
     
        public string Activite { get; set; }
       
        public string Intitule_Formation { get; set; }
        
        public string Priorite { get;  set; }
       
        public string Justification_du_besoin { get; set; }
 
        public string Nombre_de_participants { get; set; }
        public List<ParticipantFormation> ParticipantFormations { get; set; }
        public List<ParticipantToFormationModel> ParticipantToFormations { get; set; } = new List<ParticipantToFormationModel>();


    }
}
