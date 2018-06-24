using AutoMapper;
using Max.MedicalLab.Common.Dto;
using Max.MedicalLab.Data.Entity.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.ModelBinding;
using System.Web.UI;
using System.IO;
using Max.MedicalLab.Data.EntityManager;
using System.Security.Cryptography;
using Max.MedicalLab.Business.Core;
using System.Linq.Expressions;
using Max.MedicalLab.Business.Core.AutoMapper;
using Max.MedicalLab.Business.Core.Helper;

namespace Max.MedicalLab.Business.Core.Managers
{
    /// <summary>
    /// This class handles all the business logics associated with the Users of the system.
    /// </summary>
    /// 

    public class UserManager: MedLabRepository<User>
    {
        private readonly UserRepository userRepo;
        UserManagerHelper UserHelp = new UserManagerHelper();

        /// <summary>
        /// Initializes a new instance of the <see cref="UserManager"/> class.
        /// </summary>
        public UserManager()
        {
            this.userRepo = new UserRepository();
        }

        /// <summary>
        /// Gets the user by username.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns></returns>
        /// <exception cref="System.NullReferenceException">Provided username cannot be null or empty.</exception>
        public UserDto GetUserByUsername(string username)
        {
            if (!string.IsNullOrEmpty(username))
            {
                var user = userRepo.GetUser(username);

                return Mapper.Map<UserDto>(user);
            }
            else
            {
                throw new NullReferenceException("Provided username cannot be null or empty.");
            }
        }

