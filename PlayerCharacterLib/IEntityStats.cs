using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayerCharacterLib
{
    // This is for the interface "IEntityStats". This is used by both the PlayerCharacter class and the Enemy class.

    public interface IEntityStats
    {
        int HP { get; set; }

        int StrengthStat { get; set; }

        int DefenseStat { get; set; }
    }
}
