using System;
using Proyecto.App.Dominio;
using Proyecto.App.Persistencia;

namespace Proyecto.App.Consola
{
    public class Program
    {
        private static IRepositorioCategoria _repoCategoria = new RepositorioCategoria(new Proyecto.App.Persistencia.AppContext());
        private static IRepositorioCliente _repoCliente = new RepositorioCliente(new Proyecto.App.Persistencia.AppContext());
        private static IRepositorioFase _repoFase = new RepositorioFase(new Proyecto.App.Persistencia.AppContext());
        private static IRepositorioPrograma _repoPrograma = new RepositorioPrograma(new Proyecto.App.Persistencia.AppContext());

        public static void Main(string[] args)
        {
            Console.WriteLine("PROYECTO CICLO 3");
            //METODOS CLIENTE
            //AgregarCliente();
            //ModificarCliente();
            //EliminarCliente();
            //BuscarCliente();
            //VerClientes();

            //METODOS CATEGORIA
            //AgregarCategoria();
            //ModificarCategoria();
            //EliminarCategoria();
            //BuscarCategoria();
            //VerCategorias();

            //METODOS FASE
            //AgregarFase();
            //ModificarFase();
            //EliminarFase();
            //BuscarFase();
            //VerFase();

            //METODOS PROGRAMA
            //AgregarPrograma();
            //ModificarPrograma();
            //EliminarPrograma();
            //BuscarPrograma();
            //VerProgramas();
        }

        //Crear metodo para repositorio programa
        private static void AgregarPrograma()
        {
            Console.WriteLine("Agregar un programa");

            // Instancia la entidad
            Programa programaNuevo = new Programa();

            // pedir a usuario los datos del programa
            Console.WriteLine("Ingrese nombre de programa: ");
            programaNuevo.nombre = Console.ReadLine();

            Console.WriteLine("Ingrese codigo de programa: ");
            programaNuevo.codigo = Console.ReadLine();

            Console.WriteLine("Ingrese tiempo Estimado de programa: ");
            programaNuevo.tiempoEstimado = Console.ReadLine();

            Console.WriteLine("Ingrese fecha de Ejecucion de programa: ");
            programaNuevo.fechaEjecucion = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese costo de programa: ");
            programaNuevo.costo = Console.ReadLine();

            Console.WriteLine("Ingrese descripcion de programa: ");
            programaNuevo.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese estado de programa: (0 no_activo 1 activo)");
            programaNuevo.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            //Asignamos las relaciones
            Console.WriteLine("Ingrese el id del cliente");
            programaNuevo.clienteId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el id de la categoria");
            programaNuevo.categoriaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el id de la fase");
            programaNuevo.faseId = int.Parse(Console.ReadLine());

            programaNuevo.fechaRegistro = DateTime.Now;

            // Invocamos al repositorio
            _repoPrograma.Agregar(programaNuevo);
        }

        private static void ModificarPrograma()
        {
            Console.WriteLine("Modificar un programa");

            //Pedir Id del cliente a modificar
            Console.WriteLine("Ingrese el Id del programa a modificar");
            int id = int.Parse(Console.ReadLine());

            // Instancia la entidad
            Programa programaActualizar = _repoPrograma.BuscarPorId(id);

            //Obtener nuevos datos del cliente
            Console.WriteLine("Ingrese nuevo nombre de programa: ");
            programaActualizar.nombre = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo codigo de programa: ");
            programaActualizar.codigo = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo tiempo Estimado de programa: ");
            programaActualizar.tiempoEstimado = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo fecha de Ejecucion de programa: ");
            programaActualizar.fechaEjecucion = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nuevo costo de programa: ");
            programaActualizar.costo = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo descripcion de programa: ");
            programaActualizar.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo estado de programa: (0 no_activo 1 activo)");
            programaActualizar.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            //Asignamos las relaciones
            Console.WriteLine("Ingrese el nuevo id del cliente");
            programaActualizar.clienteId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo id de la categoria");
            programaActualizar.categoriaId = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nuevo id de la fase");
            programaActualizar.faseId = int.Parse(Console.ReadLine());

            //Invocamos al repositorio
            _repoPrograma.Modificar(programaActualizar);
        }

