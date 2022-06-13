using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using dg = Autodesk.DesignScript.Geometry;
using dr = Autodesk.DesignScript.Runtime;
using GeometryGym.Ifc;

namespace ifc2dyn
{
    public class IfcDoc
    {
        [dr.IsVisibleInDynamoLibrary(false)]
        public static DatabaseIfc ifc_db = null;
        public IfcDoc (string PathToFile)
        {
            ifc_db = new DatabaseIfc(PathToFile);
        }
        public string LengthUnits()
        {
            IfcProject project = ifc_db.Project;
            IfcUnitAssignment units = project.UnitsInContext;

            string ifc_lenth_element = null;
            foreach (IfcUnit one_unit in units.Units)
            {
                
                if (one_unit.ToString().Contains("LENGTHUNIT"))
                {
                    ifc_lenth_element = one_unit.ToString();
                    break;
                }
                
            }
            return ifc_lenth_element.Split(',').Last().Replace(")", String.Empty).Replace(".", String.Empty).Replace(";", String.Empty);
        }

        public List<IBaseClassIfc> GetElements()
        {
            return ifc_db.Context.Extract<IBaseClassIfc>();
        }
        /// <summary>
        /// Get IfcEnities as List if it exists. From global group IfcSharedBldgElements
        /// </summary>
        /// <returns></returns>
        [dr.MultiReturn("IfcBeam", "IfcBuildingElementProxy", "IfcChimney", "IfcColumn",
            "IfcCovering", "IfcCovering", "IfcCurtainWall", "IfcDoor", "IfcMember", "IfcPlate",
            "IfcRailing", "IfcRamp", "IfcRoof", "IfcSlab", "IfcStair", "IfcWall", "IfcWindow")]
        public Dictionary<string,object> get_IfcSharedBldgElements_enities ()
        {
            return new Dictionary<string, object>()
            {
                {"IfcBeam", ifc_db.Context.Extract<IfcBeam>()},
                {"IfcBuildingElementProxy", ifc_db.Context.Extract<IfcBuildingElementProxy>()},
                {"IfcChimney", ifc_db.Context.Extract<IfcChimney>()},
                {"IfcColumn", ifc_db.Context.Extract<IfcColumn>()},
                {"IfcCovering", ifc_db.Context.Extract<IfcCovering>()},
                {"IfcCurtainWall", ifc_db.Context.Extract<IfcCurtainWall>()},
                {"IfcDoor", ifc_db.Context.Extract<IfcDoor>()},
                {"IfcMember", ifc_db.Context.Extract<IfcMember>()},
                {"IfcPlate", ifc_db.Context.Extract<IfcPlate>()},
                {"IfcRailing", ifc_db.Context.Extract<IfcRailing>()},
                {"IfcRamp", ifc_db.Context.Extract<IfcRamp>()},
                {"IfcRoof", ifc_db.Context.Extract<IfcRoof>()},
                {"IfcSlab", ifc_db.Context.Extract<IfcSlab>()},
                {"IfcStair", ifc_db.Context.Extract<IfcStair>()},
                {"IfcWall", ifc_db.Context.Extract<IfcWall>()},
                {"IfcWindow", ifc_db.Context.Extract<IfcWindow>()}
            };
        }
        public static IEnumerable<object> sort_elements (List<IfcElement> objects)
        {
            //Фиксация Index элементов, которые либо перебраны, либо попали куда-то в колллекцию
            List<int> used_elements = new List<int>();
            List<int> all_indexes = objects.Select(a => a.Index).ToList();

            foreach (IfcElement element in objects)
            {
                int index = element.Index;
                if (!used_elements.Contains(index))
                {
                    if (element.Nests == null)
                    {
                        //PIZDES
                    }
                }
            }


            return null;
        }
    }
}
