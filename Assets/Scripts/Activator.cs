using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Activator : MonoBehaviour
{
    bool nextToCPU = false;

    [SerializeField]
    private string Map;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            nextToCPU = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            nextToCPU = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (nextToCPU == true)
            {
                SceneManager.LoadScene(Map);
            }
        }
    }
}
