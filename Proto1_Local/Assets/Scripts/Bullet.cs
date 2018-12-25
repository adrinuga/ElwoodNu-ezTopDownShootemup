using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{ 
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
        m_DistanceDuration,
        m_MaxSpeed
        ;
    private float 
        m_ActualSpeed,
        m_DistanceMade;
    [HideInInspector] Vector3 m_Direction;

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
        m_DistanceMade += m_ActualSpeed * Time.deltaTime;
    }
    void CheckDeath()
    {
        if(m_DistanceMade >= m_DistanceDuration&& m_Target == null)
        {
            Destroy(this.gameObject);
        }
    }
}
