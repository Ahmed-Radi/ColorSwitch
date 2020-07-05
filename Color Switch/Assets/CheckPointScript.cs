using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{
    public int ScoreAmount = 1;//Score
    void OnTriggerEnter2D(Collider2D other) //To know when the ball reaches the circles
    {
        if (other.gameObject.tag == "Player")
        {
            ManagerReferences refs = GameObject.Find("Manager").GetComponent<ManagerReferences>();
            refs.IncreaseScore(ScoreAmount);
            this.gameObject.SetActive(false);//Make coin Hidden
            Destroy (this);//Make coin Destroy the script
        }
    }


    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
