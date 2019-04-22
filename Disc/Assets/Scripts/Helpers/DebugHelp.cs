using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hermit {
    namespace DebugHelp {

        /// <summary>
        /// CustomDebug let´s you ´set properties to you debug text without writing rich text.
        /// </summary>
        /// <param name="_text">Debugging text</param>
        /// <param name="logType">What kind of LogType. <value>Default: Logtype.Log</value></param>
        /// <param name="color">Text color</param>
        /// <param name="size">Text size. <value>Default: 12</value></param>
        /// <param name="bold">Set text to bold</param>
        /// <param name="italic">Set text to italic</param>
        public class DebugLogging {
            public static void CustomDebug( string _text , LogType logType = LogType.Log , string color = "none" , int size = 12 , bool bold = false , bool italic = false ) {
                string text = string.Empty;
                if ( color != "none" ) {
                    text += "<color=" + color + ">";
                }

                text += "<size=" + size.ToString() + ">";

                if ( bold ) {
                    text += "<b>";
                }

                if ( italic ) {
                    text += "<i>";
                }

                text += _text;


                if ( italic ) {
                    text += "</i>";
                }


                if ( bold ) {
                    text += "</b>";
                }

                text += "</size>";

                if ( color != "none" ) {
                    text += "</color>";
                }

                Debug.unityLogger.Log( logType , text );
            }
        }
    }
}

