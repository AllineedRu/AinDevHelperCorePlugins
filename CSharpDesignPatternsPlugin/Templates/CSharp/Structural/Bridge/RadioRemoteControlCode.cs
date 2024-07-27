namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge {
    public partial class RadioRemoteControl {
        private string LanguageCode { get; set; }
        public RadioRemoteControl(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
