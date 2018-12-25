using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFather : MonoBehaviour
{
    public enum EnemyStates
    {
        Idle,
        Chase,
        Stunned,
        Dead
    }
    public EnemyStates m_ActualState;

    // Start is called before the first frame update
    void Start()
    {
        m_ActualState = EnemyStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Kill()

    {

    }
}

