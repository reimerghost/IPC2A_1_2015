using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2Ejemplos.Ejemplo1
{
    public partial class EjemploPaginacion : System.Web.UI.Page
    {
        String[] nombres;
        int[] valores;
        int p;

        protected void Page_Load(object sender, EventArgs e)
        {
            try{
                p = int.Parse(Request.QueryString["pag"]);
            }catch{
                p = 1;
            }
                
            asignarDatos();
            htmlCode.Text = entablarHTMLContenido(escribirCatalogo(nombres, valores, p, 6))
                + "" + imprimeHTMLPaginas(6) ;
        }

        //Asumiendo que éste metodo obtiene los resultados de SQL Server
        private void asignarDatos()
        {
            //Obtener resultados por medio de WebService (que retorne un array[])
            String[] n = { "Dato1", "Dato2", "Dato3", "Dato4", "Dato5", "Dato6",
                           "Dato7", "Dato8", "Dato9", "Dato10", "Dato11", "Dato12",
                           "Dato13", "Dato14", "Dato15", "Dato16", "Dato17", "Dato18", "Dato19", "Dato20",
                         "Dato1", "Dato2", "Dato3", "Dato4", "Dato5", "Dato6",
                           "Dato7", "Dato8", "Dato9", "Dato10", "Dato11", "Dato12",
                           "Dato13", "Dato14", "Dato15", "Dato16", "Dato17", "Dato18", "Dato19", "Dato20" };
            //Obtener resultados por medio de WebService (que retorne un array[])
            int[] v = { 100, 200, 300, 400, 500, 600,
                        700, 800, 900, 1000, 1100, 1200,
                        1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000,
                        100, 200, 300, 400, 500, 600,
                        700, 800, 900, 1000, 1100, 1200,
                        1300, 1400, 1500, 1600, 1700, 1800, 1900, 2000 };
            //Asignando resultados a variables locales.
            nombres = n;
            valores = v;
        }

        private String imprimeHTMLPaginas(int m)
        {
            String paginas="";
            int maxP = nombres.Length/m;
            for (int i = 1;i<=maxP;i++)
            {
                if(i==p){
                    paginas +=i+" ";
                }else{
                paginas += " <a href=\"EjemploPaginacion.aspx?pag="+i+"\">" + i + "</a>";
                }
            }
            return paginas;
        }

        private String escribirCatalogo(String[] prod, int[] precio, int pag, int items)
        {
            String fila="";

            if (pag > 0)
            {
                int inicia;
                if(pag == 1)
                {
                    inicia = 0;
                }
                else
                {
                    inicia = (items*(pag-1));
                }
                if ((inicia + items) < prod.Length)
                {
                    items = inicia + items;
                }
                else
                {
                    items = prod.Length;
                }
                for (int i = inicia; i < items; i++)
                {
                    fila += agregarFila(agregarColumna(prod[i] + "</br>" + precio[i]));
                }
            }
            else
            {
                fila = "ERROR";
            }

            return fila;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        private String agregarColumna(String cont)
        {
            return "<td>" + cont + "</td>";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cont"></param>
        /// <returns></returns>
        private String agregarFila(String cont)
        {
            return "<tr>" + cont + "</tr>";
        }


        private String entablarHTMLContenido(String cont)
        {
            String tabla;
            tabla = "<table border=\"1px\">";
            tabla += cont;
            tabla += "</table>";
            return tabla;
        }
    }
}