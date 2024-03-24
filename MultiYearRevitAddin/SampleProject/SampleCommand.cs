using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Linq;

namespace SampleProject
{
    internal class SampleCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var doc = commandData.Application.ActiveUIDocument.Document;
            var selection = commandData.Application.ActiveUIDocument.Selection.GetElementIds();
            var firstElement = doc.GetElement(selection.First());

// preprocessor directives
#if RV2021 || RV2022 || RV2023
            var id = firstElement.Id.IntegerValue;
            var idType = firstElement.Id.IntegerValue.GetType();
#else       
            var id = firstElement.Id.Value;
            var idType = firstElement.Id.Value.GetType();
#endif

            TaskDialog.Show("Element Id", $"Storage Type:{idType}\nValue:{id}");

            return Result.Succeeded;
        }
    }
}
