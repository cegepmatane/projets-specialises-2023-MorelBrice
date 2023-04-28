using UnityEngine;
using UnityEngine.UI;

public class ChangerImageCle : MonoBehaviour
{
    public RawImage Cle1;
    public RawImage Cle2;
    public RawImage Cle3;
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
    }

    public void fillKey1()
    {
        Cle1.texture = keyFilled;
    }

    public void fillKey2()
    {
        Cle2.texture = keyFilled;
    }

    public void fillKey3()
    {
        Cle3.texture = keyFilled;
    }
}