
using UnityEngine;
public class BulletU : MonoBehaviour
{
    [SerializeField] private float _SpeedLerp =3f;
    [SerializeField] private Vector3 forceContacted;
    [field: SerializeField]  public WeaponStats Stats { get; private set; }

    private Rigidbody myBody;
    private Vector3 _startPos, veloc;
    private bool coll,hittied;
    private void Awake()
    {
     
        myBody = GetComponent<Rigidbody>();
        veloc = myBody.velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        ParticlePool.Instance.PlayCanonShoot(transform.position);

        if (other.gameObject.CompareTag("Person"))
        {
            
            other.gameObject.GetComponent<Person>().TakeDamage(veloc, Stats.GetForce() + 50);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Canon"))
        {
            Destroy(gameObject);
            other.GetComponent<Canon>().GetDamage(Stats.GetDamage());
        }
            
    }
    
    private void OnCollisionEnter(Collision collision)
    {
       
        if ((collision.gameObject.CompareTag("Ground") ||  collision.gameObject.CompareTag("Castle") && !coll))
        {
          
            myBody.velocity = new Vector3(Random.Range(-forceContacted.x, forceContacted.x), forceContacted.y,
                forceContacted.z);
              //  myBody.AddForce(new Vector3(Random.Range(-forceContacted.x,forceContacted.x),forceContacted.y,forceContacted.z),ForceMode.Force);
                if (collision.transform.CompareTag("Castle") )
                {
                  Debug.Log("coll");
                        Explode();
                        ParticlePool.Instance.PlayCanonShoot(transform.position);
                         Destroy(gameObject,2f);
                }
                if(collision.transform.CompareTag("Ground"))
                    Destroy(gameObject);
            
        }

        if (collision.transform.CompareTag("Box"))
        {
            collision.transform.GetComponent<ExpllodeObject>().Explode();
            Destroy(collision.gameObject);
        }
     
    }

    public void Shoot(Transform target)
    {
        _startPos = transform.position;
        transform.LookAt(target, Vector3.forward);
        myBody.velocity = target.forward * _SpeedLerp;
    }

    public void Explode()
    {
        Debug.Log("asdas");
        Collider[] OverLapColliders = Physics.OverlapSphere(transform.position, Stats.GetRadius());
        for (int i = 0; i < OverLapColliders.Length; i++)
        {
            Rigidbody rb = OverLapColliders[i].attachedRigidbody;
            if (rb && OverLapColliders[i].CompareTag("Castle"))
            {
                Debug.Log("damage");
                
               SupportGravity obj = OverLapColliders[i].GetComponent<SupportGravity>();
               obj.GetDamage(new Vector3(Random.Range(-6, 6), Random.Range(2, 10), Random.Range(-6, 6)),Stats.GetDamage());

            }
        }
        myBody.useGravity = true; 
        myBody.isKinematic = false;
        coll = true;
    }
    
    
    private void SetActimeFalseByTime() => gameObject.SetActive(false);
}
