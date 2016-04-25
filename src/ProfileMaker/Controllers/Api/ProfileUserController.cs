using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProfileMaker.Models;
using ProfileMaker.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProfileMaker.Controllers.Api
{
    [Route("api/users")]
    public class ProfileUserController : Controller
    {
        private ILogger<ProfileUserController> _logger;
        private IProfileMakerRepository _repository;

        //constructor
        public ProfileUserController(IProfileMakerRepository repository, ILogger<ProfileUserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet("")]
        public JsonResult Get()
        {
            //Not work well with mapper? Not all tabels in db
            //var restults = Mapper.Map<IEnumerable<ProfileUserViewModel>>(_repository.GetAllProfileUsersWithAllInfo());
            //return Json(restults);

            var result = _repository.GetAllProfileUsersWithAllInfo();
            return Json(result);
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]ProfileUserViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Mapper
                    var newProfileUser = Mapper.Map<ProfileUser>(vm);

                    //Logger
                    _logger.LogInformation("Attemting to save new profile user");

                    //Save to Database
                    _repository.AddTrip(newProfileUser);

                    if (_repository.SaveAll())
                    {
                        //return
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<ProfileUserViewModel>(newProfileUser));
                    }

                }
            }
            catch (Exception ex)
            {

                //_logger.LogError("Failde to save new trip", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }


            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json(new { Message = "Failed", ModelState = ModelState });
        }
    }
}
