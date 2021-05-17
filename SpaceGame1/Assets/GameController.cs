using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public UnityEngine.UI.Text scoreLabel;
    public UnityEngine.UI.Image menu;
    public UnityEngine.UI.Button startButton;
    public UnityEngine.UI.Button respawn;
    public UnityEngine.UI.Button quit;
    public UnityEngine.UI.RawImage fullhp;
    public UnityEngine.UI.RawImage halfhp;
    public UnityEngine.UI.RawImage lowhp;
    public UnityEngine.Light ImmuneLight;
    private static GameObject player;
    private static int score = 0;
    private static bool started = false;
    public static int health = 3;
    private static GameObject respawnButton;
    private static GameObject quitButton;
    public static bool Immune;

    void GoLight()
    {
        if (Immune) ImmuneLight.gameObject.SetActive(true);
        else ImmuneLight.gameObject.SetActive(false);
    }

    public static void increaseScore(int increment)
    {
        score += increment;
    }

    void Start()
    {
        fullhp.gameObject.SetActive(false);
        halfhp.gameObject.SetActive(false);
        lowhp.gameObject.SetActive(false);
        respawnButton = respawn.gameObject;
        quitButton = quit.gameObject;
        player = GameObject.FindGameObjectWithTag("Player");
        startButton.onClick.AddListener(delegate
        {
            health = 3;
            score = 0;
            menu.gameObject.SetActive(false);
            Immune = true;
            started = true;
            player.SetActive(true);
            player.transform.position = new Vector3(0, 0, -72);
            ShowHealth();
        });
        quit.onClick.AddListener(delegate
        {
            quit.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
            ShowHealth();
            started = false;
        });
        respawn.onClick.AddListener(delegate
        {
            Immune = true;
            respawn.gameObject.SetActive(false);
            player.SetActive(true);
            player.transform.position = new Vector3(0, 0, -72);
            ShowHealth();
        });
    }
    public static void PlayerIsDead()
    {
        score -= 50;
        if (score < 0) score = 0;
        if (health == 0)
        {
            player.SetActive(false);
            quitButton.SetActive(true);
        }
        else
        {
            player.SetActive(false);
            respawnButton.SetActive(true);
        }
    }

    public static bool IsStarted()
    {
        return started;
    }

    public void ShowHealth()
    {
        if (health == 3) { fullhp.gameObject.SetActive(true); halfhp.gameObject.SetActive(false); lowhp.gameObject.SetActive(false); }
        if (health == 2) { halfhp.gameObject.SetActive(true); lowhp.gameObject.SetActive(false); fullhp.gameObject.SetActive(false); }
        if (health == 1) { lowhp.gameObject.SetActive(true); halfhp.gameObject.SetActive(false); fullhp.gameObject.SetActive(false); }
        if (health == 0) { halfhp.gameObject.SetActive(false); fullhp.gameObject.SetActive(false); lowhp.gameObject.SetActive(false); }
    }
    // Update is called once per frame
    void Update()
    {
        GoLight();
        scoreLabel.text = score.ToString();
    }
}
