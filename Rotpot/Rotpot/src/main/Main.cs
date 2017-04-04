using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Rotpot.src.gui;
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
        Level level;

        public Main()
        {
            resources = new ResourceManager();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();

            camera = new Camera(GraphicsDevice.Viewport);
            camera.Zoom = 1f;
            input = new InputHandler();
            level = new Level(resources);
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
                Exit();

            level.Update(gameTime);
            input.Update();

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
            level.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