        private static void EliminarPrograma()
        {
            Console.WriteLine("Eliminar un programa");

            //Pedir Id del programa a eliminar
            Console.WriteLine("Ingrese el Id del programa a eliminar");
            int id = int.Parse(Console.ReadLine());

            //Invocamos al repositorio
            _repoPrograma.Eliminar(id);
        }

        private static void BuscarPrograma()
        {
            Console.WriteLine("Buscar un programa");

            //Pedir Id del programa a buscar
            Console.WriteLine("Ingrese el Id del programa a buscar");
            int idPrograma = int.Parse(Console.ReadLine());

            //Buscar programa
            Programa programaBuscar = _repoPrograma.BuscarPorId(idPrograma);
            Console.WriteLine("El programa es: " + programaBuscar.nombre +
            " " + programaBuscar.codigo + " " + programaBuscar.tiempoEstimado +
            " " + programaBuscar.fechaEjecucion + " " + programaBuscar.costo +
            " " + programaBuscar.descripcion + " " + programaBuscar.estado +
            " ID DEL CLIENTE " + programaBuscar.clienteId +
            " ID DE LA CATEGORIA " + programaBuscar.categoriaId +
            " ID DE LA FASE " + programaBuscar.faseId);

        }

        private static void VerProgramas()
        {
            Console.WriteLine("Ver programas");

            //Traer todos los clientes
            var clientesVer = _repoPrograma.BuscarTodos();

            //Recorrer y mostrar todos los clientes
            foreach (var cliente in clientesVer)
            {
                Console.WriteLine("El programa es: " + cliente.nombre +
            " " + cliente.codigo + " " + cliente.tiempoEstimado +
            " " + cliente.fechaEjecucion + " " + cliente.costo +
            " " + cliente.descripcion + " " + cliente.estado +
            " ID DEL CLIENTE " + cliente.clienteId +
            " ID DE LA CATEGORIA " + cliente.categoriaId +
            " ID DE LA FASE " + cliente.faseId);
            }
        }

        //Crear metodo para repositorio fase
        private static void AgregarFase()
        {
            Console.WriteLine("Agregar una fase");

            // Instancia la entidad
            Fase faseNuevo = new Fase();

            // Obtener los datos del cliente
            Console.WriteLine("Ingrese fecha de cambio de fase: ");
            faseNuevo.fechaCambio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nombre de la fase: ");
            faseNuevo.nombreFase = Console.ReadLine();

            Console.WriteLine("Ingrese descripcion de la fase: ");
            faseNuevo.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese estado de fase: (0 no_activo 1 activo)");
            faseNuevo.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            faseNuevo.fechaRegistro = DateTime.Now;

            //Invocamos al repositorio
            _repoFase.Agregar(faseNuevo);
        }

        private static void ModificarFase()
        {
            Console.WriteLine("Modificar una fase");

            // Pedir Id del cliente a modificar
            Console.WriteLine("Ingrese el Id de la fase a modificar");
            int id = int.Parse(Console.ReadLine());

            // Instancia la entidad
            Fase faseActualizar = _repoFase.BuscarPorId(id);

            // Obtener nuevos datos del cliente
            Console.WriteLine("Ingrese nuevo fecha de cambio de fase: ");
            faseActualizar.fechaCambio = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nuevo nombre de la fase: ");
            faseActualizar.nombreFase = Console.ReadLine();

            Console.WriteLine("Ingrese nueva descripcion de la fase: ");
            faseActualizar.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo estado de fase: (0 no_activo 1 activo)");
            faseActualizar.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            // Invocamos al repositorio
            _repoFase.Modificar(faseActualizar);
        }

        private static void EliminarFase()
        {
            Console.WriteLine("Eliminar una fase");

            //Pedir Id del cliente a eliminar
            Console.WriteLine("Ingrese el Id de la fase a eliminar");
            int id = int.Parse(Console.ReadLine());

            //Invocamos al repositorio
            _repoFase.Eliminar(id);
        }

