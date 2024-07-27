namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge {
    public partial class Radio {
        private string LanguageCode { get; set; }
        public Radio(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
