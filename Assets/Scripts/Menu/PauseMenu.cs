using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pauseMenuUI;
    public Button exitButton;
    // Update is called once per frame
    
    void Start() 
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(exitGame);
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

    public void exitGame() 
    {
        Debug.Log("DEN KLIKKER PÅ KNAPPEN");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        
    }
}
