using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 1.0f;
    private Rigidbody rb; //RigitBody tan�mlamas�
    private Animator animator; //animasyon de�eri tan�mlan�r, public olarak tan�mlasayd�k direkt i�ine s�r�kleyebilirdik
    public List<GameObject> goldList; //ta��d���m�z goldlar� i�eren liste
    public int carry; //anl�k ka� tane gold ta��d���m�z� tutar

    public int carryLimit => goldList.Count; //goldList i�erisindeki limiti tutar, oyunun en ba��nda bu 3't�r
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb var olan rigitbody'e ba�lan�r.
        animator = GetComponent<Animator>(); //animasyona ula�may� sa�lar. animasyonun private tan�mland��� durumlarda yaz�l�r.

    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //klavyedeki horizontal de�erleri al�r.
        var vartical = Input.GetAxis("Vertical"); //klavyedeki vertical de�erleri al�r.

        var movementDirection = new Vector3(horizontal, 0, vartical); //(x,y,z) gidece�imiz y�n belirlenir. y eksenini istemedi�iimiz i�in z'de vartical.

        animator.SetBool("isRunning", movementDirection != Vector3.zero); //movementDir. s�f�rdan farkl�ysa bool'a de�er aktaar�l�r
        //animator.SetBool("isRunning", rb.velocity != Vector3.zero); bu �ekilde de yaz�labilir, h�za g�re kontrol eder.
        animator.SetBool("isCarrying", carry != 0); //carry s�f�r de�ilken isCarrying boolu true olur ve animasyonlar �al���r

        if (movementDirection == Vector3.zero) //karakterin 0,0 noktas�na d�nmemesi i�in, oldu�u gibi kalmas�n� sa�lar.
        {
            Debug.Log("input doesn't exist.");
            rb.velocity = Vector3.zero; //input alm�yorsa h�z� 0'a �ekilir.
            return;
        }

        rb.velocity = movementDirection * movementSpeed; //hareket h�z� ekleme

        var rotationDirection = Quaternion.LookRotation(movementDirection); //movementDirection y�n�n� rotation olarak kaydeder
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime); 
        //(a,b,t) a noktas�ndan b noktas�na t s�rede gider.
        //Time.delta ile �arpt���m�zda fps'lerin farkl� olma sorunu ��z�l�r.

    }

    public bool CollectGold() 
    {
        if (carry == carryLimit) return false; //carry say�s�n� a�arsa masalardan daha fazla gold alamamas� i�in
            
            goldList[carry].gameObject.SetActive(true); //ta��d���m�z gold objelerini g�r�n�r yapar.
            carry++;
            return true;

    }
}
