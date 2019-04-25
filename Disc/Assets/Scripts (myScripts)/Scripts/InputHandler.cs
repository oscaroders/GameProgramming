using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using Hermit.InputHelp;
using UnityEngine;

public class InputHandler {

    CustomInput input;

    #region Delegate declaration
    public InputDelegate_Button Jump = delegate { };
    public InputDelegate_Button Fire = delegate { };
    public InputDelegate_Button Collect = delegate { };
    public InputDelegate_Button Quit = delegate { };
    public InputDelegate_Button Restart = delegate { };
    public InputDelegate_Axis Horizontal = delegate { };
    public InputDelegate_Axis Vertical = delegate { };
    public InputDelegate_Cursor Position = delegate { };
    #endregion

    #region Constructor
    public InputHandler() {
        input = new CustomInput();
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    public void InputCheck() {
        input.Space( Jump );
        input.LeftMouseButton( Fire );
        input.RightMouseButton( Collect );
        input.LeftRightArrow( Horizontal );
        input.UpDownArrow( Vertical );
        input.MouseCursor( Position );
        input.Escape( Quit );
        input.R( Restart );
    }
}