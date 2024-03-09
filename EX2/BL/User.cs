using EX2.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EX2.BL
{
    public class User
    {

        string firstName;
        string familyName;
        string email;
        string password;
        bool isActive;
        bool isAdmin;
        static List<User> UsersList = new List<User>();


        public User() { }
        public User(string firstName, string familyName, string email, string password, bool isActive, bool isAdmin)
        {
            FirstName = firstName;
            FamilyName = familyName;
            Email = email;
            Password = password;
            IsActive = isActive;
            IsAdmin = isAdmin;

        }

        public string FirstName { get => firstName; set => firstName = value; }
        public string FamilyName { get => familyName; set => familyName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }

        public int InsertUser()
        {
            DBservices dbs = new DBservices();
            UsersList.Add(this);
            return dbs.InsertUser(this);

        }

        public List<User> ReadUsers()
        {
            DBservices dbs = new DBservices();
            return dbs.ReadUsers();
        }



        public User CheckLogin()
        {
            DBservices dbs = new DBservices();
            return dbs.CheckLogin(this);
        }


        public int UpdateUser(string email, string newFirstName, string newFamilyName, string newPassword)
        {
            // Find the user in the UsersList by email
            User userToUpdate = UsersList.Find(u => u.Email == email);

            if (userToUpdate != null)
            {
                // Update user information
                userToUpdate.FirstName = newFirstName;
                userToUpdate.FamilyName = newFamilyName;
                userToUpdate.Password = newPassword;

                // Update in the database (assuming DBservices has an UpdateUser method)
                DBservices dbs = new DBservices();
                return dbs.UpdateUser(userToUpdate);
            }
            else
            {
                // User not found
                return -1;
            }
        }
    }
}
