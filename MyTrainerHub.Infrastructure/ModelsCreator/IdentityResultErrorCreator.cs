using Microsoft.AspNetCore.Identity;

namespace MyTrainerHub.Infrastructure.ModelsCreator
{
    public class IdentityResultErrorCreator
    {
        public static IdentityError CreateErrorModel(string code, string desc)
        {
            IdentityError error = new()
            {
                Code = code,
                Description = desc
            };

            return error;
        }

    }
}
