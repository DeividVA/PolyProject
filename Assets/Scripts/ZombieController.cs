using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    [SerializeField] private string IntroState = "Idle";
    private Animator _animator;
    //private bool _intro;
    public bool scream;
    public bool joy;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play(IntroState);
        //_intro = true;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //_intro = false;
            Debug.Log("QuietoParao");
            StartCoroutine(Scream());


            scream = false;
            joy = false;

        }
        else if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Scream"))
        {
            Debug.Log("Gritando!!");
        }
        else 
        {
            Debug.Log("Yupi");
        }

    }



    IEnumerator Scream() 
    
    {
        
        yield return new WaitForSeconds(2f);
        _animator.Play("Scream");
        scream = true;
        StartCoroutine(Joy());

    }

    IEnumerator Joy()

    {

        yield return new WaitForSeconds(10f);
        _animator.Play("JoyJump");
        joy = true;


    }


}
