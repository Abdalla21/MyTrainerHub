namespace MyTrainerHub.Core.DTOs.RegistrationDTOs
{
    public record RegisterDto(
            string PhoneNumber,
            string Email,
            string Password,
            string ConfirmPassword,
            string UserName
    );
}
