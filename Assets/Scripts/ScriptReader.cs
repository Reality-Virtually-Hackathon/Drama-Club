using UnityEngine;
using IBM.Watson.DeveloperCloud.Services.TextToSpeech.v1;
using IBM.Watson.DeveloperCloud.Logging;
using IBM.Watson.DeveloperCloud.Utilities;
using System.Collections;

public class ScriptReader : MonoBehaviour {

    TextToSpeech _textToSpeech;

    string _createdCustomizationId;
    CustomVoiceUpdate _customVoiceUpdate;

    string _testWord = "Dramaclub";

    private bool _synthesizeTested = false;
    private bool _getVoicesTested = false;
    private bool _getVoiceTested = false;
    private bool _getPronuciationTested = false;
    private bool _getCustomizationsTested = false;
    private bool _createCustomizationTested = false;
    private bool _deleteCustomizationTested = false;
    private bool _getCustomizationTested = false;
    private bool _updateCustomizationTested = false;
    private bool _getCustomizationWordsTested = false;
    private bool _addCustomizationWordsTested = false;
    private bool _deleteCustomizationWordTested = false;
    private bool _getCustomizationWordTested = false;

    private DataController _dataController;
    private VoiceProcessor _voiceProcessor;

    void Start()
    {
        LogSystem.InstallDefaultReactors();

        _dataController = FindObjectOfType<DataController> ();
        _voiceProcessor = FindObjectOfType<VoiceProcessor> ();

        CredentialData serviceCredentials = _dataController.GetServiceCredentials ();
        ServiceCredential textToSpeechCredential = serviceCredentials.textToSpeechCredential;

        Credentials credentials = new Credentials(textToSpeechCredential.username, textToSpeechCredential.password, textToSpeechCredential.url);

        _textToSpeech = new TextToSpeech(credentials);
    }

    public void ReadText(string text, TextToSpeech.AudioFinishedCallback followupCallback)
    {
        StartCoroutine(StartTextSynthesis (text, followupCallback));
    }

    private IEnumerator StartTextSynthesis(string text, TextToSpeech.AudioFinishedCallback followupCallback)
    {
        Log.Debug("ScriptReader", "Attempting synthesize");
        _voiceProcessor.Active = false;
        _textToSpeech.Voice = VoiceType.en_US_Allison;
        _textToSpeech.ToSpeech(text, HandleToSpeechCallback, true, null, followupCallback);
        while (!_synthesizeTested)
            yield return null;
    }

    public IEnumerator Synthesize(string text)
    {
        Log.Debug("ScriptReader", "Attempting synthesize.");
        _textToSpeech.Voice = VoiceType.en_US_Allison;
        _textToSpeech.ToSpeech(text, HandleToSpeechCallback, true);
        while (!_synthesizeTested)
            yield return null;
    }

    public IEnumerator GetVoices()
    {
        Log.Debug("ScriptReader", "Attempting to get voices.");
        _textToSpeech.GetVoices(OnGetVoices);
        while (!_getVoicesTested)
            yield return null;
    }

    public IEnumerator GetVoice()
    {
        Log.Debug("ScriptReader", "Attempting to get voice {0}.", VoiceType.en_US_Allison);
        _textToSpeech.GetVoice(OnGetVoice, VoiceType.en_US_Allison);
        while (!_getVoiceTested)
            yield return null;
    }

    public IEnumerator GetPronunciation()
    {
        Log.Debug("ScriptReader", "Attempting to get pronunciation of {0}", _testWord);
        _textToSpeech.GetPronunciation(OnGetPronunciation, _testWord, VoiceType.en_US_Allison);
        while (!_getPronuciationTested)
            yield return null;
    }

    public IEnumerator GetCustomizations()
    {
        Log.Debug("ScriptReader", "Attempting to get a list of customizations");
        _textToSpeech.GetCustomizations(OnGetCustomizations);
        while (!_getCustomizationsTested)
            yield return null;
    }

    string _customizationName = "unity-example-customization";
    string _customizationLanguage = "en-US";
    string _customizationDescription = "A text to speech voice customization created within Unity.";
    public IEnumerator CreateCustomization()
    {
        Log.Debug("ScriptReader", "Attempting to create a customization");
        _textToSpeech.CreateCustomization(OnCreateCustomization, _customizationName, _customizationLanguage, _customizationDescription);
        while (!_createCustomizationTested)
            yield return null;
    }

    public IEnumerator GetCustomization()
    {
        //  Get Customization
        Log.Debug("ScriptReader", "Attempting to get a customization");
        if (!_textToSpeech.GetCustomization(OnGetCustomization, _createdCustomizationId))
            Log.Debug("ScriptReader", "Failed to get custom voice model!");
        while (!_getCustomizationTested)
            yield return null;
    }

    public IEnumerator UpdateCustomization()
    {
        Log.Debug("ScriptReader", "Attempting to update a customization");
        Word[] wordsToUpdateCustomization =
        {
            new Word()
            {
                word = "hello",
                translation = "hullo"
            },
            new Word()
            {
                word = "goodbye",
                translation = "gbye"
            },
            new Word()
            {
                word = "hi",
                translation = "ohioooo"
            }
        };

        _customVoiceUpdate = new CustomVoiceUpdate()
        {
            words = wordsToUpdateCustomization,
            description = "My updated description",
            name = "My updated name"
        };

        if (!_textToSpeech.UpdateCustomization(OnUpdateCustomization, _createdCustomizationId, _customVoiceUpdate))
            Log.Debug("ScriptReader", "Failed to update customization!");
        while (!_updateCustomizationTested)
            yield return null;
    }

