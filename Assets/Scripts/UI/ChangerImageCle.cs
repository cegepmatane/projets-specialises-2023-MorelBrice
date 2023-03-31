// https://docs.unity3d.com/2018.3/Documentation/ScriptReference/UI.RawImage-texture.html

using UnityEngine;
using UnityEngine.UI;

public class ChangerImageCle : MonoBehaviour
{
    RawImage Cle1;
    RawImage Cle2;
    RawImage Cle3;
    //Select a Texture in the Inspector to change to
    public Texture keyOutline;
    public Texture keyFilled;

    void Start()
    {
        //Fetch the RawImage component from the GameObject
        Cle1 = GameObject.Find("Cle1").GetComponent<RawImage>();
        Cle2 = GameObject.Find("Cle2").GetComponent<RawImage>();
        Cle3 = GameObject.Find("Cle3").GetComponent<RawImage>();
        //Change the Texture to be the one you define in the Inspector
        Cle1.texture = keyFilled;
        Cle3.texture = keyFilled;
    }
}