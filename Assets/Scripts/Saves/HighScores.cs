namespace JINSummer.Saves {
    public class HighScores {
        // sorted from best to worst
        public static int[] Scores = new int[10];

        static HighScores() {
            // load highscores
            for (int i = 0; i < Scores.Length; i++) {
                Scores[i] = SaveManager.ReadInt("HighScore"+i, 0);
            }
        }

        public static void NewScore(int score) {
            // insertion sort
            for (int i = 0; i < Scores.Length; i++) {
                int oldScore = Scores[i];
                if (score > oldScore) {
                    // move old scores to right
                    for (int j = Scores.Length-1; j > i; j--) {
                        Scores[j] = Scores[j-1];
                    }
                    // add new score
                    Scores[i] = score;
                    
                    break;
                }
            }

            SaveScores();
        }

        private static void SaveScores() {
            for (int i = 0; i < Scores.Length; i++) {
                SaveManager.Set("HighScore"+i, Scores[i]);
            }
            SaveManager.Save();
        }
    }
}
