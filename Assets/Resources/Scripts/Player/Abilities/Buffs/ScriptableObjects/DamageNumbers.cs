using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.Buffs.ScriptableObjects
{
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditor.UIElements;
#endif

    [CreateAssetMenu(fileName = "DamageNumbers", menuName = "Ability/Effect/DamageNumbers")]
    public class DamageNumbers : ScriptableObject
    {
        public float DamageDealt;
        public float Delay;
        [HideInInspector] public bool DamageOverTime;
        [HideInInspector] public float Interval;
        [HideInInspector] public float ApplyEveryNSeconds;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DamageNumbers))]
    public class DamageDebuff_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DamageNumbers script = (DamageNumbers)target;

            script.DamageOverTime = EditorGUILayout.Toggle("Damage over time", script.DamageOverTime);
            if (script.DamageOverTime)
            {
                script.Interval =
                    EditorGUILayout.FloatField("Interval", script.Interval);
                script.ApplyEveryNSeconds =
                    EditorGUILayout.FloatField("Deal damage every N seconds", script.ApplyEveryNSeconds);
            }
        }
    }
#endif
}
