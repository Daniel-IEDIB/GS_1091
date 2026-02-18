    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class GameManager : MonoBehaviour {
        
        public GameObject Panel1;
        public Button Road1Button;
        public Button Road2Button;
        public Button ResumeButton;
        public Button ExitButton;
        
        public GameObject MenuPanel;
        public Button MenuButton;
        
        private void Awake() {
            Road1Button.onClick.AddListener(LoadRoad1);
            Road2Button.onClick.AddListener(LoadRoad2);
            MenuButton.onClick.AddListener(OpenPanel1);
            ResumeButton.onClick.AddListener(ResumeGame);
            ExitButton.onClick.AddListener(ExitGame);
        }

        private void LoadRoad1() {
            SceneManager.LoadScene("Scenes/Road1", LoadSceneMode.Single);
            Time.timeScale = 1f;
            
            MenuPanel.SetActive(true);
            Panel1.SetActive(false);
        }

        private void LoadRoad2() {
            SceneManager.LoadScene("Scenes/Road2", LoadSceneMode.Single);
            Time.timeScale = 1f;
            
            MenuPanel.SetActive(true);
            Panel1.SetActive(false);
        }

        private void OpenPanel1() {
            Time.timeScale = 0f;
            MenuPanel.SetActive(false);
            Panel1.SetActive(true);
        }

        private void ResumeGame() {
            Panel1.SetActive(false);
            MenuPanel.SetActive(true);
            Time.timeScale = 1f;
        }

        private static void ExitGame() {
            Application.Quit();
        }
    }