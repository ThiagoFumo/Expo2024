using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dificultad : MonoBehaviour
{
    public static bool facil =false;
    public static bool normal = false;
    public static bool dificil= false;

    int contadorIDIF= 0;
    int contadorODIF = 0;
    int contadorPDIF = 0;

    void Update(){
        if(SceneManager.GetActiveScene().name == "Dificultad"){
            if (Input.GetKeyDown(KeyCode.I)){
                contadorIDIF++;
            }else if(Input.GetKeyDown(KeyCode.O)){
                contadorODIF++;
            }else if (Input.GetKeyDown(KeyCode.P)){
                contadorPDIF++;
            }
            if(contadorIDIF >= 10){
                contadorIDIF = 0;
                OnFacilButton();
            }else if(contadorODIF >= 10){
                contadorODIF = 0;
                OnNormalButton();
            }else if(contadorPDIF >= 10){
                contadorPDIF = 0;
                OnDificilButton();
            }
        }
    }
    public void OnFacilButton()
    {
        facil = true;
        SceneManager.LoadScene("Juego"); 
    }
    public void OnNormalButton()
    {
        normal = true;
        SceneManager.LoadScene("Juego");
    }
    public void OnDificilButton()
    {
        dificil = true;
        SceneManager.LoadScene("Juego");
    }

}
