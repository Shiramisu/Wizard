using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Feuerballd : MonoBehaviour
{

    public Vector3 moveDirection;
    public float speed = 10f;
    public float lifeTime = 2f;



    // Start is called before the first frame update
    void Start()
    {   
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {  
        transform.Translate(moveDirection * speed * Time.deltaTime);   
    }
}