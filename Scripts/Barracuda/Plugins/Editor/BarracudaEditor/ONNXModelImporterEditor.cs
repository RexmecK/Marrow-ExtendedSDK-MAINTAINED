using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEditor;

using UnityEngine;

namespace Barracuda
{
/// <summary>
/// Asset Importer Editor of ONNX models
/// </summary>
[CustomEditor(typeof(ONNXModelImporter))]
public class ONNXModelImporterEditor : UnityEditor.AssetImporters.ScriptedImporterEditor
{
    public override void OnInspectorGUI()
    {
        var onnxModelImporter = target as ONNXModelImporter;
        if (onnxModelImporter == null)
            return;

        SerializedProperty iterator = this.serializedObject.GetIterator();
        for (bool enterChildren = true; iterator.NextVisible(enterChildren); enterChildren = false)
        {
            if (iterator.propertyPath != "m_Script")
                EditorGUILayout.PropertyField(iterator, true);
        }
        ApplyRevertGUI();
    }

}

/// <summary>
/// Asset Importer Editor of NNModel (the serialized file generated by ONNXModelImporter)
/// </summary>
[CustomEditor(typeof(NNModel))]
public class NNModelEditor : Editor
{
    private Model m_Model;
    private List<string> m_Inputs;
    private List<string> m_InputsDesc;
    private List<string> m_Outputs;
    private List<string> m_OutputsDesc;
    private List<string> m_Memories;
    private List<string> m_MemoriesDesc;
    private List<string> m_Layers;
    private List<string> m_LayersDesc;
    private List<string> m_Warnings;
    private List<string> m_WarningsDesc;
    private string m_NumWeights;
    private Vector2 m_WarningsScrollPosition = Vector2.zero;
    private Vector2 m_InputsScrollPosition = Vector2.zero;
    private Vector2 m_OutputsScrollPosition = Vector2.zero;
    private Vector2 m_MemoriesScrollPosition = Vector2.zero;
    private Vector2 m_LayerScrollPosition = Vector2.zero;
    private const float k_Space = 5f;

    void OnEnable()
    {
        var nnModel = target as NNModel;
        if (nnModel == null)
            return;

        m_Model = ModelLoader.Load(nnModel, verbose:false);
        if (m_Model == null)
            return;

        m_Inputs = m_Model.inputs.Select(i => i.name).ToList();
        m_InputsDesc = m_Model.inputs.Select(i => $"shape: {new TensorShape(i.shape).ToString()}").ToList();

        m_Outputs = m_Model.outputs.ToList();
        m_OutputsDesc = m_Model.outputs.Select(i => "").ToList();

        m_Memories = m_Model.memories.Select(i => i.input).ToList();
        m_MemoriesDesc = m_Model.memories.Select(i => $"shape:{i.shape.ToString()} output:{i.output}").ToList();

        m_Layers = m_Model.layers.Select(i => i.type.ToString()).ToList();
        m_LayersDesc = m_Model.layers.Select(i => i.ToString()).ToList();
        m_NumWeights = m_Model.layers.Sum(l => (long)l.weights.Length).ToString();

        m_Warnings = m_Model.Warnings.Select(i => i.LayerName).ToList();
        m_WarningsDesc = m_Model.Warnings.Select(i => i.Message).ToList();
    }

    public override void OnInspectorGUI()
    {
        if (m_Model == null)
            return;

        GUI.enabled = true;
        GUILayout.Label($"Source: {m_Model.IrSource}");
        GUILayout.Label($"Version: {m_Model.IrVersion}");
        GUILayout.Label($"Producer Name: {m_Model.ProducerName}");

        ListUIHelper($"Inputs ({m_Inputs.Count.ToString()})", m_Inputs, m_InputsDesc, ref m_InputsScrollPosition);
        ListUIHelper($"Outputs ({m_Outputs.Count.ToString()})", m_Outputs, m_OutputsDesc, ref m_OutputsScrollPosition);
        ListUIHelper($"Memories ({m_Memories.Count.ToString()})", m_Memories, m_MemoriesDesc, ref m_MemoriesScrollPosition);
        ListUIHelper($"Layers ({m_Layers.Count.ToString()} using {m_NumWeights} weights)", m_Layers, m_LayersDesc, ref m_LayerScrollPosition);
        ListUIHelper($"Warnings {m_Warnings.Count.ToString()}", m_Warnings, m_WarningsDesc, ref m_WarningsScrollPosition);
    }

    private static void ListUIHelper(string sectionTitle, IReadOnlyList<string> names, IReadOnlyList<string> descriptions, ref Vector2 scrollPosition)
    {
        int n = names.Count();
        Debug.Assert(descriptions.Count == n);

        GUILayout.Space(k_Space);
        GUILayout.Label(sectionTitle, EditorStyles.boldLabel);
        float height = Mathf.Min(n * 20f + 2f, 150f);
        if (n == 0)
            return;

        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUI.skin.box, GUILayout.MinHeight(height));
        Event e = Event.current;
        float lineHeight = 16.0f;

        StringBuilder fullText = new StringBuilder();
        fullText.Append(sectionTitle);
        fullText.AppendLine();
        for (int i = 0; i < n; ++i)
        {
            string name = names[i];
            string description = descriptions[i];
            fullText.Append($"{name} {description}");
            fullText.AppendLine();
        }

        for (int i = 0; i < n; ++i)
        {
            Rect r = EditorGUILayout.GetControlRect(false, lineHeight);

            string name = names[i];
            string description = descriptions[i];

            // Context menu, "Copy"
            if (e.type == EventType.ContextClick && r.Contains(e.mousePosition))
            {
                e.Use();
                var menu = new GenericMenu();
                // need to copy current value to be used in delegate
                // (C# closures close over variables, not their values)
                menu.AddItem(new GUIContent($"Copy current line"), false, delegate {
                    EditorGUIUtility.systemCopyBuffer = $"{name} {description}";
                });
                menu.AddItem(new GUIContent($"Copy section"), false, delegate {
                    EditorGUIUtility.systemCopyBuffer = fullText.ToString();
                });
                menu.ShowAsContext();
            }

            // Color even line for readability
            if (e.type == EventType.Repaint)
            {
                GUIStyle st = "CN EntryBackEven";
                if ((i & 1) == 0)
                    st.Draw(r, false, false, false, false);
            }

            // layer name on the right side
            Rect locRect = r;
            locRect.xMax = locRect.xMin;
            GUIContent gc = new GUIContent(name.ToString(CultureInfo.InvariantCulture));

            // calculate size so we can left-align it
            Vector2 size = EditorStyles.miniBoldLabel.CalcSize(gc);
            locRect.xMax += size.x;
            GUI.Label(locRect, gc, EditorStyles.miniBoldLabel);
            locRect.xMax += 2;

            // message
            Rect msgRect = r;
            msgRect.xMin = locRect.xMax;
            GUI.Label(msgRect, new GUIContent(description.ToString(CultureInfo.InvariantCulture)), EditorStyles.miniLabel);
        }
        GUILayout.EndScrollView();
    }
}

}
