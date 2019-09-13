using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Instances
    {
        public static FormMain FormMain;
        public static FormShop FormShop;
        public static FormManageInventory FormManageInventory;
        public static FormWelcome FormWelcome;
        public static FormLogin FormLogin;
        public static FormSupport FormSupport;
        public static FormCharacterCreation FormCharacterCreation;

        public static GameController GameController;

        public static Player Player;
        public static Character Character;

#if DEBUG
        public static xDEV PanelDev;
#endif
    }
}
