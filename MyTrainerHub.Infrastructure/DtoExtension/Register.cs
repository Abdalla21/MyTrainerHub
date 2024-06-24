using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using MyTrainerHub.Core.Domain.Entities;
using MyTrainerHub.Core.DTOs.RegistrationDTOs;
using MyTrainerHub.Core.Helpers;
using MyTrainerHub.Infrastructure.ModelsCreator;

namespace MyTrainerHub.Infrastructure.DtoExtension
{
    public static class Register
    {
        public static ApplicationUser ToUser(this RegisterDto regDto)
        {
            ApplicationUser appUser = new ApplicationUser
            {
                Email = regDto.Email,
                PhoneNumber = regDto.PhoneNumber,
                UserName = regDto.UserName
            };

            return appUser;
        }

        public static IdentityResult ValidateUser(this RegisterDto regDto)
        {
            Regex phoneRegex = new(RegisterValidationConstants.PhoneRegex);

            List<IdentityError> errors = [];

            bool isValid = true;
            bool isValidEmail;
            bool isMatchedPassword = String.Equals(regDto.Password, regDto.ConfirmPassword);
            bool isValidPhoneNumber = phoneRegex.IsMatch(regDto.PhoneNumber);

            try
            {
                MailAddress address = new(regDto.Email);
                isValidEmail = String.IsNullOrEmpty(address.DisplayName);
            }
            catch (Exception )
            {
                isValidEmail = false;

            }

            if (!isValidEmail)
            {
                string invalidEmailDesc = RegisterValidationConstants.GetInvalidEmailDesc(regDto.Email);
                errors.Add(IdentityResultErrorCreator.CreateErrorModel(RegisterValidationConstants.InvalidEmail, invalidEmailDesc));

                isValid = false;
            }


            if (!isValidPhoneNumber)
            {
                string invalidPhoneNumberDesc = RegisterValidationConstants.GetInvalidPhoneNumberDesc(regDto.PhoneNumber);
                errors.Add(IdentityResultErrorCreator.CreateErrorModel(RegisterValidationConstants.InvalidPhoneNumber, invalidPhoneNumberDesc));

                isValid = false;
            }

            if (!isMatchedPassword)
            {
                errors.Add(IdentityResultErrorCreator.CreateErrorModel(RegisterValidationConstants.PasswordNotMatch, RegisterValidationConstants.PasswordNotMatchDesc));

                isValid = false;
            }

            if (!isValid)
            {
                return IdentityResult.Failed(errors.ToArray());
            }

            return IdentityResult.Success;
        }

    }
}
