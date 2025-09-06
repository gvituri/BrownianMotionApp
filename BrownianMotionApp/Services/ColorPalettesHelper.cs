using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Services {
    public enum ColorPalette {
        Material,
        Cyberpunk,
        Retro,
        Vibrant,
        Solarized
    }

    public static class ColorPalettesHelper {
        public static readonly Color[] Material = new Color[]
        {
            Color.FromArgb("#F44336"),
            Color.FromArgb("#E91E63"),
            Color.FromArgb("#9C27B0"),
            Color.FromArgb("#673AB7"),
            Color.FromArgb("#3F51B5"),
            Color.FromArgb("#2196F3"),
            Color.FromArgb("#03A9F4"),
            Color.FromArgb("#00BCD4"),
            Color.FromArgb("#009688"),
            Color.FromArgb("#4CAF50") 
        };

        public static readonly Color[] Cyberpunk = new Color[]
        {
            Color.FromArgb("#FF00FF"),
            Color.FromArgb("#00FFFF"),
            Color.FromArgb("#FFFF00"),
            Color.FromArgb("#FF1493"),
            Color.FromArgb("#7FFF00"),
            Color.FromArgb("#00FF7F"),
            Color.FromArgb("#FF4500"),
            Color.FromArgb("#9400D3"),
            Color.FromArgb("#1E90FF"),
            Color.FromArgb("#FF6347")
        };

        public static readonly Color[] Retro = new Color[]
        {
            Color.FromArgb("#FF6F61"),
            Color.FromArgb("#6B5B95"),
            Color.FromArgb("#88B04B"),
            Color.FromArgb("#F7CAC9"),
            Color.FromArgb("#92A8D1"),
            Color.FromArgb("#955251"),
            Color.FromArgb("#B565A7"),
            Color.FromArgb("#009B77"),
            Color.FromArgb("#DD4124"),
            Color.FromArgb("#45B8AC")
        };

        public static readonly Color[] Vibrant = new Color[]
        {
            Color.FromArgb("#E6194B"),
            Color.FromArgb("#3CB44B"),
            Color.FromArgb("#0082C8"),
            Color.FromArgb("#F58231"),
            Color.FromArgb("#911EB4"),
            Color.FromArgb("#46F0F0"),
            Color.FromArgb("#F032E6"),
            Color.FromArgb("#D2F53C"),
            Color.FromArgb("#FABEBE"),
            Color.FromArgb("#008080") 
        };

        public static readonly Color[] Solarized = new Color[]
        {
            Color.FromArgb("#268BD2"),
            Color.FromArgb("#2AA198"),
            Color.FromArgb("#859900"),
            Color.FromArgb("#B58900"),
            Color.FromArgb("#CB4B16"),
            Color.FromArgb("#DC322F"),
            Color.FromArgb("#6C71C4"),
            Color.FromArgb("#D33682"),
            Color.FromArgb("#93A1A1"),
            Color.FromArgb("#073642") 
        };

        public static Color[] GetPalette(ColorPalette type) => type switch {
            ColorPalette.Material => Material,
            ColorPalette.Cyberpunk => Cyberpunk,
            ColorPalette.Retro => Retro,
            ColorPalette.Vibrant => Vibrant,
            ColorPalette.Solarized => Solarized,
            _ => Material
        };
    }
}
