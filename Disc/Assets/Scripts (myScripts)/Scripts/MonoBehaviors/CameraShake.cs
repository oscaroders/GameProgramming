using System.Collections;
using System.Collections.Generic;
using Hermit.DebugHelp;
using UnityEngine;

public class CameraShake : MonoBehaviour, IComponent {

    public void OnEnable() {
        EventManager.StartListening("Shake", StartShake );
    }

    public void OnDisable() {
        EventManager.StopListening( "Shake" , StartShake );
    }

    public void Recive( string message , GameObject thing , float value ) {
        //
    }

    public void Send( string message , GameObject thing , float value ) {
        //
    }

    public void StartShake() {
        StartCoroutine("Shake");
    }

    public IEnumerator Shake() {
        float duration = 0.2f;
        float magnitude = 0.7f;
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while ( elapsed < duration ) {
            float x = Random.Range( -1f , 1f ) * magnitude;
            float y = Random.Range( -1f , 1f ) * magnitude;

            transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPosition;

    }
}