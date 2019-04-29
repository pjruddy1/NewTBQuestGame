using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;


namespace TBQUESTGame.Models
{
    interface ITrade
    {
       
        ObservableCollection<GameItemQuantity> Inventory { get; set; }

        bool MakeTrade(GameItemQuantity currentGameItem);

    }
}
