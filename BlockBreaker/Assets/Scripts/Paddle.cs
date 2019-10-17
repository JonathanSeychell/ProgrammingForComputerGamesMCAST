using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;
    Vector2 paddlePosition;

    // Start is called before the first frame update
    void Start()
    {
       paddlePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //Limit the mouse position between 1 and 15 units
        float limitMousePos = Mathf.Clamp(mousePos, 1f, 15f);

        //set the Paddle x-position to the x-mousePosition
        paddlePosition.x = limitMousePos;
        this.transform.position = paddlePosition;
    }
}
