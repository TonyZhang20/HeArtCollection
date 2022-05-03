using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundDetailsList", menuName = "Sound/SoundDetailsList")]
public class SoundDetailsList_SO : ScriptableObject
{
    public List<SoundDeails> soundDeailsList;
    public SoundDeails GetSoundDeails(SoundName name)
    {
        return soundDeailsList.Find(s => s.soundName == name);
    }
}
[System.Serializable]
public class SoundDeails
{
    public SoundName soundName;
    public AudioClip soundClip;
    [Range(0.1f,1f)]
    public float soundVolume;
}