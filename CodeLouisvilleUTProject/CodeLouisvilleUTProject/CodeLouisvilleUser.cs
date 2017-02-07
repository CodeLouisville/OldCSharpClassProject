using System;

namespace CodeLouisvilleUTProject
{
    internal class CodeLouisvilleUser : IUserInfo
    {
        public int NoOfAttempt
        {
            get;


            set;
           
        }

        public bool IsUserLocked()
        {
            if (NoOfAttempt < 3) return false;
            return true;
        }

        public bool CheckCredential(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;
            return true;

        }
    }
}