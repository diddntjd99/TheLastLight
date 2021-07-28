using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instanse; //자기 자신(클래스)을 가리키는 변수

    [Header("사운드 등록")]
    [SerializeField] Sound bgmSounds; //BGM
    [SerializeField] Sound[] sfxSounds; //효과음

    [Header("브금 플레이어")]
    [SerializeField] AudioSource bgmPlayer; //BGM 실행해주는 것

    [Header("효과음 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer; //BGM 실행해주는 것

    void Start()
    {
        instanse = this;
        playBGM();
    }

    public void playBGM()
    {
        bgmPlayer.clip = bgmSounds.clip; //bgmSounds에 들어가있는 음악을 따옴
        bgmPlayer.Play(); //재생
    }

    public void resumeBGM()
    {
        bgmPlayer.UnPause(); //일시정지 해제
    }

    public void pauseBGM()
    {
        bgmPlayer.Pause(); //일시정지
    }

    public void playSE(string soundName)
    {
        for (int i = 0; i < sfxSounds.Length; i++)
        {
            if (soundName == sfxSounds[i].soundName)
            {
                for (int x = 0; x < sfxPlayer.Length; x++)
                {
                    if (!sfxPlayer[x].isPlaying)
                    {
                        sfxPlayer[x].clip = sfxSounds[i].clip;
                        sfxPlayer[x].Play();
                        return;
                    }
                }
            }
        }
    }
}
