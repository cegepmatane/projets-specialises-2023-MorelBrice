using UnityEngine;

public class CollisionItem : MonoBehaviour
{

    AudioSource Audio;
    public AudioClip pickup;

    ChangerImageCle myInstance;


    void Start()
    {
        Audio = GetComponent<AudioSource>();    

        ChangerImageCle myInstance = GetComponent<ChangerImageCle>();
    }

    void Update()
    {
    }
    
    
    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().name == "DaKey")
        {
            Debug.Log("Item pickup");
            Destroy(GameObject.Find("DaKey"));
            Audio.PlayOneShot(pickup);
            myInstance.fillKey1();
        }
    }
}
