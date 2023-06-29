using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBase : MonoBehaviour
{
    private void Start()
    {
        EnemyList.Instance.AddCountBase();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Missile"))
        {
            EnemyList.onKilledMainBase?.Invoke();
            
        }
    }
}
