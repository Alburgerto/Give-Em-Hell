using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public float m_damage;
    public float m_slashDistance;
    public Camera m_camera;
    public Rigidbody2D m_rb;
    public Transform m_parent;

    private CameraBehaviour m_cameraBehaviour;

    private void Start()
    {
        m_cameraBehaviour = m_camera.GetComponent<CameraBehaviour>();
    }

    private void OnEnable()
    {
        Vector2 mousePos = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 parentPosition = new Vector2(m_parent.position.x, m_parent.position.y);
        Vector2 slashDirection = mousePos - parentPosition;

        float angle = Mathf.Atan2(slashDirection.y, slashDirection.x) * Mathf.Rad2Deg;
        m_rb.rotation = angle;

        transform.localPosition += new Vector3(slashDirection.normalized.x, slashDirection.normalized.y, 0) * m_slashDistance;
        //m_rb.AddForce(slashDirection.normalized * m_slashDistance);
        //m_rb.AddForceAtPosition(slashDirection.normalized * m_slashDistance, transform.localPosition + new Vector3(slashDirection.x, slashDirection.y, 0) * 10);
        //m_rb.position += slashDirection.normalized * m_slashDistance;
    }

    private void OnDisable()
    {
        m_rb.rotation = 0;
        transform.localPosition = new Vector3(0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            collision.gameObject.GetComponent<Slime>().TakeDamage(m_damage);
            StartCoroutine(m_cameraBehaviour.Shake());
        }
    }
}
