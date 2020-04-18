using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Requirement;
using UnityEngine;

namespace Assets.Resources.Scripts.Player.Class
{
    [CreateAssetMenu(menuName = "ClassData")]
    public class ClassData : ScriptableObject
    {
        public string name;
        public string description;
        public RequirementObject requirement;
        public List<Ability> activeAbilities;
        public List<Ability> PassiveAbilities;
    }
}
