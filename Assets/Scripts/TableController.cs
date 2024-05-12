using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    
    public GameObject goldObject;
    public bool IsGoldCollectable => goldObject.activeSelf; //goldobject'in açýk olup olmadýðýný kontrol eder
    private void OnCollisionEnter(Collision other) //nesnelerin çarpýþmaya baþladýðý an çalýþmaya baþlayan fonksiyon
    {
        if (!IsGoldCollectable) return; //eðer false ise boþ masaya deðdiðinde carry artmaz

        if (other.gameObject.tag != "Player") return;
        var player = other.gameObject.GetComponent<PlayerController>(); //player deðeri playerController scriptine ulaþýr.

        if (player.CollectGold()) 
        {
            goldObject.SetActive(false);
        }
    }


}
