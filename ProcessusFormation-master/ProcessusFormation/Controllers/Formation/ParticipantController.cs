using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProcessusFormation.Data;
using ProcessusFormation.Models.Formation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       /// private Database Database { get; set; }

        public ParticipantController(ApplicationDbContext context)
        {

            _context = context;

        }


        // ajouter un nouvelle participant
        [HttpPost]
        [Route("RegisterParticipant")]
        public async Task<IActionResult> PostParticipants(ParticipantModel model)

        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var participantss = new ParticipantModel()
            {
                Nom = model.Nom,
                Prenom = model.Prenom,
               
            };

            var result = await _context.Participants.AddAsync(participantss);
            _context.SaveChanges();
            return Ok(new { });


        }


        //ajouter un participant a une formation bien determiner ; id=id de la formation ; Name= name de participant
        [HttpPost]
        [Route("EditParticipantToFormation/{id}")]
        public async Task<ActionResult> AddParticipantToFormationAsync(string id, string ParticipantId)
        {
          // Name = "hana";
            var Formation = await _context.BesoinFormations.FindAsync(id);
           // var part = await _context.Participants.FindAsync(Name);
            //ici bech nzid participant ala formation d'identifiant id
           
           Formation.ParticipantFormations = new List<ParticipantFormation>
           { 
              new ParticipantFormation()
            {    BesoinFormationId=id,
                 ParticipantId = ParticipantId
           } };
            _context.SaveChanges();   
           // Add(Name); //AddToRoleAsync(applicationUser, RoleName);

            // var result = await _userManager.AddToNormalizedRoleName(applicationUser, RoleName);
            //    normalizedRoleName
            return Ok();

        }
        //get les participant de la formation d'id =id
        [HttpGet]
        [Route("GetFormationToParticipant/{id}")]
        public IEnumerable<Object> GetListePartcipant(string id) {
            var result =  _context.BesoinFormations.Find(id);
            var exist = result.ParticipantFormations.Select(x => x.ParticipantId).ToList();
          
                return exist;
            
            
        }
        //Get all participants
        [HttpGet]
        [Route("GetAllParticipant")]
        public IEnumerable<Object> GetAllParticipants()
        {
            // if (!ModelState.IsValid)
            //   {
            //   return BadRequest(ModelState);
            //  }

            // var user = await _context.ApplicationUsers.FindAsync(id);
            // Console.WriteLine(id);
            var Participant = _context.Participants;
            if (Participant == null)
            {
                return (null);
            }

            return (Participant);
        }
    }
}