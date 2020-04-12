using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ModuleSwapper : MonoBehaviour
{
    private PlayerRenderer playerRenderer;

    public GameObject Module;
    public string prefix = "DefaultClass";

    void Start()
    {
        playerRenderer = GetComponent<PlayerRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            var clipArray = Resources.LoadAll("Animations/" + Module.name, typeof(AnimationClip)).Where(i => i.name.Contains(prefix)).Cast<AnimationClip>();

            SwapModule(Module, clipArray.ToArray());
        }
    }

    private void SwapModule(GameObject ModuleToSwap, AnimationClip[] ClipsToSwap)
    {
        Animator ModuleAnimator = ModuleToSwap.GetComponent<Animator>();
        AnimatorOverrideController aoc = new AnimatorOverrideController(ModuleAnimator.runtimeAnimatorController);

        var anims = new List<KeyValuePair<AnimationClip, AnimationClip>>();
        var clipToMap = new AnimationClip();
        foreach (var a in aoc.animationClips)
        {
            switch (a.name)
            {
                default:
                case "Idle":
                    clipToMap = ClipsToSwap.First(i => i.name.Contains("Idle"));
                    anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, clipToMap));
                    break;

                case "Walking":
                    clipToMap = ClipsToSwap.First(i => i.name.Contains("Walking"));
                    anims.Add(new KeyValuePair<AnimationClip, AnimationClip>(a, clipToMap));
                    break;
            }
        }

        aoc.ApplyOverrides(anims);
        ModuleAnimator.runtimeAnimatorController = aoc;
    }
}
