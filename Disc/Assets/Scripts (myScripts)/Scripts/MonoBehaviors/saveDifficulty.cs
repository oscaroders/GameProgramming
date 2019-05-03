using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;
using UnityEngine.UI;

public class saveDifficulty : MonoBehaviour {

    public Button easyB;
    public Button middleB;
    public Button hardB;
    private float diff;
    ColorBlock cb;
    ColorBlock cbOld;
    // Start is called before the first frame update
    void Start() {
        cb = cbOld = easyB.colors;
        cb.normalColor = new Color( 32 , 213 , 217 );
    }

    private void Update() {
        diff = GameManager.INSTANCE.difficultyMultipier;

        if ( diff == 1 ) {
            easyB.colors = cb;
            middleB.colors = cbOld;
            hardB.colors = cbOld;
        }
 


        if ( diff == 2 ) {
            easyB.colors = cbOld;
            middleB.colors = cb;
            hardB.colors = cbOld;
        }
      

        if ( diff == 5 ) {
            easyB.colors = cbOld;
            middleB.colors = cbOld;
            hardB.colors = cb;
        }
       
    }
}