using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager m_instance = null;

    public PlayerController m_Player;
    public List<EnemyFather> m_Enemies;
    public List<Bullet> m_Bullets;
    public UIManager m_SceneUI;

    // Start is called before the first frame update
    void Awake()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public EnemyFather GetEnemy(Transform _transform)
    {
        EnemyFather l_Enemy = null;

        foreach (EnemyFather e in m_Enemies)
        {
            if (e.transform == _transform)
            {
                l_Enemy = e;
            }
        }
        return l_Enemy;
    }
    public Bullet GetBullet(Transform _transform)
    {
        Bullet l_Bullet = null;
        foreach(Bullet b in m_Bullets)
        {
            if(b.transform == _transform)
            {
                l_Bullet = b;
            }
        }
        return l_Bullet;
    }
}
