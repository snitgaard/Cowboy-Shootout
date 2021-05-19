using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
 

    public GameObject pauseMenuUI;
    // Update is called once per frame
    
    void Start() 
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            playerWon();
        }
    }


    void Pause()
    {
        
    }

    public void playerLost() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    
    public void playerWon() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
