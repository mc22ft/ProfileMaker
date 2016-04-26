using Microsoft.AspNet.Identity;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfileMaker.Models.Seeds
{
    public class ProfileMakerContextSeedData
    {

        private ProfileMakerContext _context;
        private UserManager<ProfileMakerUser> _userManager;

        public ProfileMakerContextSeedData(ProfileMakerContext context, UserManager<ProfileMakerUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDataAsync()
        {
            if (await _userManager.FindByEmailAsync("mathias@mail.com") == null)
            {
                //add the user
                var newUser = new ProfileMakerUser()
                {
                    UserName = "mathias",
                    Email = "mathias@mail.com"
                };

                IdentityResult result = await _userManager.CreateAsync(newUser, "Apelsin!0038");
                if (result.Succeeded)
                {
                    //await SignInAsync(user, isPersistent: false);
                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    //AddErrors(result);
                }
            }

            if (!_context.ProfileUsers.Any())
            {
                //Add new data
                var newProfileUser = new ProfileUser()
                {
                    FirstName = "Mathias",
                    LastName = "Claesson",
                    Email = "mathias@mail.com",
                    UserName = "mathias",
                    UserImage = "ImagePath/set/later/in/project",
                    CompanyName = "CA Advertising AB",
                    Address = "Hammarby Allé 132",
                    PostNumber = 12066,
                    City = "Stockholm",
                    Country = "Sverige",
                    Created = DateTime.Now,
                    Summary = "Pluggar på LNU och är klar till sommaren. Lever med sambo och två barn!",

                    OtherCourses = new List<OtherCourse>()
                    {
                        new OtherCourse() {  Name = "SQL Server", Order = 1 },
                        new OtherCourse() {  Name = "Webb of Scrum", Order = 2 }
                    },

                    TechniqueAreas = new List<TechniqueArea>()
                    {
                        new TechniqueArea() {  Name = "HTML5", Order = 1 },
                        new TechniqueArea() {  Name = "CSS", Order = 2 },
                        new TechniqueArea() {  Name = "PHP", Order = 4 },
                        new TechniqueArea() {  Name = "Ruby", Order = 5 }
                    },


                    Educations = new List<Education>()
                    {
                        new Education() {  Name = "Elprogrammet inriktning data, Gymnasiet - Eksjö", StartDate = new DateTime(2006, 01, 01), StopDate = new DateTime(2008, 12, 01), Order = 1 },
                        new Education() {  Name = "Webbprogrammerare Linnéuniversitetet", StartDate = new DateTime(2009, 01, 01), StopDate = new DateTime(2010, 12, 01), Order = 1 }
                    },

                    ProjectExperiences = new List<ProjectExperience>()
                    {
                        new ProjectExperience() {  Name = "Polisen.se", StartDate = new DateTime(2012, 01, 01), StopDate = new DateTime(2013, 12, 01), Summary = "Jobbade som en kung och fixade biffen!",
                            TechnicalEnvironments = new List<TechnicalEnvironment>()
                            {
                                new TechnicalEnvironment() {  Name = "ASP.NET MVC", Order = 1 },
                                new TechnicalEnvironment() {  Name = "Visual Studio 2013", Order = 2 }
                            },
                            Order = 1 },
                        new ProjectExperience() {  Name = "ICA.se", StartDate = new DateTime(2014, 01, 01), StopDate = new DateTime(2016, 12, 01), Summary = "Jobbade som en biff och köpte mjölken!",
                            TechnicalEnvironments = new List<TechnicalEnvironment>()
                            {
                                new TechnicalEnvironment() {  Name = "HTML5", Order = 1 },
                                new TechnicalEnvironment() {  Name = "PHP", Order = 2 }

                            },
                            Order = 1 },
                    },

                };

                //Main obj
                _context.ProfileUsers.Add(newProfileUser);
                //list to main
                _context.OtherCourses.AddRange(newProfileUser.OtherCourses);
                _context.TechniqueAreas.AddRange(newProfileUser.TechniqueAreas);
                _context.Educations.AddRange(newProfileUser.Educations);
                //nest obj add to main
                _context.ProjectExperiences.AddRange(newProfileUser.ProjectExperiences);
            
                _context.SaveChanges();

            }
        }
    }
}
