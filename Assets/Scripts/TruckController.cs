using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    public List<GameObject> golds;
    public GameObject goldsParent;
    private int currentGold; //anlýk olarak araçta tutulan gold sayýsý

    private void Start()
    {
        golds = new List<GameObject>();

        foreach (Transform gold in goldsParent.transform) //goldsParent altýndaki tüm çocuklara gold adý altýnda eriþebiliriz.
        {
            golds.Add(gold.gameObject); //goldlarý listenin içine ekler
            gold.gameObject.SetActive(false); //oyun baþlangýcýnda araçtaki goldlar görünmez
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag != "Player") return; //sadece player ile etkileþime geçer
        var player = other.gameObject.GetComponent<PlayerController>(); //player ise, player adýnda bir obje oluþturduk ve scripte ulaþtýk

        var gold = player.LoadGoldsToTruck(); //playerdaki altýn sayýsýný gold deðerine atadýk
        currentGold += gold; //playerdan gelen gold deðeriyle toplanýr.

        for (int i = 0; i < currentGold; i++) 
        {
            golds[i].SetActive(true); //arabadaki altýnlarý aktif etmemizi saðlar
        }

        
    }

}
