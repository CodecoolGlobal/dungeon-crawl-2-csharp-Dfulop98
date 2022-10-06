using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Source.Core
{
    internal class MainMenu : MonoBehaviour
    {
        public void LoadNameGame()
        {
            SceneManager.LoadScene("NameMenu");
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
