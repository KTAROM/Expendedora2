using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expendedora2.Biblioteca.Entidades
{
    public class Lata
    {
        private string _codigo;
        private string _nombre;
        private string _sabor;
        private double _precio;
        private double _volumen;
        private int _cantidad;

        public int Cantidad
        {
            set { this._cantidad = value; }
            get { return this._cantidad; }   
        }

        public string Nombre
        {
            get { return this._nombre; }
        }
        public string Codigo
        {
            get { return this._codigo; }
        }
        public string Sabor
        {
            get { return this._sabor; }
        }
        public double Precio
        {
            get { return this._precio; }
        }
        public Lata() { }
        public Lata(string codigo, string nombre, string sabor, double precio, double volumen, int cantidad)
        {
            this._codigo = codigo;
            this._nombre = nombre;
            this._sabor = sabor;
            this._precio = precio;
            this._volumen = volumen;
            this._cantidad = cantidad;
        }
        
        public double GetPrecioPorLitro()
        {
            double PrecioPorLitro = (this._precio / this._volumen )* 1000;
            return PrecioPorLitro;
        }

        public override string ToString()
        {

            return "CODIGO: " + this._codigo + "\nDESCRIPCION:\nNOMBRE: " + this._nombre + " SABOR: " + this._sabor +"\nCANTIDAD: " + this._cantidad;
        }

        
    }
}
