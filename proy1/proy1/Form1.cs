namespace proy1
{
    public partial class Form1 : Form
    {
        private double valor1 = 0;        // Primer valor para las operaciones
        private string operacion = "";    // Almacena la operación seleccionada
        private bool operacionPendiente = false; // Para limpiar el TextBox al iniciar una operación
        private bool esNegativo = false; // Para manejar los números negativos

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumero_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender; // Identificar el botón presionado

            // Si hay una operación pendiente, limpiar la pantalla
            if (operacionPendiente)
            {
                txtResultado.Clear();
                operacionPendiente = false;
            }

            // Evitar que el primer número sea "0" si ya hay más dígitos
            if (txtResultado.Text == "0")
                txtResultado.Clear();

            // Agregar el número del botón al TextBox
            txtResultado.Text += boton.Text;
        }

        private void btnOperacion_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender; // Identificar qué operación fue seleccionada

            // Verificamos si estamos ingresando un número negativo
            if (boton.Text == "-" && txtResultado.Text == "")
            {
                txtResultado.Text = "-"; // Si el TextBox está vacío, se ingresa un número negativo
                return;
            }

            valor1 = double.Parse(txtResultado.Text); // Guardar el primer número
            operacion = boton.Text;                    // Guardar la operación (+, -, *, /)
            operacionPendiente = true;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            double valor2 = double.Parse(txtResultado.Text); // Segundo valor
            double resultado = 0;

            // Realizar la operación seleccionada
            switch (operacion)
            {
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
                case "*":
                    resultado = valor1 * valor2;
                    break;
                case "/":
                    if (valor2 != 0)
                        resultado = valor1 / valor2;
                    else
                        MessageBox.Show("Error: División por cero no permitida.");
                    break;
            }

            txtResultado.Text = resultado.ToString(); // Mostrar el resultado
            operacionPendiente = true; // Permitir una nueva operación
        }

        // Método para manejar la operación de cambio de signo
        private void btnCambiarSigno_Click(object sender, EventArgs e)
        {
            // Cambiar el signo del número actual
            if (txtResultado.Text != "")
            {
                double numeroActual = double.Parse(txtResultado.Text);
                numeroActual = numeroActual * -1; // Cambiar el signo
                txtResultado.Text = numeroActual.ToString(); // Mostrar el nuevo número
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            valor1 = 0;
            operacion = "";
            txtResultado.Clear();
            operacionPendiente = false;
        }

        private void btnOperacionEspecial_Click(object sender, EventArgs e)
        {
            Button boton = (Button)sender; // Identificar qué botón fue presionado
            double numero = double.Parse(txtResultado.Text); // Obtener el número actual

            if (boton.Text == "√")
            {
                if (numero >= 0)
                {
                    double resultado = Math.Sqrt(numero); // Calcular la raíz cuadrada
                    txtResultado.Text = resultado.ToString(); // Mostrar el resultado
                }
                else
                {
                    MessageBox.Show("Error: No se puede calcular la raíz cuadrada de un número negativo.");
                }
            }
            else if (boton.Text == "x²")
            {
                double resultado = Math.Pow(numero, 2); // Calcular la potencia cuadrada
                txtResultado.Text = resultado.ToString(); // Mostrar el resultado
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtResultado_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

