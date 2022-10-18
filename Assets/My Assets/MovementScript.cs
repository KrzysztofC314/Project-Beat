using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float speed;
    public float distance;
    [HideInInspector]
    public int direction = 1;
    int lane = -1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right*Time.deltaTime*speed*direction);
        if (Input.GetKeyDown(KeyCode.W))
        {
            lane = lane * -1;
            transform.position = new Vector2(transform.position.x, transform.position.y + lane*distance);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
        }
    }
}
