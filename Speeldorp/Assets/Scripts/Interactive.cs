using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

enum TypeInteraction
{
    Particle,
    Animation,
    Both,
    None
}
public class Interactive : MonoBehaviour
{
    [Tooltip("Optional Interactions")]
    ParticleSystem _particle;
    Animator _animator;
    AudioSource _sound;
    [Header("References")]
    [SerializeField] private InputProcessor inputProcessor;


    bool _playSound;
    [SerializeField]
    TypeInteraction interaction;
    // Start is called before the first frame update
    void Start()
    {
            _animator = GetComponent<Animator>();
            _particle = GetComponent<ParticleSystem>();
            _sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(inputProcessor.screenPressed)
        {
            Debug.Log("Screen Pressed");
            CheckForHit();
        }
    }
     void CheckForHit()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == UnityEngine.TouchPhase.Began)
        {
            Ray r = Camera.main.ScreenPointToRay(Input.touches[0].position);
            Debug.Log(r);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.transform.tag == "Interaction")
                {
                    Debug.Log("Hit");
                    PlayInteraction();
                }
            }
        }
        else
        {
            Ray r = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
            Debug.DrawRay(r.origin, r.direction * 100, Color.yellow, 100f);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                if (hit.transform.tag == "Interaction")
                {
                    Debug.Log("Hit");
                    PlayInteraction();
                }
            }
        }
     
    }

    void PlayInteraction()
    {
        switch (interaction)
        {
            case TypeInteraction.Particle:
                PlayParticle();
                break;
            case TypeInteraction.Animation:
                PlayAnimation();
                break;
            case TypeInteraction.Both:
                PlayAnimation();
                PlayParticle();
                break;
            case TypeInteraction.None:
                break;
            default:
                break;
        }

        if(_playSound)
        {
            PlayAudio();
        }
    }

    void PlayAudio()
    {
        if (!_sound.isPlaying)
        {
            _sound.Play();
        }
    }
    void PlayParticle()
    {
        if(!_particle.isPlaying)
        _particle.Play();
    }
    void PlayAnimation()
    {
        _animator.Play("Interaction");
    }
}
