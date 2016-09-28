namespace SalesInventory.Core.Identity
{
    public enum SignInStatus
    {
        Success,
        LockedOut,
        RequiresTwoFactorAuthentication,
        Failure,
        RequiresVerification
    }
}