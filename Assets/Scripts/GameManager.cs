using System.Net.WebSockets;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private Player player;
    [SerializeField] private spawn spawn;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject Pauzowanie;
    private int score;
    public int Score => score;
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
            Application.targetFrameRate = 60;
            DontDestroyOnLoad(gameObject);
            Pause();
        }
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        Pauzowanie.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
        player.GoToStart();
    }
    public void GameOver()
    {
        playButton.SetActive(true);
        gameOver.SetActive(true);

        Pause();
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    public void PauzaGry()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Pauzowanie.SetActive(true);
    }
    public void WznowienieGry()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Pauzowanie.SetActive(false);
    }

}

