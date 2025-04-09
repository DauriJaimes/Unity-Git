using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void AbrirEscena(string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
