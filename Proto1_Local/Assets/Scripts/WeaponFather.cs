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

    public int 
        m_HowManyShots,
        m_HowManyBursts
        ;


    public Sprite
        m_MySprite ,
        m_BulletSprite,
        m_HeatBackSprite,
        m_HeatFillSprite
        ;
    public List<string> m_Names;

    public float
        m_DefaultDamage,
        m_MaxAmmo,
        m_TimeBetweenShoots,


        m_MaxHeat = 100f,
        m_HeatPerShoot,
        m_TotalCoolingSpeed = 10f,
        m_CoolingSpeed = 5f,

        m_FailBiassPerShot,
        m_projectileSpeed,
        m_bulletSpeedDecrease,
        m_KnockBackForce,

        m_BulletSize


        ;



}

