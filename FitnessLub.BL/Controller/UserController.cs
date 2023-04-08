﻿using FitnessLub.BL.Model;
using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessLub.BL.Controller
{   /// <summary>
    /// User Controller.  
    /// </summary>
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Application user.
        /// </summary>
        private List<User> Users { get; }

        public User CurrentUser { get; }

        private const string USERS_FILE_NAME = "users.dat";

        public bool IsNewUser { get; } = false;
        /// <summary>
        /// Create new user controller.
        /// </summary>
        /// <param name="user"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User Name cannot be empty or null!", nameof(userName));
            }
            Users = GetUserData();
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save(); 
            }
            else
            {
                Console.WriteLine(CurrentUser);
            }
            
            
        }
        /// <summary>
        /// Save user data.
        /// </summary>
        public void Save()
        {
            base.Save(USERS_FILE_NAME, Users);
        }
        /// <summary>
        /// Get user list.
        /// </summary>
        /// <returns></returns>
        private  List<User> GetUserData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
        public void SetNewUserData(string genderName, DateTime birthData, double weight = 1 , double height = 1)
        {
            // Verification
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthData = birthData;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }


    }

}
