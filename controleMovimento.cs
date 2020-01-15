using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleMovimento : MonoBehaviour {


	static Animator anim;
	static bool andando = false;
	public int rotacao ;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	
	}
	
	// Update is called once per frame
	void Update () {

		if (andando == true) {
			transform.Translate (Vector3.forward * Time.deltaTime);
			transform.Rotate (Vector3.up * Time.deltaTime*rotacao);
		}
	}

	//coloquei static aqui só por que essa funcao eh chamada por outro script
	static public void movimenta1() {
		anim.SetBool("move1", true);
		anim.SetBool("move2", false);
		andando = true;

	}
	
	//coloquei static aqui só por que essa funcao eh chamada por outro script
	static public void movimenta2() {
		anim.SetBool("move2", true);
		anim.SetBool("move1", false);
		andando = false;
	}
		
}
