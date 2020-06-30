using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] tracks;
    public Text SongPlaying;

    private AudioSource m_audioSource;
    private void Start()
    {
        m_audioSource = Camera.main.GetComponent<AudioSource>();
        //int temp = Random.Range(0, tracks.Length);
        //m_audioSource.PlayOneShot(tracks[temp]);
        //SongPlaying.text = Camera.main.GetComponent<AudioSource>().clip.name;
    }

    private void Update()
    {
        if(!m_audioSource.isPlaying)
        {
            int temp = Random.Range(0, tracks.Length);
            m_audioSource.PlayOneShot(tracks[temp]);
            SongPlaying.text = tracks[temp].name;
        }
    }
}
