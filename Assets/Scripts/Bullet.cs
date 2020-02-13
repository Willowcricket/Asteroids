using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform tf;
    public float bulletSpeed = 8.0f;
    public GameObject Killbox;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        tf.position += tf.right * bulletSpeed * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D otherObject)
    {
        if (otherObject.gameObject != GameManager.instance.Player || otherObject.gameObject != Killbox)
        {
            Debug.Log("The Player Has Collided With " + this.gameObject.name);
            Destroy(otherObject.gameObject);
            Destroy(this.gameObject);
        }
    }
}
