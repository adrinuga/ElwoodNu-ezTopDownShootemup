using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{

    [SerializeField] private SpriteRenderer m_MyGunRenderer;

    public int m_clickButton = 0;

    public bool 
        m_isLoaded = true,
        m_isReloading = false
        ;

   

    [SerializeField] private WeaponFather m_defaultWeapon;
    [HideInInspector]public WeaponFather m_actualWeapon;

    [SerializeField] private Bullet m_defaultBullet;
    [HideInInspector] public Bullet m_actualBullet;

    private float 
        m_actualReloadTime,
        m_actualWeaponHeat
        ;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon(m_defaultWeapon,  m_defaultBullet);
    }

    // Update is called once per frame
    void Update()
    {
      
        switch (m_actualWeapon.m_WeaponLoadType)
        {
            case (WeaponFather.LoadTypes.Auto):

                if(Input.GetMouseButton(m_clickButton) && m_isLoaded)
                {
                    Shoot(true);
                }
                break;

            case (WeaponFather.LoadTypes.SemiAuto):

                if (Input.GetMouseButtonDown(m_clickButton) && m_isLoaded )
                {
                    Shoot( true);
                }
                break;

            case (WeaponFather.LoadTypes.ClickReload):
                if (Input.GetMouseButtonDown(m_clickButton) && !m_isReloading)
                { 
                    if (m_isLoaded)
                    {
                        Shoot(false);

                        m_isLoaded = false;
                    }
                    else
                    {
                        
                            StartCoroutine(Reload());
                    }
                }

                break;

            case (WeaponFather.LoadTypes.OnClick):

                if (Input.GetMouseButtonDown(m_clickButton))
                {
                    Shoot(false);
                    
                }
                break;

        }
    }


    public void Shoot( bool _startReload)
    {
       
       

        StartCoroutine(ShootInBurst(m_actualWeapon.m_HowManyBursts));

      

       
        if (_startReload)
        {
            m_isLoaded = false;
            StartCoroutine(Reload());
            
        }
    }
    void CreateBullet(Vector3 _direction, Vector3 l_spawnPosition)
    {
        Bullet l_newBullet;

        _direction = AddRandomness(m_actualWeapon.m_FailBiassPerShot, _direction);
        Debug.Log(_direction);
        Quaternion l_ShootRotationOnDir = RotationToDirection(_direction);

        float l_damage = m_actualWeapon.m_DefaultDamage / m_actualWeapon.m_HowManyShots;

        l_newBullet = Instantiate(m_actualBullet.gameObject, l_spawnPosition, l_ShootRotationOnDir).GetComponent<Bullet>();

        l_newBullet.SetBullet(_direction, l_damage, m_actualWeapon.m_BulletSprite, m_actualWeapon.m_bulletSpeedDecrease,
            m_actualWeapon.m_projectileSpeed, m_actualWeapon.m_BulletSize, m_actualWeapon.m_KnockBackForce);
    }

    IEnumerator ShootInBurst(int _burstNumber)
    {
        int l_burstCounter = 0;

        while (l_burstCounter < _burstNumber)
        {
            for (int i = 0; i < m_actualWeapon.m_HowManyShots; i++)
            {
                Vector3 _dir = GetMouseDir(this);
                CreateBullet(_dir, GetSpawnPosition(_dir));
            }

           
            
            yield return new WaitForSeconds(m_actualWeapon.m_TimeBetweenShoots / 2);

            l_burstCounter++;


        }


    }

    IEnumerator Reload()
    {
        m_isReloading = true;

       

        

        m_actualReloadTime = m_actualWeapon.m_TimeBetweenShoots * m_actualWeapon.m_HowManyBursts;

        float l_originalTotal = m_actualReloadTime;

        GameManager.m_instance.m_SceneUI.m_WeaponReloadFill1.fillAmount = 1;

        while (m_actualReloadTime > 0)
        {
            yield return null;

            m_actualReloadTime -= Time.deltaTime;

            Debug.Log(l_originalTotal / m_actualReloadTime);

            GameManager.m_instance.m_SceneUI.m_WeaponReloadFill1.fillAmount = m_actualReloadTime / l_originalTotal;
        }

        GameManager.m_instance.m_SceneUI.m_WeaponReloadFill1.fillAmount = 0;

        m_isReloading = false;

        m_isLoaded = true;

    }
    Vector3 GetSpawnPosition(Vector3 _dir)
    {
        Vector3 l_spawn = transform.position + _dir * m_MyGunRenderer.size.x;
        l_spawn.z = 0;
        return l_spawn;
    }
    Vector3 GetMouseDir(GunController _gunRef)
    {
        Vector3 l_MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        l_MousePos.z = 0;
        Vector3 l_startPos = _gunRef.transform.position;
        l_startPos.z = 0;

        return (l_MousePos - l_startPos).normalized;
    }
    Quaternion RotationToDirection(Vector3 _dir)
    {
        Quaternion l_finalRot = new Quaternion();
        float rot_z = Mathf.Atan2(_dir.y, _dir.x) * Mathf.Rad2Deg;
        l_finalRot = Quaternion.Euler(0f, 0f, rot_z);
        l_finalRot.x = 0;
        l_finalRot.y = 0;
        return l_finalRot;
    }
    Vector3 AddRandomness(float _randomness, Vector3 _dir )
    {
        Vector3 l_random = Random.insideUnitSphere;
        l_random.z = 0;
        _dir += l_random * _randomness;
        Debug.Log(_dir);
        return _dir;
    }
        public void ChangeWeapon(WeaponFather _NewWeapon, Bullet m_NewBullet )
    {
        m_actualWeapon = _NewWeapon;
        m_MyGunRenderer.sprite = m_actualWeapon.m_MySprite;

       

        m_actualBullet = m_NewBullet;

    }

}
