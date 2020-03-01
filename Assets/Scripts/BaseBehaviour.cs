using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBehaviour : MonoBehaviour
{
    bool isActive;
    public Light greenLight;
    public PlayerBehaviour rechargeALife;
    public Material changeColorBaseLight;

    Renderer colorBase;
    void Start()
    {
        colorBase = GetComponent<Renderer>();
        colorBase.enabled = true;
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag.Equals("Player"))
        {
            isActive = true;
            greenLight.enabled = true;
            colorBase.material = changeColorBaseLight;
            //this.gameObject.GetComponent<MeshRenderer>().materials[1] = colorBase.material;
            this.gameObject.GetComponent<MeshRenderer>().materials.SetValue(colorBase.material,1);
            rechargeALife.BaseFounded();
        }
    }
}
