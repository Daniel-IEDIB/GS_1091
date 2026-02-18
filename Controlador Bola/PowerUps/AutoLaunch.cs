namespace PowerUps {
    public class AutoLaunch : PowerUp {
        protected override void Activate() {
            Player.Player.IsAutoLaunchActive = true;
        }
    }
}