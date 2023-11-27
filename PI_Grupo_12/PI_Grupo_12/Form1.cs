//using MySql.Data.MySqlClient;
//using Poyecto_Grupo_12.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;

using ComboBox = System.Windows.Forms.ComboBox;
using TextBox = System.Windows.Forms.TextBox;

namespace PI_Grupo_12
{
    private Panel panelForm1;
    private Panel panelForm2;
    private Panel panelConsultar;
    private Panel panelCliente;
    private Panel panelInscripcion;
    private Panel panelListado;

    private Form formularioActual;

    private Form pantallaAnterior;

    private TextBox documentoConsulta = new TextBox();

    private TextBox completar_nombre = new TextBox();
    private TextBox completar_apellido = new TextBox();
    private TextBox completar_documento = new TextBox();
    private TextBox completar_telefono = new TextBox();
    private TextBox completar_correo = new TextBox();
    private TextBox completar_direccion = new TextBox();

    private ComboBox elegir_fisico;
    private ComboBox elegir_medica;
    private ComboBox elegir_categoria;

    private DateTime elegir_fecha;

    public partial class Form1: Form
    {
        InitializeComponent();

        panelForm1 = new Panel();
        panelForm1.Dock = DockStyle.Fill;
        panelForm1.Visible = true;

        panelForm2 = new Panel();
        panelForm2.Dock = DockStyle.Fill;
        panelForm2.Visible = false;

        panelConsultar = new Panel();
        panelConsultar.Dock = DockStyle.Fill;
        panelConsultar.Visible = false;

        panelCliente = new Panel();
        panelCliente.Dock = DockStyle.Fill;
        panelCliente.Visible = false;

        panelInscripcion = new Panel();
        panelInscripcion.Dock = DockStyle.Fill;
        panelInscripcion.Visible = false;

        panelListado = new Panel();
        panelListado.Dock = DockStyle.Fill;
        panelListado.Visible = false;



        // Agregar los nombres de los operadores al comboBox1 en el constructor
        comboBox1.Items.Add("María Eugenia");
        comboBox1.Items.Add("Mariano");
        comboBox1.Items.Add("Martina");
        comboBox1.Items.Add("Luciana");
        comboBox1.Items.Add("Julian");

        this.Controls.Add(comboBox1);

        // Cada operador debe elegir el código de usuario de su PC.
        comboBox2.Items.Add("238097");
        comboBox2.Items.Add("408937");
        comboBox2.Items.Add("398765");
        comboBox2.Items.Add("134976");
        comboBox2.Items.Add("153050");

        this.Controls.Add(comboBox2);


        // Añadir controles al panelForm1
        panelForm1.Controls.Add(label1);
        panelForm1.Controls.Add(comboBox1);
        panelForm1.Controls.Add(label2);
        panelForm1.Controls.Add(comboBox2);
        panelForm1.Controls.Add(label3);
        panelForm1.Controls.Add(button1);

        //Añadir y especificar los controles del panelForm2
        Label label4 = new Label();
        //label4.Text = "Sistema de Gestión de Clientes";
        //label4.Location = new System.Drawing.Point(566, 47);
        //panelForm2.Controls.Add(label4);
        label4.AutoSize = true;
        label4.Location = new System.Drawing.Point(350, 56);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(155, 25);
        label4.TabIndex = 0;
        label4.Text = "SISTEMA DE GESTIÓN DE CLIENTES";
        panelForm2.Controls.Add(label4);

        System.Windows.Forms.Button nuevo = new System.Windows.Forms.Button();
        //nuevo.Text = "Nuevo";
        //nuevo.Location = new Point(10, 40);
        nuevo.Location = new System.Drawing.Point(200, 144);
        nuevo.Name = "nuevo";
        nuevo.Size = new System.Drawing.Size(223, 92);
        nuevo.TabIndex = 1;
        nuevo.Text = "NUEVO CLIENTE";
        nuevo.UseVisualStyleBackColor = true;
        nuevo.Click += nuevo_Click;
        panelForm2.Controls.Add(nuevo);

        System.Windows.Forms.Button deudores = new System.Windows.Forms.Button();
        //deudores.Text = "Deudores";
        //deudores.Location = new Point(10, 70);
        deudores.Location = new System.Drawing.Point(550, 300);
        deudores.Name = "deudores";
        deudores.Size = new System.Drawing.Size(259, 96);
        deudores.TabIndex = 2;
        deudores.Text = "LISTA DE DEUDORES";
        deudores.UseVisualStyleBackColor = true;
        //deudores.Click += deudores_Click;
        panelForm2.Controls.Add(deudores);

