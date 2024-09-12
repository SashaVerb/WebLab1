using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float speed = 30;
    public string axis = "Vertical";
    private Rigidbody2D rigBody;
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (axis == "Rotation")
        {
            rigBody.rotation += speed;
        }
        else
        {
            float velocity = Input.GetAxisRaw(axis);
            rigBody.velocity = new Vector2(0, velocity) * speed;
        }
    }
    void Update()
    {
        
    }
}
