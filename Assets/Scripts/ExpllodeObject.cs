using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ExpllodeObject : MonoBehaviour
{
    [SerializeField] private float _radiusExplode;
    [SerializeField] private int _damage;
    [SerializeField] private Vector3 forceExplode;
    public void Explode()
    {
        ParticlePool.Instance.PlayBoxExplose(transform.position);
        Collider[] OverLapColliders = Physics.OverlapSphere(transform.position, _radiusExplode);
        for (int i = 0; i < OverLapColliders.Length; i++)
        {
            Rigidbody rb = OverLapColliders[i].attachedRigidbody;
            if (rb )
            {
                if (OverLapColliders[i].CompareTag("Castle"))
                {
                    SupportGravity obj = OverLapColliders[i].GetComponent<SupportGravity>();
                    obj.GetDamage(new Vector3(Random.Range(-8, 8), Random.Range(10, 20), Random.Range(-8, 8)),_damage);
                    
                }

                if (OverLapColliders[i].CompareTag("Person"))
                {
                    OverLapColliders[i].GetComponent<Person>().TakeDamage(new Vector3(Random.Range(-8, 8), Random.Range(10, 20), Random.Range(-8, 8)),100f);
                }
             
            }
        }
    }
}
