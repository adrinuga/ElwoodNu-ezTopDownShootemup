using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D m_BulletRb;
    [SerializeField] private BoxCollider2D m_BulletCollider;
    public enum BulletTypes
    {
        Normal,
        Laser,
        Fire,
        Electric,
        Explosive,
        Tracing
    }
    public BulletTypes m_MyBulletType;
    public SpriteRenderer m_BulletRenderer;

    public float
        m_MaxSpeed,
        m_BulletSpeedDestroy
        ;
    private float 
        m_ActualSpeed,
        m_DecreasingSpeed
        

        ;
    [HideInInspector] public Vector3 m_Direction;

    [HideInInspector] public float m_DealDamage;
    private EnemyFather m_Target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_MyBulletType == BulletTypes.Tracing) // I'm already tracer
        {
        }

        Move();

        CheckDeath();

    }
    void Move()
    {
        transform.position += m_Direction * m_ActualSpeed * Time.deltaTime;
        //m_DistanceMade += m_ActualSpeed * Time.deltaTime;
        if(m_Target == null)
        {
            m_ActualSpeed -= m_DecreasingSpeed;
        }
    }
    void CheckDeath()
    {
        if(m_ActualSpeed <= m_BulletSpeedDestroy)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetBullet(Vector3 _dir, float _damage,Sprite _bSprite,float  _speedDecrase, float _speed, float _BulletSize)
    {
        m_ActualSpeed = _speed;

        m_Direction = _dir;
        m_DecreasingSpeed = _speedDecrase;

        m_BulletRenderer.sprite = _bSprite;

        m_DealDamage = _damage;

        this.transform.localScale *= _BulletSize;
      
    }
}
