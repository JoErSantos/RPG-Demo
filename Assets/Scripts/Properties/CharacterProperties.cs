using System;

public class CharacterProperties : ICharacterProperties
{
    //Constructor
    //i stands for inital
    public CharacterProperties(int iLevel, int iMaxHP, int iMaxEP,
        int iStregth, int iMagic, int iSpeed, int iDefense, int iVitality, int iLuck,
        weaknesChart iweaknesses)
    {
        level = iLevel;
        MaxHP = iMaxHP + (5 * iVitality);
        MaxEP = iMaxEP + (5 * iMagic);

        stregth = iStregth;
        magic = iMagic;
        speed = iSpeed;
        defense = iDefense;
        vitality = iVitality;
        luck = iLuck;

        currentHP = MaxHP;
        currentEP = MaxEP;

        weaknesses = iweaknesses;
    }

    //Base properties
    public int level { get; set; }
    public int MaxHP { get; set; }
    public int MaxEP { get; set; }

    //Stats
    public int stregth { get; set; }
    public int magic { get; set; }
    public int speed { get; set; }
    public int defense { get; set; }
    public int vitality { get; set; }
    public int luck { get; set; }

    //Calcultaion helpers
    public int currentHP { get; set; }
    public int currentEP { get; set; }
    public float penalizer { get; set; }
    public int penalizerId { get; set; }
    public weaknesChart weaknesses { get; set; }

    public void ReciveDmg(int dmg)
    {
        currentHP -= dmg;
        currentHP = (int)MathF.Max(currentHP,0);
    }


    public void useEP(int usedEP)
    {
        currentEP -= usedEP;
        currentEP = (int)MathF.Max(currentEP,0);
    }
}
