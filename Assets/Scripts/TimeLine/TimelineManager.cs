using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : SingleTon<TimelineManager>
{
    public PlayableDirector startDirector;

    protected override void Awake()
    {
        base.Awake();
        startDirector = GetComponent<PlayableDirector>();
    }

    private void OnEnable()
    {
        startDirector.played += TimeLinePlayed;
        startDirector.stopped += TimeLienStopped;
        EventHandler.StartNewGameEvent += OnAfterSceneLoaded;
    }

    private void OnDisable()
    {
        EventHandler.StartNewGameEvent -= OnAfterSceneLoaded;
    }
    private void OnAfterSceneLoaded(int obj)
    {
        if(startDirector != null)
        {
            startDirector.Play();
        }
    }


    private void TimeLienStopped(PlayableDirector director)
    {
        if (director != null)
        {
            FindObjectOfType<PlayerController>().inputDisable = false;
            director.gameObject.SetActive(false);
        }
    }

    private void TimeLinePlayed(PlayableDirector director)
    {
        if (director != null)
        {
            FindObjectOfType<PlayerController>().inputDisable = true;
        }
    }
}
