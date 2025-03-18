
namespace Cheers.Core.DTOs
{
   public class MaleDTOs
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Tz { get; set; }
        public string Class { get; set; }
        public bool AnOutsider { get; set; } = false;
        public string BackGround { get; set; }
        public string Openness { get; set; }
        public string Gender { get; set; }
        public DateTime BurnDate { get; set; }
        public int Age { get; set; }
        public bool HealthCondition { get; set; }
        public string Status { get; set; }
        public bool StatusVacant { get; set; }
        public string PairingType { get; set; }
        public double Height { get; set; }
        public string GeneralAppearance { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        

        // שדות חדשים
        public string ExpectationsFromPartner { get; set; }
        public string Club { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public string ImportantTraitsInMe { get; set; }
        public string ImportantTraitsIAmLookingFor { get; set; }
        public string PreferredSeminarStyle { get; set; }
        public string PreferredProfessionalPath { get; set; }
        public string HeadCovering { get; set; }
    }
}
