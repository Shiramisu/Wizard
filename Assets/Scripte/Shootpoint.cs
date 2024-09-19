using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Shootpoint : MonoBehaviour
{

    public Transform shootPoint;    // Referenz fuer die Zuordnung in Unity zu ShootPoint
    public GameObject bulletPrefab; // Referenz fuer die Zuordnung in Unity unter bulletPrefab

    public float shootForce = 50;       // Fuegt eine Feuerkraft von 50 hinzu
    public float cooldownTime = 3f;     // Fuegt ein Cooldown in hoehe von 3 sek. hinzu
    private float nextFireTime = 0f;    // Fuegt eine Zeit hinzu, wann der naechste Schuss fallen darf


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //  Ueberprueft, ob die linke Maustasete & der Cooldown abgelaufen ist
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            //  Feuert den Schuss ab
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.position = shootPoint.transform.position;

            Rigidbody rb = newBullet.GetComponent<Rigidbody>();
            rb.AddForce(shootPoint.transform.forward * shootForce, ForceMode.Impulse);

            // Zerstoert das "newBullet" nach 2sek.
            Destroy(newBullet, 2);

            //  Setzt die naechste erlaubte Schusszeit auf die aktuelle, plus den Cooldown
            nextFireTime = Time.time + cooldownTime;
        }
    }
}