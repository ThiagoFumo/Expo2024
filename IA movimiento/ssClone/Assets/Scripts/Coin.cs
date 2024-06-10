using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstacle>() != null){
            Destroy(gameObject);
            return;
        }
        if(other.gameObject.name != "Player"){
            return;
        }

        GameManager.inst.incrementScore();
        Debug.Log("Coin collected");

        Destroy(gameObject);
    }
    
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
