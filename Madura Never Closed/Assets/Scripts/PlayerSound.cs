using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float footstepTimer;
    private float footstepTimerMax;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    private void Start()
    {
        footstepTimer = footstepTimerMax;
    }

    private void Update()
    {
        footstepTimer -= Time.deltaTime;
        if (footstepTimer < 0f)
        {
            footstepTimer = footstepTimerMax;

            if (player.IsWalking())
            {
                SoundManager.Instance.PlayFootstepSound(player.transform.position);
            }
        }
    }
}
