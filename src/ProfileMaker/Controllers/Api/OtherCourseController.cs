using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;
using ProfileMaker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.Controllers.Api
{
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
                var results = _repository.GetProfileUserByName(ProfileUserFirstName);
                if (results == null)
                {
                    return Json(null);
                }
                return Json(Mapper.Map<IEnumerable<OtherCourseViewModel>>(results.OtherCourses.OrderBy(s => s.Order)));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get otherCourses for this user {ProfileUserFirstName}", ex);
                return Json("Error occured finding otherCourse name");
            }

        }



    }
}
