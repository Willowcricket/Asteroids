using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

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
            Destroy(otherObject.gameObject);
        }
    }
}
