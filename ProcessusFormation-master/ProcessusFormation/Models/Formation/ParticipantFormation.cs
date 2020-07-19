using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessusFormation.Models.Formation
{
    public class ParticipantFormation  
    {
        public string ParticipantId { get; set; }
        public ParticipantModel ParticipantModel { get; set; }



        public string BesoinFormationId { get; set; }
        public BesoinFormationModel BesoinFormationModel { get; set; }
    }
}
