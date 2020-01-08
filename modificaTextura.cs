using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selecionaPlaca : MonoBehaviour
{

    public Texture[] placas;
    
    public int nomeDaPlaca;

    public GameObject placaRA;

    public Material texturaDafoto;



    // Start is called before the first frame update
    void Start()
    {
        texturaDafoto = placaRA.GetComponent<Renderer>().material;
        SelecionaPlaca();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SelecionaPlaca()
    {
        nomeDaPlaca = PlayerPrefs.GetInt("placa");
        switch (nomeDaPlaca) 
        {
        case 1:
            texturaDafoto.mainTexture = placas[nomeDaPlaca];
            break;

        case 2:
            texturaDafoto.mainTexture = placas[nomeDaPlaca];
            break;

        case 3:
            texturaDafoto.mainTexture = placas[nomeDaPlaca];
            break;

        case 4:
            texturaDafoto.mainTexture = placas[nomeDaPlaca];
            break;
        }
    }
}
