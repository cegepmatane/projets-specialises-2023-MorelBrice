using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AmmoUIScript : MonoBehaviour
{
    TMP_Text UItext;

    public static float AmmoValue; 

    // Start is called before the first frame update
    void Start()
    {
        UItext = GetComponent<TextMeshProUGUI>();
    }   

    // Update is called once per frame
    void Update()
    {
        UItext.text = "Ammo : " + AmmoValue;
    }
}