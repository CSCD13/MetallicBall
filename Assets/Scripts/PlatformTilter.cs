using UnityEngine;

public class PlatformTilter : MonoBehaviour {
    private Quaternion originalRotation;
    private Quaternion finalRotation;

    private float timerValue = 5f;
    private float tiltTime = 1.5f;
    private float timer;

    private float tiltProgress;
    private bool isTilting;
    private bool tiltingForward = true;

    void Start() {
        finalRotation = Quaternion.Euler(0, 0, 45);
        originalRotation = gameObject.transform.rotation;
        timer = timerValue;
    }

    void Update() {
        if (!isTilting) {
            timer -= Time.deltaTime;
            if (timer < 0) {
                isTilting = true;
                tiltProgress = 0f;
            }
        } else {
            tiltPlatform();
        }
    }

    private void tiltPlatform() {
        tiltProgress += Time.deltaTime / tiltTime;

        if (tiltingForward) {
            gameObject.transform.rotation = Quaternion.Slerp(originalRotation, finalRotation, tiltProgress);
        } else {
            gameObject.transform.rotation = Quaternion.Slerp(finalRotation, originalRotation, tiltProgress);
        }
        
        if (tiltProgress >= 1f) {
            if (tiltingForward) {
                gameObject.transform.rotation = finalRotation;
            } else {
                gameObject.transform.rotation = originalRotation;
            }

            isTilting = false;
            tiltingForward = !tiltingForward;
            timer = timerValue;
        }
    }
}