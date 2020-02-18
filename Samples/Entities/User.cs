using System;

namespace Samples.Entities
{
    public class User
    {
        public int Id { get;}
        public string Name { get; }
        public DateTime ModifiedDate { get; set; } 

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
