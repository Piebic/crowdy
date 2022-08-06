using UnityEngine;
using UnityEditor;

public class CrowdyManager : EditorWindow {

    #region UI Constants

    class Constants {

        public static float elementsSpace = 16;

        public static float titleBeforeSpace = 20;
        public static float titleAfterSpace = 4;

        public static float buttonBeforeSpace = 8;
        public static float buttonAfterSpace = 8;

    }

    #endregion

    #region Spawning Properties

    GameObject onsitePlacersRoot;

    #endregion

    bool updateOnsitePlacersGroupEnabled;

    [MenuItem("Crowdy/Manager")]
    static void Init() {
        // Get existing open window or if none, make a new one:
        CrowdyManager window = (CrowdyManager)EditorWindow.GetWindow(typeof(CrowdyManager));
        window.Show();
    }

    void OnGUI() {
        title("Spawning");
        updateOnsitePlacers();

        title(value: "Motivations");
    }

    #region Spawning

    private void updateOnsitePlacers() {
        updateOnsitePlacersGroupEnabled = EditorGUILayout.Foldout(updateOnsitePlacersGroupEnabled, "Update On-Site Placers");

        if (updateOnsitePlacersGroupEnabled) {
            onsitePlacersRoot = EditorGUILayout.ObjectField("On-Site Placers Root", onsitePlacersRoot, typeof(GameObject), true) as GameObject;

            if (button("Update On-site placers"))
                handleOnsitePlacersUpdate();
        }
    }

    private void handleOnsitePlacersUpdate() {
        if (onsitePlacersRoot == null) {
            Debug.LogError("Can't update on-site placers: onsitePlacersRoot is null");
            return;
        }

        Debug.Log("Updated on-site placers");
    }

    #endregion

    #region Helpers

    private void title(string value) {
        GUILayout.Space(Constants.titleBeforeSpace);
        GUILayout.Label(value, EditorStyles.boldLabel);
        GUILayout.Space(Constants.titleAfterSpace);
    }

    private bool button(string title) {
        GUILayout.Space(Constants.buttonBeforeSpace);
        var value = GUILayout.Button(title);
        GUILayout.Space(Constants.buttonAfterSpace);

        return value;
    }

    #endregion

}
