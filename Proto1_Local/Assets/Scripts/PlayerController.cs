using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 

    [SerializeField]
    private KeyCode
        m_UpKey = KeyCode.W,
        m_DownKey = KeyCode.S,
        m_LeftKey = KeyCode.A,
        m_RightKey = KeyCode.D
        ;

    [SerializeField] private Transform m_WeaponTransform;
    [SerializeField] private Camera m_GameCamera;

    [SerializeField]
    private SpriteRenderer
        m_WeaponRenderer,
        m_myRenderer;

    [SerializeField] private Rigidbody2D m_PlayerRb;

    [HideInInspector] public float m_actualSpeed;

    [SerializeField]
    private float
        m_defaultSpeed
        ;
    [HideInInspector] bool m_isAlive;



    

    // Start is called before the first frame update
    void Start()
    {
        m_actualSpeed = m_defaultSpeed;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        UpdateMouse();

        Flip();

    }

    void UpdateMovement()
    {
        //float l_Vertical = Mathf.Round( Input.GetAxis("Horizontal"));
        //float l_Horizontal = Mathf.Round ( Input.GetAxis("Vertical"));

        Vector2 l_Movement = new Vector2();

        if (Input.GetKey(m_UpKey))
        {
            l_Movement.y += 1;
        }
        if (Input.GetKey(m_DownKey))
        {
            l_Movement.y -= 1;

        }
        if (Input.GetKey(m_RightKey))
        {
            l_Movement.x += 1;
        }
        if (Input.GetKey(m_LeftKey))
        {
            l_Movement.x -= 1;
        }


        l_Movement *= m_actualSpeed * Time.deltaTime;



        m_PlayerRb.velocity = l_Movement;
    }
    void UpdateMouse()
    {
        Vector3 l_MousePos = Input.mousePosition;
        l_MousePos.z = -Camera.main.transform.position.z;
        Vector3 l_objectPos = Camera.main.WorldToScreenPoint(m_WeaponTransform.position);

        l_MousePos.x -= l_objectPos.x;
        l_MousePos.y -= l_objectPos.y;

        float l_angle = Mathf.Atan2(l_MousePos.y, l_MousePos.x) * Mathf.Rad2Deg;
        m_WeaponTransform.rotation = Quaternion.Euler(m_WeaponTransform.eulerAngles.x, m_WeaponTransform.eulerAngles.y, l_angle);


    }
    void Flip()
    {
        float l_MouseX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        float l_MouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;

        float l_WeaponZ = Mathf.Abs( m_WeaponTransform.position.z);

        //Vector3 l_scale = transform.localScale;

        if (l_MouseX > transform.position.x)
        {
            m_WeaponRenderer.flipY = false;
            m_myRenderer.flipX = true;
        }
        else
        {
            m_WeaponRenderer.flipY = true;
            m_myRenderer.flipX = false;
        }
            
        if(l_MouseY < transform.position.y)
        {
            l_WeaponZ *= -1;
        }
       
        m_WeaponTransform.position = new Vector3(m_WeaponTransform.position.x, m_WeaponTransform.position.y, l_WeaponZ);
        //transform.localScale = l_scale;



    }
    public void ManageAbility()
    {

    }
}
