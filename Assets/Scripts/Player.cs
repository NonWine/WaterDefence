using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] private CameraFollowing cameraFollow;
    [SerializeField] private int health;
    private ShootController shootController;
    private HealthUI playerUI;
    private float timer;

    private void Awake()
    {
        Instance = this;
        cameraFollow.GetPlayer(transform);
    }
    
    private void Start()
    {
        shootController = GetComponent<ShootController>();
        //    weapon = GetComponent<Weapon>();
        playerUI = GetComponent<HealthUI>();
        playerUI.SetHealth(health);

    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            shootController.ShootWep();
        }
    }
 
    public void GetDamage(int dmg)
    {
       
       
        health -= dmg;
     
        playerUI.GetDamageUI((float)dmg);
        if (health <= 0)
        {
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<PlayerController>().enabled = false;
            GameManager.Instance.GameLose(); 
        }
           
    }
    
  
}