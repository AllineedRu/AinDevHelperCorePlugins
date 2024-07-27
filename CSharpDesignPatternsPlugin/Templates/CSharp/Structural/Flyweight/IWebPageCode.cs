namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Flyweight {
    public partial class IWebPage {
        private string LanguageCode { get; set; }
        public IWebPage(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
