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
        tf.position += tf.right * movementSpeed * Time.deltaTime;
        GameManager.instance.enemiesList.Add(this.gameObject);
        //adjext roto to head toward player
    }
    
    public void Shoot()
    {
        throw new NotImplementedException();
    }

    public void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.Player)
        {
            Debug.Log("The Player Has Collided With " + this.gameObject.name);
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }

    public void OnDestroy()
    {
        Debug.Log("The Enemy Has Died");
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }
}