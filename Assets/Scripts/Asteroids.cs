using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public float movementSpeed = 3.0f;
    public float rotatinSpeed = 90;
    public Transform target;
    public Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
        tf = gameObject.GetComponent<Transform>();
        if (target == null)
        {
            if (GameManager.instance.Player)
            {
                target = GameManager.instance.Player.transform; 
            }
        }
        if (target != null)
        {
            rotateTowards(target, true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.right * movementSpeed * Time.deltaTime;
    }
    
    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }

    public void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject == GameManager.instance.Player)
        {
            Debug.Log("The Player Has Collided With " + this.gameObject.name);
            Die();
            otherObject.gameObject.GetComponent<Player>().Die();
        }
    }

    public void rotateTowards(Transform target, bool isInstant)
    {
        Vector3 direction = target.position - transform.position;
        direction.Normalize();
        float zAngle = (Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 0);
        if (!isInstant)
        {
            Quaternion targetLocation = Quaternion.Euler(0, 0, zAngle);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, rotatinSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, zAngle);
        }
    }

    internal void Die()
    {
        Destroy(this.gameObject);
    }
}
