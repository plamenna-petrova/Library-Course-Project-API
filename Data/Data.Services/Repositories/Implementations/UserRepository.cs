﻿using Data.DataConnection;
using Data.DataConnection.Exceptions;
using Data.Models.Models;
using Data.Services.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Services.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userContext;

        public UserRepository(ApplicationDbContext userContext)
        {
            _userContext = userContext;
        }
        //comment
        //another comment

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = _userContext.Users.SingleOrDefault(x => x.Username == username);

            // check if username exists
            if (user == null)
            {
                return null;
            }

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            //authentication successful
            return user;
        }

        public User Create(User user, string password)
        {
            // validation
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new AppException("Password is required");
            }

            if (_userContext.Users.Any(x => x.Username == user.Username))
            {
                throw new AppException("Username \"" + user.Username + "\" is already taken");
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _userContext.Users.Add(user);
            _userContext.SaveChanges();

            return user;
        }

        public void Delete(int userId)
        {
            var user = _userContext.Users.Find(userId);
            if (user != null)
            {
                _userContext.Users.Remove(user);
                _userContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userContext.Users;
        }

        public User GetUserById(int userId)
        {
            return _userContext.Users.Find(userId);
            //mapping
        }

        public void Update(User userParam, string password = null)
        {
            //no password
            var user = _userContext.Users.Find(userParam.Id);

            if (user == null)
            {
                throw new AppException("User not found");
            }

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.Username) && userParam.Username != user.Username)
            {
                // throw error if the new username is already taken
                if (_userContext.Users.Any(x => x.Username == userParam.Username))
                {
                    throw new AppException("Username " + userParam.Username + " is already taken");
                }

                user.Username = userParam.Username;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.FirstName))
            {
                user.FirstName = userParam.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(userParam.LastName))
            {
                user.LastName = userParam.LastName;
            }

            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _userContext.Users.Update(user);
            _userContext.SaveChanges();
        }

        // private helper methods

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null)
            {
                throw new ArgumentNullException("password");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            }

            if (storedHash.Length != 64)
            {
                throw new ArgumentException("Invalid length of password hash (64 bytes expected)", "passwordHash");
            }

            if (storedSalt.Length != 128)
            {
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            }

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
