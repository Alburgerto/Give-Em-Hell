using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public GameObject m_slime;
    public float m_appearRange;
    public float m_appearanceRate;
    public float m_changeDifficultyTime; // Seconds that need to elapse until it gets more difficult
    public float m_scaleVariability;

    private Transform m_player;
    
    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnSlimes());
    }

    private IEnumerator SpawnSlimes()
    {
        float elapsed = 0, totalElapsed = 0;
        Vector2 randomPosition;
        while (true)
        {
            if (totalElapsed > m_changeDifficultyTime && m_appearanceRate > 1)
            {
                m_appearanceRate -= 0.25f;
                m_appearRange--;

                totalElapsed = 0;
            }

            if (elapsed > m_appearanceRate)
            {
                randomPosition.x = Random.Range(m_player.position.x - m_appearRange, m_player.position.x + m_appearRange);
                randomPosition.y = Random.Range(m_player.position.y - m_appearRange, m_player.position.y + m_appearRange);
                
                GameObject enemy = Instantiate(m_slime, randomPosition, Quaternion.identity);
                Slime slime = enemy.GetComponent<Slime>();
                float scale = Random.Range(-m_scaleVariability/2, m_scaleVariability);
                enemy.transform.localScale *= Mathf.Clamp(scale, 0.25f, 4);
                float speedMultiplier = Mathf.Clamp(Random.Range(scale - 2, scale + 2), 0.25f, 4);
                slime.m_speed *= speedMultiplier * 1/scale*2;

                elapsed = 0;
            }
            
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
