namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Composite {
    public partial class FileTemplate {
        private string LanguageCode { get; set; }
        public FileTemplate(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
