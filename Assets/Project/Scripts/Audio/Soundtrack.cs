using UnityEngine;

public class Soundtrack : MonoBehaviour
{
    public AudioSource sourceTrilha;
    public AudioClip[] clipMusic;
    void Start()
    {
        int IndexClipMusic = Random.Range(0 , clipMusic.Length);
        AudioClip musicClip = clipMusic[IndexClipMusic];
        sourceTrilha.clip = musicClip;
        sourceTrilha.Play();
    }


    void Update()
    {
        
    }
}
