using System;

namespace EntityMappingDemo.Domain
{
    [Flags]
    public enum WithdrawalType
    {
        None = 0,
        Transfer = 1,
        InStore = 2,
        Check = 4,
        ATM = 8
    }
}
