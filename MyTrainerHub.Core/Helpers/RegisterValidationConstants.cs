namespace MyTrainerHub.Core.Helpers
{
    public static class RegisterValidationConstants
    {
        public const string InvalidEmail = "InvalidEmail";
        public const string InvalidPhoneNumber = "InvalidPhoneNumber";
        public const string PasswordNotMatch = "PasswordNotMatch";
        public const string PasswordNotMatchDesc = "Password and Confirm Password are not the same";

        public const string PhoneRegex = "^01[0125][0-9]{8}$";

        public static string GetInvalidEmailDesc(string email)
        {
            return $"Email '{email}' is invalid.";
        }
        public static string GetInvalidPhoneNumberDesc(string phoneNumber)
        {
            return $"Phone Number '{phoneNumber}' is invalid.";
        }
        
    }
}