        /// <summary>
        /// Adds the new user.
        /// </summary>
        /// <param name="user">The user.</param>      
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        ///
        public UserDto AddNewUser(UserDto user)
        {         
            MapperConfig.ConfigAutoMapper();

            if (this.IsUserValid(user))               
            {
                if (userRepo.GetUser(user.Username) == null )
                {
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    byte[] buffer = new byte[50];

                    byte[] salt = new byte[25];
                    rng.GetBytes(salt);

                    string saltString = Encoding.Default.GetString(salt);

                    string hashedPassString = this.GenerateSaltedHash(user.Password, saltString);

                    user.Password = hashedPassString;
                    user.PasswordSalt = saltString;
                    user.IsLoked = false;
                    user.LastLogin = null;
                    user.NumOfInvalidLogins = 0;
                    user.CreatedBy = "Test User";
                    user.CreatedDate = DateTime.Now;
                    user.ModifiedBy = string.Empty;
                    user.ModifiedDate = null;

                    var savedUser = userRepo.Insert(Mapper.Map<User>(user));

                    return Mapper.Map<UserDto>(savedUser);
                }
                else
                {
                    throw new InvalidOperationException("Username is not available.");
                }               
            }
            else
            {
                throw new ArgumentNullException("Provided information is not valid.");
            }            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDto UnlockUser(UserDto user)
        {
            MapperConfig.ConfigAutoMapper();

            if (user == null)
            {
                throw new NullReferenceException("null user");
            }
            else
            {
                user.Username = UserHelp.GetUser(user.UserId).Username;
                user.Password = UserHelp.GetUser(user.UserId).Password;
                user.CreatedBy = UserHelp.GetUser(user.UserId).CreatedBy;
                user.RoleId = UserHelp.GetUser(user.UserId).RoleId;
                user.ModifiedDate = DateTime.Now;
                user.CreatedDate = UserHelp.GetUser(user.UserId).CreatedDate;
                user.NumOfInvalidLogins = 0;
                user.IsLoked = false;

                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buffer = new byte[50];

                byte[] salt = new byte[25];
                rng.GetBytes(salt);

                string saltString = Encoding.Default.GetString(salt);

                string hashedPassString = this.GenerateSaltedHash(user.Password, saltString);

                user.Password = hashedPassString;
                user.PasswordSalt = saltString;

                userRepo.Update(Mapper.Map<User>(user));
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDto DeleteUser(UserDto user)
        {
            MapperConfig.ConfigAutoMapper();

            {
                if (user == null)
                {
                    throw new NullReferenceException("null user");
                }
                else
                {
                    User DelUser = context.Users.SingleOrDefault(item => item.UserId == user.UserId);
                    context.Users.Remove(DelUser);
                    context.SaveChanges();
                }
                //patientRepo.Delete(Mapper.Map<Patient>(DelPatietnt));

            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public UserDto UpdateUser(UserDto user)
        {
            MapperConfig.ConfigAutoMapper();

            if (user == null)
            {
                throw new NullReferenceException("null user");
            }
            else
            {
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] buffer = new byte[50];

                byte[] salt = new byte[25];
                rng.GetBytes(salt);

                string saltString = Encoding.Default.GetString(salt);

                string hashedPassString = this.GenerateSaltedHash(user.Password, saltString);

                user.Password = hashedPassString;
                user.PasswordSalt = saltString;
                user.CreatedBy = UserHelp.GetUser(user.UserId).CreatedBy;
                user.CreatedDate = UserHelp.GetUser(user.UserId).CreatedDate;
                user.ModifiedDate = DateTime.Now;
                user.NumOfInvalidLogins = 0;

                userRepo.Update(Mapper.Map<User>(user));
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public UserDto Login(string username, string password)
        {
            /// ToDo: Remove this code after testing
            MapperConfig.ConfigAutoMapper();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                var user = userRepo.GetUser(username);                               
                if (user != null)
                {
                    if (!user.IsLoked)
                    {                      
                        var hashedPass = this.GenerateSaltedHash(password, user.PasswordSalt);
                        if (hashedPass.Equals(user.Password))
                        {
                            user.NumOfInvalidLogins = 0;
                            user.IsLoked = false;
                            user.LastLogin = DateTime.Now;

                            userRepo.Update(user);

                            user.Password = string.Empty;
                            user.PasswordSalt = string.Empty;

                            System.Diagnostics.Debug.WriteLine("Login success!");
                            return Mapper.Map<UserDto>(user);
                            
                        }
                        else
                        {
                           if(user.NumOfInvalidLogins < 2)
                            {
                                user.NumOfInvalidLogins++;
                                userRepo.Update(user);

                                throw new InvalidOperationException("Login not succesful.");
                            }
                            else
                            {
                                user.NumOfInvalidLogins++;
                                user.IsLoked = true;
                                userRepo.Update(user);

                                throw new InvalidOperationException("Login not succesful. Account Locked!.");
                            }
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("User has been locked.");
                    }
                }
                else
                {
                    throw new InvalidOperationException("User not found.");
                }
            }
            else
            {
                throw new ArgumentNullException("Username or password cannot be null or empty.");
            } 
            
            
        }
        
        private string GenerateSaltedHash(string passwordString, string saltString)
        {
            RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider();

            SHA256 sha256 = SHA256Managed.Create();

            byte[] passwordBytes = new byte[(passwordString.Length + saltString.Length) * sizeof(char)];
            Buffer.BlockCopy((passwordString + saltString).ToCharArray(), 0, passwordBytes, 0, passwordBytes.Length);

            byte[] passwordHash = sha256.ComputeHash(passwordBytes);

            string encryptedPassord = Encoding.Default.GetString(passwordHash);

            return encryptedPassord;
        }

        private bool IsUserValid(UserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("User Does not exists");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                throw new ArgumentNullException("Insert username Field!");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new ArgumentNullException("Insert password Field!");
            }

            if (string.IsNullOrEmpty(user.ConfirmPassword))
            {
                throw new ArgumentNullException("Insert confirm password Field!");
            }

            if (user.RoleId < 1)
            {
                throw new ArgumentNullException("Insert Role Field!");
            }

            if (!user.Password.Equals(user.ConfirmPassword))
            {
                throw new ArgumentNullException("Password mismatch!");
            }

            return true;
        }
    }
}