// === Scripts/XRInitializer.cs ===
using UnityEngine;
using UnityEngine.XR;

public class XRInitializer : MonoBehaviour {
    void Awake() {
        // Ensure 90fps on Quest 3
        Application.targetFrameRate = 90;
        QualitySettings.vSyncCount = 0;
    }

    void Start() {
        // Optional: verify XR loaded
        if (!XRSettings.enabled) {
            Debug.LogWarning("XR not enabled");
        }
    }
}


// === Scripts/HandTrackingController.cs ===
using UnityEngine;
using Meta.Interaction;  // from Meta Interaction SDK v63

public class HandTrackingController : MonoBehaviour {
    [Tooltip("Interactable prefab to spawn on pinch")] public GameObject spawnPrefab;
    private HandPoseDetector detector;

    void Start() {
        detector = GetComponent<HandPoseDetector>();
        if (detector == null) {
            Debug.LogError("HandPoseDetector required");
        }
    }

    void Update() {
        if (detector.IsPinchGesture(Handedness.Right)) {
            var pos = detector.GetPinchPosition(Handedness.Right);
            Instantiate(spawnPrefab, pos, Quaternion.identity);
        }
    }
}


// === Scripts/VoiceCommandManager.cs ===
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;

public class VoiceCommandManager : MonoBehaviour {
    private KeywordRecognizer recognizer;
    private Dictionary<string, System.Action> commands = new Dictionary<string, System.Action>();

    void Start() {
        commands.Add("reset scene", ResetScene);
        commands.Add("spawn cube", () => SpawnPrimitive(PrimitiveType.Cube));
        recognizer = new KeywordRecognizer(commands.Keys as IEnumerable<string>);
        recognizer.OnPhraseRecognized += OnPhraseRecognized;
        recognizer.Start();
    }

    private void OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        if (commands.ContainsKey(args.text)) {
            commands[args.text].Invoke();
        }
    }

    private void SpawnPrimitive(PrimitiveType type) {
        var obj = GameObject.CreatePrimitive(type);
        obj.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
        obj.AddComponent<Rigidbody>();
    }

    private void ResetScene() {
        foreach (var rb in FindObjectsOfType<Rigidbody>()) {
            Destroy(rb.gameObject);
        }
    }
}


// === Scripts/SimpleGrabInteractable.cs ===
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class SimpleGrabInteractable : MonoBehaviour {
    private XRGrabInteractable grab;

    void Awake() {
        grab = GetComponent<XRGrabInteractable>();
        grab.onSelectEntered.AddListener(OnGrab);
        grab.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor) {
        Debug.Log(gameObject.name + " grabbed by " + interactor.name);
    }

    private void OnRelease(XRBaseInteractor interactor) {
        Debug.Log(gameObject.name + " released by " + interactor.name);
    }
}


// === End of Code ===
