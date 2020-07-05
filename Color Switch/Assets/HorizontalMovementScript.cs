using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// This To control in move the shapes
/// 
/// </summary>
public class HorizontalMovementScript : MonoBehaviour
{
    public float speed = 6;//shape speed
    public float rangeMax = 10;//When the ball reaches its range, it stops and returns in another direction 
    public float direction = 1; // 1 means move to right
    public float initalPositionX;
    // Start is called before the first frame update
    void Start()
    {
        initalPositionX = this.transform.position.x; // to move in X axis
        




    }

    // Update is called once per frame
    void Update()
    {
        // to make shape move to right
        this.transform.position = new Vector2(this.transform.position.x + (direction * Time.deltaTime * speed),// dirction = 1(means go to right only) * time.delta = معدل تغير السرعه بالنسبه للزمن ) 1) * speed(can change it) = to that you will found speed increment by 1
                                              this.transform.position.y );
        if (this.transform.position.x > initalPositionX + rangeMax)
        {
            direction = -1;
        }if (this.transform.position.x < initalPositionX - rangeMax)
        {
            direction = 1;
        }
        
    }
}
