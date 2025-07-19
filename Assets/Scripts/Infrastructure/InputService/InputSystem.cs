namespace Infrastructure.InputSystem
{
    public class InputService
    {
        public PlayerControls Controls { get; }

        public InputService()
        {
            Controls = new PlayerControls();
        }

        public void EnableLobby()
        {
            Controls.Disable();
            Controls.Lobby.Enable();
        }
    }
}