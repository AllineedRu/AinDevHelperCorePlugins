namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Flyweight {
    public partial class WebPage {
        private string LanguageCode { get; set; }
        public WebPage(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
