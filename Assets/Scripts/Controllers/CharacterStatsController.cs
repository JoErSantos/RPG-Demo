using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using static Types;

public class CharacterStatsController : MonoBehaviour
{
    /////////////// STATS ///////////////////
    [SerializeField]
    private int baseLevel = 1;
    [SerializeField]
    private int baseHP = 100;
    [SerializeField]
    private int baseEP = 100;
    [SerializeField]
    private int baseStrength = 2;
    [SerializeField]
    private int baseMagic = 2;
    [SerializeField]
    private int baseSpeed = 2;
    [SerializeField]
    private int baseDefense = 2;
    [SerializeField]
    private int baseVitality = 2;
    [SerializeField]
    private int baseLuck = 2;

    /////////////// WEAKNESSES //////////////////
    [SerializeField]
    private weaknessType blunt = weaknessType.neutral;
    [SerializeField]
    private weaknessType slash = weaknessType.neutral;
    [SerializeField]
    private weaknessType pierce = weaknessType.neutral;
    [SerializeField]
    private weaknessType fire = weaknessType.neutral;
    [SerializeField]
    private weaknessType ice = weaknessType.neutral;
    [SerializeField]
    private weaknessType wind = weaknessType.neutral;
    [SerializeField]
    private weaknessType poison = weaknessType.neutral;
    [SerializeField]
    private weaknessType blessed = weaknessType.neutral;
    [SerializeField]
    private weaknessType cursed = weaknessType.neutral;
    [SerializeField]
    private weaknessType magic = weaknessType.neutral;


    /////////////// CharacterSheet ///////////////
    private CharacterProperties characterSheet;
    
    void Awake(){
        weaknesChart baseWeaknesses = new weaknesChart(blunt,slash,pierce,fire,ice,wind,poison,blessed,cursed,magic);
        characterSheet = new CharacterProperties(baseLevel, baseHP, baseEP, 
            baseStrength, baseMagic, baseSpeed, baseDefense, baseVitality, baseLuck, baseWeaknesses);
    }
    // Start is called before the first frame update
    public int Attacked(ICharacterProperties attacker)
    {
        return DamageCalculator.CalculateDmg(15,AttackContactType.Physical,AttackType.blunt,attacker,characterSheet);
    }

    // Update is called once per frame
    public ICharacterProperties getCharacterSheet()
    {
        return characterSheet;
    }
}
