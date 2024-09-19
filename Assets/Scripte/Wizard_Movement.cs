using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wizard_Steuerung : MonoBehaviour
{

    public Rigidbody rb;    // Referenz auf den Rigidbody des Charakters, notwendig fuer physikalische Berechnungen
    public AudioSource audioSource; // Referenz auf die Audioquelle, die den Sprung-Sound abspielen wird

    public float speed = 5f;    // Geschwindigkeit des Charakters
    public float jumpForce = 5f;    // Sprungkraft des Charakters

    private bool isGrounded = true; // Boolesche Variable, die anzeigt, ob der Charakter auf dem Boden steht

    UnityEngine.Vector3 startPos;   //Speichert die Startposition des Charakters



    // Start wird einmalig beim Start des Spiels aufgerufen
    private void Start()
    {
        startPos = transform.position;  // Speichern der aktuellen Position als Startposition
    }





    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        // Charakter Movement with Rigidbody
        // Erfassen der horizontalen und vertikalen Eingaben des Spielers
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // Die Position wird mithilfe des Rigidbodys geaendert
        rb.MovePosition(rb.position + (new Vector3(x, 0, z) * speed * Time.deltaTime));


        
        //  Charakter fall (fallen)
        if (transform.position.y < -5)  // Ueberprueft ob der Charakter auf der Y-Achse unter -5 faellt
        {
            transform.position = startPos;  // Setzt den Charakter wieder auf die startPos
        }


        
        //  Charakter Jump
        // Ueberpruefen, ob die Leertaste gedrueckt wurde und der Charakter auf dem Boden steht
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            // Anwenden einer Kraft nach oben, um den Charakter springen zu lassen
            rb.AddForce(UnityEngine.Vector3.up * jumpForce, ForceMode.Impulse);

            isGrounded = false; // Setzen von isGrounded auf false, um zu verhindern, dass der Charakter mehrfach springt

            audioSource.Play(); // Abspielen des Sprung-Sounds
        }


        
        // Charakter Rotation
        if (x < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 270f, 0f);   // Nach links schauen
        }
        else if (x > 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 90f, 0f);    // Nach rechts schauen
        }
        else if (z > 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);     // Nach vorne schauen
        }
        else if (z < 0)
        {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);   // Nach hinten schauen
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}

