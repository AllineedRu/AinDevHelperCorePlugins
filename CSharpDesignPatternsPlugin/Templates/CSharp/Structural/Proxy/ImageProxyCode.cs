namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Proxy {
    public partial class ImageProxy {
        private string LanguageCode { get; set; }
        public ImageProxy(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
