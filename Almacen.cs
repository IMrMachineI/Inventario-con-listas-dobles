using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioDoblementeEnlazado
{
    class Almacen
    {
        Productos inicio;
        Productos final;
        public Almacen()
        {
            inicio = null;
            final = null;
        }

        public bool almacenVacio()
        {
            if(inicio == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void agregarProducto(Productos producto)
        {
            Productos varTemporal = producto;
            if(almacenVacio())
            {
                inicio = varTemporal;
                final = varTemporal;
            }
            else
            {
                final.siguiente = varTemporal;
                varTemporal.anterior = final;
                final = varTemporal;
            }
        }
        public void agregarInicio(Productos producto)
        {
            Productos varTemporal = producto;
            varTemporal.siguiente = inicio;
            inicio.anterior = varTemporal;
            inicio = varTemporal;
        }
        public Productos buscarProducto(int codigo)
        {
            Productos varTemporal = inicio;
            while(varTemporal != null && varTemporal.codigo != codigo)
            {
                varTemporal = varTemporal.siguiente;
            }
            return varTemporal;
        }
        public void eliminarProducto(int codigo)
        {
            Productos productoAnterior = inicio;
            Productos productoActual = inicio;
            int contador = 0;
            if(codigo == 1)
            {
                inicio = inicio.siguiente;
                inicio.anterior = null;
            }
            else if(codigo > contador)
            {
                while(codigo != contador && productoActual != null)
                {
                    productoAnterior = productoActual;
                    productoActual = productoActual.siguiente;
                    contador++;
                }
                productoAnterior.siguiente = productoActual.siguiente;
            }
        }
        public string reporte()
        {
            string resultado = "";
            Productos varTemporal = inicio;
            while (varTemporal != null)
            {
                resultado += varTemporal.ToString();
                varTemporal = varTemporal.siguiente;
            }
            return resultado;
        }
        public string reporteInverso()
        {
            string resultado = "";
            Productos varTemporal = final;
            while(varTemporal != null)
            {
                resultado += varTemporal.ToString();
                varTemporal = varTemporal.anterior;
            }
            return resultado;
        }
        public void EliminarInicio()
        {
            inicio = inicio.siguiente;
            inicio.anterior = null;
        }
        public void EliminarUltimo()
        {
            final = final.anterior;
            final.siguiente = null;
        }
        public void insertar(int posicion,Productos producto)
        {
            Productos varTemporal = producto;
            if (posicion == 1)
            {
                varTemporal.siguiente = inicio;
                inicio.anterior = varTemporal;
                inicio = varTemporal;
            }
            else
            {
                int contador = 1;
                while(inicio.siguiente != null && contador != posicion)
                {
                    contador++;
                    inicio = inicio.siguiente;
                }
                varTemporal.siguiente = inicio;
                inicio.anterior = varTemporal;
                varTemporal.anterior = inicio.anterior;
                inicio = varTemporal;
            }
        }
    }
}
