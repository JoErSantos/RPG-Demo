using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Types;

public class weaknesChart
{
    public weaknesChart()
    {
        
    }

    public weaknesChart(weaknessType bluntWeakness, weaknessType slashWeakness, weaknessType pierceWeakness,
        weaknessType fireWeakness, weaknessType iceWeakness , weaknessType windWeakness, weaknessType poisonWeakness,
        weaknessType blessedWeakness, weaknessType cursedWeakness ,weaknessType magicWeakness)
    {
        blunt = bluntWeakness;
        slash = slashWeakness;
        pierce = pierceWeakness;
        fire = fireWeakness;
        ice = iceWeakness;
        wind = windWeakness;
        poison = poisonWeakness;
        blessed = blessedWeakness;
        cursed = cursedWeakness;
        magic = magicWeakness;
    }
    
    private weaknessType blunt = weaknessType.neutral;
    private weaknessType slash = weaknessType.neutral;
    private weaknessType pierce = weaknessType.neutral;
    private weaknessType fire = weaknessType.neutral;
    private weaknessType ice = weaknessType.neutral;
    private weaknessType wind = weaknessType.neutral;
    private weaknessType poison = weaknessType.neutral;
    private weaknessType blessed = weaknessType.neutral;
    private weaknessType cursed = weaknessType.neutral;
    private weaknessType magic = weaknessType.neutral;

    public List<weaknessType> getWeaknessesTable(){
        return new List<weaknessType>(){
            blunt,
            slash,
            pierce,
            fire,
            ice,
            wind,
            poison,
            blessed,
            cursed,
            magic
        };
    }
}