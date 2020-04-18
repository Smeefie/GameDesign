using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
    public class UnlockableAbility : Unlockable
    {
        public Ability ability;
        void Start()
        {
            gameObject.transform.Find("Name").GetComponent<Text>().text = ability.name;
            gameObject.transform.Find("Locked").gameObject.SetActive(Locked);
        }
    }
}
