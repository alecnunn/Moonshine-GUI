using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Moonshine.gui.Misc;
using Moonshine.gui.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace Moonshine.gui {
    public class Textbox : Control, ITransparentControl, IAnimatableControl {
        /// <summary>
        /// Gets or sets the transparency of this <see cref="Moonshine.gui.Control"/>
        /// </summary>
        public int Transparency { get; set; }

        public SortedList<string, Animator> animators { get; set; }

        public Textbox() : base(){
            Transparency = 255;
            animators = new SortedList<string, Animator>();
            Text = "";
        }
        private Texture2D background = null;
        private Texture2D background_active = null;
        public void SetTexture(Texture2D _background) {
            background = _background;
            if(background_active == null)
                background_active = _background;
        }

        public void SetTexture(Texture2D _background, Texture2D _background_active) {
            background = _background;
            background_active = _background_active;
        }

        private SpriteFont font = null;
        public void SetFont(SpriteFont _font) {
            font = _font;
        }
        public bool MouseIntersects {
            get {
                return (Bounds.Intersects(new Rectangle(MouseHandler.Position.X, MouseHandler.Position.Y, 1, 1)));
            }
        }
        private string _text;
        private bool _textlocked;
        private bool _hot = false;
        private bool _selected = false;
        public override void Update(GameTime t) {
            if(MouseIntersects) {
                _hot = true;
                if(MouseHandler.state.LeftButton == ButtonState.Pressed) {
                    _selected = true;
                }
            } else {
                _hot = false;
                _selected = false;
            }
            if(_selected ) {
                Text += KeyboardHandler.KeyPressedStr(Keys.Q);
                Text += KeyboardHandler.KeyPressedStr(Keys.W);
                Text += KeyboardHandler.KeyPressedStr(Keys.E);
                Text += KeyboardHandler.KeyPressedStr(Keys.R);
                Text += KeyboardHandler.KeyPressedStr(Keys.T);
                Text += KeyboardHandler.KeyPressedStr(Keys.Y);
                Text += KeyboardHandler.KeyPressedStr(Keys.U);
                Text += KeyboardHandler.KeyPressedStr(Keys.I);
                Text += KeyboardHandler.KeyPressedStr(Keys.O);
                Text += KeyboardHandler.KeyPressedStr(Keys.P);
                Text += KeyboardHandler.KeyPressedStr(Keys.A);
                Text += KeyboardHandler.KeyPressedStr(Keys.S);
                Text += KeyboardHandler.KeyPressedStr(Keys.D);
                Text += KeyboardHandler.KeyPressedStr(Keys.F);
                Text += KeyboardHandler.KeyPressedStr(Keys.G);
                Text += KeyboardHandler.KeyPressedStr(Keys.H);
                Text += KeyboardHandler.KeyPressedStr(Keys.J);
                Text += KeyboardHandler.KeyPressedStr(Keys.K);
                Text += KeyboardHandler.KeyPressedStr(Keys.L);
                Text += KeyboardHandler.KeyPressedStr(Keys.Z);
                Text += KeyboardHandler.KeyPressedStr(Keys.X);
                Text += KeyboardHandler.KeyPressedStr(Keys.C);
                Text += KeyboardHandler.KeyPressedStr(Keys.V);
                Text += KeyboardHandler.KeyPressedStr(Keys.B);
                Text += KeyboardHandler.KeyPressedStr(Keys.N);
                Text += KeyboardHandler.KeyPressedStr(Keys.M);
                Text += KeyboardHandler.KeyPressedStr(Keys.D1);
                if(KeyboardHandler.KeyPressedStr(Keys.Space) != "") {
                        Text += " ";
                }
                if(KeyboardHandler.KeyPressedStr(Keys.Back) != "") {
                    if(Text != "") {
                        Text = Text.Remove(Text.Length - 1);
                    }
                }
            }
            base.Update(t);
        }

        public Vector2 TextPosition {
            get {
                return new Vector2(Position.X + 3,Position.Y + (Position.Y /4));
            }
        }
        public string actualText() {
            string tempText = Text;
            float c = Width / 9;
            if(c < tempText.Length) {
                int start = Convert.ToInt32(tempText.Length - c);
                int length = tempText.Length - start;
                tempText = Text.Substring(start, length);
            }
            return tempText;
        }
        public override void Render(GameTime t, SpriteBatch b) {
            if(!_hot && background != null)
                b.Draw(background, Bounds, Color.White);
            else if(_hot && background_active != null)
                b.Draw(background_active, Bounds, Color.White);
            else if(_hot && background != null)
                b.Draw(background, Bounds, Color.White);

            if(font != null)
                b.DrawString(font, actualText(), TextPosition, Color.White);

            base.Render(t, b);
        }



    }
}
