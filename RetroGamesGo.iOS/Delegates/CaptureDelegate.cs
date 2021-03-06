﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ARKit;
using CoreGraphics;
using Foundation;
using MvvmCross;
using RetroGamesGo.Core.Repositories;
using SceneKit;
using UIKit;

namespace RetroGamesGo.iOS.Delegates
{
    /// <summary>
    /// Delegate for AR Rendering
    /// </summary>
    public class CaptureDelegate : ARSCNViewDelegate
    {
        private ICharacterRepository characterRepository = Mvx.IoCProvider.Resolve<ICharacterRepository>();
        private Action<string> imageCapturedAction;

        public CaptureDelegate(Action<string> imageCapturedAction) : base()
        {
            this.imageCapturedAction = imageCapturedAction;
        }

        public override async void DidAddNode(ISCNSceneRenderer renderer, SCNNode node, ARAnchor anchor)
        {
            if (anchor != null && anchor is ARImageAnchor)
            {
                var imageAnchor = (ARImageAnchor)anchor;
                var imageName = imageAnchor.ReferenceImage.Name;
                imageCapturedAction?.Invoke(imageName);
            }
        }

        public override void DidFail(ARSession session, NSError error)
        {
           // Handle the error
        }

    }
}