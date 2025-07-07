using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    public float width = 40f;
    public float speed = 3.0f;


    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -width)
        {
            transform.position += new Vector3(width * 2f, 0, 0);
        }
        
    }
}
