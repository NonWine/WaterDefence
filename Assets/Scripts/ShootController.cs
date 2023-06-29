using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Transform _cameraPosSpawnBullet;
    [SerializeField] private BulletU _bullet;
    private Image filledImage,buttonImage;
    private Camera _CashedCamera;
    private bool canShoot = true, hold;
    private float timer = 0f, tutortimer;
    private int _weaponIndex =0;
    private bool trig;
    private void Start()
    {
        _CashedCamera = Camera.main;
    }
    

    public void ShootWep()
    {
       // BulletU bullet = _bullet;
         //   trig = true;
            timer += Time.deltaTime;
        if (timer > _bullet.Stats.GetCD()) 
        {
            Ray ray = _CashedCamera.ScreenPointToRay(Input.mousePosition);
           // if (Physics.Raycast(ray, out RaycastHit hit))
           // {
                for (int i = 0; i < _bullet.Stats.GetCount(); i++)
                {
                    Transform spawnPos = _cameraPosSpawnBullet;
                    BulletU newBullet = Instantiate(_bullet, spawnPos.position, Quaternion.identity);
                    newBullet.Shoot(spawnPos);
                }
            //}
            timer = 0f;
        }
    }
}
