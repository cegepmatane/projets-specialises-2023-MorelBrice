using UnityEngine;

public class CollisionItem : MonoBehaviour
{

    AudioSource Audio;
    public AudioClip pickup;

    ChangerImageCle myInstance;

    public Texture keyOutline;

    public static float numberOfKeys;

    bool is1Activated;
    bool is2Activated;
    bool is3Activated;


    void Start()
    {
        Audio = GetComponent<AudioSource>();    

        myInstance = GetComponent<ChangerImageCle>();

        is1Activated = false;
        is2Activated = false;
        is3Activated = false;
    }

    void Update()
    {
    }
    
    
    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().name == "DaKey1" && !is1Activated)
        {
            Destroy(GameObject.Find("DaKey1"));
            Debug.Log("Item pickup");
            Audio.PlayOneShot(pickup);
            myInstance.fillKey1();
            numberOfKeys++;
            is1Activated = true;
        }

        else if(col.GetComponent<Collider>().name == "DaKey2" && !is2Activated)
        {
            Destroy(GameObject.Find("DaKey2"));
            Debug.Log("Item pickup");
            Audio.PlayOneShot(pickup);
            myInstance.fillKey2();
            numberOfKeys++;
            is2Activated = true;
        }

        else if(col.GetComponent<Collider>().name == "DaKey3" && !is3Activated)
        {
            Destroy(GameObject.Find("DaKey3"));
            Debug.Log("Item pickup");
            Audio.PlayOneShot(pickup);
            myInstance.fillKey3();
            numberOfKeys++;
            is3Activated = true;
        }
        Debug.Log(numberOfKeys);
    }

    void OnTriggerExit(Collider col)
    {
        is1Activated = false;
        is2Activated = false;
        is3Activated = false;
    }

}
