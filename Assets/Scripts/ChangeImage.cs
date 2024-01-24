using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
    //makes changes to ui ^

public class ChangeImage : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeButtonImage()
    {
        button.image.sprite = newButtonImage;

    }

    // what happens when button is clicked ^
}
