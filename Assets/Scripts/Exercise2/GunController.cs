using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject missilePrefab;
    public Transform firePoint; 
    public float bulletSpeed = 10f;
    [SerializeField] int bulletPoolSize = 50;
    private Animator animator;
    public Queue<GameObject> bulletPool = new Queue<GameObject>();
    private HomingMissileController homingMissileController;
    private GameObject target;


    [Header("Muzzle Flash Settings")]
    public ParticleSystem muzzleFlashParticle; 
    public Transform muzzlePoint;

    


    [Header("Missile Setting")]
    public float speed = 20f;
    public float rotationSpeed = 1000f;

    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        homingMissileController = GetComponent<HomingMissileController>();
        for (int i = 0; i < bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            if (bullet != null)
            {
                bullet.SetActive(false);
                bulletPool.Enqueue(bullet);
            }
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlaySceneController.isPaused) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (bulletPool.Count > 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            homingMissileController.Skill_1(speed, rotationSpeed, firePoint);
        }   
        //if (Input.GetKeyDown(KeyCode.G) && playerSkillController.UseSkill("Ultimate") == true)
        //{   
        //    homingMissileController.activeUltimate(speed, rotationSpeed, firePoint, 20);
        //}
    }

    void Shoot()
    {
            GameObject bullet = bulletPool.Dequeue();
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            bullet.SetActive(true);
            rb.linearVelocity = firePoint.up * bulletSpeed;
            animator.SetTrigger("IsShoot");
            ShowMuzzleFlash();
    }

    public void DeactiveBullet(GameObject bullet)
    {
        
        bulletPool.Enqueue(bullet);
        bullet.SetActive(false);
        //Debug.Log("Bullet out of area");
    }

    void ShowMuzzleFlash()
    {
        //muzzleFlashParticle.transform.position = muzzlePoint.position;
        muzzleFlashParticle.Play();
    }

   

    



    
}
