using AutoMapper;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProfileMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProfileMaker.Controllers.Api
{
    //THIS IS RAW MODEL OF OTHER CONTROLLERS!!!

    [Authorize]
    [Route("api/users/{ProfileUserFirstName}/OtherCourses")]
    public class OtherCourseController : Controller
    {
        private ILogger<OtherCourseController> _logger;
        private IProfileMakerRepository _repository;

        //constructor
        public OtherCourseController(IProfileMakerRepository repository, ILogger<OtherCourseController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpGet("")]
        public JsonResult Get(string ProfileUserFirstName)
        {
            try
            {
                var results = _repository.GetProfileUserByName(ProfileUserFirstName, User.Identity.Name);
                if (results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<OtherCourseViewModel>>(results.OtherCourses.OrderBy(o => o.Order)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get courses for this user {ProfileUserFirstName}", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured finding course name");
            }

        }

        [HttpPost("")]
        public JsonResult Post(string profileUserFirstName, [FromBody]OtherCourseViewModel vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Map to the Entity
                    var newOtherCourse = Mapper.Map<OtherCourse>(vm);

                    //Save to Database
                    _repository.AddOtherCourse(profileUserFirstName, User.Identity.Name, newOtherCourse);

                    if (_repository.SaveAll())
                    {
                        Response.StatusCode = (int)HttpStatusCode.Created;
                        return Json(Mapper.Map<OtherCourseViewModel>(newOtherCourse));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new course", ex);
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured save new course");

            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Validation failed on new course");
        }


    }
}
