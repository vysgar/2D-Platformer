using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject GameObject;
    [SerializeField] float climbSpeed = 1f;
    bool canClimb = false;
    void Start()
    {
        GameObject = GameObject.FindWithTag("PlayPlayer");
    }

    // Update is called once per frame
    void Update()
    {
        
        if (canClimb)
        {
            if(Input.GetKey(KeyCode.W))
            {
                GameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
                GameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                GameObject.transform.Translate(new Vector3(0, 1, 0) * climbSpeed * Time.deltaTime);
                
            }
            else if(Input.GetKey(KeyCode.S))
            {
                GameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
                GameObject.transform.Translate(Vector3.down * climbSpeed * Time.deltaTime);
            }
             
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("PlayPlayer"))
        {
            canClimb = true;
            
          
        }
       
      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canClimb = false;
        GameObject.GetComponent<Rigidbody2D>().gravityScale = 1f;
    }
}
