﻿using System;
using MvvmCross;
using MvvmCross.ViewModels;

namespace RetroGamesGo.Core.Models
{
    public class Character : MvxNotifyPropertyChanged
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public int Year { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string FunFact { get; set; }
        public string Picture { get; set; }
        public string Silhouette { get; set; }

        private bool captured;

        public bool Captured
        {
            get => this.captured;
            set
            {
                this.captured = value;
                this.RaisePropertyChanged(() => this.Captured);
            }
        }
    }
}
