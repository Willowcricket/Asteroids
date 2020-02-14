using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform tf;
    public float rotationSpeed = 90.0f;
    public float movementSpeed = 4.0f;

    public GameObject BulletPreFab;
    public Transform FirePoint;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            tf.Rotate(0,0,rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            tf.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Instantiate(BulletPreFab, FirePoint.position, FirePoint.rotation);
    }

    public void OnDestroy()
    {
        Debug.Log("The Player Has Died");
        GameManager.instance.Lives--;
    }

    public void Die()
    {
        foreach (GameObject gameO in GameManager.instance.enemiesList)
        {
            if (gameO.GetComponent<Enemy>())
            {
                gameO.GetComponent<Enemy>().Die(); 
            }
            else if (gameO.GetComponent<Asteroids>())
            {
                gameO.GetComponent<Asteroids>().Die();
            }
        }
        Destroy(this.gameObject);
    }
}
