using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TipsControl : MonoBehaviour
{
    public Sprite[] imagenes;
    [SerializeField]private int index = 0;
    public GameObject AreaTip;
    public Image image;
    public TextMeshProUGUI descripcion;
    public int escenario;

    private void Start()
    {
        image = AreaTip.GetComponent<Image>();
        image.sprite = imagenes[0];
        descripcion.text = descripciones(0);
    }

    void Update() {
        if (Input.GetButtonDown("Horizontal")) {
            int dir = (int)Input.GetAxisRaw("Horizontal");
            index += dir;
            index = Mathf.Clamp(index, 0, imagenes.Length - 1);
            image.sprite = imagenes[index];
            descripcion.text = descripciones(index);
        }
        if (Input.GetButtonDown("Fire1")) {
            SceneManager.LoadScene(escenario);
        }
    }

    private string descripciones(int index) {
        if(index <= 4) {
            return "Son Objectos del Escenario para que te puedas esconder, Usa la tecla F para esconderte y Salir con la tecla Esc";
        }
        if(index == 5) {
            return "Usa tus Oidos para escuchar a los Enemigos, Cuidado ellos tambien te escucharan";
        }
        if(index == 6) {
            return "Cuando Tengas Items para lanzar, Clic derecho, mientras mas tiempo lo mantengas mas lejos lanzara el item, Clic izquierdo para lanzarlo";
        }
        if(index == 7) {
            return "Usa con sabiduria, pueden ser tus mejores aliados o tus peores pesadilla, las botellas distraen a los enemigos";
        }
        if (index == 8) {
            return "Si el Enemigo te Ve, perderas inmediatamente, los Items brillan cuando enfocas tus ojos en ellos";
        }
        return "hola";
    }

}
