using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.Models
{
    public class ProfileMakerRepository : IProfileMakerRepository
    {
        private ProfileMakerContext _context;
        private ILogger<IWorldRepository> _logger;

        public ProfileMakerRepository(ProfileMakerContext context, ILogger<IWorldRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddOtherCourse(string profileUserFirstName, string username, OtherCourse newOtherCourse)
        {
            var theProfileUser = GetProfileUserByName(profileUserFirstName, username);
            newOtherCourse.Order = theProfileUser.OtherCourses.Max(s => s.Order) + 1;
            theProfileUser.OtherCourses.Add(newOtherCourse);
            _context.OtherCourses.Add(newOtherCourse);
        }

        public void AddTrip(ProfileUser newProfileUser)
        {
            _context.Add(newProfileUser);
        }

        public IEnumerable<ProfileUser> GetAllProfileUsers()
        {
            try
            {
                return _context.ProfileUsers.OrderBy(p => p.FirstName).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get users from database", ex);
                return null;
            }
        }

        public IEnumerable<ProfileUser> GetAllProfileUsersWithAllInfo()
        {
            try
            {
                return _context.ProfileUsers
                   .Include(p => p.Educations)
                   .Include(p => p.OtherCourses)
                   .Include(p => p.TechniqueAreas)
                   .Include(p => p.ProjectExperiences)
                   .ThenInclude(t => t.TechnicalEnvironments)
                   .OrderBy(p => p.FirstName)
                   .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get users with info from database", ex);
                return null;
            }
           
        }

        public ProfileUser GetProfileUserByName(string profileUserName, string username)
        {
            return _context.ProfileUsers.Include(t => t.OtherCourses)
               .Where(t => t.FirstName == profileUserName && t.UserName == username)
               .FirstOrDefault();
        }

        public IEnumerable<ProfileUser> GetProfileUserWithAllInfo(string name)
        {
            try
            {
                return _context.ProfileUsers
                   .Include(p => p.Educations)
                   .Include(p => p.OtherCourses)
                   .Include(p => p.TechniqueAreas)
                   .Include(p => p.ProjectExperiences)
                   .ThenInclude(t => t.TechnicalEnvironments)
                   .OrderBy(p => p.FirstName)
                   .Where(P => P.UserName == name)
                   .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get users with info from database", ex);
                return null;
            }
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