        private static void BuscarFase()
        {
            Console.WriteLine("Buscar una fase");

            //Pedir Id del cliente a buscar
            Console.WriteLine("Ingrese el Id de la fase a buscar");
            int id = int.Parse(Console.ReadLine());

            //Buscar categoria
            Fase faseBuscar = _repoFase.BuscarPorId(id);
            Console.WriteLine("La fase es: " + faseBuscar.fechaCambio + " " + faseBuscar.nombreFase +
              " " + faseBuscar.descripcion + " " + faseBuscar.estado);
        }

        private static void VerFase()
        {
            Console.WriteLine("Ver fases");

            //Traer todos los clientes
            var clientesVer = _repoFase.BuscarTodos();

            //Recorrer y mostrar todos los clientes
            foreach (var cliente in clientesVer)
            {
                Console.WriteLine(cliente.fechaCambio + "" + cliente.nombreFase + " " +
                   cliente.descripcion + " " + cliente.estado);
            }
        }

        //Crear metodo para repositorio categoria
        private static void AgregarCategoria()
        {
            Console.WriteLine("Agregar una categoria");

            // Instancia la entidad
            Categoria categoriaNueva = new Categoria();

            // Obtener los datos del cliente
            Console.WriteLine("Ingrese nombre de la categoria: ");
            categoriaNueva.nombreCategoria = Console.ReadLine();

            Console.WriteLine("Ingrese descripcion de la categoria: ");
            categoriaNueva.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese estado de categoria: (0 no_activo 1 activo)");
            categoriaNueva.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            categoriaNueva.fechaRegistro = DateTime.Now;

            //Invocamos al repositorio
            _repoCategoria.Agregar(categoriaNueva);
        }

        private static void ModificarCategoria()
        {
            Console.WriteLine("Modificar una categoria");

            // Pedir Id del cliente a modificar
            Console.WriteLine("Ingrese el Id de la categoria a modificar");
            int id = int.Parse(Console.ReadLine());

            // Instancia la entidad
            Categoria categoriaActualizar = _repoCategoria.BuscarPorId(id);

            // Obtener nuevos datos del cliente
            Console.WriteLine("Ingrese nuevo nombre de la categoria: ");
            categoriaActualizar.nombreCategoria = Console.ReadLine();

            Console.WriteLine("Ingrese nueva descripcion de la categoria: ");
            categoriaActualizar.descripcion = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo estado de categoria: (0 no_activo 1 activo)");
            categoriaActualizar.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            // Invocamos al repositorio
            _repoCategoria.Modificar(categoriaActualizar);
        }

        private static void EliminarCategoria()
        {
            Console.WriteLine("Eliminar una categoria");

            //Pedir Id del cliente a eliminar
            Console.WriteLine("Ingrese el Id de la categoria a eliminar");
            int id = int.Parse(Console.ReadLine());

            //Invocamos al repositorio
            _repoCategoria.Eliminar(id);
        }

        private static void BuscarCategoria()
        {
            Console.WriteLine("Buscar una categoria");

            //Pedir Id del cliente a eliminar
            Console.WriteLine("Ingrese el Id de la categoria a buscar");
            int id = int.Parse(Console.ReadLine());

            //Buscar categoria
            Categoria categoriaBuscar = _repoCategoria.BuscarPorId(id);
            Console.WriteLine("La categoria es: " + categoriaBuscar.nombreCategoria +
              " " + categoriaBuscar.descripcion + " " + categoriaBuscar.estado);
        }

        private static void VerCategorias()
        {
            Console.WriteLine("Ver categorias");

            //Traer todos los clientes
            var clientesVer = _repoCategoria.BuscarTodos();

            //Recorrer y mostrar todos los clientes
            foreach (var cliente in clientesVer)
            {
                Console.WriteLine(cliente.nombreCategoria + " " +
                   cliente.descripcion + " " + cliente.estado);
            }
        }

