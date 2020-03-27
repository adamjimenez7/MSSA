using System;
using System.Collections.Generic;

//Ended up not using this class, and just created users as type Tuple<string, string> in the NewUser class
namespace Exercise_9A
{
    class User
    {
        string UserName { get; set; }
        string UserPass { get; set; }

        public User(Tuple<string, string> user)
        {
            UserName = user.Item1;
            UserPass = user.Item2;
        }
    }
}