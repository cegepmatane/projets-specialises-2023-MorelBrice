using UnityEngine;

public class CollisionItem : MonoBehaviour
{

    AudioSource Audio;
    public AudioClip pickup;



    void Start()
    {
        Audio = GetComponent<AudioSource>();    

        ChangerImageCle myInstance = myGameObject.GetComponent<ChangerImageCle>();
    }

    void Update()
    {
    }
    
    
    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().name == "DaKey")
        {
            Debug.Log("Item pickup");
            Audio.PlayOneShot(pickup);
            fillKey1();
            Destroy(GameObject.Find("DaKey"));
        }
    }
}
