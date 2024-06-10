using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public enum Carriles { IZQUIERDA, CENTRO, DERECHA}


public class PlayerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 5f;
    public float maxSpeed = 17f; // Velocidad de movimiento del jugador
    [SerializeField] float jumpForce = 8f; // Fuerza del salto
    public float fallForce = 11.5f; // Fuerza del salto
    public float laneWidth = 3f; // Ancho de cada carril
    public Transform[] lanePositions; // Arreglo de transformaciones de los carriles
    private Carriles currentLane = Carriles.CENTRO; // Carril actual (comienza en el carril central)
    private bool isJumping = false; // Variable para rastrear si el jugador está saltando
    private float carril=1;
    private Rigidbody rb;
    public float speedIncreasePerPoint;
    public float rotationSpeed = 20f;
    private bool isLayingDown = false;
        private Vector3 initialPosition;
    public float timeSliding = 1f;


    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Obtener el componente Rigidbody
        if(Dificultad.facil){
            speedIncreasePerPoint = 0.2f;
            Debug.Log("Facil velocidad activada");
        }else if(Dificultad.normal){
            speedIncreasePerPoint = 0.4f;
        }else if(Dificultad.dificil){
            speedIncreasePerPoint = 0.6f;
        }
    }

    void Update()
    {
       if(!alive)return; 
        // Movimiento lateral
        if (Input.GetKeyDown(KeyCode.A) && currentLane > Carriles.IZQUIERDA && !isLayingDown)
        {
            MoveLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) && currentLane < Carriles.DERECHA && !isLayingDown)
        {
            MoveLane(1);
        }

        // Salto
        if (Input.GetKeyDown(KeyCode.W) && !isJumping)
        {
            Jump();
        }

        //Ir para abajo
        if (Input.GetKeyDown(KeyCode.S) && isJumping)
        {
            GoDown();
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isJumping ){
            Slide();
        }
        float timeSliding = 1f;
        Vector3 fowardMove = transform.forward * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + fowardMove);

        if(transform.position.y < -5){
            Die();
        }


    }

    void Slide(){
        if (!isLayingDown)
            {
                StartCoroutine(LayDownForASecond());
            }
            //else
    
    }

    IEnumerator LayDownForASecond()
    {
        isLayingDown = true;
        transform.rotation = Quaternion.Euler(- 90, 0, 0); 
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX;
        rb.velocity = new Vector3(0, 0, speed);
        
        if(speed > 8){
            timeSliding = 0.85f;
        }else if(speed > 14){
            timeSliding = 0.65f;
        }else if(speed > 20){
            timeSliding = 0.60f;
        }
        yield return new WaitForSeconds(timeSliding);
        rb.constraints = RigidbodyConstraints.None;
        // Stand the player back up
        transform.rotation = Quaternion.identity; 
        rb.velocity = Vector3.zero;
        isLayingDown = false;
        
        
        
    }

    void GoDown()
    {
      rb.AddForce(Vector3.down * fallForce, ForceMode.Impulse);
    }

    void MoveLane(int direction)
    {
        Debug.Log("Direction: " + direction + " Current Lane: " + currentLane);
        currentLane += direction;
        Debug.Log("Direction: " + direction + " Current Lane: " + currentLane);
        
        // Asegúrate de que el carril actual esté dentro de los límites del enum
        if (currentLane <= Carriles.IZQUIERDA)
        {
            currentLane = Carriles.IZQUIERDA;
            Debug.Log(" Current Lane: " + currentLane);
            
        }
        else if (currentLane >= Carriles.DERECHA)
        {
            currentLane = Carriles.DERECHA;
        }

        // Calcula la nueva posición del jugador en función del carril actual
        if(currentLane == Carriles.IZQUIERDA){
             carril = -1;
        }else if(currentLane == Carriles.CENTRO){
             carril = 0;
        }else{
            carril = 1;
        }   
        float targetX = carril * laneWidth;
        Vector3 newPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        transform.position = newPosition;         
        
    }


    void Jump()
    {
        // Aplica una fuerza vertical para hacer que el jugador salte
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isJumping = true;
    }

    // Restablece la variable isJumping cuando el jugador aterriza
    void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

    public void Die(){
        alive = false;
        SceneManager.LoadScene("Derrota");
    }
    
   
}


