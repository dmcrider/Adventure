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
        ACCEPTED = 2,
        IN_PROGRESS = 3,
        COMPLETE_REWARD_AVAIL = 4,
        COMPLETE_NO_REWARD = 5,
        COMPLETE_ONLY_ITEM = 6,
        CAN_COMPLETE = 7
    }
}
