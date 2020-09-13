namespace JINSummer {
    public enum Team {
        PLAYER,
        ENEMIES
    }

    public static class TeamExtensions {
        public static bool OnSameTeam(this Team self, Team other) {
            return self == other;
        }
        
        public static bool OnOpposingTeam(this Team self, Team other) {
            return self != other;
        }
    }
}
