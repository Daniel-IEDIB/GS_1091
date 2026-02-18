namespace Game {
    public static class GameStats {

        public static bool IsWaveActive = false;
        public static int Round = 0;
        public static bool IsPowerUpActive = false;
        public static bool IsRoundsScreenActive = false;
        
        public static int Score = 0;
        public static int EnemyScore = 0;

        public static bool IsGoal = true;


        public static bool IsRoundEnded() {
            return !IsRoundsScreenActive && !IsWaveActive && IsGoal;
        }
    }
}