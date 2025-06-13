using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLib.Models
{

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }
    }

    public class UserListResponse
    {
        public int Page { get; set; }
        public List<User> Data { get; set; }
    }

    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public class CreateUserResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public string CreatedAt { get; set; }
    }
    public class SingleUserResponse
    {
        public User? Data { get; set; }
    }

}
