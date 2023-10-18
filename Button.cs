using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private bool IsMouseOver()
    {
        // Get the mouse position in world coordinates
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Get the collider for the button
        Collider2D collider = GetComponent<Collider2D>();

        // Return true if the mouse is over the button
        return collider.OverlapPoint(mousePosition);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If the mouse is over the button, save the current color 
        // and change the color to red
        Color currentColor = GetComponent<SpriteRenderer>().color;
        while (IsMouseOver())
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        //change the color back to the saved color
        GetComponent<SpriteRenderer>().color = currentColor;

    }
}
