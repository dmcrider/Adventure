using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public enum State
    {
        NEW = 1,
        IN_PROGRESS = 2,
        COMPLETE_REWARD_AVAIL = 3,
        COMPLETE_NO_REWARD = 4
    }
}
