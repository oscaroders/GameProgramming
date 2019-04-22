using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

namespace Hermit {
    namespace InputHelp {

        public delegate void InputDelegate_Button();
        public delegate void InputDelegate_Axis( float number );
        public delegate void InputDelegate_Cursor( Vector2 position );

        public class CustomInput {

            #region Special keys
            public void Space( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Space ) )
                    action();
            }

            public void Escape( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Escape ) )
                    action();
            }

            public void Backspace( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Backspace ) )
                    action();
            }

            public void CapsLock( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.CapsLock ) )
                    action();
            }

            public void Shift( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.LeftShift ) || Input.GetKeyDown( KeyCode.RightShift ) )
                    action();
            }

            public void Control( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.LeftControl ) || Input.GetKeyDown( KeyCode.RightControl ) )
                    action();
            }
            #endregion

            #region Letter keys
            public void E( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.E ) )
                    action();
            }
            #endregion

            #region Numpad
            #endregion

            #region Mouse
            public void LeftMouseButton( InputDelegate_Button action ) {
                if ( Input.GetMouseButtonDown( 0 ) )
                    action();
            }

            public void RightMouseButton( InputDelegate_Button action ) {
                if ( Input.GetMouseButtonDown( 1 ) )
                    action();
            }

            public void MouseCursor( InputDelegate_Cursor action ) {
                action( Input.mousePosition );
            }
            #endregion

            #region Axis
            public void LeftRightArrow( InputDelegate_Axis action ) {
                if ( Input.GetAxisRaw( "Horizontal" ) != 0 )
                    action( Input.GetAxisRaw( "Horizontal" ) );
            }

            public void UpDownArrow( InputDelegate_Axis action ) {
                if ( Input.GetAxisRaw( "Vertical" ) != 0 )
                    action( Input.GetAxisRaw( "Vertical" ) );
            }
            #endregion
        }
    }
}
