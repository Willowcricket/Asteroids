using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform tf;
    public float movementSpeed = 2.75f;
    public float rotatinSpeed = 60;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        GameManager.instance.enemiesList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.right * movementSpeed * Time.deltaTime;
        if (target == null)
        {
            if (GameManager.instance.Player)
            {
                target = GameManager.instance.Player.transform; 
            }
        }
        else
        {
            rotateTowards(target, false);
        }
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
            Die();
            otherObject.gameObject.GetComponent<Player>().Die();

        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void OnDestroy()
    {
        Debug.Log("The Enemy Has Died");
        GameManager.instance.enemiesList.Remove(this.gameObject);
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
}