using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public GameObject objectivePlayer;
    public Vector3 targetPosition;
    public float cameraSpeed; 
    public float minimumHeight;

    Vector3 height; 

    void LateUpdate()
    {
        FollowPlayer();
    }

    void FollowPlayer()
    {
        targetPosition = new Vector3(objectivePlayer.transform.position.x, objectivePlayer.transform.position.y + minimumHeight, objectivePlayer.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);  
    }
}
