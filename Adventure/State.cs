using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public class State
    {
        public const int NEW = 1;
        public const int IN_PROGRESS = 2;
        public const int COMPLETE_REWARD_AVAIL = 3;
        public const int COMPLETE_NO_REWARD = 4;
    }
}
