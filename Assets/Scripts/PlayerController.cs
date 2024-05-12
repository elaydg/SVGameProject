using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 1.0f;
    private Rigidbody rb; //RigitBody tanýmlamasý
    private Animator animator; //animasyon deðeri tanýmlanýr, public olarak tanýmlasaydýk direkt içine sürükleyebilirdik
    public List<GameObject> goldList; //taþýdýðýmýz goldlarý içeren liste
    public int carry; //anlýk kaç tane gold taþýdýðýmýzý tutar

    public int carryLimit => goldList.Count; //goldList içerisindeki limiti tutar, oyunun en baþýnda bu 3'tür
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb var olan rigitbody'e baðlanýr.
        animator = GetComponent<Animator>(); //animasyona ulaþmayý saðlar. animasyonun private tanýmlandýðý durumlarda yazýlýr.

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //klavyedeki horizontal deðerleri alýr.
        var vartical = Input.GetAxis("Vertical"); //klavyedeki vertical deðerleri alýr.

        var movementDirection = new Vector3(horizontal, 0, vartical); //(x,y,z) gideceðimiz yön belirlenir. y eksenini istemediðiimiz için z'de vartical.

        animator.SetBool("isRunning", movementDirection != Vector3.zero); //movementDir. sýfýrdan farklýysa bool'a deðer aktaarýlýr
        //animator.SetBool("isRunning", rb.velocity != Vector3.zero); bu þekilde de yazýlabilir, hýza göre kontrol eder.
        animator.SetBool("isCarrying", carry != 0); //carry sýfýr deðilken isCarrying boolu true olur ve animasyonlar çalýþýr

        if (movementDirection == Vector3.zero) //karakterin 0,0 noktasýna dönmemesi için, olduðu gibi kalmasýný saðlar.
        {
            Debug.Log("input doesn't exist.");
            rb.velocity = Vector3.zero; //input almýyorsa hýzý 0'a çekilir.
            return;
        }

        rb.velocity = movementDirection * movementSpeed; //hareket hýzý ekleme

        var rotationDirection = Quaternion.LookRotation(movementDirection); //movementDirection yönünü rotation olarak kaydeder
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime); 
        //(a,b,t) a noktasýndan b noktasýna t sürede gider.
        //Time.delta ile çarptýðýmýzda fps'lerin farklý olma sorunu çözülür.

    }

    public bool CollectGold() 
    {
        if (carry == carryLimit) return false; //carry sayýsýný aþarsa masalardan daha fazla gold alamamasý için
            
            goldList[carry].gameObject.SetActive(true); //taþýdýðýmýz gold objelerini görünür yapar.
            carry++;
            return true;

    }
}
