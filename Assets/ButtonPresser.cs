using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPresser : MonoBehaviour
{
    private Image SR;
    public Sprite defaultImage;
    public Sprite pressedImage;
    public KeyCode keyToPress;

    // Start is called before the first frame update
    void Start()
    {
        SR = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyToPress))
        {
            SR.sprite = defaultImage;
        }
    }
}
