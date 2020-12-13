using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VPController : MonoBehaviour
{
    bool ISPlaying;
    public GameObject playbutton, pausebutton;
    public VideoPlayer videoPlayer;

    private void Start()
    {
        ISPlaying = false;
    }

    private void Update()
    {
        if ((videoPlayer.frame) > 0 && (videoPlayer.isPlaying == false))
        {
            playbutton.SetActive(true);
            pausebutton.SetActive(false);
            ISPlaying = false;
            videoPlayer.Pause();
        }
    }

    public void OnMouseDown()
    {
        if(ISPlaying)
        {
            
            playbutton.SetActive(true);
            pausebutton.SetActive(false);
            ISPlaying = false;
            videoPlayer.Pause();

        }
        else
        {
            playbutton.SetActive(false);
            pausebutton.SetActive(true);
            ISPlaying = true;
            videoPlayer.Play();
        }
        
    }
}
