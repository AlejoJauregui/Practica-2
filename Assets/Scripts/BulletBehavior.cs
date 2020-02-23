using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public int velocity;
    public GameObject objectToDestroy;

    Vector3 bulletDirection;
    PlayerBehaviour player; 
    void FixedUpdate()
    {
        setDirection(transform.position);
    }

    private void OnTriggerEnter(Collider destroyTrigger)
    {
        if(destroyTrigger.gameObject.tag.Equals("Turret"))
        {
            Debug.Log("Has destruido una " + destroyTrigger.name);
            destroyTrigger.gameObject.SetActive(false);
        }
        if(destroyTrigger.gameObject.tag.Equals("Player"))
        {
            player.Hit(objectToDestroy);
            destroyTrigger.gameObject.SetActive(false);
        }
            
    }

    public void setDirection (Vector3 direction)
    {
        bulletDirection = direction;
    }
}
