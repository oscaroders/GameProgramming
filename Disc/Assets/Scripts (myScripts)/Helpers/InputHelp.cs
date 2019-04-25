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

            #region Numbers
            public void Zero( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha0 ) || Input.GetKeyDown( KeyCode.Keypad0 ) )
                    action();
            }

            public void One( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha1 ) || Input.GetKeyDown( KeyCode.Keypad1 ) )
                    action();
            }

            public void Two( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha2 ) || Input.GetKeyDown( KeyCode.Keypad2 ) )
                    action();
            }

            public void Three( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha3 ) || Input.GetKeyDown( KeyCode.Keypad3 ) )
                    action();
            }

            public void Four( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha4 ) || Input.GetKeyDown( KeyCode.Keypad4 ) )
                    action();
            }

            public void Five( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha5 ) || Input.GetKeyDown( KeyCode.Keypad5 ) )
                    action();
            }

            public void Six( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha6 ) || Input.GetKeyDown( KeyCode.Keypad6 ) )
                    action();
            }

            public void Seven( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha7 ) || Input.GetKeyDown( KeyCode.Keypad7 ) )
                    action();
            }

            public void Eight( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha8 ) || Input.GetKeyDown( KeyCode.Keypad8 ) )
                    action();
            }

            public void Nine( InputDelegate_Button action ) {
                if ( Input.GetKeyDown( KeyCode.Alpha9 ) || Input.GetKeyDown( KeyCode.Keypad9 ) )
                    action();
            }
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
