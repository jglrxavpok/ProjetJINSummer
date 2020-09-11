using System;
using JINSummer.Saves;

namespace JINSummer {
    public class Controls {
        
        // TODO: configurable options
        public static bool UseMouseToAim = SaveManager.ReadBoolean("UseMouseToAim", false);
    }
}
