using UnityEditor;
using UnityEngine;

namespace WiggedOut.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            GameEvent e = target as GameEvent;
            if (GUILayout.Button("Raise Current Event"))
                e.RaiseEvents();
        }
    }
}