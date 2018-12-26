﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFather : MonoBehaviour
{
    public enum LoadTypes
    {
        Auto,
        SemiAuto,
        OnClick,
        ClickReload,

    }
    public enum ShootTypes
    {
        Single,
        Burst,
        Spread

    }
    public LoadTypes m_WeaponLoadType;
    public ShootTypes m_WeaponShootType;

    public int m_HowManyShots;


    public Sprite m_MySprite , m_BulletSprite;
    public List<string> m_Names;

    public float
        m_DefaultDamage,
        m_MaxAmmo,
        m_TimeBetweenShoots,


        m_MaxHeat,
        m_HeatPerShoot,
        m_TotalCoolingTime,
        m_CoolingTime,

        m_FailBiassPerShot,
        m_projectileDistance,
        m_projectileSpeed

        ;



}

