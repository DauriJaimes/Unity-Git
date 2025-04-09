using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript
{
    public void AbrirEscena (string nombreEscena)
    {
        SceneManager.LoadScene(nombreEscena);   
    }
}
