using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rutas2
{
    class Estructura
    {
        Base inicio = null;
        private int _contador;
        public int contador
        {
            get { return _contador; }
        }
        public Estructura()
        {
            _contador = 0;
        }
        public void AgregarFinal(Base nuevo)
        {
            if (Buscar(nuevo.nombre) == null)

                if (inicio == null)
                {
                    inicio = nuevo;
                    inicio.anterior = inicio;
                    inicio.siguiente = inicio;
                    _contador++;
                }
                else
                {
                    Base temp = inicio;
                    temp.anterior = nuevo;
                    temp.anterior.siguiente = inicio;

                    if (temp.siguiente == inicio)
                    {
                        temp.siguiente = nuevo;
                        temp.siguiente.anterior = temp;
                    }
                    else
                    {
                        while (temp.siguiente != inicio)
                        {
                            temp = temp.siguiente;
                        }
                        temp.siguiente = nuevo;
                        temp.siguiente.anterior = temp;
                    }

                    _contador++;
                }
        }
        public Base Buscar(string name)
        {
            Base temp = inicio;
            if (temp != null)
                if (temp.siguiente != inicio)
                {
                    if ((name.CompareTo(temp.nombre) == 0))
                    {
                        return temp;
                    }
                    temp = temp.siguiente;
                    while (temp != inicio)
                    {
                        if (temp.nombre != null)
                        {
                            if ((name.CompareTo(temp.nombre) == 0))
                            {
                                return temp;
                            }
                        }
                        temp = temp.siguiente;
                    }

                }
                else
                {

                    if ((name.CompareTo(temp.nombre) == 0))
                    {
                        return temp;
                    }

                }
            return null;
        }
        public string Lista(DateTime Inicio,DateTime Fin)
        {
            string res = "";
            Base temp = inicio;
            if (inicio != null)
            {
                do
                {
                    res += temp.ToString() + "\t";
                    temp = temp.siguiente;
                } while (temp != inicio && temp != null);
                res += Environment.NewLine;
                temp = inicio;
                while (Inicio <= Fin) {
                    do
                    {
                        res += Inicio.Hour+":"+Inicio.Minute+"\t";
                        Inicio=Inicio.AddMinutes(10);
                        temp = temp.siguiente;
                    } while (temp != inicio && temp != null);
                    temp = inicio;
                    res += Environment.NewLine;
                }
            }
            return res;
        }
        public Base Eliminar(string name)
        {
            Base buscado = Buscar(name);
            Base anterior;// = new Carro();
            Base siguente;// = new Carro();
            if (inicio != null)
            {
                if (buscado != null)
                {
                    if (buscado == inicio)
                    {
                        EliminarPrimero();
                    }
                    else
                    if (buscado.siguiente != inicio)
                    {
                        anterior = buscado.anterior;
                        siguente = buscado.siguiente;
                        anterior.siguiente = siguente;
                        siguente.anterior = anterior;
                        _contador--;
                    }
                    else
                    {


                        EliminarUltimo();

                    }

                }


                else MessageBox.Show("Registro no encontrado");
            }
            else MessageBox.Show("No existen Registros");

            return buscado;
        }
        public Base EliminarUltimo()
        {
            Base temp = inicio;
            Base eliminado = null;

            if (temp != null)
            {
                if (temp.siguiente == inicio)
                {
                    eliminado = inicio;
                    inicio = null;
                    _contador--;
                }
                else
                {
                    while (temp.siguiente.siguiente != inicio)
                    {
                        temp = temp.siguiente;
                    }
                    eliminado = temp.siguiente;
                    temp.siguiente = inicio;
                    temp.siguiente.anterior = temp;

                }

                _contador--;
            }
            return eliminado;
        }
        public Base EliminarPrimero()
        {
            Base eliminado = inicio;
            if (inicio != null)
                if (inicio.siguiente != inicio)
                {
                    Base buscado = inicio;
                    Base anterior;// = new Carro();
                    Base siguente;// = new Carro();

                    anterior = buscado.anterior;
                    inicio = siguente = buscado.siguiente;

                    anterior.siguiente = siguente;
                    siguente.anterior = anterior;

                    _contador--;
                }
                else
                {
                    inicio = null;
                    _contador = 0;
                }


            return eliminado;
        }
        public void Insertar(Base nuevo, int posicion)
        {
            Base temp = inicio;
            Base Encontrado = Buscar(nuevo.nombre);
            if (Encontrado == null)
                if (posicion == _contador)
                {
                    AgregarFinal(nuevo);
                }
                else
                {
                    Base aux;
                    Base aux2;
                    int a = 1;
                    int i = posicion;
                    if (i > 1)
                    {

                        while (a < (i - 1))
                        {
                            temp = temp.siguiente;
                            a++;
                        }
                        aux = temp.siguiente;

                        temp.siguiente = nuevo;
                        temp.siguiente.anterior = temp;
                        temp.siguiente.siguiente = aux;
                        temp.siguiente.siguiente.anterior = temp.siguiente;
                        _contador++;
                    }
                    else
                    {
                        aux2 = temp.anterior;
                        inicio = nuevo;
                        inicio.siguiente = temp;
                        inicio.siguiente.anterior = inicio;
                        inicio.anterior = aux2;
                        inicio.anterior.siguiente = inicio;
                        _contador++;

                    }

                }

        }
    }
}
