using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float m_speed;
    public GameObject m_slash;

    private Rigidbody2D m_rb;
    private Animator m_animator;
    private Vector2 m_moveVector;
    private SpriteRenderer m_renderer;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
        m_renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Movement
        m_moveVector.x = Input.GetAxisRaw("Horizontal");
        m_moveVector.y = Input.GetAxisRaw("Vertical");

        if (m_moveVector.x == 1)
        {
            m_renderer.flipX = false;
        } else if (m_moveVector.x == -1)
        {
            m_renderer.flipX = true;
        }

        // Attack
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_animator.SetTrigger("Attack");
        }

        
    }

    private void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + m_moveVector * m_speed * Time.fixedDeltaTime);
    }

}
