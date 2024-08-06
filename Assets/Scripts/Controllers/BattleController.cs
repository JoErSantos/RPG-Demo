using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField]
    private List<CharacterStatsController> party;
    private List<CharacterStatsController> enemys = new List<CharacterStatsController>();
    private PlayerBattleUI playerUI;

    private bool isPlayerTurn = false;

    private bool hasBattleStarted = false;

    private int turnNumber;

    void Start()
    {
        playerUI = GetComponent<PlayerBattleUI>();
        playerUI.setCurrentPlayer(party[0]);
    }

    void Update()
    {
        if(hasBattleStarted)
        {
            InvokeRepeating("turnController", 3f, 2f);
        }
    }

    public void StartBattle(GameObject enemy, bool advantage)
    {
        enemy.GetComponent<EnemyUIController>().ToogleHpBar(true);
        playerUI.ToogleBattleUI(true);
        enemys = new List<CharacterStatsController>
        {
            enemy.GetComponent<CharacterStatsController>()
        };
        playerUI.setCurrentTarget(enemys[0]);
        isPlayerTurn = advantage;
        turnNumber = 1;
        hasBattleStarted = true;
    }

    public async void AttackManager(CharacterStatsController attacker, CharacterStatsController target)
    {
        int dmg = target.Attacked(attacker.getCharacterSheet());
        target.gameObject.GetComponent<IBattleUI>().updateHpBar();
        await target.gameObject.GetComponent<IBattleUI>().showDmgTakenAsync(dmg);
        await Task.Delay(5000);
    }

    public void turnController()
    {
        if(isPlayerTurn)
        {
            playerUI.enableBtns();
            CancelInvoke();
        }
        else
        {
            
            foreach(CharacterStatsController enemy in enemys)
            {
                AttackManager(enemy,party[0]);
            }
            isPlayerTurn = true;
        }
    }

    public List<CharacterStatsController> GetEnemys()
    {
        return enemys;
    }

    public CharacterStatsController getCurrentTurnPartyMemeber()
    {
        return party[0];
    }

    public void tooglePlayerTurn(bool flag)
    {
        isPlayerTurn = flag;
    }
}
