using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class EnemyUIController : MonoBehaviour , IBattleUI
{
    [SerializeField]
    private GameObject hpBarUi;
    [SerializeField]
    private RectTransform hpBar;
    [SerializeField]
    private GameObject dmgTag;
    private CharacterStatsController enemyStats;

    void Start()
    {
        enemyStats = GetComponent<CharacterStatsController> ();
    }

    public void ToogleHpBar(bool flag)
    {
        hpBarUi.SetActive(flag);
    }

    public void updateHpBar()
    {
        float percentage = (float)enemyStats.getCharacterSheet().currentHP / enemyStats.getCharacterSheet().MaxHP;
        percentage = Mathf.Max(percentage,0);
        hpBar.localScale = new Vector3(percentage,1,1) ;
    }

    public async Task showDmgTakenAsync(int dmg)
    {
        dmgTag.SetActive(true);
        dmgTag.GetComponent<TextMeshProUGUI> ().text = '-' + dmg.ToString();
        await Task.Delay(1000);
        dmgTag.SetActive(false);
    }

}
