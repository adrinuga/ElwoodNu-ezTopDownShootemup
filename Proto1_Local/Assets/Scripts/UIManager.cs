using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image
        m_PlayerHealthUIFill,
        m_WeaponHeatFillUI1,
        m_WeaponHeatFillUI2,
        m_WeaponReloadFill1,
        m_weaponReloadFill2
        ;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.m_instance.m_SceneUI = this;

     
        m_WeaponReloadFill1.fillAmount = 0;
        m_weaponReloadFill2.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
