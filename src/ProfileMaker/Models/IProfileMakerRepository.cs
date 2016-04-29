using System.Collections.Generic;

namespace ProfileMaker.Models
{
    public interface IProfileMakerRepository
    {
        IEnumerable<ProfileUser> GetAllProfileUsers();
        IEnumerable<ProfileUser> GetAllProfileUsersWithAllInfo();
        void AddTrip(ProfileUser newProfileUser);
        bool SaveAll();
        ProfileUser GetProfileUserByName(string profileUserName, string username);
        void AddOtherCourse(string profileUserFirstName, string username, OtherCourse newOtherCourse);
        IEnumerable<ProfileUser> GetProfileUserWithAllInfo(string name);
    }
}