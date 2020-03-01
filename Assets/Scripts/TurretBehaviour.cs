using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public Transform guns;
    public GameObject playerSpaceship;
    public GameObject bulletPrefab;
    public int shootDistance;
    public int shootRate;
    public int speedShoot;

    int lastTimeShoot;
    Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //placeObjective(playerSpaceship.GetComponent<Collider>());
        guns.transform.LookAt(playerSpaceship.transform);
    }

    void OnTriggerEnter(Collider objective)
    {
        if(objective.transform == playerSpaceship.transform)
        {
            TurretShoot();
        }
    }
    void TurretShoot()
    {
        if(lastTimeShoot < shootRate)
        {
            GameObject bulletInstantiated = GameObject.Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0.2f, 0.51f), Quaternion.identity);
            Debug.Log("Posición balas instanciadas: " + bulletInstantiated.transform.position);
            bulletRigidbody = bulletInstantiated.GetComponent<Rigidbody>();
            bulletRigidbody.AddForce(transform.forward * speedShoot);
            lastTimeShoot++;
            Debug.Log("El valor de lastTime: " + lastTimeShoot);
            Destroy(bulletInstantiated, 2f);
        }
        if (lastTimeShoot >= shootRate)
            lastTimeShoot = 0;
        //else
        //{
            //lastTimeShoot = 0;
        //}
    }
}
