using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Inventario
    {
        public int ID { get; set; }
        public String NOMBRECORTO { get; set; }
        public String DESCRIPCION { get; set; }
        public String SERIE { get; set; }
        public String COLOR { get; set; }
        public String FECHAADQUISICION { get; set; }
        public String TIPOADQUISICION { get; set; }
        public String OBSERVACIONES { get; set; }
        public int AREAS_ID { get; set; }

    }
}