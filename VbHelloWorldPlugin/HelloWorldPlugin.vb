Imports AinDevHelperPluginLibrary
Imports AinDevHelperPluginLibrary.Actions
Imports AinDevHelperPluginLibrary.Language
Imports AinDevHelperPluginLibrary.Language.AinDevHelperLanguageCodeConstants

Public Class HelloWorldPlugin
    Inherits StandardAinDevHelperPlugin
    ' =======================================================================================================================
    ' [RU] Имена поддерживаемых плагином действий
    ' [EN] Names of actions supported by this plugin
    ' =======================================================================================================================
    Public Const RU_HELLO_WORLD_ACTION As String = "Привет, мир!"
    Public Const EN_HELLO_WORLD_ACTION As String = "Hello World!"
    Public Const DE_HELLO_WORLD_ACTION As String = "Hallo Welt!"

    ' =======================================================================================================================
    ' [RU] ID поддерживаемых плагином действий
    ' [EN] IDs of actions supported by the plugin
    ' =======================================================================================================================
    Public Const ID_HELLO_WORLD As String = "hello_world"

    ' =======================================================================================================================
    ' [RU] Переопределения для свойств базового класса StandardAinDevHelperPlugin
    ' [EN] Overrides for properties of the StandardAinDevHelperPlugin base class
    ' =======================================================================================================================
    Public Overrides ReadOnly Property Name As String
        Get
            Return "Hello World Plugin"
        End Get
    End Property

    Public Overrides ReadOnly Property Company As String
        Get
            Return "Название Вашей компании-производителя или просто пустая строка"
        End Get
    End Property

    Public Overrides ReadOnly Property Description As String
        Get
            Return "Мой первый плагин для AinDevHelper.."
        End Get
    End Property

    Public Overrides ReadOnly Property Author As String
        Get
            Return "Ваше Имя"
        End Get
    End Property

    Public Overrides ReadOnly Property AuthorEmail As String
        Get
            Return "youremail@yourdomain.ru"
        End Get
    End Property

    Public Overrides ReadOnly Property MajorVersion As Integer
        Get
            Return 1
        End Get
    End Property

    Public Overrides ReadOnly Property MinorVersion As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property BuildVersion As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property RevisionVersion As Integer
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property AuthorSiteURL As String
        Get
            Return "https://allineed.ru"
        End Get
    End Property

    Public Overrides ReadOnly Property Tags As IEnumerable(Of String)
        Get
            Return {"helloworld", "hello", "greeting", "first plugin"}
        End Get
    End Property

    Public Overrides ReadOnly Property SupportedLanguageCodes As IEnumerable(Of String)
        Get
            Return {RU, EN, DE}
        End Get
    End Property

    Public Overrides ReadOnly Property LocalizedDescriptions As IEnumerable(Of AinDevHelperLocalizedMessage)
        Get
            Return {
                New AinDevHelperLocalizedMessage(EN, "My first plugin for AinDevHelper."),
                New AinDevHelperLocalizedMessage(DE, "Mein erstes Plugin für AinDevHelper.")
            }
        End Get
    End Property

    ' =======================================================================================================================
    ' [RU] Реализация методов плагина
    ' [EN] Implementing plugin methods
    ' =======================================================================================================================

    Public Overrides Function GetActions() As IEnumerable(Of AinDevHelperPluginAction)
        Return AinDevHelperPluginAction.From(
                        AinDevHelperPluginAction.ActionFrom(RU_HELLO_WORLD_ACTION, ID_HELLO_WORLD,
                            (EN, EN_HELLO_WORLD_ACTION),
                            (DE, DE_HELLO_WORLD_ACTION)
                        ))
    End Function

    Public Overrides Function RunAction(actionToRun As AinDevHelperPluginAction) As AinDevHelperPluginActionResult
        Select Case actionToRun.ID
            Case ID_HELLO_WORLD
                Return New AinDevHelperPluginActionResult(Me, actionToRun, RU_HELLO_WORLD_ACTION, (EN, EN_HELLO_WORLD_ACTION), (DE, DE_HELLO_WORLD_ACTION))
            Case Else
                Return GetErroneousResponseActionNotRecognized(actionToRun)
        End Select
    End Function
End Class
