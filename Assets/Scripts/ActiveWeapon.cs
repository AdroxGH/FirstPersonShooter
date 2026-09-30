using UnityEngine;
using StarterAssets;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    Animator animator;

    StarterAssetsInputs starterAssetsInputs;
    Weapon currentWeapon;
    float timeSinceLastShot = 0f;
    const string SHOOT_STRING = "Shoot";
    void Awake()
    {
        starterAssetsInputs = GetComponentInParent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentWeapon = GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        HandleShoot();
        timeSinceLastShot =+ Time.deltaTime;
    }

    void HandleShoot()
    {
        if (!starterAssetsInputs.shoot) return;

        if(timeSinceLastShot >= weaponSO.FireRate)
        {
            currentWeapon.Shoot(weaponSO);
            animator.Play(SHOOT_STRING, 0, 0f);
            timeSinceLastShot = 0f;
        }

        starterAssetsInputs.ShootInput(false);
        
    }
}
