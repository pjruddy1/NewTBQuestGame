using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQUESTGame.Models;

namespace TBQUESTGame.DataLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Name = "PJ",
                HitPoints = 100,
                Lives = 5,
                Gold = 25,
                WeaponCarried = Player.Items.BowieKnife,
                ItemCarried = Player.Items.Rope,
                
            };
        }

        public static List<string> InitialMessages()
        {
            return new List<string>()
            {
                "\tAfter a 14 hour flight from northern Michigan you land in San Pedro, Belize.  You quickly meet up with friends that you haven't seen in years. There's a bunch of commosion coming from all your friends standing in a circle.  As you walk up John " +
                "quickly runs up to you and informs you that Sally was murdered",
                "\tYou will need to go from neighborhood to neighborhood to find out more about what happened to Sally and who is behind it."
            };
        }
    }
}
