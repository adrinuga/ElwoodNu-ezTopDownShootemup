using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_MyGunRenderer;

    public enum PlayerAbilities
    {
        None,
        Teleport,
        CutDash,
        VortexGranade,
        Deflect,
        AkimboWeapons,
        SonicBoom
    }

    public bool m_isLoaded = true;

    public PlayerAbilities m_actualAbility = PlayerAbilities.None;

    [SerializeField] private WeaponFather m_defaultWeapon;
    [HideInInspector]public WeaponFather m_actualWeapon;

    [SerializeField] private Bullet m_defaultBullet;
    [HideInInspector] public Bullet m_actualBullet;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWeapon(m_defaultWeapon, PlayerAbilities.None, m_defaultBullet);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 l_MousePos = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        l_MousePos.z = 0;
        Vector3 l_startPos = transform.position;
        l_startPos.z = 0;
        switch (m_actualWeapon.m_WeaponLoadType)
        {
            case (WeaponFather.LoadTypes.Auto):

                if(Input.GetMouseButton(0)&& m_isLoaded)
                {
                    Shoot((l_MousePos - l_startPos).normalized,true);
                }
                break;

            case (WeaponFather.LoadTypes.SemiAuto):

                if (Input.GetMouseButtonDown(0)&& m_isLoaded)
                {
                    Shoot((l_MousePos - l_startPos).normalized, true);
                }
                break;

            case (WeaponFather.LoadTypes.ClickReload):
                if (Input.GetMouseButtonDown(0))
                {
                    if (m_isLoaded)
                    {
                        Shoot((l_MousePos - l_startPos).normalized, false);

                        m_isLoaded = false;
                    }
                    else
                    {
                        StartCoroutine(Reload());
                    }
                }

                break;

            case (WeaponFather.LoadTypes.OnClick):

                if (Input.GetMouseButtonDown(0))
                {
                    Shoot((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.root.position).normalized, false);
                    
                }
                break;

        }
    }
    public void ChangeWeapon(WeaponFather _NewWeapon, PlayerAbilities m_NewAbility, Bullet m_NewBullet )
    {
        m_actualWeapon = _NewWeapon;
        m_MyGunRenderer.sprite = m_actualWeapon.m_MySprite;

        m_actualAbility = m_NewAbility;

        m_actualBullet = m_NewBullet;

    }
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(m_actualWeapon.m_TimeBetweenShoots);

        m_isLoaded = true;
        
    }
    public void Shoot(Vector3 _direction, bool _startReload)
    {
       
        _direction.z = 0;
        
        Vector3 l_spawnPosition = transform.position +  _direction * m_MyGunRenderer.size.x;

        switch (m_actualWeapon.m_WeaponShootType)
        {
            case (WeaponFather.ShootTypes.Single):

                CreateBullet(_direction, l_spawnPosition);

            break;

            case (WeaponFather.ShootTypes.Burst):

              for(int i= 0; i< m_actualWeapon.m_HowManyShots; i++)
                {
                    CreateBullet(_direction, l_spawnPosition);
                }


            break;

            case (WeaponFather.ShootTypes.Spread):


            break;

        }

       
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

        l_newBullet = Instantiate(m_actualBullet.gameObject, l_spawnPosition, l_ShootRotationOnDir).GetComponent<Bullet>();

        l_newBullet.SetBullet(_direction, m_actualWeapon.m_DefaultDamage, m_actualWeapon.m_BulletSprite, m_actualWeapon.m_bulletSpeedDecrease, m_actualWeapon.m_projectileSpeed);
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

}
