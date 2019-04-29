using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    interface IBattle
    {
       Weapon MyWeapon { get; set; }
        BattleEnum BattleType { get; set; }

        int Attack();
        int Defend();


    }
}
