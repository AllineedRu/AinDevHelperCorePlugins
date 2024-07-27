namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge {
    public partial class TV {
        private string LanguageCode { get; set; }
        public TV(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
