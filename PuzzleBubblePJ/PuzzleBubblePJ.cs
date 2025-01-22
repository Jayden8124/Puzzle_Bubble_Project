using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PuzzleBubblePJ;

public class PuzzleBubblePJ : Game
{

    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    Texture2D _bubble, _gun, _rect;

    enum GameState
    {
        Start,
        Waiting,
        GameOver
    }

    GameState _currentGameState;

    public PuzzleBubblePJ()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // Size Screen
        // var displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        // _graphics.PreferredBackBufferWidth = displayMode.Width;
        // _graphics.PreferredBackBufferHeight = displayMode.Height;
        // _graphics.IsFullScreen = true; // False for Windows Mode

        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;

        _graphics.ApplyChanges();

        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent() // Auto Load When Initialize Run
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _bubble = Content.Load<Texture2D>("bubble"); // Bubble Texture
        _gun = Content.Load<Texture2D>("gun");  // gun Texture

        _rect = new Texture2D(GraphicsDevice, 1200, 830);

        Color[] data = new Color[1200 * 830];
        for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
        _rect.SetData(data);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        MouseState state = Mouse.GetState();

        if (state.LeftButton == ButtonState.Pressed )
        {
            // _currentGameState = GameState.Waiting;
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.DarkGray);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_rect, new Vector2(110, 100), null, Color.Black, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        // TODO: Add your drawing code here

        _spriteBatch.End();
        base.Draw(gameTime);
    }

    // private void InitializeBubblesGrid()
    // {
    //     int rows = 5;
    //     int cols = 8;
    //     int bubbleSize = 50;

    //     for (int row = 0; row < rows; row++)
    //     {
    //         for (int col = 0; col < cols; col++)
    //         {
    //             Vector2 position = new Vector2(); // calculate position
    //             bubbles.Add(new Bubble(bubbleTexture, position));
    //         }
    //     }
    // }
}
