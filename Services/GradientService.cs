using MudBlazor;
using System.Timers;
namespace AmidPortfolio.Services
{
    public class GradientTheme
    {
        public string Background { get; init; } = "";
        public string BackgroundRgba { get; init; } = "";
        public string Shadow { get; init; } = "";
        public string Color { get; init; } = "";
        public string Secondary { get; init; } = "";
        public string ShadowRgba { get; init; } = "";
    }

    public class GradientService : IDisposable
    {
        private readonly GradientTheme[] _themes =
         [
             new()
        {
            Background = "linear-gradient(90deg,#6366f1,#a855f7)",
             BackgroundRgba = "linear-gradient(90deg, rgba(99,102,241,.18), rgba(168,85,247,.18))",
            Shadow = "#8b5cf6",
            Color = "#8b5cf6",
            Secondary = "#8B5CF6",
            ShadowRgba = "rgba(139,92,246,.20)"
        },
        new()
        {
            Background = "linear-gradient(90deg,#22c55e,#14b8a6)",
               BackgroundRgba = "linear-gradient(90deg, rgba(34,197,94,.18), rgba(20,184,166,.18))",
            Shadow = "#22c55e",
             Color = "#22c55e",
             Secondary = "#14B8A6",
              ShadowRgba = "rgba(34,197,94,.20)"
        },
        new()
        {
            Background = "linear-gradient(90deg,#ff4d6d,#ec4899)",
              BackgroundRgba = "linear-gradient(90deg, rgba(255,77,109,.18), rgba(236,72,153,.18))",

            Shadow = "#ec4899",
             Color = "#ec4899",
             Secondary = "#F43F5E",
              ShadowRgba = "rgba(236,72,153,.20)"
        },
        new()
        {
            Background = "linear-gradient(90deg,#ff7b00,#ef4444)",
             BackgroundRgba = "linear-gradient(90deg, rgba(255,123,0,.18), rgba(239,68,68,.18))",
            Shadow = "#ef4444",
             Color = "#ef4444",
             Secondary = "#EF4444",
              ShadowRgba = "rgba(239,68,68,.20)"
        }
         ];

        private int _index = 0;
        private readonly System.Timers.Timer _timer;

        public GradientTheme CurrentTheme => _themes[_index];

        public event Action? OnChange;

        public GradientService()
        {
            _timer = new System.Timers.Timer(5000);

            _timer.Elapsed += (_, _) =>
            {
                _index++;

                if (_index >= _themes.Length)
                    _index = 0;

                OnChange?.Invoke();
            };

            _timer.Start();
        }

        public void Dispose()
        {
            _timer.Dispose();
        }
    }
}
