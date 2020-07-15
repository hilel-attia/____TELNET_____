using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProcessusFormation.Data;

namespace ProcessusFormation.Controllers.Formation
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormateursController : ControllerBase
       
    {
        private readonly ApplicationDbContext _context;
        public FormateursController(ApplicationDbContext context)
         {
            _context = context;
         }

      
    }
}