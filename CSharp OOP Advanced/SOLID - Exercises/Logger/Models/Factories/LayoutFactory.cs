﻿using Logger.Models.Contracts;
using Logger.Models.Layouts;
using System;

namespace Logger.Models.Factories
{
    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;
                case "XmlLayout":
                    layout = new XmlLayout();
                    break;
                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }

            return layout;
        }
    }
}
