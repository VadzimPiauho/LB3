using System;   

namespace Bankomat
{
    namespace Clientspace
    {
        class Client
        {
            public Bankomat.Accountspace.Account objAccount;
            public string firstName { get; set; } = "default";
            public string lastName { get; set; } = "default";

            public Client(string firstName, string lastName)
            {
                this.firstName = firstName;
                this.lastName = lastName;
            }
        }
    }
}
