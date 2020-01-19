using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour {

	public string URL = "http://appefcday.azurewebsites.net/pontuacaoranking.php";


	public string respostaServidor;
	public string respostaBanco;
	public string emailUsuario;

	public string[] listaInicial;
	public List<string[]> listaQuebrada2 = new List<string[]> ();
	public List<string[]> temp = new List<string[]> ();
	//public List<string[]> temp = new temp<string[]> ();

	public Text nomeJogador;
	public Text pontuacaoJogador;
	public Text posicaoJogador;
	public Image rostoJogador;
	public Image carregando;

	public Sprite descobridor;
	public Sprite soldador;
	public Sprite mecanico;

	public int tipoPersonagem;

	public int pontucaoRanking;


	public Text NomePrimeiroLugar;
	public Text NomeSegundoLugar;
	public Text NomeTerceiroLugar;

	public Text	PontosPrimeiroLugar;
	public Text PontosSegundoLugar;
	public Text PontosTerceiroLugar;

	public Image RostoPrimeiroLugar;
	public Image RostoSegundoLugar;
	public Image RostoTerceiroLugar;


	public bool varre = false;


	// Use this for initialization
	public void Start () {

		//vai receber a pontuacao que está guardada na memória fixa para ser comparada com as demais
		pontucaoRanking = PlayerPrefs.GetInt ("pontos");


		emailUsuario = PlayerPrefs.GetString ("mail");

		//vai receber a pontuacao para ser mostrada na tela
		pontuacaoJogador.text = PlayerPrefs.GetInt ("pontos").ToString ();
		//vai receber o nome para ser mostrado na tela
		nomeJogador.text = PlayerPrefs.GetString ("name");

		tipoPersonagem = PlayerPrefs.GetInt ("persona");
		//Debug.Log (tipoPersonagem);


		Chamada ();

		//respostaServidor = "Thiago Ferreira,500,2#Victor Mota,189,2#Arthur Ferreira,376,3#Iramar Loiola,400,3#Francisco Serejo,287,2#Klayton Carlos,144,3#Amanda,456,1#Tasso,90,2";



	}
	
	// Update is called once per frame
	void atualiza () {


				

				if (tipoPersonagem == 1) {
					rostoJogador.sprite = descobridor;
				}

				if (tipoPersonagem == 2) {
					rostoJogador.sprite = soldador;
				}

				if (tipoPersonagem == 3) {
					rostoJogador.sprite = mecanico;
				}

				respostaServidor = respostaBanco; //+ nomeJogador.text + "," + pontucaoRanking.ToString () + "," + tipoPersonagem.ToString ();

				Debug.Log (respostaServidor);



				listaInicial = respostaServidor.Split (new string[]{ "#" }, 0);


				for (int i = 0; i < listaInicial.Length; i++) {
					listaQuebrada2.Add (listaInicial [i].Split (new string[]{ "," }, 0));
				}
				//listaQuebrada2.Add (new string[]{ nomeJogador.text, pontucaoRanking.ToString(), tipoPersonagem.ToString() });


				//Debug.Log (listaQuebrada2 [listaQuebrada2.Count-1][0]);


				//FAZER O BUBLLE SORT
				
				for (int i = 0; i < listaQuebrada2.Count - 1; i++) {
					for (int sort = 0; sort < listaQuebrada2.Count - 1; sort++) {
						int temp1;
						int temp2;
						int.TryParse (listaQuebrada2 [sort] [1], out temp1);
						int.TryParse (listaQuebrada2 [sort + 1] [1], out temp2);

						//Debug.Log ("" + listaQuebrada2 [0] [1] + ";" + listaQuebrada2 [1] [1] + ";" + listaQuebrada2 [2] [1] + ";" + listaQuebrada2 [3] [1] + ";" + listaQuebrada2 [4] [1] + ";" + listaQuebrada2 [5] [1] + ";" + listaQuebrada2 [6] [1] + ";" + listaQuebrada2 [7] [1] + ";" + listaQuebrada2 [8] [1]);
						Debug.Log (temp2 + " é > " + temp1);
						if (temp2 > temp1) {

							Debug.Log ("SIM");

							string loc1 = listaQuebrada2 [sort] [0];
							string loc2 = listaQuebrada2 [sort] [1];
							string loc3 = listaQuebrada2 [sort] [2];

							//listaQuebrada2 [sort] = listaQuebrada2 [sort + 1];
							listaQuebrada2 [sort] [0] = listaQuebrada2 [sort + 1] [0];
							listaQuebrada2 [sort] [1] = listaQuebrada2 [sort + 1] [1];
							listaQuebrada2 [sort] [2] = listaQuebrada2 [sort + 1] [2];

							listaQuebrada2 [sort + 1] [0] = loc1;
							listaQuebrada2 [sort + 1] [1] = loc2;
							listaQuebrada2 [sort + 1] [2] = loc3;
						} else {
							Debug.Log ("NÃO");
						}

					}
					Debug.Log ("FIM DE VARREDURA");
				}

//				Debug.Log (listaQuebrada2 [0] [2]);
				
				//

				NomePrimeiroLugar.text = listaQuebrada2 [0] [0];
				PontosPrimeiroLugar.text = listaQuebrada2 [0] [1];

				if (listaQuebrada2 [0] [2] == "1") {
					RostoPrimeiroLugar.sprite = descobridor;
				}
				if (listaQuebrada2 [0] [2] == "2") {
					RostoPrimeiroLugar.sprite = soldador;
				}
				if (listaQuebrada2 [0] [2] == "3") {
					RostoPrimeiroLugar.sprite = mecanico;
				}

				NomeSegundoLugar.text = listaQuebrada2 [1] [0];
				PontosSegundoLugar.text = listaQuebrada2 [1] [1];

				if (listaQuebrada2 [1] [2] == "1") {
					RostoSegundoLugar.sprite = descobridor;
				}
				if (listaQuebrada2 [1] [2] == "2") {
					RostoSegundoLugar.sprite = soldador;
				}
				if (listaQuebrada2 [1] [2] == "3") {
					RostoSegundoLugar.sprite = mecanico;
				}

				NomeTerceiroLugar.text = listaQuebrada2 [2] [0];
				PontosTerceiroLugar.text = listaQuebrada2 [2] [1];

				if (listaQuebrada2 [2] [2] == "1") {
					RostoTerceiroLugar.sprite = descobridor;
				}
				if (listaQuebrada2 [2] [2] == "2") {
					RostoTerceiroLugar.sprite = soldador;
				}
				if (listaQuebrada2 [2] [2] == "3") {
					RostoTerceiroLugar.sprite = mecanico;
				}

				for (int i = 0; i < listaQuebrada2.Count; i++) {
					//Debug.Log (listaQuebrada2[i][0]);

					if (listaQuebrada2 [i] [0] == nomeJogador.text) {
						posicaoJogador.text = (i + 1).ToString () + "º"; //index da posicao do logador dentro do vetor
					}

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