        System.Windows.Forms.Button actividades = new System.Windows.Forms.Button();
        actividades.Text = "Actividades";
        actividades.Location = new Point(150, 300);
        actividades.Size = new System.Drawing.Size(337, 92);
        actividades.TabIndex = 3;
        actividades.Text = "REGISTRO DE ACTIVIDADES";
        actividades.UseVisualStyleBackColor = true;
        /*actividades.Location = new System.Drawing.Point(966, 144);
        actividades.Name = "actividades";
        actividades.Size = new System.Drawing.Size(337, 92);
        actividades.TabIndex = 3;
        actividades.Text = "REGISTRO DE ACTIVIDADES";
        actividades.UseVisualStyleBackColor = true; */
        //actividades.Click += actividades_Click;
        panelForm2.Controls.Add(actividades);

        System.Windows.Forms.Button listado = new System.Windows.Forms.Button();
        //listado.Text = "Listado";
        //listado.Location = new Point(10, 130);
        listado.Location = new System.Drawing.Point(550, 144);
        listado.Name = "listado";
        listado.Size = new System.Drawing.Size(261, 96);
        listado.TabIndex = 4;
        listado.Text = "LISTA DE CLIENTES";
        listado.UseVisualStyleBackColor = true;
        //listado.Click += listado_Click;
        panelForm2.Controls.Add(listado);


        // Agregar los paneles al formulario principal
        Controls.Add(panelForm1);
        Controls.Add(panelForm2);
        Controls.Add(panelCliente);
        Controls.Add(panelInscripcion);
        Controls.Add(panelListado);


        // Manejar eventos
        button1.Click += ingresar_Click;
        nuevo.Click += nuevo_Click;
        deudores.Click += deudores_Click;
        actividades.Click += actividades_Click;
        listado.Click += listado_Click;
        comprobar.Click += comprobar_Click;
        //alta.Click += alta_Click;
        //modificar.Click += modificacion_Click;
    }

    // Evento Click del botón Ingresar
    private void ingresar_Click(object sender, EventArgs e)
    {
        // Al hacer clic en Ingresar, mostrar el nuevo formulario en el panel
        panelForm1.Visible = false;
        panelForm2.Visible = true;
        panelCliente.Visible = false;
        panelInscripcion.Visible = false;
    }

    /*
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable tablaLogin = new DataTable(); // es la que recibe los datos desde el formulario
            Datos.Usuarios dato = new Datos.Usuarios(); // variable que contiene todas las caracteristicas de la clase
            tablaLogin = dato.Log_Usu(txtUsuario.Text, txtPass.Text);

        if (tablaLogin.Rows.Count > 0)
            {
                // ____ quiere decir que el resultado tiene 1 fila por lo que el usuario EXISTE ___
            // _____ informamos con un mensaje al usuario _____

                MessageBox.Show("Ingreso exitoso", "MENSAJES DEL SISTEMA",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                /* 
                __________________________________________________________
                ___________________
                una vez que tenemos la conexion establecida PASAMOS al 
                formulario PRINCIPAL
                Se debe "Instanciar" un objeto de la clase formulario 
                principal
                ___________________________________________________________________________
                _______ */

    /*          frmPrincipal Principal = new frmPrincipal();

          /* 
              _________________________________________________________
              ___________
              * la siguiente linea permite tomar el dominio de la 
              primera columna 
              * de la primera fila del resultado de la ejecucion de la 
              query
              * 
              ________________________________________________________
              ____________ */
    /*        Principal.rol = Convert.ToString(tablaLogin.Rows[0][0]);
            Principal.usuario = Convert.ToString(txtUsuario.Text);
            Principal.Show(); // se llama al formulario principal
            this.Hide(); // se oculta el formulario del login
    }
    else
    {
        MessageBox.Show("La selección del operador y/o usuario fue incorrecta");
    }
}

*/

    // Método para mostrar un formulario en el panel
    private void MostrarFormulario(Form formulario)
    {


        // Ocultar el formulario actual si hay uno
        if (formularioActual != null)
        {
            formularioActual.Hide();
        }

        // Asignar el nuevo formulario
        formularioActual = formulario;

        // Configurar el formulario para que se ajuste al panel contenedor
        formulario.TopLevel = false;
        formulario.FormBorderStyle = FormBorderStyle.None;
        formulario.Dock = DockStyle.Fill;


        // Mostrar el formulario
        formulario.Show();
    }

