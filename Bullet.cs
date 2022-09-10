using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Vector3 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        //Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection);
        // Destroy(gameObject, 0.5f);
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Enemy")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
