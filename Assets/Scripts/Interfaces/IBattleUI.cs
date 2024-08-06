using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public interface IBattleUI
{   void updateHpBar();
    Task showDmgTakenAsync(int dmg);
}
