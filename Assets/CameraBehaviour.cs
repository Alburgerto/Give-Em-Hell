using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public float m_cameraSpeed;
    public float m_shakeTime;

    private Transform m_player;
    private Vector3 m_targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        m_player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_targetPosition.x = m_player.position.x;
        m_targetPosition.y = m_player.position.y;
        m_targetPosition.z = transform.position.z;

        transform.position = Vector3.Lerp(transform.position, m_targetPosition, m_cameraSpeed * Time.deltaTime);
    }

    public IEnumerator Shake()
    {
        float time = 0;
        float offset = 0.04f;
        while (time < m_shakeTime)
        {
            float x = Random.Range(-offset, offset);
            float y = Random.Range(-offset, offset);
            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            time += Time.deltaTime;
            yield return null;
        }
    }
}
