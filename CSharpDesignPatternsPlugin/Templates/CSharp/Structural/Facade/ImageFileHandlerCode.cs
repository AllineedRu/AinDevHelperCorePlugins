namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Facade {
    public partial class ImageFileHandler {
        private string LanguageCode { get; set; }
        public ImageFileHandler(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
