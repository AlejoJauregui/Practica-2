using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public int bulletSpeed;
    public GameObject playerToDestroy;
    //public Rigidbody bulletRigidbody;

    Vector3 bulletDirection;
    PlayerBehaviour player;

    private void Start()
    {
        //bulletRigidbody = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {

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
            player.Hit(playerToDestroy);
            destroyTrigger.gameObject.SetActive(false);
        }
            
    }

    //Por alguna extraña razón, cuando llamaba este método en el PlayerBehaviour no añadía fuerza a la bala y esta no se movía. 
    public void setDirection (Rigidbody bullet)
    {
        //bulletRigidbody.AddForce(direction * velocity * Time.deltaTime);
        //transform.position = direction * velocity * Time.deltaTime;
        //bulletRigidbody.AddRelativeForce(direction.normalized * velocity, ForceMode.VelocityChange);
        bullet.AddForce(Vector3.forward * bulletSpeed);
        Debug.Log("Entré: " + bullet.transform.position);
    }
}
