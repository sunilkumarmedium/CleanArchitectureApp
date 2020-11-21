using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Interfaces.Services;
using FluentValidation.Results;
using PasswordGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CleanArchitectureApp.Infrastructure.Shared.Services
{
    public class PasswordService : IPasswordService
    {
        public string Base64Decode(string password)
        {
            password = password.Replace('-', '+');
            password = password.Replace('_', '/');
            password = password.PadRight(password.Length + (4 - password.Length % 4) % 4, '=');

            var data = Convert.FromBase64String(password);
            return Encoding.UTF8.GetString(data);
        }

        public bool IsBase64String(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            s = s.Trim();
            return (s.Length % 4 == 0) && Regex.IsMatch(s, @"^[a-zA-Z0-9\+/]*={0,3}$", RegexOptions.None);
        }

        public void CreatePasswordHash(string password, out string passwordHash, out string passwordSalt)
        {
            IList<ValidationFailure> messages = new List<ValidationFailure>();

            if (password == null) messages.Add(new ValidationFailure("Password", "Password is null"));
            if (string.IsNullOrWhiteSpace(password)) messages.Add(new ValidationFailure("password", "Value cannot be empty or whitespace only string."));

            if (messages.Count > 0) throw new ValidationException(messages);

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = Convert.ToBase64String(hmac.Key);
                passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
            }
        }

        public bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            IList<ValidationFailure> messages = new List<ValidationFailure>();

            if (password == null) messages.Add(new ValidationFailure("password", "Password is null"));
            if (string.IsNullOrWhiteSpace(password)) messages.Add(new ValidationFailure("password", "Value cannot be empty or whitespace only string."));
            if (storedHash.Length != 64) messages.Add(new ValidationFailure("passwordHash", "Invalid length of password hash (64 bytes expected)."));
            if (storedSalt.Length != 128) throw new ArgumentException("passwordHash", "Invalid length of password salt (128 bytes expected).");

            if (messages.Count > 0) throw new ValidationException(messages);

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(storedHash);
            }
        }

        public string GeneratePassword(int passwordlength)
        {
            var pwd = new Password(passwordlength).IncludeLowercase().IncludeUppercase().IncludeNumeric().IncludeSpecial("[]{}^_=");
            return pwd.Next();
        }
    }
}