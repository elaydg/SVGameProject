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
            Invoke(nameof(ReloadGold), Random.Range(5f,15f)); 
            //Inkove fonksiyon ismini string olarak al�r ve belirlenen s�re sonra �al��t�r�r. isim k�sm�nda sorun ��kmamas� i�in nameof() fonk.
            //kullan�labilir. 5-15 aras� rastgele saniyelerde ReloadGold fonk �al��t�r�r.
        }
    }
    private void ReloadGold() 
    {
        goldObject.SetActive(true); //alt�n objesini a�ar
    }


}
