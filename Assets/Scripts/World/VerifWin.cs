using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VerifWin : MonoBehaviour
{

    void Start()
    {
    }

    public void win()
    {
        if(CollisionItem.numberOfKeys == 3)
        {
            SceneManager.LoadScene("End Screen");
        }
        else
        {         
            StartCoroutine(ResetText());
        }
    }


    IEnumerator ResetText()
    {
        GameObject.Find("Popup").GetComponent<TMP_Text>().text = "<--- Il vous faut ces 3 clés pour sortir :)";

        yield return new WaitForSeconds(2);

        GameObject.Find("Popup").GetComponent<TMP_Text>().text = " ";
    }
}
