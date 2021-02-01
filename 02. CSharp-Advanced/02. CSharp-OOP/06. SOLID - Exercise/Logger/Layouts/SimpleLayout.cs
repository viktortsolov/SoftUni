namespace Logger.Layouts
{
    class SimpleLayout : ILayout
    {
        private const string DefaultTemplate = "{0} - {1} - {2}";

        public string Template => DefaultTemplate;


    }
}
