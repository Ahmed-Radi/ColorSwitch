using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcherScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ColorUsed[] AllowedColor; // to choic the color from allowed colors
    void OnTriggerEnter2D(Collider2D other) //To know when the ball reaches the circles
    {
        if (other.gameObject.tag == "Player")//player الحاجه الى بتحرك بيها التاج بتاعها اسمه    
        {
            ManagerReferences refs = GameObject.Find("Manager").GetComponent<ManagerReferences>();
            int index = Random.Range(0, AllowedColor.Length - 1);
            ColorUsed newColor = AllowedColor[index];
            
            refs.SwitchPlayerColor(newColor);
            this.gameObject.SetActive(false);//Make coin Hidden
            Destroy(this);//Make coin Destroy the script
        }
    }






}
