using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float m_inBetweenBlinks;
    public float m_health;
    public float m_pushForce;
    public float m_speed;

    private Transform m_target;
    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        m_animator = GetComponent<Animator>();
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, m_target.position, m_speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player ")
        {
            // Explode
        }
        else if(collision.gameObject.tag == "Slash")
        {
            Vector2 direction = gameObject.transform.position - collision.gameObject.transform.position;
            GetComponent<Rigidbody2D>().AddForce(direction * m_pushForce, ForceMode2D.Force);
            
        }
    }

    private IEnumerator Blink()
    {
        float time;
        while (true)
        {
            time = Random.Range(m_inBetweenBlinks - 1, m_inBetweenBlinks + 1);
            yield return new WaitForSeconds(time);
            m_animator.SetTrigger("Blink");
        }
    }

    public void TakeDamage(float m_damage)
    {
        m_health -= m_damage;
        if (m_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
