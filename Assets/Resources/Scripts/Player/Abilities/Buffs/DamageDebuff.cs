using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Abilities.Buffs
{
    #if UNITY_EDITOR
    using UnityEditor;
    using UnityEditor.UIElements;
    #endif

    public class DamageDebuff : Debuff
    {
        public float DamageDealt;
        public float Delay;

        [HideInInspector] public bool DamageOverTime;
        [HideInInspector] public float Interval;
        [HideInInspector] public float ApplyEveryNSeconds;

        private int appliedTimes = 0;

        protected override IEnumerator Effect()
        {
            yield return new WaitForSeconds(Delay);

            if (!DamageOverTime) Interval = 1;

            while (appliedTimes < Interval)
            {
                gameObject.GetComponent<Health>().ReduceHealth(DamageDealt);
                yield return new WaitForSeconds(ApplyEveryNSeconds);
                appliedTimes++;
            }

            Destroy(this);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(DamageDebuff))]
    public class DamageDebuff_Editor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            DamageDebuff script = (DamageDebuff)target;

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
