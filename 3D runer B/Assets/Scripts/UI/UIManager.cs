using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class UIManager : MonoBehaviour
{
    public InterstitialAds interstitialAds;

    public event Action<GameObject> StartGameEvent; 
    public Slider MagnetLevelSlider;
    public Slider MultiplierLevelSlider;

    [SerializeField] private GameObject plyCanvas;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject mainCanvas;

    private void Start()
    {
        if(!PlayerController.isplay)
        {
            AudioManager.Instance.PlayMusic("PlyMenuMusic");
        }

        CollisionDetector.OnCollisionDeathEvent += ShowLoseGamePanel;
        if(PlayerController.isplay)
        {
            mainCanvas.SetActive(false);
            plyCanvas.SetActive(true);
        }
    }
    private IEnumerator ShoowLosePanel()
    {
        yield return new WaitForSeconds(1);
        losePanel.SetActive(true);
        plyCanvas.SetActive(false);
    }

    private void ShowLoseGamePanel(GameObject gameObject)
    {
        StartCoroutine(ShoowLosePanel());
    }

    private void OnDisable()
    {
        CollisionDetector.OnCollisionDeathEvent -= ShowLoseGamePanel;
    }

    public void RestrartGame()
    {
        PlayerController.isplay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);      
    }

    public void StrtGame()
    {
        StartGameEvent.Invoke(gameObject);
        PlayerController.isplay = true;
        AudioManager.Instance.PlayMusic("PlyMusic");
    }

    public void MainMenu()
    {
        interstitialAds.ShowAd();
        PlayerController.isplay = false;
        AudioManager.Instance.musicSource.Pause();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        Time.timeScale = PlayerController.currentTimeScale;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
