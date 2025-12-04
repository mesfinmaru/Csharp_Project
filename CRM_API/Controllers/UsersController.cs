using System;
using System.Linq;
using CRMdataLayer; // Import your data layer

namespace CRM_API.Controllers // Or wherever you are keeping this file
{
    public class UsersController
    {
        public bool Validate(string username, string password)
        {
            using (var db = new AppDBContext())
            {
                // Now this works because we added the properties to Users.cs in step 1
                return db.Users.Any(u => u.Username == username && u.Password == password);
            }
        }
    }
}