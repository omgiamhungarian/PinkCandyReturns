using System.ComponentModel;

namespace PinkCandyReturns
{
    public class Config
    {
        [Description("Whether or not the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;

        [Description("Chance to get the pink candy. (1 = same chance as the other candies.)")]
        public float CandyWeight { get; set; } = 0.5f;
    }
}