        //Crear metodo para repositorio cliente
        public static void AgregarCliente()
        {
            Console.WriteLine("Agregar un cliente");

            // Instancia la entidad
            Cliente clienteNuevo = new Cliente();

            // Obtener los datos del cliente
            Console.WriteLine("Ingrese nombre de cliente: ");
            clienteNuevo.nombre = Console.ReadLine();

            Console.WriteLine("Ingrese apellido de cliente: ");
            clienteNuevo.apellido = Console.ReadLine();

            Console.WriteLine("Ingrese numero de documento de cliente: ");
            clienteNuevo.numDocumento = Console.ReadLine();

            Console.WriteLine("Ingrese numero de telefono de cliente: ");
            clienteNuevo.numTelefono = Console.ReadLine();

            Console.WriteLine("Ingrese email de cliente: ");
            clienteNuevo.email = Console.ReadLine();

            Console.WriteLine("Ingrese direccion de cliente: ");
            clienteNuevo.direccion = Console.ReadLine();

            Console.WriteLine("Ingrese nacionalidad de cliente: ");
            clienteNuevo.nacionalidad = Console.ReadLine();

            Console.WriteLine("Ingrese estado de cliente: (0 no_activo 1 activo)");
            clienteNuevo.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            clienteNuevo.fechaRegistro = DateTime.Now;

            //Invocamos al repositorio
            _repoCliente.Agregar(clienteNuevo);
        }

        public static void ModificarCliente()
        {
            Console.WriteLine("Modificar un cliente");

            //Pedir Id del cliente a modificar
            Console.WriteLine("Ingrese el Id del cliente a modificar"); 
            int id = 0;
            try //Se usa try catch para realizar una validacion rn la que no se ingresen datos erroneos
            {
                id = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine("Id no valido");
            }

            // Instancia la entidad
            Cliente clienteActualizar = _repoCliente.BuscarPorId(id);

            //Obtener nuevos datos del cliente
            Console.WriteLine("Ingrese nuevo nombre de cliente: ");
            clienteActualizar.nombre = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo apellido de cliente: ");
            clienteActualizar.apellido = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo numero de documento de cliente: ");
            clienteActualizar.numDocumento = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo numero de telefono de cliente: ");
            clienteActualizar.numTelefono = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo email de cliente: ");
            clienteActualizar.email = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo direccion de cliente: ");
            clienteActualizar.direccion = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo nacionalidad de cliente: ");
            clienteActualizar.nacionalidad = Console.ReadLine();

            Console.WriteLine("Ingrese nuevo estado de cliente: (0 no_activo 1 activo)");
            clienteActualizar.estado = (Estado)Enum.Parse(typeof(Estado), Console.ReadLine());

            //Invocamos al repositorio
            _repoCliente.Modificar(clienteActualizar);
        }

        private static void EliminarCliente()
        {
            Console.WriteLine("Eliminar un cliente");

            //Pedir Id del cliente a eliminar
            Console.WriteLine("Ingrese el Id del cliente a eliminar");
            int id = int.Parse(Console.ReadLine());

            //Invocamos al repositorio
            _repoCliente.Eliminar(id);
        }

        private static void BuscarCliente()
        {
            Console.WriteLine("Buscar un cliente");

            //Pedir Id del cliente a buscar
            Console.WriteLine("Ingrese el Id del cliente a buscar");
            int id = int.Parse(Console.ReadLine());

            //Buscar cliente
            Cliente clienteBuscar = _repoCliente.BuscarPorId(id);
            Console.WriteLine("El cliente es: " + clienteBuscar.nombre +
            " " + clienteBuscar.apellido + " " + clienteBuscar.numDocumento +
            " " + clienteBuscar.numTelefono + " " + clienteBuscar.email +
            " " + clienteBuscar.direccion + " " + clienteBuscar.nacionalidad +
            " " + clienteBuscar.estado);
        }

        private static void VerClientes()
        {
            Console.WriteLine("ver los clientes");

            //Traer todos los clientes
            var clientesVer = _repoCliente.BuscarTodos();

            //Recorrer y mostrar todos los clientes
            foreach (var cliente in clientesVer)
            {
                Console.WriteLine(cliente.nombre + " " + cliente.apellido +
                " " + cliente.numDocumento + " " + cliente.numTelefono +
                " " + cliente.email + " " + cliente.direccion +
                " " + cliente.nacionalidad + " " + cliente.estado);
            }
        }
    }
}