using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net.Mail;
using System.Reflection;
using UserAuthenticationJWTGenerated.Data;
using UserAuthenticationJWTGenerated.Dto;
using UserAuthenticationJWTGenerated.Dtos;
using UserAuthenticationJWTGenerated.Helpers;
using UserAuthenticationJWTGenerated.Interfaces;
using UserAuthenticationJWTGenerated.Models;
using UserAuthenticationJWTGenerated.Repositories;

namespace UserAuthenticationJWTGenerated.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;
        private readonly IEmailService _emailService;
        public AuthController(IUserRepository repository, JwtService jwtService, IEmailService emailService)
        {
            _repository = repository;
            _jwtService = jwtService;
            _emailService = emailService;
        }

        [HttpPost("send-email")]
        public IActionResult SendEmails(EmailDto request)
        {
            if (request == null) return BadRequest(new { message = "Request not Found" });
            else
            {
                _emailService.SendEmail(request);
                return Ok("Email Send Succcessfully");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var users = _repository.GetByEmail(dto.Email);
            if (users == null) return BadRequest(new { message = "Invalid Credential" });
            if (!BCrypt.Net.BCrypt.Verify(dto.Password, users.Password))
            {
                return BadRequest(new { message = "Invalid Credential" });
            }

            var jwt = _jwtService.Generate(users.Id);

            //Response.Cookies.Append("jwt", jwt, new CookieOptions
            //{
            //    HttpOnly = true
            //});

            return Ok(new
            {
                jwt,
                users.FullName,
                users.Email,
                users.Roles,
                users.State,
                users.Pincode
            });
        }

        [HttpPost]
        [Route("forgot-password")]
        public IActionResult ForgotPassword(LoginDto dto)
        {
            var users = _repository.GetByEmail(dto.Email);
            EmailDto request = new EmailDto();
            if (users!=null)
            {
                if(users.Email.Equals(dto.Email))
                { 
                    _emailService.SendEmail(request);
                }
               
            }
            else
            {
                return BadRequest(new { message = "EmailId Not Found" });
            }
            return Ok("Password Changes");
        }

        [HttpPost]
        [Route("register-chairman")]
        public Users RegisterChairman(RegisterDto dto)
        {
            var vulunteerRegister = new Users
            {
                ProfilePicture = dto.ProfilePicture,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FullName = dto.FirstName + " " + dto.LastName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                DoB = dto.DoB,
                Gender = dto.Gender,
                State = dto.State,
                City = dto.City,
                TownOrDistrict = dto.TownOrDistrict,
                AadharCard = dto.AadharCard,
                Landmark = dto.Landmark,
                Pincode = dto.Pincode,
                MobileNo = dto.MobileNo,
                AltMobNo = dto.AltMobNo,
                BloodGroup = dto.BloodGroup,
                NearestRailwayStation = dto.NearestRailwayStation,
                NearestAirport = dto.NearestAirport,
                NearestBusStation = dto.NearestBusStation,
                RouteCoordinator = dto.RouteCoordinator,
                GochriSeva = dto.GochriSeva,
                ViharSeva = dto.ViharSeva,
                Other = dto.Other,
                AnySocialGroup = dto.AnySocialGroup,
                NameOfOrganization = dto.NameOfOrganization,
                Position = dto.Position,
                
                Roles = Level.Chairman.ToString()
            };

           Users vulunteers =  _repository.Create(vulunteerRegister);
            return vulunteers;
        }

        [HttpPost]
        [Route("register-CoChairman")]
        public Users RegisterCoChairman(RegisterDto dto)
        {
            var vulunteerRegister = new Users
            {
                ProfilePicture = dto.ProfilePicture,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FullName = dto.FirstName + " " + dto.LastName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                DoB = dto.DoB,
                Gender = dto.Gender,
                State = dto.State,
                City = dto.City,
                TownOrDistrict = dto.TownOrDistrict,
                AadharCard = dto.AadharCard,
                Landmark = dto.Landmark,
                Pincode = dto.Pincode,
                MobileNo = dto.MobileNo,
                AltMobNo = dto.AltMobNo,
                BloodGroup = dto.BloodGroup,
                NearestRailwayStation = dto.NearestRailwayStation,
                NearestAirport = dto.NearestAirport,
                NearestBusStation = dto.NearestBusStation,
                RouteCoordinator = dto.RouteCoordinator,
                GochriSeva = dto.GochriSeva,
                ViharSeva = dto.ViharSeva,
                Other = dto.Other,
                AnySocialGroup = dto.AnySocialGroup,
                NameOfOrganization = dto.NameOfOrganization,
                Position = dto.Position,
                Roles = Level.CoChairman.ToString()
            };

            Users vulunteers = _repository.Create(vulunteerRegister);
            return vulunteers;
        }

        [HttpPost]
        [Route("register-routeCoordinators")]
        public Users RegisterRouteCoordinators(RegisterDto dto)
        {
            var vulunteerRegister = new Users
            {
                ProfilePicture = dto.ProfilePicture,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                FullName = dto.FirstName + " " + dto.LastName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                DoB = dto.DoB,
                Gender = dto.Gender,
                State = dto.State,
                City = dto.City,
                TownOrDistrict = dto.TownOrDistrict,
                AadharCard = dto.AadharCard,
                Landmark = dto.Landmark,
                Pincode = dto.Pincode,
                MobileNo = dto.MobileNo,
                AltMobNo = dto.AltMobNo,
                BloodGroup = dto.BloodGroup,
                NearestRailwayStation = dto.NearestRailwayStation,
                NearestAirport = dto.NearestAirport,
                NearestBusStation = dto.NearestBusStation,
                RouteCoordinator = dto.RouteCoordinator,
                GochriSeva = dto.GochriSeva,
                ViharSeva = dto.ViharSeva,
                Other = dto.Other,
                AnySocialGroup = dto.AnySocialGroup,
                NameOfOrganization = dto.NameOfOrganization,
                Position = dto.Position,
                Roles = Level.RouteCoordinators.ToString()
            };

            Users vulunteers = _repository.Create(vulunteerRegister);
            return vulunteers;
        }
    }
}
