using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Core
{
    internal class MainMenu : MonoBehaviour
    {
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
