using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button respawn;
    private static GameObject player;

    private static int score = 0;
    private static bool started = false;

    private static GameObject respawnButton;

    public static void increaseScore(int increment)
    {
        score += increment;
    }
    void Start()
    {
        respawnButton = respawn.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        startButton.onClick.AddListener(delegate
        {
            score = 0;
            menu.gameObject.SetActive(false);
            started = true;
            player.SetActive(true);
            player.transform.position = new Vector3(0, 0, -72);
        });        
        respawn.onClick.AddListener(delegate
        {
            respawn.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
            started = false;
        });
    }
    public static void PlayerIsDead()
    {
        respawnButton.SetActive(true);
        player.SetActive(false);
    }

    public static bool IsStarted()
    {
        return started;
    }

    void Update()
    {
        scoreLabel.text = score.ToString();
    }
}
