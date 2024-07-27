namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Router {
    public partial class AboutController {
        private string LanguageCode { get; set; }
        public AboutController(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
