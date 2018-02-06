using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 direction2Player;
    Transform playerTransform;
    Rigidbody2D rb;
    public float thrust = 20;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        direction2Player = (playerTransform.position - transform.position).normalized;
        rb.AddForce(direction2Player * thrust, ForceMode2D.Impulse);
    }

}
