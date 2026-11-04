using System;
using System.Collections.Generic;
using System.Text;
using Zxcvbn;
using Entities;

namespace Service
{
    public class PasswordService : IPasswordService
    {
        public int GetPassword(string password)
        {
            return Zxcvbn.Core.EvaluatePassword(password).Score;

        }
    }
}
