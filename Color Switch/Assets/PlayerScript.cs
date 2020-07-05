using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float Maxvelocity = 10;//Max for force
    public float intansity = 350;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        StupIntialColor();//chanage color whene start game
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            
            ManagerReferences refs = GameObject.Find("Manager").GetComponent<ManagerReferences>();
            if (refs.gameIsON && body.gravityScale == 0) // graityScale == 0 علشان منعملش فك فريز لجسم فعلا مش فريز 
            {
                refs.UnFreezPlayer();
            }



            //add force upward or add impules upward 
            if(body != null)
            {
                body.AddForce(Vector2.up * intansity);//push to up
            }
        }
        //limit force
        //Debug.Log("velocity" + body.velocity.y);
        if(body.velocity.y > Maxvelocity)
        {

            body.AddForce(Vector2.down * intansity); ///To reduce the force of the ball when falling down to keep going up
        }
    }

    //give color to Ball
    void StupIntialColor()
    {
        ManagerReferences  refs = GameObject.Find("Manager").GetComponent<ManagerReferences>();
        if(refs != null)
        {
            int colorsCount = refs.Colors.Length;
            int randomIndex = Random.Range(0, colorsCount - 1); // get random color
            Color newColor = refs.Colors[randomIndex];
            SpriteRenderer renderer=GetComponent<SpriteRenderer>();
            renderer.color = newColor;



        }
    }
}
