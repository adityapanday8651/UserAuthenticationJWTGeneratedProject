using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace UserAuthenticationJWTGenerated.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string DoB { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string TownOrDistrict { get; set; }
        public string AadharCard { get; set; }
        public string Landmark { get; set; }
        public int Pincode { get; set; }
        public string MobileNo { get; set; }
        public string AltMobNo { get; set; }
        public string BloodGroup { get; set; }
        public string NearestRailwayStation { get; set; }
        public string NearestAirport { get; set; }
        public string NearestBusStation { get; set; }
        public string RouteCoordinator { get; set; }
        public string GochriSeva { get; set; }
        public string ViharSeva { get; set; }
        public string Other { get; set; }
        public string AnySocialGroup { get; set; }
        public string NameOfOrganization { get; set; }
        public string Position { get; set; }
        public string Roles { get; set; }
        
    }
     public enum Level
    {
        SuperAdmin,
        Chairman,
        CoChairman,
        RouteCoordinators
    }
}
