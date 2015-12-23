﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Lui
{
	public class LFrameAnimation : MonoBehaviour
    {
        
        public float fps = 15f;
		public bool isPlayOnwake = false;
		public string path;

        protected Image comImage;
        protected float time;
        protected int frameLenght;
        protected bool isPlaying = false;
		protected int currentIndex = 0;
        protected Sprite[] spriteArr;

        // Use this for initialization
        void Start()
        {
            comImage = gameObject.GetComponent<Image>();

			if (isPlayOnwake) {
				loadTexture ();
				play ();
			}
        }

		public void loadTexture()
		{
			//load textures
			Object[] texObj = Resources.LoadAll(path,typeof(Sprite));
            frameLenght = texObj.Length;
            spriteArr = new Sprite[frameLenght];

            for (int i = 0; i < frameLenght; i++)
            {
				Sprite sp = texObj[i] as Sprite;
				spriteArr[i] = sp;
            }
		}

        void OnGUI()
        {
            if (isPlaying)
            {
                drawAnimation();
            }
        }

        // Update is called once per frame
        protected void drawAnimation()
        {
            comImage.sprite = spriteArr[currentIndex];

            if (currentIndex < frameLenght)
            {
                time += Time.deltaTime;
                if (time >= 1.0f / fps)
                {
					currentIndex++;
                    time = 0;
                    if (currentIndex == frameLenght)
                    {
                        currentIndex = 0;
                    }
                }
            }
        }

        public void play()
        {
            isPlaying = true;
        }

        public void stop()
        {
            isPlaying = false;
            currentIndex = 0;
            comImage.sprite = spriteArr[0];
        }

        public void pause()
        {
            isPlaying = false;
        }
    }
}