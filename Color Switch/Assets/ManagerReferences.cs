using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//using for canvas
using UnityEngine.SceneManagement;//to restart level


/// <summary>
/// This Class for check  color and calcolute score 
/// </summary>
/// 

public enum ColorUsed //global for all scripts
{
    Red,
    Yellow,
    Green,
    Blue,
    Purple
}

public class ManagerReferences : MonoBehaviour
{
    

    public GameObject PlayerSphere;//Sphere = Ball
    public Color[] Colors;//Colors For Ball
    //score 
    public int score=0;
    public Text ScoreText;//initialize score
    //Start Game

    public GameObject MainPanel;
    //Freez
    float Gravity =1;
    public bool gameIsON = false; //boolean because game is true or false

    //instructions look like -> tap to play
    public GameObject instructions;

    //GameOver
    public GameObject GameOverPanel;

    // Start is called before the first frame update
    void Start()
    {
        FreezPlayer();
        instructions.SetActive(false);
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void IncreaseScore(int amount )
    {
        score += amount;
        //desplayScore
        ScoreText.text = score.ToString ();

    }

    //Change Color
    public void SwitchPlayerColor(ColorUsed newColor)
    {
        SpriteRenderer renderer = PlayerSphere.GetComponent<SpriteRenderer>();

        switch (newColor)
        {
            case ColorUsed.Red:
                renderer.color = Colors[0];
                break;
            case ColorUsed.Yellow:
                renderer.color = Colors[1];
                break;
            case ColorUsed.Green:
                renderer.color = Colors[2];
                break;
            case ColorUsed.Blue:
                renderer.color = Colors[3];
                break;
            case ColorUsed.Purple:
                renderer.color = Colors[4];
                break;

            default:
                renderer.color = Colors[0];
                break;
        }

    }
    //When click in button start GAME
    public void pressdedPlayButton()
    {
        MainPanel.SetActive(false);//When you click "Play", the panel disappears
        gameIsON = true;
        instructions.SetActive(true);//display instructions  look like -> tap to play
        GameOverPanel.SetActive(false);
    }

    //Freez Ball to star when cklic play button
    public void FreezPlayer()//when start game
    {
        Rigidbody2D body = PlayerSphere.GetComponent<Rigidbody2D>();
        Gravity = body.gravityScale;
        body.gravityScale = 0;
        //body.Sleep();//to make ball freeze until press button
        body.isKinematic = true;//controll to the gravity       
    }

    public void UnFreezPlayer()//when click on screen
    {
        Rigidbody2D body = PlayerSphere.GetComponent<Rigidbody2D>();
        body.gravityScale = Gravity;
        body.isKinematic = false;//controll to the gravity
        instructions.SetActive(false);//hide instructions  look like -> tap to play
    }
    public void ShowGameOverPanel()
    {
        Rigidbody2D body = PlayerSphere.GetComponent<Rigidbody2D>();
        body.isKinematic = true;//controll to the gravity
        GameOverPanel.SetActive(true);
        gameIsON = false;
    }
    //Restart the Game
    public void PressedRestartButton()
    {
        SceneManager.LoadScene("SampleScene"); // SampleScene الى هو المكان الي بتتعرض فيه العبه اسمه
        Time.timeScale = 1;//Make game start again(hidde panel Game Over)
    }




}
