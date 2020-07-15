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
    public class BesoinFormationController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
       
        public static class MyGlobals
        {
            public static string key;

        }
        public BesoinFormationController(ApplicationDbContext context)
        {
          
            _context = context;

        }

        //ajouter un nouveau formation
        [HttpPost]
        [Route("RegisterFormation")]
        public async Task<IActionResult> PostBesoinFormation(BesoinFormationModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }
            var BesoinFormation = new BesoinFormationModel()
            {
                Activite = model.Activite,
                Intitule_Formation = model.Intitule_Formation,
                Priorite = model.Priorite,
                Justification_du_besoin = model.Justification_du_besoin,
                Nombre_de_participants = model.Nombre_de_participants

            };
            //icij'ajoute une nouvelle formation et au meme temps je paaser l'id de cette formation comme un parametre ala fonction GetBesoinFormation()
            await _context.BesoinFormations.AddAsync(BesoinFormation);
            _context.SaveChanges();
             var application = await _context.BesoinFormations.FindAsync(BesoinFormation.Id);
            //Console.WriteLine(application.Id);
           // await GetBesoinFormation(application.Id);
           MyGlobals.key = BesoinFormation.Id;
            
            return Ok(new { MyGlobals.key });

        }





        [HttpPost]
      //  [ValidateAntiForgeryToken]
        [Route("EditParticipantToFormation/{id}")]
        public async Task<ActionResult> AddParticipantToFormationAsync(string id, string Id)
        {
            // Name = "hana";
            var Formation = await _context.BesoinFormations.FindAsync(id);
            // var part = await _context.Participants.FindAsync(Name);
            //ici bech nzid participant ala formation d'identifiant id

            Formation.ParticipantToFormations = new List<ParticipantToFormationModel>
           {
              new ParticipantToFormationModel()
            {    IdFormation=id,
                Id = Id
           } };
            _context.SaveChanges();
            // Add(Name); //AddToRoleAsync(applicationUser, RoleName);

            // var result = await _userManager.AddToNormalizedRoleName(applicationUser, RoleName);
            //    normalizedRoleName
            return Ok();

        }














        // [HttpGet("{id}")] ;   public async Task<object> GetBesoinFormation([FromRoute] string id)

        [HttpGet] 
        [Route("GetOnBesoin")]
        public async Task<object> GetBesoinFormation()
        {
            Console.WriteLine(MyGlobals.key);
            if (MyGlobals.key is null)
            {
                return Ok(new { });
            }
            var BesoinFormation = await _context.BesoinFormations.FindAsync(MyGlobals.key);
            if (BesoinFormation == null)
            {
                return NotFound();
            }

            return (BesoinFormation);
        }


        [HttpGet]
        [Route("GetAllBesoin")]
        public IEnumerable<Object> GetAllBesoins()
        {
            // if (!ModelState.IsValid)
            //   {
            //   return BadRequest(ModelState);
            //  }

            // var user = await _context.ApplicationUsers.FindAsync(id);
            // Console.WriteLine(id);
            var BesoinFormation = _context.BesoinFormations;
            if (BesoinFormation == null)
            {
                return (null);
            }

            return (BesoinFormation);
        }
    }
}