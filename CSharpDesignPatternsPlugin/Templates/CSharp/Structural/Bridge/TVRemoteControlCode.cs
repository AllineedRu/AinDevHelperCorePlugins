namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge {
    public partial class TVRemoteControl {
        private string LanguageCode { get; set; }
        public TVRemoteControl(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
