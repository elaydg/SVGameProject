using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    
    public GameObject goldObject;
    public bool IsGoldCollectable => goldObject.activeSelf; //goldobject'in a��k olup olmad���n� kontrol eder
    private void OnCollisionEnter(Collision other) //nesnelerin �arp��maya ba�lad��� an �al��maya ba�layan fonksiyon
    {
        if (!IsGoldCollectable) return; //e�er false ise bo� masaya de�di�inde carry artmaz

        if (other.gameObject.tag != "Player") return;
        var player = other.gameObject.GetComponent<PlayerController>(); //player de�eri playerController scriptine ula��r.

        if (player.CollectGold()) 
        {
            goldObject.SetActive(false);
        }
    }


}
