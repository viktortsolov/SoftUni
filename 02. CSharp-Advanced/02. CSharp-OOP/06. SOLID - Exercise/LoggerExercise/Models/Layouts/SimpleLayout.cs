using LoggerExercise.Models.Contracts;

namespace LoggerExercise.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
