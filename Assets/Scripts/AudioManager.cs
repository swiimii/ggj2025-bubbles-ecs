using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Singleton;
    public GameObject clipPrefab;
    public AudioClip popSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Singleton = this;
    }

    public static void PlayAudioAtLocation(Vector3 location )
    {
        var clipPlayer = Instantiate(Singleton.clipPrefab);
        clipPlayer.transform.position = location;
        var audioSource = clipPlayer.GetComponent<AudioSource>();
        audioSource.pitch = Random.Range(.6f, 1.5f);
        audioSource.PlayOneShot(Singleton.popSound);
    }

}
