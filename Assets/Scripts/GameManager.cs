using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerPreFab;
    public GameObject Player;
    public GameObject AsteroidPreFab;
    public static GameManager instance;
    public int Lives = 3;
    public int score = 0;
    public List<GameObject> enemiesList = new List<GameObject>();
    public GameObject[] enemyPreFabs;
    public List<GameObject> spawnPoints = new List<GameObject>();

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            Debug.LogError("I tried to create a second game manager");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputHandler();
        SpawnHandler();
    }

    private void InputHandler()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("The Player Has " + Lives + " Lives Remaining");
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            Lives++;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Player == null)
            {
                Respawn();
            }
            else
            {
                Debug.Log("There is already a Player");
            }
        }
    }

    private void SpawnHandler()
    {
        if (GameManager.instance.Player == null)
        {

        }
        else if (enemiesList.Count < 3)
        {
            int spawns = Random.Range(0, spawnPoints.Count);
            int enemyPres = Random.Range(0, enemyPreFabs.Length);
            Instantiate(enemyPreFabs[enemyPres], spawnPoints[spawns].transform.position, spawnPoints[spawns].transform.rotation);
        }
        
    }

    public void Respawn()
    {
        if (Lives > 0)
        {
            Player = Instantiate(PlayerPreFab);
        }
        else
        {
            Debug.Log("You have no more lives");
        }
    }
}
