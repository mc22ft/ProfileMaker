using System.Collections.Generic;

namespace ProfileMaker.Models
{
    public interface IProfileMakerRepository
    {
        IEnumerable<ProfileUser> GetAllProfileUsers();
        IEnumerable<ProfileUser> GetAllProfileUsersWithAllInfo();
    }
}