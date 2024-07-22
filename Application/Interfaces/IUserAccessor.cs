namespace Application.Interfaces
{
    public interface IUserAccessor
    {
        /// <summary>
        /// Function for returning name of user or null via claims.
        /// </summary>
        /// <returns>User name or null.</returns>
        string GetUserName();
        /// <summary>
        /// Function for returning users nickname or null via claims.
        /// </summary>
        /// <returns>User nickname or null.</returns>
        string GetUserNickname();
    }
}