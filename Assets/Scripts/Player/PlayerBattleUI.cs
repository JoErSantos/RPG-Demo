using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerBattleUI : MonoBehaviour , IBattleUI
{
    [SerializeField]
    private GameObject battleUI;
    
    //Stas
    [SerializeField]
    private TextMeshProUGUI name;
    [SerializeField]
    private TextMeshProUGUI level;
    [SerializeField]
    private TextMeshProUGUI hp;
    [SerializeField]
    private TextMeshProUGUI ep;

    //bars
    [SerializeField]
    private RectTransform hpBar;
    [SerializeField]
    private RectTransform epBar;

    //Buttons
    [SerializeField]
    private Button AttackBtn;
    [SerializeField]
    private Button DefendBtn;
    [SerializeField]
    private Button RunBtn;


    private CharacterStatsController currentPlayer;
    private CharacterStatsController currentTarget;

    private BattleController battleController;
    
    void Start()
    {
        battleController = GetComponent<BattleController>();
        battleUI.SetActive(false);
        AttackBtn.onClick.AddListener(attackTarget);
    }

    public void ToogleBattleUI(bool flag)
    {
        battleUI.SetActive(flag);
    }

    public void setCurrentPlayer(CharacterStatsController player)
    {
        currentPlayer = player;
        updateCurrentPlayerStast();
    }

    public void setCurrentTarget(CharacterStatsController target)
    {
        currentTarget = target;
    }

    private void updateCurrentPlayerStast()
    {
        level.text = "Lv. " + currentPlayer.getCharacterSheet().level;
        updateHpBar();
        updateEpBar();
    }

    public void updateHpBar()
    {
        float percentage = (float)currentPlayer.getCharacterSheet().currentHP / currentPlayer.getCharacterSheet().MaxHP;
        percentage = Mathf.Max(percentage,0);
        hp.text = currentPlayer.getCharacterSheet().currentHP + " / " + currentPlayer.getCharacterSheet().MaxHP;
        hpBar.localScale = new Vector3(percentage,1,1) ;
    }

    public void updateEpBar()
    {
        float percentage = (float)currentPlayer.getCharacterSheet().currentEP / currentPlayer.getCharacterSheet().MaxEP;
        percentage = Mathf.Max(percentage,0);
        hp.text = currentPlayer.getCharacterSheet().currentEP + " / " + currentPlayer.getCharacterSheet().MaxEP;
        epBar.localScale = new Vector3(percentage,1,1) ;
    }

    public async Task showDmgTakenAsync(int dmg)
    {
        Debug.Log(dmg);
        await Task.Delay(1000);
    }

    private void attackTarget()
    {
        battleController.AttackManager(currentPlayer,currentTarget);
        disableBtns();
    }

    private void disableBtns()
    {
        battleController.tooglePlayerTurn(false);
        AttackBtn.interactable = false;
        DefendBtn.interactable = false;
        RunBtn.interactable = false;
    }

    public void enableBtns()
    {
        AttackBtn.interactable = true;
        DefendBtn.interactable = true;
        RunBtn.interactable = true;
    }
}
