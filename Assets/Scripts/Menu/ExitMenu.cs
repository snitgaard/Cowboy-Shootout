using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExitMenu : MonoBehaviour
{
    public GameObject exitMenuUI;
    public GameObject UI;
    public Button exitButton;
    void Start() 
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(exitGame);
    }
    
    public void gameOver() 
    {
        Cursor.lockState = CursorLockMode.Confined;
        UI.SetActive(false);
        exitMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void exitGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
