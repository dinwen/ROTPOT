using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rotpot.src.gui;
using Rotpot.src.level;
using Rotpot.src.level.entities;
using Rotpot.src.utils;
using Svennebanan;

namespace Svennebanan
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ResourceManager resources;
        public static Camera camera;
        private InputHandler input;

        public static Level level;
        public static int currentLevelID = 1;

        MainMenu menu;

        public enum STATE
        {
            Game, Menu, Quit
        };

        public static STATE state = STATE.Menu;

        public Main()
        {
            resources = new ResourceManager();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            camera = new Camera(GraphicsDevice.Viewport);
            camera.Zoom = 1f;
            input = new InputHandler();
            level = new LevelOne(resources);

            menu = new MainMenu(resources, new Vector2(), level);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            resources.LoadContent(Content);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                
            }


            if (state == STATE.Quit)
            {
                Exit();
            }

            if (state == STATE.Game)
            {
                level.Update(gameTime);
                input.Update();
            } 
            else if(state == STATE.Menu)
            {
                menu.Update();
            }

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
            if (state == STATE.Game)
            {
                level.Draw(spriteBatch);
            }
            else if(state == STATE.Menu)
            {
                menu.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
