using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Canon : MonoBehaviour
{
    [SerializeField] private GameObject destroyedCanon;
    [SerializeField] private GameObject mainCanon;
    [SerializeField] private float _health;
    [SerializeField] private GameObject  _headRotation;
    [SerializeField] private float speedRotation;
    [SerializeField] private PersonBullet _bullet;
    [SerializeField] private Rigidbody[] _roots;
    [SerializeField] private Transform _bulletSpawnPosition;
    private Transform _target;
    private HealthUI healthUI;
    private float elapsedTime;
    private Detector _detector;
    private bool Noticed { get; set; }
    private bool isDeath;

    private void Awake()
    {
       

    }

    private void Start()
    {
        EnemyList.Instance.AddCountCanon();
        _detector = GetComponent<Detector>();
        healthUI = GetComponent<HealthUI>();
        healthUI.SetHealth(_health);
        _target = Camera.main.transform;
        Noticed = true;
    }

    private void Update()
    {
        _detector.TryFindTheNearlestEnemy();
        if (_detector.isDetected())
        {
            if (!isDeath)
            {
                Vector3 dir = (_target.position ) - _headRotation.transform.position;
                Quaternion rot = Quaternion.Slerp(_headRotation.transform.rotation, Quaternion.LookRotation(dir), speedRotation * Time.deltaTime);
                _headRotation.transform.rotation = rot;
            }

            if (Noticed)
            {
                elapsedTime += Time.fixedDeltaTime;
                if (elapsedTime >= _bullet.GetCooldown())
                {
                    //ParticlePool.Instance.PlayCanonShoot(_headRotation.transform.GetChild(0).transform.position);
                    PersonBullet Prefab = Instantiate(_bullet, _bulletSpawnPosition.position, Quaternion.identity);
                    elapsedTime = 0;
          
                    Prefab._endPos = _target.position;
                    // Destroy(Prefab, 5f);
                }

            }
        }
   
    }

    public void GetDamage(int damage)
    {
        _health -= damage;
        healthUI.GetDamageUI((float)damage);
        if (_health <= 0f)
        {
            mainCanon.gameObject.SetActive(false);
            destroyedCanon.gameObject.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            foreach (var item in _roots)
            {
                item.freezeRotation = false;
                item.isKinematic = false;
                item.WakeUp();
                item.AddForce(new Vector3(Random.Range(-4, 4), Random.Range(0, 10), Random.Range(-4, 4)), ForceMode.VelocityChange);
            }
            GetComponent<Canon>().enabled = false;
            EnemyList.onKilledCanon?.Invoke();
            Destroy(gameObject,5f);
        }
    }
    
}