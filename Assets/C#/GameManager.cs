using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  MyNamespace
{

    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance { get; private set; }

        public MainTextController mainTextController;
        public UserScriptManager userScriptManager;
        public ImageManager imageManager;
        public PlayerController playerController;
        public InteractionManager interactionManger;
        public FadeEffectManager fadeEffectManager;
        public AspectMangaer imageDisplayManager;
        public HelthController helthController;
        public MousePoint mousePoint;
        public SceneController sceneController;
        public AudioManager audioManager;
        public StateMachine stateMachine;

        [NonSerialized] public int lineNumber;//public but not serialized
        // Singleton Pattern
        void Awake()
        {
            
            Instance = this;

            lineNumber = 0;
        }
    }
}

