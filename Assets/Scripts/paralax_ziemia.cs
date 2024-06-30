using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bparalax_ziemia : MonoBehaviour
{
    float startX;
    [SerializeField] float limitX = -40;
    void Start()
    {
        startX = transform.position.x;
        transform.position = new Vector2(startX, -4);
    }
    void Update()
    {
        if (Time.timeScale >= 1f)
        {
            transform.position = new Vector2(transform.position.x - 0.05f, transform.position.y);
            if (transform.position.x <= limitX)
            {
                transform.position = new Vector2(startX, -4);
            }
        }
    }
}
