using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeManager : MonoBehaviour
{
    public static PuntajeManager instance;

    public Text puntajePlayer1Text, puntajePlayer2Text;

    int puntajePlayer1 = 0;
    int puntajePlayer2 = 0;

    string tagPlayer1 = "";
    string tagPlayer2 = "";

    private void Awake()
    {
        instance = this;
    }

    public void setPuntajePlayer1(int puntaje, string tag)
    {
        this.puntajePlayer1 = puntaje;
        this.tagPlayer1 = tag;
    }

    public void setPuntajePlayer2(int puntaje, string tag)
    {
        this.puntajePlayer2 = puntaje;
        this.tagPlayer2 = tag;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntajePlayer1Text.text = "PUNTAJE " + tagPlayer1.ToString() + ":" + puntajePlayer1.ToString();
        puntajePlayer2Text.text = "PUNTAJE "+ tagPlayer2.ToString() + ":" + puntajePlayer2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //puntaje = puntaje + 1;
        puntajePlayer1Text.text = "PUNTAJE " + tagPlayer1.ToString() + ":" + puntajePlayer1.ToString();
        puntajePlayer2Text.text = "PUNTAJE " + tagPlayer2.ToString() + ":" + puntajePlayer2.ToString();

    }
}
