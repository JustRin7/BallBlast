using UnityEngine;
using UnityEngine.SceneManagement;//работа со сценой


public class SceneHelper : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void RestartLevel()//метод перезагрузки лвл
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );//получение текущей сцены
    }

    public void LoadLevel(int buildIndex)//включает лвл на старте
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void Quit()//выход из игры
    {
        Application.Quit();
    }

}
