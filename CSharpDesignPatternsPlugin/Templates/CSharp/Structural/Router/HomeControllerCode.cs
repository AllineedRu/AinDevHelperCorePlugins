namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Router {
    public partial class HomeController {
        private string LanguageCode { get; set; }
        public HomeController(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
