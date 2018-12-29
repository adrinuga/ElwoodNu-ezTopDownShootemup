using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]private float mapX = 100.0f;
    [SerializeField] private float mapY = 100.0f;

    private float

        m_minX,
        m_maxX,
        m_minY,
        m_maxY
        ;
    
     
     void Start()
    {
        var vertExtent = Camera.main.orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        m_minX = horzExtent - mapX / 2.0f;
        m_maxX = mapX / 2.0f - horzExtent;
        m_minY = vertExtent - mapY / 2.0f;
        m_maxY = mapY / 2.0f - vertExtent;
    }

    void LateUpdate()
    {
        Vector3 v3 = GameManager.m_instance.m_Player.transform.position;
        v3.x = Mathf.Clamp(v3.x, m_minX, m_maxX);
        v3.y = Mathf.Clamp(v3.y, m_minY, m_maxY);
        v3.z = transform.position.z;
        transform.position = v3;
    }
}
