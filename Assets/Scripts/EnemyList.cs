using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyList : MonoBehaviour
{
    public static EnemyList Instance { get; private set; }
    [SerializeField] private TMP_Text _enemyText;
    [SerializeField] private TMP_Text canonText;
    [SerializeField] private TMP_Text mainBaseText;
    public static Action onKilledEnemy;
    public static Action onKilledCanon;
    public static Action onKilledMainBase;
    private int currentEnemy;
    private int currentCanon;
    private int currentBase;
    private  int _counterEnemy;
    private  int _counterCanon;
    private  int _counterBase;
    private bool isKilledEnemy, isKilledCanon, isKilledBase;
    private void Awake()
    {
        Instance = this;
        onKilledEnemy += ReduceEnemy;
        onKilledCanon += ReduceCanon;
        onKilledMainBase += ReduceMainBAse;
    }

    private void Start()
    {
        
       // canonText.text = currentCanon.ToString() + "/" + _counterCanon.ToString();
      //  mainBaseText.text = currentBase.ToString() + "/" + _counterBase.ToString();

    }



    public void AddCountEnemy()
    {
        _counterEnemy++;
        _enemyText.text = currentEnemy.ToString() + "/" + _counterEnemy.ToString();

    }

    public   void AddCountCanon()
    {
        _counterCanon++;
        canonText.text = currentCanon.ToString() + "/" + _counterCanon.ToString();
    }

    public   void AddCountBase()
    {
        _counterBase++;
        mainBaseText.text = currentBase.ToString() + "/" + _counterBase.ToString();

    }


    private void ReduceMainBAse()
    {
        currentBase++;
        mainBaseText.text = currentBase.ToString() + "/" + _counterBase.ToString();
        if (currentBase == _counterBase)
            isKilledBase = true;
        CheckGameWin();
    }
    
    private void ReduceCanon()
    {
        currentCanon++;
        canonText.text = currentCanon.ToString() + "/" + _counterCanon.ToString();
        if (currentCanon == _counterCanon)
            isKilledCanon = true;
        CheckGameWin();
    }

    private  void ReduceEnemy()
    {
        currentEnemy++;
        _enemyText.text = currentEnemy.ToString() + "/" + _counterEnemy.ToString();
        if (currentEnemy == _counterEnemy)
            isKilledEnemy = true;
        CheckGameWin();
    }

    private void CheckGameWin()
    {
        if(isKilledBase && isKilledCanon && isKilledEnemy)
            GameManager.Instance.GameWin();
    }

    private void OnDestroy()
    {
        onKilledEnemy -= ReduceEnemy;
        onKilledCanon -= ReduceCanon;
        onKilledMainBase -= ReduceMainBAse;
    }
}
