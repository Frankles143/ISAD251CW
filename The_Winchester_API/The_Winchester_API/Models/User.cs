using System;
using System.Collections.Generic;

namespace The_Winchester_API
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte Admin { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
