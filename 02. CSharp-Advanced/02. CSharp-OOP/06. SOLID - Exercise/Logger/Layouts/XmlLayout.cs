namespace Logger.Layouts
{
    class XmlLayout : ILayout
    {
        private const string DefaultTemplate =
@"<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";

        public string Template => DefaultTemplate;
    }
}
