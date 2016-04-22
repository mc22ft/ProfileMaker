using Microsoft.AspNet.Mvc;
using ProfileMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.Controllers.Api
{
    [Route("api/users")]
    public class ProfileUserController : Controller
    {
        private IProfileMakerRepository _repository;

        //constructor
        public ProfileUserController(IProfileMakerRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("")]
        public JsonResult Get()
        {
            var result = _repository.GetAllProfileUsersWithAllInfo();
            return Json(result);
        }
    }
}
