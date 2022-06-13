using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using dg = Autodesk.DesignScript.Geometry;
using dr = Autodesk.DesignScript.Runtime;
using GeometryGym.Ifc;
using static ifc2dyn.IfcDoc;

namespace ifc2dyn
{
    public class IfcElementInfo
    {
        private IfcElement element;
        [dr.MultiReturn("Description", "GlobalId", "Guid", "Index", "Name", "ObjectPlacement", 
            "ObjectType", "Representation", "StepClassName","Tag")]
        public Dictionary<string,object> get_info()
        {
            return new Dictionary<string, object>()
            {
                {"Description",element.Description },
                {"GlobalId",element.GlobalId },
                {"Guid",element.Guid.ToString() },
                {"Index",element.Index },
                {"Name",element.Name },
                {"ObjectPlacement",element.ObjectPlacement },
                {"ObjectType",element.ObjectType },
                {"Representation",element.Representation },
                {"StepClassName",element.StepClassName },
                {"Tag",element.Tag }
            };
        }
        public IfcElementInfo (IfcElement input_element)
        {
            this.element = input_element;
        }
    }
}
