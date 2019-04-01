using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public class Player : Character
    {
        protected int _expierencePnts;
        protected int _lives;
        protected Items _backPackItem1;
        protected Items _backPackItem2;
        protected Items _backPackItem3;
        protected Items _backPackItem4;
        protected Items _backPackItem5;
        private List<Location> _locationsVisited;

        public List<Location> LocationsVisited
        {
            get { return _locationsVisited; }
            set { _locationsVisited = value; }
        }

        public int ExpierencePnts
        {
            get { return _expierencePnts; }
            set
            {
                _expierencePnts = value;
               OnPropertyChanged(nameof(ExpierencePnts));
            }
        }

        public int Lives
        {
            get { return _lives; }
            set
            {
               _lives = value;
                OnPropertyChanged(nameof(Lives));
            }
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

        public Player()
        {
            _locationsVisited = new List<Location>();
        }

        public override string DefaultGreeting()
        {
            return base.DefaultGreeting();
        }

        public bool HasVisited(Location location)
        {
            return _locationsVisited.Contains(location);
        }

        
    }
}
