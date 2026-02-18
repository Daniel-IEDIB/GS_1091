namespace Game {
    public static class GameStats {
        public static int Record = 0;
        public static int Points = 0;
        public static bool GameOver = false;
        public static bool Restart = false;
        public static bool IsGameOverScreenActive = false;

        public static void EndGame() {
            GameOver = true;
        }

        public static void RestartGame() {
            Restart = true;
        }

        public static void ResetStats() {
            Points = 0;
            GameOver = false;
            Restart = false;
            IsGameOverScreenActive = false;
        }
        
        public static bool IsRecord() {
            return Points > Record;
        }

        public static void SetRecord() {
            Record = Points;
        }
    }
}