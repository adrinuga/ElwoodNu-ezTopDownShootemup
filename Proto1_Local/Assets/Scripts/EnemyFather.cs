using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFather : MonoBehaviour
{
    public enum EnemyStates
    {
        Idle,
        Attack,
        Stunned,
        Hit,
        Dead,
        
    }
    public EnemyStates m_ActualState;

    public float m_NormalSpeed;
    [HideInInspector]public float 
        m_ActualSpeed,
        m_EnemyHealth
        ;
    [SerializeField] Rigidbody2D m_EnemyRb;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.m_instance.m_Enemies.Add(this);
        m_ActualState = EnemyStates.Attack;
    }

    // Update is called once per frame
    void Update()
    {
        switch (m_ActualState)
        {
            case EnemyStates.Idle:

                break;

            case EnemyStates.Attack:

                Vector3 l_playerPos = GameManager.m_instance.m_Player.transform.position;
                l_playerPos.z = 0;
                Vector3 dir = l_playerPos - transform.position;
                dir.z = 0;

                Debug.Log("update");

                dir.Normalize();
                m_EnemyRb.velocity = dir * m_NormalSpeed * Time.deltaTime;
               

                break;

            case EnemyStates.Stunned:
                break;

            case EnemyStates.Hit:
                break;

            case EnemyStates.Dead:
                break;


        }
    }
    void ChangeState(EnemyStates _nextState)
    {
        switch (_nextState)
        {
            case EnemyStates.Idle:

                break;

            case EnemyStates.Attack:

              
                

                break;

            case EnemyStates.Stunned:
                break;

            case EnemyStates.Hit:
                break;

            case EnemyStates.Dead:
                break;


        }

        m_ActualState = _nextState;
    }
    public void Kill()
    {

    }
    public void SetKnockBack()
    {

    }
    public void ImpactBullet( Bullet.BulletTypes _typeBullet, float _knockBackPower, float _damage, Vector3 _dir)
    {

        m_EnemyRb.velocity = Vector2.zero;
        m_EnemyRb.AddForce(_dir * _knockBackPower);
        m_EnemyHealth -= _damage;
        if(m_EnemyHealth <= 0)
        {
            ChangeState(EnemyStates.Dead);
        }
    }
}

