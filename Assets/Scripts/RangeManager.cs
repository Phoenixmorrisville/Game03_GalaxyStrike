
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public class RangeManager : MonoBehaviour
{
    [SerializeField] Target[] targets;
    [SerializeField] PlayableDirector missionDirector;

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetTargets();
        }
    }

    void ResetTargets()
    {
        missionDirector.Stop();

        foreach (Target target in targets)
        {
            if (target != null)
            {
                target.ResetTarget();
            }
        }

        missionDirector.time = 0;
        missionDirector.Evaluate();
        missionDirector.Play();

        Debug.Log("All targets reset!");
    }
}
