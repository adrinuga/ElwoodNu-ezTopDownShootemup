using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFather : MonoBehaviour
{
    public enum ShootTypes
    {
        Auto,
        SemiAuto,
        OnClick,
        Burst,

    }
    public ShootTypes m_WeaponShootType;

    public Sprite m_MySprite;
    public List<string> m_Names;

    public float
        m_DefaultDamage,
        m_MaxAmmo,
        m_TimeBetweenShoots,


        m_MaxHeat,
        m_HeatPerShoot,
        m_TotalCoolingTime,
        m_CoolingTime
        ;



}
