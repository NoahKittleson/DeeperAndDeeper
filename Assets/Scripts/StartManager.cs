using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;
using UnityEngine.Playables;

public class StartManager : MonoBehaviour
{

    public UnityEvent onGameLoad;
    public UnityEvent onIntroStart;
    public UnityEvent onGameStart;

    public TimelineAsset introTimeline;

    private PlayableDirector director;

    private void Start()
    {
        this.director = GetComponent<PlayableDirector>();
        onGameLoad.Invoke();
        StartCoroutine(WaitForMouseDown());
    }

    private IEnumerator WaitForMouseDown()
    {
        while (!Input.GetMouseButtonDown(0))
        {
            yield return null;
        }
        this.onIntroStart.Invoke();
        this.StartTimeline(introTimeline);
    }

    private void StartTimeline(TimelineAsset timeline)
    {
        director.playableAsset = timeline;
        director.extrapolationMode = DirectorWrapMode.None;
        director.RebuildGraph();
        director.time = 0f;
        director.Play();
    }

    public void StartGame()
    {
        onGameStart.Invoke();
    }
}
