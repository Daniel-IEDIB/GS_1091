namespace PowerUps {
    public class Speed : PowerUp {
        protected override void Activate() {
            Player.Player.Speed *= 3f;
        }
    }
}