    public IEnumerator GetCustomizationWords()
    {
        Log.Debug("ScriptReader", "Attempting to get a customization's words");
        if (!_textToSpeech.GetCustomizationWords(OnGetCustomizationWords, _createdCustomizationId))
            Log.Debug("ScriptReader", "Failed to get {0} words!", _createdCustomizationId);
        while (!_getCustomizationWordsTested)
            yield return null;
    }

    public IEnumerator AddCustomizationWords()
    {
        Log.Debug("ScriptReader", "Attempting to add words to a customization");
        Word[] wordArrayToAddToCustomization =
        {
            new Word()
            {
                word = "bananna",
                translation = "arange"
            },
            new Word()
            {
                word = "orange",
                translation = "gbye"
            },
            new Word()
            {
                word = "tomato",
                translation = "tomahto"
            }
        };

        Words wordsToAddToCustomization = new Words()
        {
            words = wordArrayToAddToCustomization
        };

        if (!_textToSpeech.AddCustomizationWords(OnAddCustomizationWords, _createdCustomizationId, wordsToAddToCustomization))
            Log.Debug("ScriptReader", "Failed to add words to {0}!", _createdCustomizationId);
        while (!_addCustomizationWordsTested)
            yield return null;   
    }

    public IEnumerator GetCustomizationWord()
    {
        Log.Debug("ScriptReader", "Attempting to get the translation of a custom voice model's word.");
        string customIdentifierWord = "hello";
        if (!_textToSpeech.GetCustomizationWord(OnGetCustomizationWord, _createdCustomizationId, customIdentifierWord))
            Log.Debug("ScriptReader", "Failed to get the translation of {0} from {1}!", customIdentifierWord, _createdCustomizationId);
        while (!_getCustomizationWordTested)
            yield return null;
    }

    public IEnumerator DeleteCustomizationWord()
    {
        Log.Debug("ScriptReader", "Attempting to delete customization word from custom voice model.");
        string wordToDelete = "goodbye";
        if (!_textToSpeech.DeleteCustomizationWord(OnDeleteCustomizationWord, _createdCustomizationId, wordToDelete))
            Log.Debug("ScriptReader", "Failed to delete {0} from {1}!", wordToDelete, _createdCustomizationId);
        while (!_deleteCustomizationWordTested)
            yield return null;
    }

    public IEnumerator DeleteCustomization()
    {
        Log.Debug("ScriptReader", "Attempting to delete a customization");
        if (!_textToSpeech.DeleteCustomization(OnDeleteCustomization, _createdCustomizationId))
            Log.Debug("ScriptReader", "Failed to delete custom voice model!");
        while (!_deleteCustomizationTested)
            yield return null;
    }


    void HandleToSpeechCallback(AudioClip clip, string customData, TextToSpeech.AudioFinishedCallback followupCallback)
    {
        PlayClip(clip, followupCallback);
    }
        
    private void PlayClip(AudioClip clip, TextToSpeech.AudioFinishedCallback followupCallback)
    {
        if (Application.isPlaying && clip != null)
        {
            GameObject audioObject = new GameObject("AudioObject");
            AudioSource source = audioObject.AddComponent<AudioSource>();
            source.spatialBlend = 0.0f;
            source.loop = false;
            source.clip = clip;
            source.Play();

            Destroy(audioObject, clip.length);
            StartCoroutine(WaitForAudioFinishedCallback(clip.length, followupCallback));

            _synthesizeTested = true;
        }
    }

    private IEnumerator WaitForAudioFinishedCallback(float time, TextToSpeech.AudioFinishedCallback followupCallback)
    {
        yield return new WaitForSeconds(time);
        _voiceProcessor.Active = true;
        if (followupCallback != null)
        {
            followupCallback ();
        }
    }

    private void OnGetVoices(Voices voices, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get voices response: {0}", customData);
        _getVoicesTested = true;
    }

    private void OnGetVoice(Voice voice, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get voice  response: {0}", customData);
        _getVoiceTested = true;
    }

    private void OnGetPronunciation(Pronunciation pronunciation, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get pronunciation response: {0}", customData);
        _getPronuciationTested = true;
    }

    private void OnGetCustomizations(Customizations customizations, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get customizations response: {0}", customData);
        _getCustomizationsTested = true;
    }

    private void OnCreateCustomization(CustomizationID customizationID, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Create customization response: {0}", customData);
        _createdCustomizationId = customizationID.customization_id;
        _createCustomizationTested = true;
    }

    private void OnDeleteCustomization(bool success, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Delete customization response: {0}", customData);
        _createdCustomizationId = null;
        _deleteCustomizationTested = true;
    }

    private void OnGetCustomization(Customization customization, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get customization response: {0}", customData);
        _getCustomizationTested = true;
    }

    private void OnUpdateCustomization(bool success, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Update customization response: {0}", customData);
        _updateCustomizationTested = true;
    }

    private void OnGetCustomizationWords(Words words, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get customization words response: {0}", customData);
        _getCustomizationWordsTested = true;
    }

    private void OnAddCustomizationWords(bool success, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Add customization words response: {0}", customData);
        _addCustomizationWordsTested = true;
    }

    private void OnDeleteCustomizationWord(bool success, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Delete customization word response: {0}", customData);
        _deleteCustomizationWordTested = true;
    }

    private void OnGetCustomizationWord(Translation translation, string customData)
    {
        Log.Debug("ScriptReader", "Text to Speech - Get customization word response: {0}", customData);
        _getCustomizationWordTested = true;
    }
}
