using SpaceInvaders.Domain.Models;
using SpaceInvaders.Presentation.Views.CompositeMenu.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.Presentation.Views.CompositeMenu
{
    public class LevelMenu : MenuItem
    {
        private readonly IList<MenuItem> _menuItems = new List<MenuItem>();
        private readonly string _name;

        public LevelMenu(string name)
        {
            _name = name;
        }

        public override void Add(MenuItem item)
        {
            FileLogger.Log("Composite pattern: add");

            if (_menuItems.Contains(item)) return;

            _menuItems.Add(item);
        }

        public override void Remove(MenuItem item)
        {
            FileLogger.Log("Composite pattern: remove");

            if (!_menuItems.Contains(item)) return;

            _menuItems.Remove(item);
        }

        public override MenuItem GetChild(int index)
        {
            FileLogger.Log("Composite pattern: get child");

            if (_menuItems?.Count > index || index < 0) return null;

            return (_menuItems ?? throw new ArgumentException(nameof(_menuItems))).ElementAt(index);
        }

        public override string Display()
        {
            FileLogger.Log("Composite pattern: display");

            var builder = new StringBuilder();
            builder.AppendLine("Select game difficulty");
            for (var index = 0; index < _menuItems.Count; index++)
            {
                builder.AppendLine($"{index+1}. {_menuItems[index].Display()}");
            }
            return builder.ToString();
        }

        public override string GetName()
        {
            return _name;
        }
    }
}