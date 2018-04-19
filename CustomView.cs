using Dynamo.Controls;
using Dynamo.Wpf;


namespace CustomNode
{
    
    public class CustomView : INodeViewCustomization<CustomNode>
    {

        public void CustomizeView(CustomNode node, NodeView view)
        {
            var UI = new CustomUI(node, this);
            view.inputGrid.Children.Add(UI);
            UI.DataContext = node;
        }

        public void Dispose()
        {

        }

    }

}