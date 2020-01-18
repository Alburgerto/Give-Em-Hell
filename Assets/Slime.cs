using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public float m_inBetweenBlinks;
    public float m_health;

    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        m_animator = GetComponent<Animator>();
        StartCoroutine(Blink());
    }

    // Update is called once per frame
    void Update()
    {

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
