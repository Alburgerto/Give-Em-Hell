using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour
{
    public Transform m_player;
    public GameObject m_slime;
    public float m_appearRange;
    public float m_appearanceRate;
    public float m_changeDifficultyTime; // Seconds that need to elapse until it gets more difficult
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSlimes());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnSlimes()
    {
        float elapsed = 0;
        Vector2 randomPosition;
        while (true)
        {
            if (elapsed > m_appearanceRate)
            {
                randomPosition.x = Random.Range(m_player.position.x - m_appearRange, m_player.position.x + m_appearRange);
                randomPosition.y = Random.Range(m_player.position.y - m_appearRange, m_player.position.y + m_appearRange);

                Instantiate(m_slime, randomPosition, Quaternion.identity);
            }
            
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
