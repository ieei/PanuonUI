﻿using Caliburn.Micro;
using Panuon.UI;
using Panuon.UIBrowser.Views.Partial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Panuon.UIBrowser.ViewModels.Partial
{
    public class WindowsViewModel : Screen, IShell
    {
        private PUWindow _window;

        public WindowsViewModel(PUWindow window)
        {
            _window = window;
        }

        public void OpenDialog(string type)
        {
            switch (type)
            {
                case "scale":
                    PUMessageBox.ShowDialog("这是一个PUMessageBox对话框。");
                    return;
                case "gradual":
                    PUMessageBox.ShowDialog("这是一个PUMessageBox对话框。", "提示", true, UI.PUWindow.AnimationStyles.Gradual);
                    return;
                case "fade":
                    PUMessageBox.ShowDialog("这是一个PUMessageBox对话框。", "提示", true, UI.PUWindow.AnimationStyles.Fade);
                    return;
            }
        }

        public void ShowAwait()
        {
            _window.IsAwaitShow = true;
            var task = new Task(() =>
            {
                Thread.Sleep(2000);
                App.Current.Dispatcher.BeginInvoke(new System.Action(() =>
                {
                    _window.IsAwaitShow = false;
                }));
            });
            task.Start();
        }
    }
}
