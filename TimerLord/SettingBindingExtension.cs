﻿using System.Windows.Data;

namespace TimerLord
{
    public class SettingBindingExtension : Binding
    {
        public SettingBindingExtension()
        {
            Initialize();
        }

        public SettingBindingExtension(string path) : base(path)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.Source = TimerLord.Properties.Settings.Default;
            this.Mode = BindingMode.TwoWay;
        }
    }
}
