namespace CSharpDesignPatternsPlugin.Templates.CSharp.Structural.Bridge {
    public partial class RemoteControl {
        private string LanguageCode { get; set; }
        public RemoteControl(string languageCode) {
            LanguageCode = languageCode;
        }
    }
}
