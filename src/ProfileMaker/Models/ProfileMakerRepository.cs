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
               //TechnicalEnvironments in?
               .OrderBy(p => p.FirstName)
               .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Could not get users with info from database", ex);
                return null;
            }
           
        }
    }
}
