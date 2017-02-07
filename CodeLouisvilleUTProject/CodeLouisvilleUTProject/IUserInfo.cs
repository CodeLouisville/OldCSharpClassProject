namespace CodeLouisvilleUTProject
{
    internal interface IUserInfo
    {
        int NoOfAttempt { get; set; }

        bool CheckCredential(string username, string password);
        bool IsUserLocked();
    }
}