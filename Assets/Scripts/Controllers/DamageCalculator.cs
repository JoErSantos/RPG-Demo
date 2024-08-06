using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Types;

public static class DamageCalculator
{
    public static int CalculateDmg(int moveStrength,AttackContactType contactType,AttackType attackType, 
        ICharacterProperties attacker,ICharacterProperties target)
    {
        int dmgDealt = 0;
        int dmgMultiplier = (int)target.weaknesses.getWeaknessesTable()[(int)attackType] / 10;
        if(contactType == AttackContactType.Physical)
            dmgDealt = ((moveStrength * attacker.stregth) - (target.defense * 2)) * dmgMultiplier;
        else
            dmgDealt = ((moveStrength * attacker.magic) - ((target.defense * 2) + target.magic/2)) * dmgMultiplier;

        target.ReciveDmg(dmgDealt);

        return dmgDealt;
    }
}
