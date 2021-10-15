using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expendedora2.Excepciones;

namespace Expendedora2.Biblioteca.Entidades
{
    public class Expendedora
    {
        private List<Lata> _latas;
        private string _proveedor;
        private int _capacidad;
        private double _dinero;
        private bool _encendida;

        public bool Encendida
        {
            get { return this._encendida; }
        }

        public List<Lata> ListadoLatas
        {
            get { return this._latas; }
        }
        public Expendedora()
        {
            this._capacidad = 300;
            this._proveedor = "Unico proveedor";
            this._latas = new List<Lata>();
        }

        public void AgregarLata(Lata lata1)
        {
            foreach(Lata lata2 in this._latas)
            {
                if(lata2.Codigo==lata1.Codigo)
                { throw new CodigoInvalidoException("Ya existe el código que está ingresando"); }
            }

            if(lata1.Cantidad>GetCapacidadRestante())
            {
                throw new CapacidadInsuficienteException("La máquina no posee capacidad para esa cantidad de latas\n" +
                    "CAPACIDAD RESTANTE: " + GetCapacidadRestante());
            }
            _latas.Add(lata1);
        }

        public Lata ExtraerLata(string codigo, double precio)
        {
            Lata LataExtraer = new Lata();
            
           foreach(Lata lata1 in this._latas)
                {
                if(lata1.Codigo.ToUpper()==codigo.ToUpper())
                {
                    LataExtraer = lata1;
                }

            }
           
            if (LataExtraer.Nombre == null)
            {
                throw new CodigoInvalidoException("No existe el código ingresado");
            }
            else if (LataExtraer.Precio > precio)
            {
                throw new DineroInsuficienteException("El dinero ingresado no alcanza\nPRECIO DE LATA: $" + LataExtraer.Precio);
            }
            else if (LataExtraer.Cantidad == 0)
            {
                throw new SinStockException("No hay stock del código ingresado en este momento");
            }
            else
            {
                LataExtraer.Cantidad -= 1;
                this._dinero += LataExtraer.Precio;
            }
          

            return LataExtraer;
        }
        public string GetBalance()
        {
            int cantlatas = this._capacidad - GetCapacidadRestante();
           
            string Balance = "Dinero disponible: $" + this._dinero + "\nLatas totales: " + cantlatas+"\nCapacidad Restante: "+GetCapacidadRestante();
            return Balance;
        }

        public int GetCapacidadRestante()
        {
            int cantlatas = 0;
            foreach (Lata lata1 in this._latas)
            {
                cantlatas += lata1.Cantidad;
            }

            int CapacidadRestante = this._capacidad - cantlatas;
            return CapacidadRestante;
        }

        public void EncenderMaquina()
        {
            this._encendida = true;
        }

        public bool EstaVacia()
        {
            if(GetCapacidadRestante()==this._capacidad)
            { return true; }
            return false;
        }
    }
}
