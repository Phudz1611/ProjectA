using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    // Start is called before the first frame update

    void Start() {
        Cursor.lockState = CursorLockMode.None;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}
