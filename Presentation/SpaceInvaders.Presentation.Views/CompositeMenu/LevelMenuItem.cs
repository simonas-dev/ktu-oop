using System;
using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.CompositeMenu.Base;

namespace SpaceInvaders.Presentation.Views.CompositeMenu
{
    public class LevelMenuItem : MenuItem
    {
        private readonly string _name;

        public LevelMenuItem(string name)
        {
            FileLogger.Log("Composite pattern: child");

            _name = name;
        }

        public override string Display()
        {
            FileLogger.Log("Composite pattern: child dsiplay");

            return _name;
        }

        public override string GetName()
        {
            FileLogger.Log("Composite pattern: get name");

            return _name;
        }
    }
}