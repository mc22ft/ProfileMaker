using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace ProfileMaker.Models
{
    public class ProfileMakerUser : IdentityUser
    {
        public DateTime FirstProfil { get; set; }
    }
}