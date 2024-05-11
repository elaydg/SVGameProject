using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 1.0f;
    private Rigidbody rb; //RigitBody tanýmlamasý

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb var olan rigitbody'e baðlanýr.
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //klavyedeki horizontal deðerleri alýr.
        var vartical = Input.GetAxis("Vertical"); //klavyedeki vertical deðerleri alýr.

        var movementDirection = new Vector3(horizontal, 0, vartical); //(x,y,z) gideceðimiz yön belirlenir. y eksenini istemediðiimiz için z'de vartical.

        if (movementDirection == Vector3.zero) //karakterin 0,0 noktasýna dönmemesi için, olduðu gibi kalmasýný saðlar.
        {
            Debug.Log("input doesn't exist.");
            return;
        }

        rb.velocity = movementDirection * movementSpeed; //hareket hýzý ekleme

        var rotationDirection = Quaternion.LookRotation(movementDirection); //movementDirection yönünü rotation olarak kaydeder
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime); 
        //(a,b,t) a noktasýndan b noktasýna t sürede gider.
        //Time.delta ile çarptýðýmýzda fps'lerin farklý olma sorunu çözülür.

    }
}
