using System.Collections.Generic;
using UnityEngine;

public class CooldownManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private Dictionary<string, float> cooldowns = new Dictionary<string, float>();

    public void StartCooldown(string skillName, float cooldownTime)
    {
        cooldowns[skillName] = Time.time + cooldownTime;
    }

    public bool IsCooldown(string skillName)
    {
        return cooldowns.ContainsKey(skillName) && Time.time < cooldowns[skillName];
    }

    public float GetCooldownRemaining(string skillName)
    {
        return cooldowns.ContainsKey(skillName) ? Mathf.Max(0, cooldowns[skillName] - Time.time) : 0;
    }
}
