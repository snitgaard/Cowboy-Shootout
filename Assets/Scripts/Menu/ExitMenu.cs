using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject exitMenuUI;
    public GameObject UI;
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

    public void playerLost() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        UI.SetActive(false);
        exitMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    
    public void playerWon() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        UI.SetActive(false);
        exitMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void exitGame() 
    {
        Debug.Log("DEN KLIKKER PÅ KNAPPEN");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        
    }
}
