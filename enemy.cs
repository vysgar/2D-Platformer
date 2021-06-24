using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float enemRight = 0f;
    [SerializeField] float enemLeft = 0f;
    [SerializeField] float enemSpeed = 0f;

    Rigidbody2D enemyRb;
    SpriteRenderer enemSpirite;
    int enemDirection = 1;
    Vector3 initialPosition;
    Animator EnemyAnim;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemSpirite = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        initialPosition = transform.position;
        if (initialPosition.x <= enemRight && enemDirection == 1)
        {
            enemSpirite.flipX= false;
            enemyRb.velocity = new Vector2(1 * enemSpeed, 0)  ;
        }
        else
        {
            enemDirection = -1;
        }


       if(initialPosition.x >= enemLeft && enemDirection == -1)
        {
            enemSpirite.flipX = true;
            enemyRb.velocity = new Vector2(-1 * enemSpeed, 0 );
        }
        else
        {
            enemDirection = 1;
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        enemyRb.constraints = RigidbodyConstraints2D.FreezePosition;
        EnemyAnim.speed = 0;
    }


}
