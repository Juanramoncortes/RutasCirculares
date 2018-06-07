using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutas2
{
    class Base
    {
        string _nombre;
        public string nombre { get { return _nombre; } }
        private Base _siguiente;
        private Base _anterior;
        public Base siguiente
        {
            get { return _siguiente; }
            set { _siguiente = value; }
        }
        public Base anterior
        {
            get { return _anterior; }
            set { _anterior = value; }
        }

        public Base(string nombre)
        {
            this._nombre = nombre;
            
        }
        public Base()
        {
            this._nombre = "";
            
        }

        public override string ToString()
        {
            return _nombre;
        }
    }




}
