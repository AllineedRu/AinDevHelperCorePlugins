namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Facade {
    public partial class TextFileHandler {
        private string LanguageCode { get; set; }
        public TextFileHandler(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
