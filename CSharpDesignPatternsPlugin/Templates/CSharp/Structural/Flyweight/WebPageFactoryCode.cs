namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Flyweight {
    public partial class WebPageFactory {
        private string LanguageCode { get; set; }
        public WebPageFactory(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
