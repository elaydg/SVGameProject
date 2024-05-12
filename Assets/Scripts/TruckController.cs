using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public List<GameObject> golds;
    public GameObject goldsParent;
    private int currentGold; //anl�k olarak ara�ta tutulan gold say�s�

    private void Start()
    {
        golds = new List<GameObject>();

        foreach (Transform gold in goldsParent.transform) //goldsParent alt�ndaki t�m �ocuklara gold ad� alt�nda eri�ebiliriz.
        {
            golds.Add(gold.gameObject); //goldlar� listenin i�ine ekler
            gold.gameObject.SetActive(false); //oyun ba�lang�c�nda ara�taki goldlar g�r�nmez
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") return; //sadece player ile etkile�ime ge�er
        var player = other.gameObject.GetComponent<PlayerController>(); //player ise, player ad�nda bir obje olu�turduk ve scripte ula�t�k

        var gold = player.LoadGoldsToTruck(); //playerdaki alt�n say�s�n� gold de�erine atad�k
        currentGold += gold; //playerdan gelen gold de�eriyle toplan�r.

        for (int i = 0; i < currentGold; i++) 
        {
            golds[i].SetActive(true); //arabadaki alt�nlar� aktif etmemizi sa�lar
        }

        
    }

}
