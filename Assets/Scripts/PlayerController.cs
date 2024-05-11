using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 1.0f;
    private Rigidbody rb; //RigitBody tan�mlamas�

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //rb var olan rigitbody'e ba�lan�r.
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); //klavyedeki horizontal de�erleri al�r.
        var vartical = Input.GetAxis("Vertical"); //klavyedeki vertical de�erleri al�r.

        var movementDirection = new Vector3(horizontal, 0, vartical); //(x,y,z) gidece�imiz y�n belirlenir. y eksenini istemedi�iimiz i�in z'de vartical.

        if (movementDirection == Vector3.zero) //karakterin 0,0 noktas�na d�nmemesi i�in, oldu�u gibi kalmas�n� sa�lar.
        {
            Debug.Log("input doesn't exist.");
            return;
        }

        rb.velocity = movementDirection * movementSpeed; //hareket h�z� ekleme

        var rotationDirection = Quaternion.LookRotation(movementDirection); //movementDirection y�n�n� rotation olarak kaydeder
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationDirection, rotationSpeed * Time.deltaTime); 
        //(a,b,t) a noktas�ndan b noktas�na t s�rede gider.
        //Time.delta ile �arpt���m�zda fps'lerin farkl� olma sorunu ��z�l�r.

    }
}
