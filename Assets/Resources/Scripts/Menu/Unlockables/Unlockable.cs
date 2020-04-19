using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Resources.Scripts.Requirement;
using Assets.Resources.Scripts.Statistics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Resources.Scripts.Menu.Unlockables
{
  public abstract class Unlockable : MonoBehaviour
  {
      protected bool Locked = true;

      protected string PopupwindowName = "PopupWindow";
      

      protected void Unlock()
      {
          Locked = false;
          gameObject.transform.Find("Locked").gameObject.SetActive(!Locked);
      }

      public abstract void CheckCondition(runtimeStatistics stats);

      public bool isLocked()
      {
          return Locked;
      }
  }
}
