using UnityEngine;
using UnityEngine.Audio;

public class MusicScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    public int currentLevel = 0;

    private readonly string drumsMixer = "drums";
    private readonly string sirenMixer = "siren";
    private readonly string bassMixer = "bass";
    private readonly string snareMixer = "snare";

    void OnEnable()
    {
        GameManager.OnMenuStateChange += HandleIsOnMenu;
    }
    void OnDisable()
    {
        GameManager.OnMenuStateChange += HandleIsOnMenu;
    }
 
    void HandleIsOnMenu(bool isOpen)
    {
      
        if (isOpen)
        {
            currentLevel += 1;
            PlayMenuMusic();
        }
        else
        {
            if (currentLevel == 1)
            {
                PlayLevel1Music();
            }
            else if (currentLevel == 2)
            {
                PlayLevel2Music();
            }
            else if (currentLevel == 3)
            {
                PlayLevel3Music();
            }
            else if (currentLevel >= 4)
            {
                PlayLevel4Music();
            }
        }

    }

    void PlayMenuMusic()
    {
        TurnOffInstrument(drumsMixer);
        TurnOffInstrument(sirenMixer);
        TurnOffInstrument(bassMixer);
        TurnOffInstrument(snareMixer);
    }

    void PlayLevel4Music()
    {
        TurnOnInstrument(drumsMixer);
        TurnOnInstrument(snareMixer);
        TurnOnInstrument(bassMixer);
        TurnOnInstrument(sirenMixer);
    }

    void PlayLevel3Music()
    {
        TurnOnInstrument(drumsMixer);
        TurnOnInstrument(snareMixer);
        TurnOnInstrument(bassMixer);
        TurnOffInstrument(sirenMixer);
    }

    void PlayLevel2Music()
    {
        TurnOnInstrument(drumsMixer);
        TurnOnInstrument(snareMixer);

        TurnOffInstrument(bassMixer);
        TurnOffInstrument(sirenMixer);
    }
    void PlayLevel1Music()
    {
        TurnOnInstrument(drumsMixer);

        TurnOffInstrument(snareMixer);
        TurnOffInstrument(bassMixer);
        TurnOffInstrument(sirenMixer);
    }





    void TurnOffInstrument(string instrumentGroup)
    {
        audioMixer.SetFloat(instrumentGroup + "Volume", -80f);
    }
    void TurnOnInstrument(string instrumentGroup)
    {
        audioMixer.SetFloat(instrumentGroup + "Volume", 0f);
    }

}
