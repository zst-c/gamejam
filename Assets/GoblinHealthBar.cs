using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinHealthBar : MonoBehaviour
{
    int goblinState = 0;
    Animator healthAnimator;
    [SerializeField] GameObject goblin;

    private void Start()
    {
        healthAnimator = GetComponent<Animator>();
    }
    public void GoblinHurt()
    {
        goblinState++;
    }

    private void Update()
    {
        if (goblinState == 1)
        {
            Debug.Log("state 1 goblin");
            healthAnimator.SetBool("1", true);
            Destroy(goblin);
        }
        else if (goblinState == 2)
        {
            Debug.Log("state 2 goblin");
            healthAnimator.SetBool("2", true);
        }
    }
}
