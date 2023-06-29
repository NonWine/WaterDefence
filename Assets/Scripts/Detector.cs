using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private string[] _tag;
    [SerializeField] private int _radius;
    private  bool inTrigger;
    private Vector3 closestTarget;
    private Transform tardetDetected;
    private float point;
    
    private void Start()
    {
        point = Mathf.Infinity;
        closestTarget = Vector3.zero;
    }


    public void TryFindTheNearlestEnemy()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) < _radius)
        {
            inTrigger = true;
        }
        else
        {

            inTrigger = false;
        }
        // Debug.Log("asDSA");
        // Collider[] enemys = Physics.OverlapSphere(transform.position, _radius);
        // foreach (var item in enemys)
        // {
        //     if (CheckTag(item.transform))
        //     {
        //         Debug.Log("TRIG");
        //             inTrigger = true;
        //             break;
        //     }
        //     else
        //         inTrigger = false;
        // }
    }

    
    public void IncreaseRadius(int value)
    {
        _radius += value;
        PlayerPrefs.GetInt("ArcherRadius", _radius);
    }

    public void SetRadius(int value) => _radius = value;
    public  bool isDetected() { return inTrigger; }
    public void SetDetected(bool flag) => inTrigger = flag;
    public  Transform GetTargetInfo() { return tardetDetected; }

    public void DeleteTarget() { tardetDetected = null; inTrigger = false; }

    public void setPointInfinity() => point = Mathf.Infinity;

   // public string GetTag() { return _tag; }

    public bool CheckTag(Transform obj)
    {
        foreach (var item in _tag)
        {
            if (obj.transform.tag == item)
                    return true;
              
        }
        return false;
    }
}
