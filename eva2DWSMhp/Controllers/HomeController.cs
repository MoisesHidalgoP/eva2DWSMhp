using eva2DWSMhp.Models;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using System.Diagnostics;

namespace eva2DWSMhp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
             _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InsertNotas(String cod_alumno,
            String nota_evaluacion,String cod_evaluacion)
        {
            Console.WriteLine("Entrando a metodo del insert");
            //Hacemos la conexion
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Pooling=true;Database=bd_evaluacion;UserId=postgres;Password=doshermanas1;");
            Console.WriteLine("ABRIENDO CONEXION");
            connection.Open();
            NpgsqlCommand consulta = new NpgsqlCommand($"INSERT INTO \"sc_evaluacion\".\"eva_tch_notas_evaluacion\" (cod_alumno, nota_evaluacion, cod_evaluacion ) VALUES('{cod_alumno}','{nota_evaluacion}','{cod_evaluacion}')", connection);
            if (cod_alumno == null || nota_evaluacion == null || cod_evaluacion == null)
            {
                return View();
            }
            NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

            return View();
        }

        public IActionResult SelectCodAlumno(String cod_alumno,String nota_evaluacion, String cod_evaluacion)
        {
            //Hacemos la conexion
            var connection = new NpgsqlConnection("Host=localhost;Port=5432;Pooling=true;Database=bd_evaluacion;UserId=postgres;Password=doshermanas1;");
            Console.WriteLine("ABRIENDO CONEXION");
            connection.Open();
            NpgsqlCommand consulta = new NpgsqlCommand($"SELECT cod_alumno, nota_evaluacion, cod_evaluacion  FROM \"sc_evaluacion\".\"eva_tch_notas_evaluacion\" WHERE cod_empleado='{cod_alumno}'", connection);
            List<string> listaAlumnos = new List<string>();
            listaAlumnos.Add(cod_alumno);
            listaAlumnos.Add(nota_evaluacion);
            listaAlumnos.Add(cod_evaluacion);
            ViewBag.Lista = listaAlumnos;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}