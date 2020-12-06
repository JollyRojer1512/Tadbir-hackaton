using EventServiceApi.ViewModels;

namespace EventServiceApi.Models
{
    public class PreacherFemale : Preacher
    {
        public new PreacherFemaleViewModel ConvertToViewModel()
        {
            return new PreacherFemaleViewModel()
            {
                PreacherId = Id,
                PreacherFirstName = FirstName,
                PreacherLastName = LastName,
                PreacherRequiredPhoneNumber = RequiredPhoneNumber,
                PreacherAdditionalPhoneNumber = AdditionalPhoneNumber,
                PreacherCity = City,
                PreacherDistrict = District
            };
        }

    }
}