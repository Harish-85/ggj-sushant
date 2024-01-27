using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public VideoClip[] videoClips; // Array of VideoClips
    [SerializeField] RenderTexture texture;
    private int currentVideoIndex = 0;

    void Start()
    {
        
        rawImage.texture = texture;
        // Subscribe to the videoPlayer's loopPointReached event
        videoPlayer.loopPointReached += OnVideoEnd;

        // Start playing the first video
        PlayNextVideo();
    }

    void PlayNextVideo()
    {
        if (currentVideoIndex < videoClips.Length)
        {
            // Load and play the next video clip
            videoPlayer.clip = videoClips[currentVideoIndex];
            videoPlayer.Play();
        }
        else
        {
            // All videos played, switch to the next scene by build index
            SwitchToNextScene();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Called when the video ends
        currentVideoIndex++;
        PlayNextVideo();
    }

    void SwitchToNextScene()
    {
        // Load the next scene by build index
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if there is a next scene
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more scenes in build order.");
            // Optionally, you can handle this case (e.g., loop back to the first scene)
        }
    }
}