    private void administrador_Click(object sender, EventArgs e)
    {

    }

    private void operador_Click(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void usuario_Click(object sender, EventArgs e)
    {

    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void label4_Click(object sender, EventArgs e)
    {

    }


    private void nuevo_Click(object sender, EventArgs e)
    {
        // Al hacer clic en Nuevo, mostrar el panelCliente y ocultar los demás paneles
        panelForm1.Visible = false;
        panelForm2.Visible = false;
        panelCliente.Visible = true;
        panelInscripcion.Visible = false;

        // Lógica específica del panelCliente
        MostrarFormularioCliente();
    }

    // Método para mostrar un formulario en el panelCliente
    private void MostrarFormularioCliente()
    {
        // Limpiar controles existentes en el panelCliente (si es necesario)
        // panelCliente.Controls.Clear();


        // Agregar y configurar controles específicos del panelCliente
        Label labelCliente = new Label();
        labelCliente.Text = "Cliente";
        labelCliente.Location = new Point(442, 56);
        panelCliente.Controls.Add(labelCliente);


        //Agregar y especificar los que lleva el Panelform3(Nuevo cliente)
        Label label5 = new Label();
        //label5.Text = "Sistema de Gestión de Clientes";
        //label5.Location = new System.Drawing.Point(566, 47);
        //panelForm3.Controls.Add(label5);
        label5.AutoSize = true;
        label5.Location = new System.Drawing.Point(442, 56);
        label5.Name = "cliente";
        label5.Size = new System.Drawing.Size(155, 25);
        label5.TabIndex = 0;
        label5.Text = "Cliente";
        panelCliente.Controls.Add(label5);

        // 
        // comprobar Lo que se quiere hacer en este caso es comprobar si el nuevo cliente ya se encuentra registrado.
        // 
        System.Windows.Forms.Button comprobar = new System.Windows.Forms.Button();
        comprobar.Location = new System.Drawing.Point(180, 177);
        comprobar.Name = "comprobar";
        comprobar.Size = new System.Drawing.Size(149, 104);
        comprobar.TabIndex = 1;
        comprobar.Text = "COMPROBAR DNI";
        comprobar.UseVisualStyleBackColor = true;
        //comprobar.Click += comprobar_Click;
        panelCliente.Controls.Add(comprobar);

        // 
        // alta Se quiere generar una nueva inscripción y el alta en el sistema.
        // 
        System.Windows.Forms.Button alta = new System.Windows.Forms.Button();
        alta.Location = new System.Drawing.Point(426, 173);
        alta.Name = "Inscripcion";
        alta.Size = new System.Drawing.Size(149, 104);
        alta.TabIndex = 2;
        alta.Text = "GENERAR INSCRIPCIÓN";
        alta.UseVisualStyleBackColor = true;
        alta.Click += alta_Click;
        panelCliente.Controls.Add(alta);

        // 
        // modificar Se quiere generar la modificación de una inscripción previamente realizada.
        // 
        System.Windows.Forms.Button modificar = new System.Windows.Forms.Button();
        modificar.Location = new System.Drawing.Point(673, 173);
        modificar.Name = "Modificar Inscripcion";
        modificar.Size = new System.Drawing.Size(149, 104);
        modificar.TabIndex = 3;
        modificar.Text = "MODIFICAR INSCRIPCIÓN";
        modificar.UseVisualStyleBackColor = true;
        //modificar.Click += modificacion_Click;
        panelCliente.Controls.Add(modificar);
    }
    private void deudores_Click(object sender, EventArgs e)
    {

    }

    private void actividades_Click(object sender, EventArgs e)
    {

    }

    private void listado_Click(object sender, EventArgs e)
    {

    }

    private void comprobar_Click(object sender, EventArgs e)
    {
        // Al hacer clic en Nuevo, mostrar el panelCliente y ocultar los demás paneles
        panelForm1.Visible = false;
        panelForm2.Visible = false;
        panelCliente.Visible = false;
        panelConsultar.Visible = true;
        panelInscripcion.Visible = false;

        // Lógica específica del panelCliente
        MostrarFormularioConsultar();
    }


    // Método para mostrar un formulario en el panelClient
    private void MostrarFormularioConsultar()
    {
        // Etiqueta para el mensaje de consulta
        Label labelConsulta = new Label();
        labelConsulta.Text = "Ingrese el DNI del cliente a consultar:";
        labelConsulta.Location = new System.Drawing.Point(45, 400);
        labelConsulta.AutoSize = true;
        panelConsultar.Controls.Add(labelConsulta);

        // Cuadro de texto para ingresar el DNI a consultar
        TextBox documentoConsulta = new TextBox();
        documentoConsulta.Location = new System.Drawing.Point(200, 397);
        documentoConsulta.Name = "documentoConsulta";
        documentoConsulta.Size = new System.Drawing.Size(150, 31);
        documentoConsulta.TabIndex = 24;
        panelConsultar.Controls.Add(documentoConsulta);

        // Botón para realizar la consulta
        //System.Windows.Forms.Button botonConsulta = new System.Windows.Forms.Button();
        Button botonConsulta = new Button();
        botonConsulta.Location = new System.Drawing.Point(360, 397);
        botonConsulta.Name = "botonConsulta";
        botonConsulta.Size = new System.Drawing.Size(100, 31);
        botonConsulta.TabIndex = 25;
        botonConsulta.Text = "Consultar";
        botonConsulta.UseVisualStyleBackColor = true;
        botonConsulta.Click += botonConsulta_Click;
        panelConsultar.Controls.Add(botonConsulta);
    }

    private void botonConsulta_Click(object sender, EventArgs e)
    {
        // Obtener el valor del DNI a consultar desde el TextBox
        string dniConsulta = documentoConsulta.Text;

        // Verificar si el DNI existe en la base de datos
        if (DocumentoExisteEnBaseDeDatos(dniConsulta))
        {
            MessageBox.Show($"El DNI {dniConsulta} está registrado en nuestro sistema", "Documento Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show($"El DNI {dniConsulta} no está registrado en nuestro sistema", "Documento No Existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    private bool DocumentoExisteEnBaseDeDatos(string dniConsulta)
    {
        using (MySqlConnection connection = new MySqlConnection("cadena_de_conexion"))
        {
            connection.Open();

            string consultaSql = $"SELECT * FROM cliente WHERE dni = '{dniConsulta}'";

            using (MySqlCommand command = new MySqlCommand(consultaSql, connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Devolver true si el DNI existe, false si no existe
                    return reader.HasRows;
                }
            }

        }

    }
    private void alta_Click(object sender, EventArgs e)
    {
        // Al hacer clic en Nuevo, mostrar el panelCliente y ocultar los demás paneles
        panelForm1.Visible = false;
        panelForm2.Visible = false;
        panelCliente.Visible = false;
        panelInscripcion.Visible = true;

        // Lógica específica del panelCliente
        MostrarFormularioInscripcion();
    }

    // Método para mostrar un formulario en el panelCliente
    private void MostrarFormularioInscripcion()
    {
        // Limpiar controles existentes en el panelCliente (si es necesario)
        panelInscripcion.Controls.Clear();

        /*
        // Agregar y configurar controles específicos del panelCliente
        Label labelCliente = new Label();
        labelCliente.Text = "Contenido del Cliente";
        labelCliente.Location = new Point(442, 56);
        panelCliente.Controls.Add(labelCliente);
        */

        //Agregar y especificar los que lleva el PanelInscripcion
        Label label6 = new Label();
        //label6.Text = "Sistema de Gestión de Clientes";
        //label6.Location = new System.Drawing.Point(566, 47);     
        label6.AutoSize = true;
        label6.Location = new System.Drawing.Point(362, 31);
        label6.Name = "registro";
        label6.Size = new System.Drawing.Size(590, 25);
        label6.TabIndex = 0;
        label6.Text = "FORMULARIO DE REGISTRO DE INSCRIPCIÓN PARA UN NUEVO CLIENTE";
        label6.Click += label6_Click;
        panelInscripcion.Controls.Add(label6);

        // 
        // nombre del cliente que desea inscribirse
        // 
        Label nombre = new Label();
        nombre.AutoSize = true;
        nombre.Location = new System.Drawing.Point(45, 97);
        nombre.Name = "nombre";
        nombre.Size = new System.Drawing.Size(78, 25);
        nombre.TabIndex = 1;
        nombre.Text = "Nombre";
        nombre.Click += nombre_Click;
        panelInscripcion.Controls.Add(nombre);

        // 
        // apellido del cliente que desea inscribirse
        // 
        Label apellido = new Label();
        apellido.AutoSize = true;
        apellido.Location = new System.Drawing.Point(493, 97);
        apellido.Name = "apellido";
        apellido.Size = new System.Drawing.Size(78, 25);
        apellido.TabIndex = 2;
        apellido.Text = "Apellido";
        apellido.Click += apellido_Click;
        panelInscripcion.Controls.Add(apellido);

        // 
        // número de documento del cliente que desea inscribirse
        // 
        Label documento = new Label();
        documento.AutoSize = true;
        documento.Location = new System.Drawing.Point(905, 97);
        documento.Name = "documento";
        documento.Size = new System.Drawing.Size(43, 25);
        documento.TabIndex = 3;
        documento.Text = "DNI";
        documento.Click += dni_Click;
        panelInscripcion.Controls.Add(documento);

        // 
        // telefono del cliente que desea inscribirse
        //
        Label telefono = new Label();
        telefono.AutoSize = true;
        telefono.Location = new System.Drawing.Point(45, 165);
        telefono.Name = "telefono";
        telefono.Size = new System.Drawing.Size(79, 25);
        telefono.TabIndex = 4;
        telefono.Text = "Teléfono";
        telefono.Click += telefono_Click;
        panelInscripcion.Controls.Add(telefono);

        // 
        // correo electronico del cliente que desea inscribirse
        // 
        Label correo = new Label();
        correo.AutoSize = true;
        correo.Location = new System.Drawing.Point(493, 165);
        correo.Name = "correo";
        correo.Size = new System.Drawing.Size(54, 25);
        correo.TabIndex = 5;
        correo.Text = "Email";
        correo.Click += email_Click;
        panelInscripcion.Controls.Add(correo);

        // 
        // direccion del cliente que desea inscribirse
        // 
        Label direccion = new Label();
        direccion.AutoSize = true;
        direccion.Location = new System.Drawing.Point(905, 165);
        direccion.Name = "direccion";
        direccion.Size = new System.Drawing.Size(85, 25);
        direccion.TabIndex = 6;
        direccion.Text = "Dirección";
        direccion.Click += direccion_Click;
        panelInscripcion.Controls.Add(direccion);

        // 
        // apto_fisico
        // 
        Label apto_fisico = new Label();
        apto_fisico.AutoSize = true;
        apto_fisico.Location = new System.Drawing.Point(45, 233);
        apto_fisico.Name = "apto";
        apto_fisico.Size = new System.Drawing.Size(101, 25);
        apto_fisico.TabIndex = 7;
        apto_fisico.Text = "Apto Físico";
        apto_fisico.Click += apto_Click;
        panelInscripcion.Controls.Add(apto_fisico);

        // 
        // ficha medica del cliente que desea inscribirse
        // 
        Label medico = new Label();
        medico.AutoSize = true;
        medico.Location = new System.Drawing.Point(493, 238);
        medico.Name = "medico";
        medico.Size = new System.Drawing.Size(114, 25);
        medico.TabIndex = 8;
        medico.Text = "Ficha Médica";
        medico.Click += ficha_Click;
        panelInscripcion.Controls.Add(medico);

        // 
        // fecha inscripcion del cliente
        //
        Label fecha = new Label();
        fecha.AutoSize = true;
        fecha.Location = new System.Drawing.Point(905, 238);
        fecha.Name = "fecha";
        fecha.Size = new System.Drawing.Size(57, 25);
        fecha.TabIndex = 9;
        fecha.Text = "Fecha";
        fecha.Click += fecha_Click;
        panelInscripcion.Controls.Add(fecha);

        // 
        // categoria del cliente que desea inscribirse
        // 
        Label categoria = new Label();
        categoria.AutoSize = true;
        categoria.Location = new System.Drawing.Point(45, 319);
        categoria.Name = "categoria";
        categoria.Size = new System.Drawing.Size(88, 25);
        categoria.TabIndex = 10;
        categoria.Text = "Categoría";
        categoria.Click += clasificacion_Click;
        panelInscripcion.Controls.Add(categoria);

        // 
        // completar_nombre
        // 
        TextBox completar_nombre = new TextBox();
        completar_nombre.Location = new System.Drawing.Point(153, 94);
        completar_nombre.Name = "completarNombre";
        completar_nombre.Size = new System.Drawing.Size(302, 31);
        completar_nombre.TabIndex = 11;
        completar_nombre.TextChanged += completarNombre_TextChanged;
        panelInscripcion.Controls.Add(completar_nombre);

        // 
        // completar_apellido
        // 
        TextBox completar_apellido = new TextBox();
        completar_apellido.Location = new System.Drawing.Point(577, 91);
        completar_apellido.Name = "completarApellido";
        completar_apellido.Size = new System.Drawing.Size(302, 31);
        completar_apellido.TabIndex = 12;
        completar_apellido.TextChanged += completarApellido_TextChanged;
        panelInscripcion.Controls.Add(completar_apellido);

        // 
        // completar_documento
        // 
        TextBox completar_documento = new TextBox();
        completar_documento.Location = new System.Drawing.Point(996, 91);
        completar_documento.Name = "completarDocumento";
        completar_documento.Size = new System.Drawing.Size(276, 31);
        completar_documento.TabIndex = 13;
        completar_documento.TextChanged += completarDocumento_TextChanged;
        panelInscripcion.Controls.Add(completar_documento);

        // 
        // completar_telefono
        // 
        TextBox completar_telefono = new TextBox();
        completar_telefono.Location = new System.Drawing.Point(153, 159);
        completar_telefono.Name = "completarTelefono";
        completar_telefono.Size = new System.Drawing.Size(302, 31);
        completar_telefono.TabIndex = 14;
        completar_telefono.TextChanged += completarTelefono_TextChanged;
        panelInscripcion.Controls.Add(completar_telefono);

        // 
        // completar_correo
        // 
        TextBox completar_correo = new TextBox();
        completar_correo.Location = new System.Drawing.Point(577, 162);
        completar_correo.Name = "completarCorreo";
        completar_correo.Size = new System.Drawing.Size(302, 31);
        completar_correo.TabIndex = 15;
        completar_correo.TextChanged += completarCorreo_TextChanged;
        panelInscripcion.Controls.Add(completar_correo);

        // 
        // completar_direccion
        // 
        TextBox completar_direccion = new TextBox();
        completar_direccion.Location = new System.Drawing.Point(996, 162);
        completar_direccion.Name = "completarDireccion";
        completar_direccion.Size = new System.Drawing.Size(277, 31);
        completar_direccion.TabIndex = 16;
        completar_direccion.TextChanged += completarDireccion_TextChanged;
        panelInscripcion.Controls.Add(completar_direccion);

        // 
        // elegir_fisico
        // 
        ComboBox elegir_fisico = new ComboBox();
        elegir_fisico.Items.Add("Presenta");
        elegir_fisico.Items.Add("No Presenta");
        elegir_fisico.FormattingEnabled = true;
        elegir_fisico.Location = new System.Drawing.Point(153, 230);
        elegir_fisico.Name = "elegirFisico";
        elegir_fisico.Size = new System.Drawing.Size(302, 33);
        elegir_fisico.TabIndex = 17;
        elegir_fisico.SelectedIndexChanged += elegirFisico_SelectedIndexChanged;
        this.Controls.Add(elegir_fisico);
        panelInscripcion.Controls.Add(elegir_fisico);

        // 
        // elegir si el cliente presenta o no la ficha medica
        // 
        ComboBox elegir_medica = new ComboBox();
        elegir_medica.Items.Add("Presenta");
        elegir_medica.Items.Add("No Presenta");
        elegir_medica.FormattingEnabled = true;
        elegir_medica.Location = new System.Drawing.Point(623, 235);
        elegir_medica.Name = "elegirMedica";
        elegir_medica.Size = new System.Drawing.Size(231, 33);
        elegir_medica.TabIndex = 18;
        elegir_medica.SelectedIndexChanged += elegirMedica_SelectedIndexChanged;
        this.Controls.Add(elegir_medica);
        panelInscripcion.Controls.Add(elegir_medica);

        // 
        // elegir categoria de cliente
        // 
        ComboBox elegir_categoria = new ComboBox();
        elegir_categoria.Items.Add("Socio");
        elegir_categoria.Items.Add("No Socio");
        elegir_categoria.FormattingEnabled = true;
        elegir_categoria.Location = new System.Drawing.Point(153, 319);
        elegir_categoria.Name = "elegirCategoria";
        elegir_categoria.Size = new System.Drawing.Size(302, 33);
        elegir_categoria.TabIndex = 19;
        elegir_categoria.SelectedIndexChanged += elegirCategoria_SelectedIndexChanged;
        this.Controls.Add(elegir_categoria);
        panelInscripcion.Controls.Add(elegir_categoria);

        // 
        // dateTimePicker1
        // 
        DateTimePicker elegir_fecha = new DateTimePicker();
        elegir_fecha.Location = new System.Drawing.Point(973, 233);
        elegir_fecha.Name = "elegirFecha";
        elegir_fecha.Size = new System.Drawing.Size(300, 31);
        elegir_fecha.TabIndex = 20;
        elegir_fecha.ValueChanged += elegirFecha_ValueChanged;
        panelInscripcion.Controls.Add(elegir_fecha);

        // 
        // button1
        // 
        System.Windows.Forms.Button continuar = new System.Windows.Forms.Button();
        continuar.Location = new System.Drawing.Point(746, 347);
        continuar.Name = "continuar";
        continuar.Size = new System.Drawing.Size(176, 48);
        continuar.TabIndex = 21;
        continuar.Text = "CONTINUAR";
        continuar.UseVisualStyleBackColor = true;
        continuar.Click += continuar_Click;
        panelInscripcion.Controls.Add(continuar);

        // 
        // button2
        // 
        System.Windows.Forms.Button volver = new System.Windows.Forms.Button();
        volver.Location = new System.Drawing.Point(1020, 347);
        volver.Name = "volver";
        volver.Size = new System.Drawing.Size(176, 48);
        volver.TabIndex = 22;
        volver.Text = "VOLVER";
        volver.UseVisualStyleBackColor = true;
        volver.Click += volver_Click;
        panelInscripcion.Controls.Add(volver);

        // 
        // button3
        // 
        System.Windows.Forms.Button limpiar = new System.Windows.Forms.Button();
        limpiar.Location = new System.Drawing.Point(503, 347);
        limpiar.Name = "limpiar";
        limpiar.Size = new System.Drawing.Size(181, 48);
        limpiar.TabIndex = 23;
        limpiar.Text = "Limpiar";
        limpiar.UseVisualStyleBackColor = true;
        limpiar.Click += btnLimpiar_Click;
        panelInscripcion.Controls.Add(limpiar);



        // 
        // comprobar Lo que se quiere hacer en este caso es comprobar si el nuevo cliente ya se encuentra registrado.
        // 
        System.Windows.Forms.Button comprobar = new System.Windows.Forms.Button();
        comprobar.Location = new System.Drawing.Point(180, 177);
        comprobar.Name = "comprobar";
        comprobar.Size = new System.Drawing.Size(149, 104);
        comprobar.TabIndex = 1;
        comprobar.Text = "COMPROBAR DNI";
        comprobar.UseVisualStyleBackColor = true;
        comprobar.Click += comprobar_Click;
        panelCliente.Controls.Add(comprobar);

        // 
        // alta Se quiere generar una nueva inscripción y el alta en el sistema.
        // 
        System.Windows.Forms.Button alta = new System.Windows.Forms.Button();
        alta.Location = new System.Drawing.Point(426, 173);
        alta.Name = "Inscripcion";
        alta.Size = new System.Drawing.Size(149, 104);
        alta.TabIndex = 2;
        alta.Text = "GENERAR INSCRIPCIÓN";
        alta.UseVisualStyleBackColor = true;
        alta.Click += alta_Click;
        panelCliente.Controls.Add(alta);

        // 
        // modificar Se quiere generar la modificación de una inscripción previamente realizada.
        // 
        System.Windows.Forms.Button modificar = new System.Windows.Forms.Button();
        modificar.Location = new System.Drawing.Point(673, 173);
        modificar.Name = "Modificar Inscripcion";
        modificar.Size = new System.Drawing.Size(149, 104);
        modificar.TabIndex = 3;
        modificar.Text = "MODIFICAR INSCRIPCIÓN";
        modificar.UseVisualStyleBackColor = true;
        //modificar.Click += modificacion_Click;
        panelCliente.Controls.Add(modificar);

        //pantallaAnterior = this;

        MostrarFormularioInscripcion();

    }


    private void label6_Click(object sender, EventArgs e)
    {

    }

    private void nombre_Click(object sender, EventArgs e)
    {

    }

    private void completarNombre_TextChanged(object sender, EventArgs e)
    {

    }

    private void apellido_Click(object sender, EventArgs e)
    {

    }

    private void completarApellido_TextChanged(object sender, EventArgs e)
    {

    }

    private void dni_Click(object sender, EventArgs e)
    {

    }

    private void completarDocumento_TextChanged(object sender, EventArgs e)
    {

    }

    private void telefono_Click(object sender, EventArgs e)
    {

    }

    private void completarTelefono_TextChanged(object sender, EventArgs e)
    {

    }

    private void email_Click(object sender, EventArgs e)
    {

    }

    private void completarCorreo_TextChanged(object sender, EventArgs e)
    {

    }

    private void direccion_Click(object sender, EventArgs e)
    {

    }

    private void completarDireccion_TextChanged(object sender, EventArgs e)
    {

    }

    private void apto_Click(object sender, EventArgs e)
    {

    }

    private void elegirFisico_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void ficha_Click(object sender, EventArgs e)
    {

    }

    private void elegirMedica_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void fecha_Click(object sender, EventArgs e)
    {

    }

    private void elegirFecha_ValueChanged(object sender, EventArgs e)
    {

    }

    private void clasificacion_Click(object sender, EventArgs e)
    {

    }

    private void elegirCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void continuar_Click(object sender, EventArgs e)
    {

        if
        (completar_nombre.Text == "" || completar_apellido.Text == "" || completar_documento.Text == "" || completar_telefono.Text == "" || completar_correo.Text == "" || completar_direccion.Text == "" || elegir_fisico.Text == "" || elegir_medica.Text == "" || /*elegir_fecha == "" ||*/ elegir_categoria.Text == "")
        {
            MessageBox.Show(
            "Debe completar datos requeridos (*) ",
            "AVISO DEL SISTEMA",
            MessageBoxButtons.OK,
            MessageBoxIcon.Error);
        }
        else
        {

            /*
            string respuesta;
           Nueva_Inscripcion cliente = new Nueva_Inscripcion();
            cliente.Nombre = textBox1.Text;
            cliente.Apellido = textBox2.Text;
            cliente.Dni = textBox3.Text;
            cliente.Telefono = textBox4.Text;
            cliente.Email = textBox5.Text;
            cliente.Direccion = textBox6.Text;
            cliente.Apto_fisico = comboBox1.Text;
            cliente.Ficha_medica = comboBox2.Text;
            cliente.Fecha = dateTimePicker1.Text;
            cliente.Categoria = comboBox3.Text;
            */
        }

    }
    private void volver_Click(object sender, EventArgs e)
    {
        pantallaAnterior.Show();
        this.Hide();

        /*
            panelForm1.Visible = false;
            panelForm2.Visible = false;
            panelCliente.Visible = true;
            panelInscripcion.Visible = false;
            */
    }

    //Se agrega el botón que dice limpiar
    private void btnLimpiar_Click(object sender, EventArgs e)


    {
        completar_nombre.Text = "";
        completar_apellido.Text = "";
        completar_documento.Text = "";
        completar_telefono.Text = "";
        completar_correo.Text = "";
        completar_direccion.Text = "";
    }

    private void modificacion_Click(object sender, EventArgs e)
    {

    }



}
}






    /*{
        private TabControl tabControl1;

    public Form1(TabPage bienvenida)
    {
        InitializeComponent();

        // Vamos a agregar los nombres de los operadores de la administración al comboBox1 en el constructor
        comboBox1.Items.Add("María Eugenia");
        comboBox1.Items.Add("Mariano");
        comboBox1.Items.Add("Martina");
        comboBox1.Items.Add("Luciana");
        comboBox1.Items.Add("Julian");

        this.Controls.Add(comboBox1);

        //Cada operador debe elegir el código de usuario de su PC.

        comboBox2.Items.Add("238097");
        comboBox2.Items.Add("408937");
        comboBox2.Items.Add("398765");
        comboBox2.Items.Add("134976");
        comboBox2.Items.Add("153050");

        this.Controls.Add(comboBox2);
        this.bienvenida = bienvenida;
    }




    private void administrador_Click(object sender, EventArgs e)
    {

    }

    private void operador_Click(object sender, EventArgs e)
    {

    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void usuario_Click(object sender, EventArgs e)
    {

    }

    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Ocultar la pestaña anterior al mostrar una nueva pestaña
        for (int i = 0; i < tabControl1.TabPages.Count; i++)
        {
            if (i != tabControl1.SelectedIndex)
            {
                tabControl1.TabPages[i].Hide();
            }
        }
    }

    private void btnCambiarPantalla_Click(object sender, EventArgs e)
    {
        // Cambiar a la siguiente pestaña al hacer clic en el botón "Ingresar"
        int siguientePestana = tabControl1.SelectedIndex + 1;

        // Asegúrate de no superar el índice máximo
        if (siguientePestana < tabControl1.TabPages.Count)
        {
            tabControl1.SelectedIndex = siguientePestana;
        }
    }

}
}
/*
private Panel panelPantalla1;
private Panel panelPantalla2;
private Panel panelCliente;
private Panel panelListadoClientes;
    */
