using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeManager : MonoBehaviour
{
    public static PuntajeManager instance;

    public Text puntajePlayer1Text, puntajePlayer2Text;
    public Text vidaPlayer1Text, vidaPlayer2Text;

    int puntajePlayer1 = 0;
    int puntajePlayer2 = 0;
    int vidaPlayer1 = 3 ;
    int vidaPlayer2 = 3;
    float velocidadPlayer1 = 10f;
    float velocidadPlayer2 = 10f;

    public float getvelocidadPlayer1()
    {
        return velocidadPlayer1;
    }

    public float getvelocidadPlayer2()
    {
        return velocidadPlayer2;
    }


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
    public void setvidaPlayer1(int puntaje, string tag)
    {
        this.vidaPlayer1 = puntaje;
        this.tagPlayer1 = tag;
    }
    public void setvelocidadPlayer1(float puntaje, string tag)
    {
        this.velocidadPlayer1 = puntaje;
        this.tagPlayer1 = tag;
    }

    public void setPuntajePlayer2(int puntaje, string tag)
    {
        this.puntajePlayer2 = puntaje;
        this.tagPlayer2 = tag;
    }
    public void setvidaPlayer2(int puntaje, string tag)
    {
        this.vidaPlayer2 = puntaje;
        this.tagPlayer2 = tag;
    }

    public void setvelocidadPlayer2(float puntaje, string tag)
    {
        this.velocidadPlayer2 = puntaje;
        this.tagPlayer2 = tag;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        puntajePlayer1Text.text = "PUNTAJE " + tagPlayer1.ToString() + ":" + puntajePlayer1.ToString();
        puntajePlayer2Text.text = "PUNTAJE "+ tagPlayer2.ToString() + ":" + puntajePlayer2.ToString();
        vidaPlayer1Text.text = "VIDA " + tagPlayer1.ToString() + ":" + vidaPlayer1.ToString();
        vidaPlayer2Text.text = "VIDA " + tagPlayer2.ToString() + ":" + vidaPlayer2.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //puntaje = puntaje + 1;
        puntajePlayer1Text.text = "PUNTAJE " + tagPlayer1.ToString() + ":" + puntajePlayer1.ToString();
        puntajePlayer2Text.text = "PUNTAJE " + tagPlayer2.ToString() + ":" + puntajePlayer2.ToString();
        vidaPlayer1Text.text = "VIDA " + tagPlayer1.ToString() + ":" + vidaPlayer1.ToString();
        vidaPlayer2Text.text = "VIDA " + tagPlayer2.ToString() + ":" + vidaPlayer2.ToString();
    }
}
