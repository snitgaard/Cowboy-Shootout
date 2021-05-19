using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    public GameObject UI;
    public GameObject startMenuUI;
    public Button startButton;
    public PlayerSpawner playerSpawner;
    public PowerUpSpawner powerUpSpawner;
    public SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(startGame);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startGame() 
    {
        Debug.Log("Den gør det her");
        playerSpawner.spawnPlayer();
        powerUpSpawner.spawnPowerUp();
        spawnManager.startEnemySpawn();
        startMenuUI.SetActive(false);
        UI.SetActive(true);
    }
}
