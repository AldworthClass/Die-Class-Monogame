using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Die_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        KeyboardState keyboardState, prevKeyboardState;

        List<Texture2D> dieTextures;

        Die die1;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            dieTextures = new List<Texture2D>();
            base.Initialize();
            die1 = new Die(dieTextures, new Rectangle(10, 10, 75, 75));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            for (int i = 1; i <= 6; i++)
                dieTextures.Add(Content.Load<Texture2D>("white_die_" + i));
        }

        protected override void Update(GameTime gameTime)
        {
            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();   
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Space) && prevKeyboardState.IsKeyUp(Keys.Space))
                die1.RollDie();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            die1.DrawDie(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}