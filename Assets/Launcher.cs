using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public bool hasStarted;
    public GameObject Note;
    public Transform firePoint;
    public KeyCode breaker;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            if (Input.anyKeyDown)
            {
                hasStarted = true;
            }
        }
        else
        {
            while (hasStarted == true)
            {
                StartCoroutine(TimeDelay());
                if (Input.GetKeyDown(breaker))
                {
                    hasStarted = !hasStarted;
                }
            }
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(2);
        Shoot();
    }

    void Shoot()
    {
        Instantiate(Note, firePoint.position, firePoint.rotation);

    }
}
