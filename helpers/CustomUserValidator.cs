using Microsoft.AspNetCore.Identity;

public class CustomUserValidator<TUser> : UserValidator<TUser> where TUser : class
{
    public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    {
        // Remove a validação de unicidade do UserName
        var result = await base.ValidateAsync(manager, user);

        var errors = result.Errors
            .Where(e => e.Code != "DuplicateUserName")
            .ToList();

        return errors.Any() ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
    }
}
