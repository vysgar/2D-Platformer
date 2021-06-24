using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D bulletRb;
    public float bulletSpeed;
    
    public GameObject Explosion;
    public enemy enemyclass;
    void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        enemyclass = GetComponent<enemy>();
        bulletRb.velocity = transform.right * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         
        Debug.Log(collision.gameObject.name);
        Destroy(gameObject);
        GameObject DestryExplosion = Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(DestryExplosion, 0.3f);

    }
}
