namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Composite {
    public partial class FileSystemItem {
        private string LanguageCode { get; set; }
        public FileSystemItem(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
