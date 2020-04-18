using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Requirement;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
  public abstract class Unlockable : MonoBehaviour
  {
      protected bool Locked = false;

      protected string PopupwindowName = "PopupWindow";
      

      public void Unlock()
      {
          Locked = false;
          gameObject.transform.Find("Locked").gameObject.SetActive(!Locked);
        }
  }
}
