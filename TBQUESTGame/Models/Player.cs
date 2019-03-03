using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Player
    {
        public enum Items
        {
            None, Machette, BowieKnife, Pistol, Riffle, Bat, Hammer, BoltCutters, Rope, GrapplingHook, Banana, BBQMeat, Melon
        }

        private string _name;
        private int _hitPoints;
        private int _gold;
        private Items _weaponCarried;
        private Items _itemCarried;
        private Items _backPackItem1;
        private Items _backPackItem2;
        private Items _backPackItem3;
        private Items _backPackItem4;
        private Items _backPackItem5;
        private int _lives;

        public int Lives
        {
            get { return _lives; }
            set { _lives = value; }
        }


        public Items BackPackItem5
        {
            get { return _backPackItem5; }
            set { _backPackItem5 = value; }
        }


        public Items BackPackItem4
        {
            get { return _backPackItem4; }
            set { _backPackItem4 = value; }
        }


        public Items BackPackItem3
        {
            get { return _backPackItem3; }
            set { _backPackItem3 = value; }
        }


        public Items BackPackItem2
        {
            get { return _backPackItem2; }
            set { _backPackItem2 = value; }
        }


        public Items BackPackItem1
        {
            get { return _backPackItem1; }
            set { _backPackItem1 = value; }
        }


        public Items ItemCarried
        {
            get { return _itemCarried; }
            set { _itemCarried = value; }
        }


        public Items WeaponCarried
        {
            get { return _weaponCarried; }
            set { _weaponCarried = value; }
        }

        public int Gold
        {
            get { return _gold; }
            set { _gold = value; }
        }

        public int HitPoints
        {
            get { return _hitPoints; }
            set { _hitPoints = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
