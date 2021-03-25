using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacground : MonoBehaviour
{
    [SerializeField] float speed = 0;
    [SerializeField] bool isBack;
    void Update()
    {
        transform.position -= Vector3.right * Time.deltaTime * speed;
        if (isBack)
        {
            transform.position += Vector3.up * Time.deltaTime * 0.2f * (0.5f - Mathf.PingPong(Time.time, 1));
        }

        if (transform.position.x <= -17.7f * 3)
        {
            transform.position = Vector3.right * 17.7f * 2;
        }
    }
}
