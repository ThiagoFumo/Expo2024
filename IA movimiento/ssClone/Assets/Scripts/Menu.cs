using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    int contadorIMENU = 0;
    int contadorPMENU = 0;
    int contadorIDER = 0;
    int contadorPDER = 0;
    void Update(){
        if(SceneManager.GetActiveScene().name == "Menu"){
            if (Input.GetKeyDown(KeyCode.I)){
                contadorIMENU++;
            }else if(Input.GetKeyDown(KeyCode.P)){
                contadorPMENU++;
            }
            if(contadorIMENU >= 5){
                contadorIMENU = 0;
                QuitGame();
            }else if(contadorPMENU >= 5){
                contadorPMENU = 0;
                OnPlayButton();
            }
        }
        if(SceneManager.GetActiveScene().name == "Derrota"){
            if (Input.GetKeyDown(KeyCode.I)){
                contadorIDER++;
            }else if(Input.GetKeyDown(KeyCode.P)){
                contadorPDER++;
            }
            if(contadorIDER >= 5){
                contadorIDER = 0;
                OnMenuButton();
            }else if(contadorPDER >= 5){
                contadorPDER = 0;
                OnVolverJugarButton();
            }
        }
    }
   public void OnPlayButton()
   {                            
       SceneManager.LoadScene("Dificultad");
   }
   public void QuitGame()
   {
       Debug.Log("Quit");
       Application.Quit();
   }
    public void OnVolverJugarButton(){
        SceneManager.LoadScene("Dificultad");

    }
    public void OnMenuButton(){
        SceneManager.LoadScene("Menu");
    }
}