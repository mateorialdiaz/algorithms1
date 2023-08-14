using Microsoft.VisualBasic;
using System.Drawing;
using System.Net;
using System.Security.Policy;

namespace Figuras_en_matrices
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn col in dataGridView1.Columns)  //para esta grilla recorro la coleccion de columnas 
            {
                //itero la coleccion de columnas para hacerlo mas dinámico cuando cargue el formulario
                col.HeaderText = "";//limpie los nombres de cada cabecera de la columna por espacios vacios
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            } //con la linea de arriba hace que por defecto en todas las celdas haya alineacion central
            dataGridView1.Rows.Add(5); //esto lo que hace es agregar las filas
        }    //la colección de filas tiene el metodo add (esta sobrecarga le agrega el numero de filas que deseo (int count))
       //asi queda finalmente representada la matriz


    private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++) //for entre 0 y 4
            {
                //dataGridView1[i, i] devuelve una celda
                dataGridView1[i, i].Value = "*";
            }
                    }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(5);
            for (int i = 0; i < 5; i++)   
            {
                dataGridView1[i, 4-i].Value = "*"; 
                //los indices son [col, fila]
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //letra V
            //cuando llegue a la columna 2 la variable q usé para la fila quiero q vuelva a disminuir
            //para esto uso la variable entera f de fila

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(5);
            int f = 0;
            //esto funciona siempre que la matriz sea un numero impar 
            //sólo habría que cambiar el c<5 y el c>=2
            for (int c = 0; c < 5; c++)
            {
                dataGridView1[c, f].Value = "*";
                if (c >= 2)  //la columna sube pero la fila baja
                    //cuando llego a la columna 2, la variable que uso para la fila disminuye
                    //con una estructura de decision if, encontramos cuando la columna sea mayor o igual a dos
                {
                    f--;
                }
                else { f++; }
            }
        }


        // *          *
        //    *    *
        //       *           <---    dibuja esto
        //       *                         |
        //       *                         v
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(5);
            int f = 0;
            for (int c = 0; c < 5; c++)
            {
                dataGridView1[c, f].Value = "*";
                if (c >= 2)     //hardcodeo la c y trabajo con la fila bajando
                                 //uso el valor que itera las columnas para las filas de la linea del medio de la Y
                {
                    f--;                              //cuando ocurre c>=2, la columna la quiero hardcodeada en 2 y la fila va a ser el valor de c
                    dataGridView1[2, c].Value = "*"; //hardcodeadisimo pero funciona jaj
                }
                else { f++; }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(5);
            //se hace con for y una condicion
            for (int i = 0; i < 5; i++)
            {
                if (i > 3) { dataGridView1[3, i].Value = "*"; }
                else { dataGridView1[i, i].Value = "*"; }
            }
            //siempre que sea >3 hardcodeo 
            //si i>3 pongo * en la col 3 fila 4 
            //la fila me la puede dar i pero la col la dejo en 3 fijo
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int n1 = int.Parse(Interaction.InputBox("n1: "));
            int n2 = int.Parse(Interaction.InputBox("n2: "));
            int n3 = int.Parse(Interaction.InputBox("n3: "));
            int temporal;

            if (n1 > n2)
            {
                temporal = n1;
                n1 = n2;
                n2 = temporal;
            }

            if (n2 > n3)
            {
                temporal = n2;
                n2 = n3;
                n3 = temporal;
            }

            if (n1 > n2)
            {
                temporal = n1;
                n1 = n2;
                n2 = temporal;
            }
            textBox1.Text = $"Ordenados: {n1}, {n2}, {n3}";



        }

        private void button7_Click(object sender, EventArgs e)
        {
            //esta consigna se basa en un límite numérico

            // la serie se continuará generando hasta llegar a un número que sea igual o menor a un límite determinado "n".
            // Por ej., si el usuario ingresa 10, la serie sería 0, 1, 1, 2, 3, 5, 8.

            int n = int.Parse(Interaction.InputBox("Ingrese el valor máximo para la serie de Fibonacci: "));


            //acá se inicializan a los dos primeros números en la serie
            int a = 0;
            int b = 1;

            // Comenzamos con la cadena para mostrar la serie
            string serieFibonacci = "Serie de Fibonacci: " + a;

            // Mientras que el siguiente número en la serie no exceda n
            //asegura que la serie de Fibonacci se continúe generando solo hasta que alcance o supere el valor máximo n

            while (b <= n)
            {
                // se añade el número actual b a la cadena de la serie,
                // y luego se calcula el próximo número de la serie
                // sumando a y b
                serieFibonacci += ", " + b;

                // Acá calculo el siguiente número en la serie
                int temp = a + b;
                a = b;
                b = temp;
            }

            // muestro la serieFibonacci 
            textBox2.Text = serieFibonacci;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            //esta consinga se basa en la cantidad de términos de la serie.
            // la serie se generará para los primeros "n" términos, independientemente de los valores de esos términos.
            // Por ej., si el usuario ingresa 5, la serie sería 0, 1, 1, 2, 3, sin importar que los números sean mayores
            // o menores que el número 5.


            int n = int.Parse(Interaction.InputBox("Ingrese la cantidad de números de la serie de Fibonacci que desea: "));

            int a = 0;
            int b = 1;

            // Comenzamos con la cadena para mostrar la serie
            string serieFibonacci = "Serie de Fibonacci: ";

            // Vamos a calcular los primeros n números en la serie
            for (int i = 0; i < n; i++)
            {
                if (i == 0)
                {
                    serieFibonacci += a; // El primer número en la serie
                }
                else
                {
                    serieFibonacci += ", " + b; // El resto de los números en la serie

                    // Calculamos el siguiente número en la serie
                    int temp = a + b;
                    a = b;
                    b = temp;
                }
            }

            // Aquí puedes mostrar la serieFibonacci donde desees, por ejemplo, en un TextBox
            textBox3.Text = serieFibonacci;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //RECORDAR QUE:
            //Un número primo es un número natural mayor que 1 que solo tiene dos divisores distintos:
            //él mismo y 1. Si un número es divisible por cualquier otro número además de 1 y él mismo,
            //entonces no es primo


            //Lo que hace el siguiente algoritmo es obtener números primos desde el 1 hasta
            //el número que no supere el número n ingresado por el usuario.


            int n = int.Parse(Interaction.InputBox("Ingrese el numero: "));
            string primos = "Números primos: 2"; // 2 es el primer número primo
 
            for (int i = 3; i <= n; i += 2) // Comenzamos desde 3 y saltamos los números pares, ya que (excepto el 2) estos no pueden ser primos
            {
                bool esPrimo = true;


                //si un número i no es primo, tendrá un divisor que sea menor o igual a su raíz cuadrada.
                //Entonces, en lugar de probar todos los posibles divisores hasta i,
                //solo necesitamos probar hasta la raíz cuadrada de i
                for (int j = 2; j * j <= i; j++)
                {
                    if (i % j == 0)
                    {
                        //esta condicion nos permite determinar si un número no es primo
                        //tan pronto como encontremos un divisor exacto
                        esPrimo = false;
                        break;
                    }
                }

                if (esPrimo)
                {
                    primos += ", " + i.ToString();
                }
            }

            textBox4.Text = primos;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int n = int.Parse(Interaction.InputBox("Ingrese la cantidad de números primos que desea obtener: "));
            string primos = "Números primos: ";
            int contadorPrimos = 0;
            int numero = 2; // Comienzo desde 2, el primer número primo

            while (contadorPrimos < n)
            {
                bool esPrimo = true;

                for (int j = 2; j * j <= numero; j++)
                {
                    if (numero % j == 0)
                    {
                        esPrimo = false;
                        break;
                    }
                }

                if (esPrimo)
                {

                    //Añade el número primo actual (el valor de numero) a la cadena primos
                    primos += numero.ToString();
                    if (contadorPrimos < n - 1)
                    {
                        //Añade una coma y espacio después del número primo actual, pero solo si no es el último número primo en la lista.
                        //La condición contadorPrimos < n - 1 verifica si aún quedan más números primos por agregar a la lista.
                        // entonces esta condición asegura que la coma se
                        //agregue solo si todavia quedan más números primos por encontrar.


                        primos += ", ";
                        

                    }
                    contadorPrimos++;
                }

                numero++;
            }

            textBox5.Text = primos;
        }
    }
    }
    
    
