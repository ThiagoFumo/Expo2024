using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 offset;
    // Start is called before the first frame update
    private void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 targePos = player.position + offset;
        targePos.x = 0;
        transform.position = targePos;
    }
}
