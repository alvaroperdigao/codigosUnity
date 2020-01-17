using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

	public string URL = "http://appefcday.azurewebsites.net/pontuacaoranking.php";


	public string respostaServidor;	
  
  
  
  public void Start () {
    Chamada ();
  }
  
  
  void atualiza(){
  
    respostaServidor = respostaBanco;
    listaInicial = respostaServidor.Split (new string[]{ "#" }, 0);
    for (int i = 0; i < listaInicial.Length; i++) {
		  listaQuebrada2.Add (listaInicial [i].Split (new string[]{ "," }, 0));
		}
  
  }




  public void Chamada(){

		URL = URL + "?eemail=" + emailUsuario + "&ppontos=" + pontuacaoJogador.text;
		Debug.Log (URL);
		WWW chama = new WWW (URL);
		StartCoroutine (OnResponse(chama));
	}
  
  
  private IEnumerator OnResponse(WWW req){

		yield return req;
		respostaBanco = req.text;
		if(respostaBanco != ""){
			carregando.transform.Translate (1000,1000,1000);
		}
		atualiza ();
		//Debug.Log (respostaBanco);
	}
}
