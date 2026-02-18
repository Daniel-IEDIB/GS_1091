using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Panels {
    public class PanelManager : MonoBehaviour {
        [SerializeField] private GameObject MainMenu;
        [SerializeField] private GameObject SettingsMenu;
        [SerializeField] private GameObject CreditsMenu;
        private VisualElement _rootSettings;
        private VisualElement _rootMain;
        private VisualElement _rootCredits;

        private void OnEnable() {
            LoadMainMenu();
            LoadSettingsMenu();
            LoadCreditsMenu();
        }

        private void LoadMainMenu() {
            _rootMain = MainMenu.GetComponent<UIDocument>().rootVisualElement;

            Button playButton = _rootMain.Q<Button>("PlayButton");
            Button settingsButton = _rootMain.Q<Button>("SettingsButton");
            Button creditsButton = _rootMain.Q<Button>("CreditsButton");
            Button exitButton = _rootMain.Q<Button>("ExitButton");

            playButton.clicked += OnClickPlayButton;
            settingsButton.clicked += OnClickSettingsButton;
            creditsButton.clicked += OnClickCreditsButton;
            exitButton.clicked += OnClickExitButton;
        }
        
        private void LoadSettingsMenu() {
            _rootSettings = SettingsMenu.GetComponent<UIDocument>().rootVisualElement;
            Button returnButton = _rootSettings.Q<Button>("ReturnButton");
            returnButton.clicked += OnClickReturnButton;

            _rootSettings.style.display = DisplayStyle.None;
        }
        
        private void LoadCreditsMenu() {
            _rootCredits = CreditsMenu.GetComponent<UIDocument>().rootVisualElement;
            Button returnButton = _rootCredits.Q<Button>("ReturnButton");
            returnButton.clicked += OnClickReturnButton;

            _rootCredits.style.display = DisplayStyle.None;
        }

        private void OnClickPlayButton() {
            DisableScreens();
            SceneManager.LoadScene("Scenes/scene1", LoadSceneMode.Additive);
        }

        private void OnClickSettingsButton() {
            DisableScreens();
            _rootSettings.style.display = DisplayStyle.Flex;
            SettingsMenu.SetActive(true);
        }
        
        private void OnClickCreditsButton() {
            DisableScreens();
            _rootCredits.style.display = DisplayStyle.Flex;
            CreditsMenu.SetActive(true);
        }

        private void OnClickReturnButton() {
            DisableScreens();
            _rootMain.style.display = DisplayStyle.Flex;
        }

        private static void OnClickExitButton() {
            /*if (UnityEditor.EditorApplication.isPlaying) UnityEditor.EditorApplication.isPlaying = false;
            else Application.Quit();*/
            Application.Quit();
        }

        private void DisableScreens() {
            _rootMain.style.display = DisplayStyle.None;
            _rootSettings.style.display = DisplayStyle.None;
            _rootCredits.style.display = DisplayStyle.None;
        }
    }
}