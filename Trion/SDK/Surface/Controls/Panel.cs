﻿using System.Collections.Generic;
using System.Drawing;

using Trion.SDK.Interfaces;

namespace Trion.SDK.Surface.Controls
{
    internal class Panel : Control
    {
        #region Variables
        public readonly List<Control> Controls = new List<Control>();
        #endregion

        #region Indexer
        public Control this[int Index]
        {
            get => Controls[Index];
            set => Controls.Add(value);
        }

        public Control this[string Name]
        {
            get
            {
                foreach (Control Control in Controls)
                {
                    if (Control.Name == Name)
                    {
                        return Control;
                    }
                }

                return null;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value.Name))
                {
                    value.Name = Name;
                }

                value.Position.X += Position.X;
                value.Position.Y += Position.Y;

                Controls.Add(value);
            }
        }

        public Control this[string Name, string Text]
        {
            set
            {
                if (string.IsNullOrWhiteSpace(value.Name))
                {
                    value.Name = Name;
                }
                if (string.IsNullOrWhiteSpace(value.Text))
                {
                    value.Text = Text;
                }

                value.Position.X += Position.X;
                value.Position.Y += Position.Y;

                Controls.Add(value);
            }
        }
        #endregion

        public override void Show()
        {
            Interface.Surface.SetDrawColor(BackColor);

            Interface.Surface.SetDrawFilledRect(Position.X, Position.Y, Position.X + Size.Width, Position.Y + Size.Height);

            foreach (Control Element in Controls)
            {
                if (Element.Visible)
                {
                    Element.Show();
                }
            }
        }
    }
}