using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasActions : MonoBehaviour
{
    private const string MAIN_SCENE = "SampleScene";

    public void restartGame() {
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
