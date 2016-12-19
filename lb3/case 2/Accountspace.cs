using System;


namespace Bankomat
{
    namespace Accountspace
    {
        class Account
        {
            public uint accountNumber { get; set; } = 0;
            public uint pass { get; set; } = 0;
            public uint amount { get; set; } = 0;
            public Account(uint accountNumber, uint pass/*, uint amount*/)
            {
                this.accountNumber = accountNumber;
                this.pass = pass;
                // this.amount = amount;
            }
        }
    }
}
