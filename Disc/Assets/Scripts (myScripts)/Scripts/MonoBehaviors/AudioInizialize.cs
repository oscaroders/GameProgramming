using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class AudioInizialize : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        ServiceLocator.Initialize();
        ServiceLocator.ProvideAudio( new RealAudioProvider() );
    }
}