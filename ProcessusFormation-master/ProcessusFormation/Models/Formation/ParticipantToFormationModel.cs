using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class ParticipantToFormationModel
    {
        public string Id { get; set; }
        public string IdFormation { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUsers { get; set; }
        public BesoinFormationModel BesoinFormation { get; set; }
    }
}
