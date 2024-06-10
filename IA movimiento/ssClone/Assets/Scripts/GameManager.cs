using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score;
    public static GameManager inst;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] PlayerMovement playerMovement;


    public void incrementScore(){
        if(Dificultad.facil){
            score++;
        }else if(Dificultad.normal){
            score+=2;
        }else if(Dificultad.dificil){
            score+=3;
        }
        scoreText.text = "Score: " + score;
        if(playerMovement.speed < playerMovement.maxSpeed)
        {
            playerMovement.speed += playerMovement.speedIncreasePerPoint;
        }
    }


    private void Awake(){
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
