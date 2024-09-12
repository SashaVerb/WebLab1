using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static int leftCounter = 0;
    public static int rightCounter = 0;
    static int kukinCounter = 1;
    public float speed = 30;
    public float boomScale = 1;
    public int startDirection = 1;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, startDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Left"))
        {
            rightCounter++;
            DestroyKukin(1);
        }
        else
        {
            leftCounter++;
            DestroyKukin(-1);
        }

    }

    private void DestroyKukin(int startDirection)
    {
        if (kukinCounter == 1)
        {
            transform.position = Vector3.zero;
            transform.localScale = new Vector3(0.5f, 0.5f, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, startDirection);
        }
        else
        {
            kukinCounter--;
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "RacketLeft")
        {
            float y = HitFactor(transform.position, 
                                collision.transform.position, 
                                collision.collider.bounds.size.y);

            Vector2 direction = new Vector2(1 ,y).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
            transform.localScale += new Vector3(0.1f, 0.1f, 0);

            if(transform.localScale.x > boomScale)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                if (kukinCounter < 100)
                {
                    var newKukin = Instantiate(gameObject, transform.position, Quaternion.identity);
                    newKukin.GetComponent<Ball>().startDirection = 1;
                    kukinCounter++;
                }
            }
        }
        else if (collision.gameObject.name == "RacketRight")
        {
            float y = HitFactor(transform.position,
                                collision.transform.position,
                                collision.collider.bounds.size.y);

            Vector2 direction = new Vector2(-1, y).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
            transform.localScale += new Vector3(0.1f, 0.1f, 0);

            if (transform.localScale.x > boomScale)
            {
                transform.localScale = new Vector3(0.5f, 0.5f, 0f);
                if (kukinCounter < 100)
                {
                    var newKukin = Instantiate(gameObject, transform.position, Quaternion.identity);
                    newKukin.GetComponent<Ball>().startDirection = -1;
                    kukinCounter++;
                }
            }
        }
    }

    float HitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }
}
