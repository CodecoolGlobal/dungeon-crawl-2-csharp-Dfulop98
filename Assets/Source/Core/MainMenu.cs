using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Core
{
    internal class MainMenu : MonoBehaviour
    {
        public string PlayerName = "Röszkei Rambó";
        public void GoToChoiceScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        public void NewGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void QuitGame()
        {
            Application.Quit();
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
