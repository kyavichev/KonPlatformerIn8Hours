using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager GetInstance() { return instance; }

    public GameUIController uiController;
    public GameObject hero;


    void Awake()
    {
        GameManager.instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    public void Win()
    {
        uiController.Win();
    }
}
