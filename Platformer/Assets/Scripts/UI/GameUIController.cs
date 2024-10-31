using UnityEngine;

public class GameUIController : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject failPanel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GetInstance().hero == null)
        {
            failPanel.SetActive(true);
        }
    }


    public void Restart()
    {
        GameManager.GetInstance().Restart();
    }


    public void Win()
    {
        winPanel.SetActive(true);
    }
}
