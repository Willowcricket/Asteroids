using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform tf;
    public float movementSpeed = 2.75f;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position -= tf.right * movementSpeed * Time.deltaTime;
    }
    
    public void Shoot()
    {
        throw new NotImplementedException();
    }

    public void OnDestroy()
    {
        Debug.Log("The Enemy Has Died");
    }
}