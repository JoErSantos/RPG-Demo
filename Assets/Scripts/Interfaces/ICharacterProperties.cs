using System.Collections.Generic;
using static Types;

public interface ICharacterProperties
{
    //Basic properties
    int level { get; set; }
    int MaxHP { get; set; }
    int MaxEP { get; set; }

    //Stats
    int stregth { get; set; }
    int magic { get; set; }
    int speed { get; set; }
    int defense { get; set; }
    int vitality { get; set; }
    int luck { get; set; }

    //Calculators
    int currentHP { get; set; }
    int currentEP { get; set; }
    float penalizer { get; set; }
    int penalizerId { get; set; }
    weaknesChart weaknesses { get; set; }

    //Methods
    void ReciveDmg(int dmg);
    void useEP(int usedEP);
}

