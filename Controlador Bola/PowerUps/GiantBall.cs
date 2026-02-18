namespace PowerUps {
    public class GiantBall : PowerUp {

        protected override void Activate() {
            Player.Player.Scale *= 5;
            Player.Player.Mass *= 1.5f;
        }
    }
}