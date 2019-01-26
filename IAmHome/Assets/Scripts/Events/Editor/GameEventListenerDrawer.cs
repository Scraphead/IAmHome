using UnityEditor;
using UnityEngine;
namespace WiggedOut.Events
{
    [CustomPropertyDrawer(typeof(GameEventReferencer))]
    public class GameEventListenerDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions =
            { "Use ScriptableObject Events", "Use Premade Events" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Get properties
            SerializedProperty _useCustomGameEvent = property.FindPropertyRelative("useCustomGameEvent");
            SerializedProperty _gameEvent = property.FindPropertyRelative("gameEvent");
            SerializedProperty _gameState = property.FindPropertyRelative("gameState");

            // Calculate rect for configuration button
            Rect buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            int indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            int result = EditorGUI.Popup(buttonRect, _useCustomGameEvent.boolValue ? 0 : 1, popupOptions, popupStyle);

            _useCustomGameEvent.boolValue = result == 0;

            EditorGUI.PropertyField(position,
                _useCustomGameEvent.boolValue ? _gameEvent : _gameState,
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}

