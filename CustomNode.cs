using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;


namespace CustomNode
{

    [IsDesignScriptCompatible]

    [NodeName("Custom Node")]
    [NodeCategory("Custom Node")]
    [NodeDescription("Custom Node Test.")]
    [NodeSearchTags("Custom","Node")]
    [AlsoKnownAs("CustomNode.CustomNode")]

    [InPortNames("1", "2", "3")]
    [InPortTypes("string","string","string")]
    [InPortDescriptions("string", "string", "string")]

    [OutPortNames("A", "B", "C")]
    [OutPortTypes("string", "string", "string")]
    [OutPortDescriptions("string", "string", "string")]

    public class CustomNode : NodeModel
    {

        [JsonConstructor]
        private CustomNode(IEnumerable<PortModel> inPorts, IEnumerable<PortModel> outPorts) : base(inPorts, outPorts)
        {
            Init();
        }

        public CustomNode()
        {
            RegisterAllPorts();
            Init();
        }

        public void Init()
        {
            this.PropertyChanged += Node_PropertyChanged;
            foreach (var port in InPorts)
            {
                port.Connectors.CollectionChanged += Connectors_CollectionChanged;
            }

            // Code
        }

        void Node_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != "CachedValue") return;
            if (InPorts.Any(x => x.Connectors.Count == 0)) return;

            // Code
        }

        void Connectors_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            // Code
        }

        public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
        {
            BinaryExpressionNode A = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), inputAstNodes[0]);
            BinaryExpressionNode B = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(1), inputAstNodes[1]);
            BinaryExpressionNode C = AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(2), inputAstNodes[2]);
            return new[] { A, B, C };
        }

    }

}