using System.Linq;
using System.Web.Mvc;
using System;

public class TestController : Controller
{
    private ApplicationDbContext db = new ApplicationDbContext();

    // Acción para probar la conexión
    public ActionResult TestConnection()
    {
        try
        {
            var users = db.Users.ToList();
            return Content("Conexión exitosa. Se recuperaron " + users.Count + " usuarios.");
        }
        catch (Exception ex)
        {
            // Mostrar el mensaje completo de la excepción y la InnerException
            return Content("Error de conexión: " + ex.Message + "\n" + ex.InnerException?.Message);
        }
    }
}