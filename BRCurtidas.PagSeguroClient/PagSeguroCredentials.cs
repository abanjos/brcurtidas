using BRCurtidas.Common;
using System;

namespace BRCurtidas.PagSeguro
{
    public class PagSeguroCredentials
    {
        public PagSeguroCredentials(string email, string token)
        {
            if (String.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));

            if (String.IsNullOrWhiteSpace(token))
                throw new ArgumentNullException(nameof(token));

            if (!email.IsValidEmail())
                throw new ArgumentException("Invalid API user e-mail.");

            Email = email;
            Token = token;
        }

        public string Email { get; private set; }

        public string Token { get; private set; }
    }
}
