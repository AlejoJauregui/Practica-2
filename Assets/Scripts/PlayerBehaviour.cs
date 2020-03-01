using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    int playerLifes;
    int basesfounded;
    GameObject bulletInstantiated;
    Rigidbody bulletRigidbody;
    int bulletsCounter = 0;



    public int bulletSpeed;
    public float accelerationPlayer;
    public float turnAccelerationPlayer;
    public GameObject bulletPrefab;
    public Rigidbody playerRigidbody;
    void Start()
    {
        basesfounded = 0;
        playerLifes = 4;
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        TurnOnPlayerEngines();
        Shoot();
    }
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletInstantiated = GameObject.Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bulletRigidbody = bulletInstantiated.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(-transform.forward * bulletSpeed);
            Destroy(bulletInstantiated, 1.5f); 
        }

    }
    public void BaseFounded()
    {
        basesfounded++;
        playerLifes++;
        if (basesfounded == 4)
            Debug.Log("You founded all the bases captain. We are saved...GameOver");
    }
    public void Hit (GameObject objectToDestroy)
    {
        playerLifes--;
        if (playerLifes <= 0)
            Debug.Log("Mayday Captain...our systems are failing...we gonna die!...GAME OVER");
    }
    public void TurnOnPlayerEngines() //Method to move the spaceship on the scene
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
           playerRigidbody.AddRelativeForce( Vector3.back * accelerationPlayer * Time.deltaTime, ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.DownArrow))
            playerRigidbody.AddRelativeForce(Vector3.forward * accelerationPlayer * Time.deltaTime, ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.RightArrow))
            playerRigidbody.AddTorque(Vector3.up * turnAccelerationPlayer * Time.deltaTime, ForceMode.Acceleration);
        if (Input.GetKey(KeyCode.LeftArrow))
            playerRigidbody.AddTorque(-Vector3.up * turnAccelerationPlayer * Time.deltaTime, ForceMode.Acceleration);
    }
}
