using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selecionaCena : MonoBehaviour
{
   public void chamaCena(int cena) {

        SceneManager.LoadScene(cena);
    }
}
