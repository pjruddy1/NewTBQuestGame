using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQUESTGame.Models
{
    public interface ICommunicate
    {
        List<string> Messages { get; set; }

        string CurrentMessage();       
        
    }
}
