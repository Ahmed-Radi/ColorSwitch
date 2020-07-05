using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public ColorUsed colorIndex;

    
    
    // Start is called before the first frame update
    void Start()
    {
        //Ball Color
        ManagerReferences refs = GameObject.Find("Manager").GetComponent<ManagerReferences>();
        if(refs != null )
        {
            Color newColor = refs.Colors[(int)colorIndex];
            gameObject.GetComponent<SpriteRenderer>().color = newColor;
        }
        //
    }
    void OnTriggerEnter2D(Collider2D other) //To know when the ball reaches the circles
    {
        if (other.gameObject.tag == "Player")//player الحاجه الى بتحرك بيها التاج بتاعها اسمه    
        {
            //Check if it is the same color or not
            Color playerColor = other.gameObject.GetComponent<SpriteRenderer>().color; //this to get ball color
            Color thisColor = this.gameObject.GetComponent<SpriteRenderer>().color; //this to get shape color
            if (playerColor != thisColor)
            {
                Debug.Log("Game Over");
                ManagerReferences refs = GameObject.Find("Manager").GetComponent<ManagerReferences>();
                //Game Over
                if (refs != null)
                {
                    refs.GameOverPanel.SetActive(true);
                    Time.timeScale = 0;//Makes the game stop when you click on the wrong color(Show panel GameOver)
                }
            }
        }
    }
    /*
    // Update is called once per frame
    void Update()
    {
        
    }*/
}
