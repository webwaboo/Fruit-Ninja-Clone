using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    //var,field for min movement velocity required
    public float minVelo = 0.1f;
    //var for rigidbody of the blade/mouse
    private Rigidbody2D rb;

    
    //var for position of the mouse
    private Vector3 lastMousePos;
    //var for velocity of mouse
    private Vector3 mouseVelo;

    //var for for collider of the blade
    private Collider2D col;


    // Initiate rigidbody and collider of mouse/blade
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //enable collision only if mouse is moving
        //col.enabled = IsMouseMoving();
        SetBladeToMouse();
        Vector2 direction = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        if (direction.magnitude > minVelo)
            col.enabled = true;
        else col.enabled = false;
    }

    //transpose position of rigidbody to mouse
    private void SetBladeToMouse()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 7;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }

    //check if mouse is moving or not, by checking distance between current and last pos
    private bool IsMouseMoving()
    {
        //initialise current pos
        Vector3 curMousePos= transform.position;
        //store traveled distance between last and current pos
        float traveled = (lastMousePos - curMousePos).magnitude;
        //update last pos with current
        lastMousePos = curMousePos;
        
        //check if traveled distance is inferior to minVelo
        if (traveled < minVelo)
            return true;
        else 
            return false;
    }
}
