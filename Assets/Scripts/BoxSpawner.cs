using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private ExpllodeObject box;
    [SerializeField] private Transform[] points;
    [SerializeField] private int count;
    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            ExpllodeObject prefabBox = Instantiate(box, points[Random.Range(0,points.Length)].position, Quaternion.identity);
        }
    }
}
