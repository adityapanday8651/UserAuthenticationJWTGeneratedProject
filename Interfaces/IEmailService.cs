using UserAuthenticationJWTGenerated.Dto;

namespace UserAuthenticationJWTGenerated.Interfaces
{
    public interface IEmailService
    {
        public void SendEmail(EmailDto request);
    }
}
