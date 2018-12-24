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
        
    }
    public void ChangeWeapon(WeaponFather _NewWeapon, PlayerAbilities m_NewAbility, Bullet m_NewBullet )
    {
        m_actualWeapon = _NewWeapon;
        m_MyGunRenderer.sprite = m_actualWeapon.m_MySprite;

        m_actualAbility = m_NewAbility;

        m_actualBullet = m_NewBullet;

    }

}
