using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class localizacaoPersonagem : MonoBehaviour
{

    public Text latitudeText;
    public Text longitudetext;

    public float coordenadaZ;
    public float coordenadaX;
    

    public float posicaoX;
    public float posicaoZ;


    public float latitude;
    public float longitude;

    float elapsed = 0f;

    public GameObject Personagem;
    public GameObject CameraPrincipal;

    public string Status;

    public bool GPSEmulado;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartLocalService());
    }

    // Update is called once per frame
    void Update()
    {

        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            StartLocalService();
        }


        if (GPSEmulado)
        {
            posicaoX = 3321521.3191f + (75039.8f * coordenadaX); //longitude
            posicaoZ = 178015.75f + (71392.49f * coordenadaZ); //latitude
        }
        else
        {
            posicaoX = 3321521.3191f + (75039.8f * longitude); //longitude
            posicaoZ = 178015.75f + (71392.49f * latitude); //latitude
        }

        Personagem.transform.localPosition = new Vector3(posicaoX, 2, posicaoZ);

        latitudeText.text = latitude.ToString();
        longitudetext.text = longitude.ToString();

    }


    private IEnumerator StartLocalService()
    {

        while (true)
        {
            if (!Input.location.isEnabledByUser)
            {
                Status = ("O usuário não ativou o GPS");
                // gpsAlert.enabled = true;
                yield break;
            }

            //gpsAlert.enabled = false;

            Input.location.Start();
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }
            if (maxWait <= 0)
            {
                Status = ("Tempo esgotado");
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Status = ("Não foi possivel determinar a localização do dispositivo");
                yield break;
            }

            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;

            //yield break;
            yield return new WaitForSeconds(1);
        }


    }

    public void zoomMaisCamera() {

        CameraPrincipal.transform.localPosition = CameraPrincipal.transform.localPosition + new Vector3(0,-10,0);
        if (CameraPrincipal.transform.localPosition.y < 90) {
            CameraPrincipal.transform.localPosition = new Vector3(0, 90, 0);
        }
    }

    public void zoomMenosCamera() {
        CameraPrincipal.transform.localPosition = CameraPrincipal.transform.localPosition + new Vector3(0, +10, 0);
        if (CameraPrincipal.transform.localPosition.y > 500)
        {
            CameraPrincipal.transform.localPosition = new Vector3(0, 500, 0);
        }
    }


}
