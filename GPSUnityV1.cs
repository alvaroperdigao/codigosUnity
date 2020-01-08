using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GPSgame : MonoBehaviour {

	public static GPSgame Instance { set; get; }

	RectTransform pos_personagem;
	public RectTransform paiDoMapa;

	public int horasFinal = 15;
	public int minutosFinal = 60;

	public int horaMomento;
	public int minutoMomento;

	public string hrs;
	public string mins;

	public Text nomeJogador;
	public Text pontuacaoJogador;
	public Text progresso;
	public Text tempoRestante;

	public Image gpsAlert;

	public Image checkEspaco;
	public Image checkVagao;
	public Image checkStand;
	public Image checkIlha1;
	public Image checkIlha2;
	public Image checkIlha3;

	public Sprite vazio;
	public Sprite simbCheck;

	public Image rostoJogador;
	public Image avatarPersonagem;


	public Sprite rostoMecanico;
	public Sprite rostoSoldador;
	public Sprite rostoDescobridor;

	public Sprite corpoMecanico;
	public Sprite corpoSoldador;
	public Sprite corpoDescobridor;

	public float pos_mapa_x, pos_mapa_y;

	public float latitude;
	public float longitude;

	public float temp_mapaLat;
	public float temp_mapaLon;

	public string Status;

	public Text coordenadas;
	public Text estado;

	float elapsed = 0f;

	public string perguntas;
	public string[] perguntasQnt;
	public int qntPerguntas;
	public int qntRespondida;
	public float sli;

	public Slider percentual;

	public string quiosque1;
	public string quiosque2;
	public string quiosque3;
	public string espaco;
	public string auditorio;

	public Text perguntasQuiosque1;
	public Text perguntasQuiosque2;
	public Text perguntasQuiosque3;
	public Text perguntasEspaco;
	public Text perguntasAuditorio;


	public Text artefatoQuiosque1;
	public Text artefatoQuiosque2;
	public Text artefatoQuiosque3;
	public Text artefatoEspaco;
	public Text artefatoAuditorio;
	public Text artefatoTrem;

	public int qntPergQui1 = 0;
	public int qntPergQui2 = 0;
	public int qntPergQui3 = 0;
	public int qntPergEsp = 0;
	public int qntPergAud = 0;
	public int qntPergTrem = 0;

	public int qntRespQui1;
	public int qntRespQui2;
	public int qntRespQui3;
	public int qntRespEsp;
	public int qntRespAud;
	public int qntRespTrem;


	public int qntArtefatoEspaco = 0;
	public int qntArtefatoTrem = 0;
	public int qntArtefatoQuiosque1 = 0;
	public int qntArtefatoQuiosque2 = 0;
	public int qntArtefatoQuiosque3 = 0;
	public int qntArtefatoAuditorio = 0;
	public int qntArtefatoMovel = 0;

	public int qntEncontradoEspaco;
	public int qntEncontradoTrem;
	public int qntEncontradoQui1;
	public int qntEncontradoQui2;
	public int qntEncontradoQui3;
	public int qntEncontradoAuditorio;
	public int qntEncontradoMovel;



	//public Vector3 tempPos;


	// Use this for initialization
	void Start () {

		gpsAlert.enabled = false;

		nomeJogador.text = PlayerPrefs.GetString ("name");
		cadastroGame.personagem = PlayerPrefs.GetInt ("persona");
		pontuacaoJogador.text = PlayerPrefs.GetInt ("pontos").ToString () + " pts";
		Instance = this;
		DontDestroyOnLoad (gameObject);
		StartCoroutine (StartLocalService ());
		pos_personagem = GetComponent<RectTransform>();

		if (cadastroGame.personagem == 1) {
			rostoJogador.sprite = rostoDescobridor;
			avatarPersonagem.sprite = corpoDescobridor;
		}

		if (cadastroGame.personagem == 2) {
			rostoJogador.sprite = rostoSoldador;
			avatarPersonagem.sprite = corpoSoldador;
		}

		if (cadastroGame.personagem == 3) {
			rostoJogador.sprite = rostoMecanico;
			avatarPersonagem.sprite = corpoMecanico;
		}

		perguntas = bancoDePerguntasTotal.bancoPerguntas;
		perguntasQnt = perguntas.Split (new string[]{"#"},0);

		qntPerguntas = perguntasQnt.Length;

		//quantidade respondida
		qntRespondida = 0;




		for (int i=0; i < qntPerguntas; i++){
			string[] temporario = perguntasQnt[i].Split (new string[]{"|"},0);
			//Debug.Log (temporario[7]);
			if (temporario[7] == "quiosque1"){
				qntPergQui1++;
			}
			if (temporario[7] == "quiosque2"){
				qntPergQui2++;
			}
			if (temporario[7] == "quiosque3"){
				qntPergQui3++;
			}

			if (temporario[7] == "espaco"){
				qntPergEsp++;
			}
			if (temporario[7] == "auditorio"){
				qntPergAud++;
			}

			if (temporario[7] == "artEspaco"){
				qntArtefatoEspaco++;
			}
			if (temporario[7] == "artTrem"){
				qntArtefatoTrem++;
			}
			if (temporario[7] == "artQuiosque1"){
				qntArtefatoQuiosque1++;
			}
			if (temporario[7] == "artQuiosque2"){
				qntArtefatoQuiosque2++;
			}
			if (temporario[7] == "artQuiosque3"){
				qntArtefatoQuiosque3++;
			}
			if (temporario[7] == "artAuditorio"){
				qntArtefatoAuditorio++;
			}
			if (temporario[7] == "artMovel"){
				qntArtefatoMovel++;
			}
		}


		for (int n=0; n < 6; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntRespEsp++;
			}
		}

		for (int n=8; n < 18; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntRespAud++;
			}
		}

		for (int n=22; n < 24; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntRespQui1++;
			}
		}
		for (int n=24; n < 26; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntRespQui2++;
			}
		}
		for (int n=26; n < 28; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntRespQui3++;
			}
		}

		for (int n=102; n < 105; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoEspaco++;
			}
		}

		for (int n=105; n < 107; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoTrem++;
			}
		}

		for (int n=107; n < 108; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoQui1++;
			}
		}

		for (int n=108; n < 110; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoQui2++;
			}
		}

		for (int n=110; n < 112; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoQui3++;
			}
		}

		for (int n=112; n < 121; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoAuditorio++;
			}
		}

		for (int n=121; n < 122; n++){
			if (PlayerPrefs.HasKey("P"+ n.ToString())){
				qntEncontradoMovel++;
			}
		}







		qntRespondida = qntRespEsp +  qntRespAud +  qntRespQui1 + qntRespQui2 + qntRespQui3 + qntEncontradoEspaco + qntEncontradoTrem + qntEncontradoQui1 + qntEncontradoQui2 + qntEncontradoQui3 + qntEncontradoAuditorio + qntEncontradoMovel ;


		progresso.text = qntRespondida.ToString () + "/" + qntPerguntas.ToString ();


		sli = (qntRespondida * 1.0f) / (qntPerguntas * 1.0f);


		percentual.value = sli;



		perguntasEspaco.text=       qntRespEsp    + "/" + qntPergEsp;
		perguntasAuditorio.text =   qntRespAud    + "/" + qntPergAud;
		perguntasQuiosque1.text =   qntRespQui1   + "/" + qntPergQui1;
		perguntasQuiosque2.text =   qntRespQui2   + "/" + qntPergQui2;
		perguntasQuiosque3.text =   qntRespQui3   + "/" + qntPergQui3;

		artefatoQuiosque1.text = qntEncontradoQui1 + "/"+ qntArtefatoQuiosque1;
		artefatoQuiosque2.text = qntEncontradoQui2 + "/"+ qntArtefatoQuiosque2;
		artefatoQuiosque3.text = qntEncontradoQui3 + "/"+ qntArtefatoQuiosque3;
		artefatoEspaco.text    = qntEncontradoEspaco + "/" + qntArtefatoEspaco;
		artefatoAuditorio.text = qntEncontradoAuditorio + "/" + qntArtefatoAuditorio;
		artefatoTrem.text      = qntEncontradoTrem + "/" + qntArtefatoTrem;


		
		
		
		


	

	}

	private IEnumerator StartLocalService(){

		while (true) {
			if (!Input.location.isEnabledByUser) {
				Status = ("O usuário não ativou o GPS");
				gpsAlert.enabled = true;
				yield break;
			}

			gpsAlert.enabled = false;

			Input.location.Start ();
			int maxWait = 20;
			while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0) {
				yield return new WaitForSeconds (1);
				maxWait--;
			}
			if (maxWait <= 0) {
				Status = ("Tempo esgotado");
				yield break;
			}

			if (Input.location.status == LocationServiceStatus.Failed) {
				Status = ("Não foi possivel determinar a localização do dispositivo");
				yield break;
			}

			latitude = Input.location.lastData.latitude;
			longitude = Input.location.lastData.longitude;

			//yield break;
			yield return new WaitForSeconds(1);
		}


	}


	
	// Update is called once per frame
	void Update () {

		horaMomento = horasFinal- 1 - System.DateTime.Now.TimeOfDay.Hours;

		if ((minutosFinal - (System.DateTime.Now.TimeOfDay.Minutes)) == 60) {
			mins = "00";
			//hrs = horaMomento.ToString ();
		} else {
			//hrs = (horasFinal - System.DateTime.Now.TimeOfDay.Hours).ToString();
			minutoMomento = minutosFinal - System.DateTime.Now.TimeOfDay.Minutes;
			mins = minutoMomento.ToString ();
		}

		hrs = horaMomento.ToString ();

		if (System.DateTime.Now.TimeOfDay.Hours > 15){
			hrs = "0";
			mins = "0";
		}

		tempoRestante.text = hrs + "h:" + mins + "m";

		//Debug.Log (System.DateTime.Now.TimeOfDay.Hours);

		elapsed += Time.deltaTime;
		if (elapsed >= 1f) {
			elapsed = elapsed % 1f;
			StartLocalService ();
		}

		coordenadas.text = "*LAT:" + latitude.ToString ()+ "     "+ "*LON:" + longitude.ToString();

		//fazer o mapeamento da Latitude e da Longitude para ficar dentro dos valores mapa
		// pos_persona_x = longitude * fator;

		if (latitude == 0.0f) {
			latitude = -2.568915f;
		}
		if (longitude == 0.0f) {
			
			longitude = -44.32781f;
		}

		temp_mapaLon = (longitude + 44) * 100000 * (-1);
		temp_mapaLat = (latitude + 2)* 100000 * (-1);

		pos_mapa_x = (((temp_mapaLon - 32781.0f)/(32613 - 32781))*(887.0f + 608.0f))-608.0f;
		pos_mapa_y = (((temp_mapaLat - 56891.0f)/(57002.0f - 56891.0f))*(-678.0f - 324.0f))+324.0f;

		pos_personagem.anchoredPosition = new Vector2 (pos_mapa_x,pos_mapa_y);




		if (qntRespEsp == qntPergEsp && qntEncontradoEspaco == qntArtefatoEspaco){
			checkEspaco.sprite = simbCheck;
		}

		if (qntEncontradoTrem == qntArtefatoTrem){
			checkVagao.sprite = simbCheck;
		}

		if (qntRespQui1 == qntPergQui1 && qntEncontradoQui1 == qntArtefatoQuiosque1) {
			checkIlha1.sprite = simbCheck;
		}

		if (qntRespQui2 == qntPergQui2 && qntEncontradoQui2 == qntArtefatoQuiosque2) {
			checkIlha2.sprite = simbCheck;
		}

		if (qntRespQui3 == qntPergQui3 && qntEncontradoQui3 == qntArtefatoQuiosque3) {
			checkIlha3.sprite = simbCheck;
		}

		if (qntRespAud == qntPergAud && qntEncontradoAuditorio == qntArtefatoAuditorio) {
			checkStand.sprite = simbCheck;
		}




	}

	public void zoomMapaMais(){

		if (paiDoMapa.transform.localScale.x < 1.5f){
			paiDoMapa.transform.localScale += new Vector3 (0.05f, 0.05f, 0);
		}
	}

	public void zoomMapaMenos(){
		if (paiDoMapa.transform.localScale.x > 0.3f){
			paiDoMapa.transform.localScale -= new Vector3 (0.05f, 0.05f, 0);
		}
	}




}
